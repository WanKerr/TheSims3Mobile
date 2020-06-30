// Decompiled with JetBrains decompiler
// Type: SevenZip.Compression.LZMA.Encoder
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using SevenZip.Compression.LZ;
using SevenZip.Compression.RangeCoder;
using System;
using System.IO;

namespace SevenZip.Compression.LZMA
{
    public class Encoder : ICoder, ISetCoderProperties, IWriteCoderProperties
    {
        private Base.State _state = new Base.State();
        private uint[] _repDistances = new uint[(4)];
        private Encoder.Optimal[] _optimum = new Encoder.Optimal[(4096)];
        private SevenZip.Compression.RangeCoder.Encoder _rangeEncoder = new SevenZip.Compression.RangeCoder.Encoder();
        private BitEncoder[] _isMatch = new BitEncoder[(192)];
        private BitEncoder[] _isRep = new BitEncoder[(12)];
        private BitEncoder[] _isRepG0 = new BitEncoder[(12)];
        private BitEncoder[] _isRepG1 = new BitEncoder[(12)];
        private BitEncoder[] _isRepG2 = new BitEncoder[(12)];
        private BitEncoder[] _isRep0Long = new BitEncoder[(192)];
        private BitTreeEncoder[] _posSlotEncoder = new BitTreeEncoder[(4)];
        private BitEncoder[] _posEncoders = new BitEncoder[(114)];
        private BitTreeEncoder _posAlignEncoder = new BitTreeEncoder(4);
        private Encoder.LenPriceTableEncoder _lenEncoder = new Encoder.LenPriceTableEncoder();
        private Encoder.LenPriceTableEncoder _repMatchLenEncoder = new Encoder.LenPriceTableEncoder();
        private Encoder.LiteralEncoder _literalEncoder = new Encoder.LiteralEncoder();
        private uint[] _matchDistances = new uint[(548)];
        private uint _numFastBytes = 32;
        private uint[] _posSlotPrices = new uint[256];
        private uint[] _distancesPrices = new uint[(512)];
        private uint[] _alignPrices = new uint[(16)];
        private uint _distTableSize = 44;
        private int _posStateBits = 2;
        private uint _posStateMask = 3;
        private int _numLiteralContextBits = 3;
        private uint _dictionarySize = 4194304;
        private uint _dictionarySizePrev = uint.MaxValue;
        private uint _numFastBytesPrev = uint.MaxValue;
        private Encoder.EMatchFinderType _matchFinderType = Encoder.EMatchFinderType.BT4;
        private uint[] reps = new uint[(4)];
        private uint[] repLens = new uint[(4)];
        private byte[] properties = new byte[5];
        private uint[] tempPrices = new uint[(128)];
        private static byte[] g_FastPos = new byte[2048];
        private static string[] kMatchFinderIDs = new string[2]
        {
      "BT2",
      "BT4"
        };
        private const uint kIfinityPrice = 268435455;
        private const int kDefaultDictionaryLogSize = 22;
        private const uint kNumFastBytesDefault = 32;
        private const uint kNumLenSpecSymbols = 16;
        private const uint kNumOpts = 4096;
        private const int kPropSize = 5;
        private byte _previousByte;
        private IMatchFinder _matchFinder;
        private uint _longestMatchLength;
        private uint _numDistancePairs;
        private uint _additionalOffset;
        private uint _optimumEndIndex;
        private uint _optimumCurrentIndex;
        private bool _longestMatchWasFound;
        private uint _alignPriceCount;
        private int _numLiteralPosStateBits;
        private long nowPos64;
        private bool _finished;
        private Stream _inStream;
        private bool _writeEndMark;
        private bool _needReleaseMFStream;
        private uint _matchPriceCount;
        private uint _trainSize;

        static Encoder()
        {
            int index1 = 2;
            Encoder.g_FastPos[0] = (byte)0;
            Encoder.g_FastPos[1] = (byte)1;
            for (byte index2 = 2; index2 < (byte)22; ++index2)
            {
                uint num1 = (uint)(1 << ((int)index2 >> 1) - 1);
                uint num2 = 0;
                while (num2 < num1)
                {
                    Encoder.g_FastPos[index1] = index2;
                    ++num2;
                    ++index1;
                }
            }
        }

        private static uint GetPosSlot(uint pos)
        {
            if (pos < 2048U)
                return (uint)Encoder.g_FastPos[pos];
            return pos < 2097152U ? (uint)Encoder.g_FastPos[(pos >> 10)] + 20U : (uint)Encoder.g_FastPos[(pos >> 20)] + 40U;
        }

        private static uint GetPosSlot2(uint pos)
        {
            if (pos < 131072U)
                return (uint)Encoder.g_FastPos[(pos >> 6)] + 12U;
            return pos < 134217728U ? (uint)Encoder.g_FastPos[(pos >> 16)] + 32U : (uint)Encoder.g_FastPos[(pos >> 26)] + 52U;
        }

        private void BaseInit()
        {
            this._state.Init();
            this._previousByte = (byte)0;
            for (uint index = 0; index < 4U; ++index)
                this._repDistances[index] = 0U;
        }

        private void Create()
        {
            if (this._matchFinder == null)
            {
                BinTree binTree = new BinTree();
                int numHashBytes = 4;
                if (this._matchFinderType == Encoder.EMatchFinderType.BT2)
                    numHashBytes = 2;
                binTree.SetType(numHashBytes);
                this._matchFinder = (IMatchFinder)binTree;
            }
            this._literalEncoder.Create(this._numLiteralPosStateBits, this._numLiteralContextBits);
            if ((int)this._dictionarySize == (int)this._dictionarySizePrev && (int)this._numFastBytesPrev == (int)this._numFastBytes)
                return;
            this._matchFinder.Create(this._dictionarySize, 4096U, this._numFastBytes, 274U);
            this._dictionarySizePrev = this._dictionarySize;
            this._numFastBytesPrev = this._numFastBytes;
        }

        public Encoder()
        {
            for (int index = 0; index < 4096; ++index)
                this._optimum[index] = new Encoder.Optimal();
            for (int index = 0; index < 4; ++index)
                this._posSlotEncoder[index] = new BitTreeEncoder(6);
        }

        private void SetWriteEndMarkerMode(bool writeEndMarker)
        {
            this._writeEndMark = writeEndMarker;
        }

        private void Init()
        {
            this.BaseInit();
            this._rangeEncoder.Init();
            for (uint index1 = 0; index1 < 12U; ++index1)
            {
                for (uint index2 = 0; index2 <= this._posStateMask; ++index2)
                {
                    uint num = (index1 << 4) + index2;
                    this._isMatch[num].Init();
                    this._isRep0Long[num].Init();
                }
                this._isRep[index1].Init();
                this._isRepG0[index1].Init();
                this._isRepG1[index1].Init();
                this._isRepG2[index1].Init();
            }
            this._literalEncoder.Init();
            for (uint index = 0; index < 4U; ++index)
                this._posSlotEncoder[index].Init();
            for (uint index = 0; index < 114U; ++index)
                this._posEncoders[index].Init();
            this._lenEncoder.Init((uint)(1 << this._posStateBits));
            this._repMatchLenEncoder.Init((uint)(1 << this._posStateBits));
            this._posAlignEncoder.Init();
            this._longestMatchWasFound = false;
            this._optimumEndIndex = 0U;
            this._optimumCurrentIndex = 0U;
            this._additionalOffset = 0U;
        }

        private void ReadMatchDistances(out uint lenRes, out uint numDistancePairs)
        {
            lenRes = 0U;
            numDistancePairs = this._matchFinder.GetMatches(this._matchDistances);
            if (numDistancePairs > 0U)
            {
                lenRes = this._matchDistances[(numDistancePairs - 2U)];
                if ((int)lenRes == (int)this._numFastBytes)
                    lenRes += this._matchFinder.GetMatchLen((int)lenRes - 1, this._matchDistances[(numDistancePairs - 1U)], 273U - lenRes);
            }
            ++this._additionalOffset;
        }

        private void MovePos(uint num)
        {
            if (num <= 0U)
                return;
            this._matchFinder.Skip(num);
            this._additionalOffset += num;
        }

        private uint GetRepLen1Price(Base.State state, uint posState)
        {
            return this._isRepG0[state.Index].GetPrice0() + this._isRep0Long[((state.Index << 4) + posState)].GetPrice0();
        }

        private uint GetPureRepPrice(uint repIndex, Base.State state, uint posState)
        {
            uint num;
            if (repIndex == 0U)
            {
                num = this._isRepG0[state.Index].GetPrice0() + this._isRep0Long[((state.Index << 4) + posState)].GetPrice1();
            }
            else
            {
                uint price1 = this._isRepG0[state.Index].GetPrice1();
                num = repIndex != 1U ? price1 + this._isRepG1[state.Index].GetPrice1() + this._isRepG2[state.Index].GetPrice(repIndex - 2U) : price1 + this._isRepG1[state.Index].GetPrice0();
            }
            return num;
        }

        private uint GetRepPrice(uint repIndex, uint len, Base.State state, uint posState)
        {
            return this._repMatchLenEncoder.GetPrice(len - 2U, posState) + this.GetPureRepPrice(repIndex, state, posState);
        }

        private uint GetPosLenPrice(uint pos, uint len, uint posState)
        {
            uint lenToPosState = Base.GetLenToPosState(len);
            return (pos >= 128U ? this._posSlotPrices[((lenToPosState << 6) + Encoder.GetPosSlot2(pos))] + this._alignPrices[(pos & 15U)] : this._distancesPrices[(lenToPosState * 128U + pos)]) + this._lenEncoder.GetPrice(len - 2U, posState);
        }

        private uint Backward(out uint backRes, uint cur)
        {
            this._optimumEndIndex = cur;
            uint posPrev = this._optimum[cur].PosPrev;
            uint backPrev = this._optimum[cur].BackPrev;
            do
            {
                if (this._optimum[cur].Prev1IsChar)
                {
                    this._optimum[posPrev].MakeAsChar();
                    this._optimum[posPrev].PosPrev = posPrev - 1U;
                    if (this._optimum[cur].Prev2)
                    {
                        this._optimum[(posPrev - 1U)].Prev1IsChar = false;
                        this._optimum[(posPrev - 1U)].PosPrev = this._optimum[cur].PosPrev2;
                        this._optimum[(posPrev - 1U)].BackPrev = this._optimum[cur].BackPrev2;
                    }
                }
                uint num1 = posPrev;
                uint num2 = backPrev;
                backPrev = this._optimum[num1].BackPrev;
                posPrev = this._optimum[num1].PosPrev;
                this._optimum[num1].BackPrev = num2;
                this._optimum[num1].PosPrev = cur;
                cur = num1;
            }
            while (cur > 0U);
            backRes = this._optimum[0].BackPrev;
            this._optimumCurrentIndex = this._optimum[0].PosPrev;
            return this._optimumCurrentIndex;
        }

        private uint GetOptimum(uint position, out uint backRes)
        {
            if ((int)this._optimumEndIndex != (int)this._optimumCurrentIndex)
            {
                uint num = this._optimum[this._optimumCurrentIndex].PosPrev - this._optimumCurrentIndex;
                backRes = this._optimum[this._optimumCurrentIndex].BackPrev;
                this._optimumCurrentIndex = this._optimum[this._optimumCurrentIndex].PosPrev;
                return num;
            }
            this._optimumCurrentIndex = this._optimumEndIndex = 0U;
            uint lenRes1;
            uint numDistancePairs;
            if (!this._longestMatchWasFound)
            {
                this.ReadMatchDistances(out lenRes1, out numDistancePairs);
            }
            else
            {
                lenRes1 = this._longestMatchLength;
                numDistancePairs = this._numDistancePairs;
                this._longestMatchWasFound = false;
            }
            uint num1 = this._matchFinder.GetNumAvailableBytes() + 1U;
            if (num1 < 2U)
            {
                backRes = uint.MaxValue;
                return 1;
            }
            if (num1 > 273U)
                ;
            uint num2 = 0;
            for (uint index = 0; index < 4U; ++index)
            {
                this.reps[index] = this._repDistances[index];
                this.repLens[index] = this._matchFinder.GetMatchLen(-1, this.reps[index], 273U);
                if (this.repLens[index] > this.repLens[num2])
                    num2 = index;
            }
            if (this.repLens[num2] >= this._numFastBytes)
            {
                backRes = num2;
                uint repLen = this.repLens[num2];
                this.MovePos(repLen - 1U);
                return repLen;
            }
            if (lenRes1 >= this._numFastBytes)
            {
                backRes = this._matchDistances[(numDistancePairs - 1U)] + 4U;
                this.MovePos(lenRes1 - 1U);
                return lenRes1;
            }
            byte indexByte1 = this._matchFinder.GetIndexByte(-1);
            byte indexByte2 = this._matchFinder.GetIndexByte(-(int)this._repDistances[0] - 1 - 1);
            if (lenRes1 < 2U && (int)indexByte1 != (int)indexByte2 && this.repLens[num2] < 2U)
            {
                backRes = uint.MaxValue;
                return 1;
            }
            this._optimum[0].State = this._state;
            uint posState1 = position & this._posStateMask;
            Encoder.Optimal optimal1 = this._optimum[1];
            int price0 = (int)this._isMatch[((this._state.Index << 4) + posState1)].GetPrice0();
            Encoder.LiteralEncoder.Encoder2 subCoder = this._literalEncoder.GetSubCoder(position, this._previousByte);
            int price1 = (int)subCoder.GetPrice(!this._state.IsCharState(), indexByte2, indexByte1);
            int num3 = price0 + price1;
            optimal1.Price = (uint)num3;
            this._optimum[1].MakeAsChar();
            uint price1_1 = this._isMatch[((this._state.Index << 4) + posState1)].GetPrice1();
            uint num4 = price1_1 + this._isRep[this._state.Index].GetPrice1();
            if ((int)indexByte2 == (int)indexByte1)
            {
                uint num5 = num4 + this.GetRepLen1Price(this._state, posState1);
                if (num5 < this._optimum[1].Price)
                {
                    this._optimum[1].Price = num5;
                    this._optimum[1].MakeAsShortRep();
                }
            }
            uint num6 = lenRes1 >= this.repLens[num2] ? lenRes1 : this.repLens[num2];
            if (num6 < 2U)
            {
                backRes = this._optimum[1].BackPrev;
                return 1;
            }
            this._optimum[1].PosPrev = 0U;
            this._optimum[0].Backs0 = this.reps[0];
            this._optimum[0].Backs1 = this.reps[1];
            this._optimum[0].Backs2 = this.reps[2];
            this._optimum[0].Backs3 = this.reps[3];
            uint num7 = num6;
            do
            {
                this._optimum[num7--].Price = 268435455U;
            }
            while (num7 >= 2U);
            for (uint repIndex = 0; repIndex < 4U; ++repIndex)
            {
                uint repLen = this.repLens[repIndex];
                if (repLen >= 2U)
                {
                    uint num5 = num4 + this.GetPureRepPrice(repIndex, this._state, posState1);
                    do
                    {
                        uint num8 = num5 + this._repMatchLenEncoder.GetPrice(repLen - 2U, posState1);
                        Encoder.Optimal optimal2 = this._optimum[repLen];
                        if (num8 < optimal2.Price)
                        {
                            optimal2.Price = num8;
                            optimal2.PosPrev = 0U;
                            optimal2.BackPrev = repIndex;
                            optimal2.Prev1IsChar = false;
                        }
                    }
                    while (--repLen >= 2U);
                }
            }
            uint num9 = price1_1 + this._isRep[this._state.Index].GetPrice0();
            uint len1 = this.repLens[0] >= 2U ? this.repLens[0] + 1U : 2U;
            if (len1 <= lenRes1)
            {
                uint num5 = 0;
                while (len1 > this._matchDistances[num5])
                    num5 += 2U;
                while (true)
                {
                    uint matchDistance = this._matchDistances[(num5 + 1U)];
                    uint num8 = num9 + this.GetPosLenPrice(matchDistance, len1, posState1);
                    Encoder.Optimal optimal2 = this._optimum[len1];
                    if (num8 < optimal2.Price)
                    {
                        optimal2.Price = num8;
                        optimal2.PosPrev = 0U;
                        optimal2.BackPrev = matchDistance + 4U;
                        optimal2.Prev1IsChar = false;
                    }
                    if ((int)len1 == (int)this._matchDistances[num5])
                    {
                        num5 += 2U;
                        if ((int)num5 == (int)numDistancePairs)
                            break;
                    }
                    ++len1;
                }
            }
            uint cur = 0;
        label_45:
            uint lenRes2;
            Base.State state1;
            uint posState2;
            uint num10;
            uint num11;
            uint num12;
            do
            {
                byte indexByte3;
                byte indexByte4;
                uint num5;
                bool flag;
                uint num8;
                uint limit1;
                do
                {
                    ++cur;
                    if ((int)cur == (int)num6)
                        return this.Backward(out backRes, cur);
                    this.ReadMatchDistances(out lenRes2, out numDistancePairs);
                    if (lenRes2 >= this._numFastBytes)
                    {
                        this._numDistancePairs = numDistancePairs;
                        this._longestMatchLength = lenRes2;
                        this._longestMatchWasFound = true;
                        return this.Backward(out backRes, cur);
                    }
                    ++position;
                    uint num13 = this._optimum[cur].PosPrev;
                    if (this._optimum[cur].Prev1IsChar)
                    {
                        --num13;
                        if (this._optimum[cur].Prev2)
                        {
                            state1 = this._optimum[this._optimum[cur].PosPrev2].State;
                            if (this._optimum[cur].BackPrev2 < 4U)
                                state1.UpdateRep();
                            else
                                state1.UpdateMatch();
                        }
                        else
                            state1 = this._optimum[num13].State;
                        state1.UpdateChar();
                    }
                    else
                        state1 = this._optimum[num13].State;
                    if ((int)num13 == (int)cur - 1)
                    {
                        if (this._optimum[cur].IsShortRep())
                            state1.UpdateShortRep();
                        else
                            state1.UpdateChar();
                    }
                    else
                    {
                        uint num14;
                        if (this._optimum[cur].Prev1IsChar && this._optimum[cur].Prev2)
                        {
                            num13 = this._optimum[cur].PosPrev2;
                            num14 = this._optimum[cur].BackPrev2;
                            state1.UpdateRep();
                        }
                        else
                        {
                            num14 = this._optimum[cur].BackPrev;
                            if (num14 < 4U)
                                state1.UpdateRep();
                            else
                                state1.UpdateMatch();
                        }
                        Encoder.Optimal optimal2 = this._optimum[num13];
                        if (num14 < 4U)
                        {
                            switch (num14)
                            {
                                case 0:
                                    this.reps[0] = optimal2.Backs0;
                                    this.reps[1] = optimal2.Backs1;
                                    this.reps[2] = optimal2.Backs2;
                                    this.reps[3] = optimal2.Backs3;
                                    break;
                                case 1:
                                    this.reps[0] = optimal2.Backs1;
                                    this.reps[1] = optimal2.Backs0;
                                    this.reps[2] = optimal2.Backs2;
                                    this.reps[3] = optimal2.Backs3;
                                    break;
                                case 2:
                                    this.reps[0] = optimal2.Backs2;
                                    this.reps[1] = optimal2.Backs0;
                                    this.reps[2] = optimal2.Backs1;
                                    this.reps[3] = optimal2.Backs3;
                                    break;
                                default:
                                    this.reps[0] = optimal2.Backs3;
                                    this.reps[1] = optimal2.Backs0;
                                    this.reps[2] = optimal2.Backs1;
                                    this.reps[3] = optimal2.Backs2;
                                    break;
                            }
                        }
                        else
                        {
                            this.reps[0] = num14 - 4U;
                            this.reps[1] = optimal2.Backs0;
                            this.reps[2] = optimal2.Backs1;
                            this.reps[3] = optimal2.Backs2;
                        }
                    }
                    this._optimum[cur].State = state1;
                    this._optimum[cur].Backs0 = this.reps[0];
                    this._optimum[cur].Backs1 = this.reps[1];
                    this._optimum[cur].Backs2 = this.reps[2];
                    this._optimum[cur].Backs3 = this.reps[3];
                    uint price2 = this._optimum[cur].Price;
                    indexByte3 = this._matchFinder.GetIndexByte(-1);
                    indexByte4 = this._matchFinder.GetIndexByte(-(int)this.reps[0] - 1 - 1);
                    posState2 = position & this._posStateMask;
                    int num15 = (int)price2 + (int)this._isMatch[((state1.Index << 4) + posState2)].GetPrice0();
                    subCoder = this._literalEncoder.GetSubCoder(position, this._matchFinder.GetIndexByte(-2));
                    int price3 = (int)subCoder.GetPrice(!state1.IsCharState(), indexByte4, indexByte3);
                    num5 = (uint)(num15 + price3);
                    Encoder.Optimal optimal3 = this._optimum[(cur + 1U)];
                    flag = false;
                    if (num5 < optimal3.Price)
                    {
                        optimal3.Price = num5;
                        optimal3.PosPrev = cur;
                        optimal3.MakeAsChar();
                        flag = true;
                    }
                    num10 = price2 + this._isMatch[((state1.Index << 4) + posState2)].GetPrice1();
                    num8 = num10 + this._isRep[state1.Index].GetPrice1();
                    if ((int)indexByte4 == (int)indexByte3 && (optimal3.PosPrev >= cur || optimal3.BackPrev != 0U))
                    {
                        uint num14 = num8 + this.GetRepLen1Price(state1, posState2);
                        if (num14 <= optimal3.Price)
                        {
                            optimal3.Price = num14;
                            optimal3.PosPrev = cur;
                            optimal3.MakeAsShortRep();
                            flag = true;
                        }
                    }
                    uint val2 = this._matchFinder.GetNumAvailableBytes() + 1U;
                    num11 = Math.Min(4095U - cur, val2);
                    limit1 = num11;
                }
                while (limit1 < 2U);
                if (limit1 > this._numFastBytes)
                    limit1 = this._numFastBytes;
                if (!flag && (int)indexByte4 != (int)indexByte3)
                {
                    uint matchLen = this._matchFinder.GetMatchLen(0, this.reps[0], Math.Min(num11 - 1U, this._numFastBytes));
                    if (matchLen >= 2U)
                    {
                        Base.State state2 = state1;
                        state2.UpdateChar();
                        uint posState3 = position + 1U & this._posStateMask;
                        uint num13 = num5 + this._isMatch[((state2.Index << 4) + posState3)].GetPrice1() + this._isRep[state2.Index].GetPrice1();
                        uint num14 = cur + 1U + matchLen;
                        while (num6 < num14)
                            this._optimum[++num6].Price = 268435455U;
                        uint num15 = num13 + this.GetRepPrice(0U, matchLen, state2, posState3);
                        Encoder.Optimal optimal2 = this._optimum[num14];
                        if (num15 < optimal2.Price)
                        {
                            optimal2.Price = num15;
                            optimal2.PosPrev = cur + 1U;
                            optimal2.BackPrev = 0U;
                            optimal2.Prev1IsChar = true;
                            optimal2.Prev2 = false;
                        }
                    }
                }
                num12 = 2U;
                for (uint repIndex = 0; repIndex < 4U; ++repIndex)
                {
                    uint matchLen1 = this._matchFinder.GetMatchLen(-1, this.reps[repIndex], limit1);
                    if (matchLen1 >= 2U)
                    {
                        uint num13 = matchLen1;
                        do
                        {
                            while (num6 < cur + matchLen1)
                                this._optimum[++num6].Price = 268435455U;
                            uint num14 = num8 + this.GetRepPrice(repIndex, matchLen1, state1, posState2);
                            Encoder.Optimal optimal2 = this._optimum[(cur + matchLen1)];
                            if (num14 < optimal2.Price)
                            {
                                optimal2.Price = num14;
                                optimal2.PosPrev = cur;
                                optimal2.BackPrev = repIndex;
                                optimal2.Prev1IsChar = false;
                            }
                        }
                        while (--matchLen1 >= 2U);
                        uint len2 = num13;
                        if (repIndex == 0U)
                            num12 = len2 + 1U;
                        if (len2 < num11)
                        {
                            uint limit2 = Math.Min(num11 - 1U - len2, this._numFastBytes);
                            uint matchLen2 = this._matchFinder.GetMatchLen((int)len2, this.reps[repIndex], limit2);
                            if (matchLen2 >= 2U)
                            {
                                Base.State state2 = state1;
                                state2.UpdateRep();
                                uint num14 = position + len2 & this._posStateMask;
                                int num15 = (int)num8 + (int)this.GetRepPrice(repIndex, len2, state1, posState2) + (int)this._isMatch[((state2.Index << 4) + num14)].GetPrice0();
                                subCoder = this._literalEncoder.GetSubCoder(position + len2, this._matchFinder.GetIndexByte((int)len2 - 1 - 1));
                                int price2 = (int)subCoder.GetPrice(true, this._matchFinder.GetIndexByte((int)len2 - 1 - ((int)this.reps[repIndex] + 1)), this._matchFinder.GetIndexByte((int)len2 - 1));
                                uint num16 = (uint)(num15 + price2);
                                state2.UpdateChar();
                                uint posState3 = (uint)((int)position + (int)len2 + 1) & this._posStateMask;
                                uint num17 = num16 + this._isMatch[((state2.Index << 4) + posState3)].GetPrice1() + this._isRep[state2.Index].GetPrice1();
                                uint num18 = len2 + 1U + matchLen2;
                                while (num6 < cur + num18)
                                    this._optimum[++num6].Price = 268435455U;
                                uint num19 = num17 + this.GetRepPrice(0U, matchLen2, state2, posState3);
                                Encoder.Optimal optimal2 = this._optimum[(cur + num18)];
                                if (num19 < optimal2.Price)
                                {
                                    optimal2.Price = num19;
                                    optimal2.PosPrev = (uint)((int)cur + (int)len2 + 1);
                                    optimal2.BackPrev = 0U;
                                    optimal2.Prev1IsChar = true;
                                    optimal2.Prev2 = true;
                                    optimal2.PosPrev2 = cur;
                                    optimal2.BackPrev2 = repIndex;
                                }
                            }
                        }
                    }
                }
                if (lenRes2 > limit1)
                {
                    lenRes2 = limit1;
                    uint num13 = 0;
                    while (lenRes2 > this._matchDistances[num13])
                        num13 += 2U;
                    this._matchDistances[num13] = lenRes2;
                    numDistancePairs = num13 + 2U;
                }
            }
            while (lenRes2 < num12);
            uint num20 = num10 + this._isRep[state1.Index].GetPrice0();
            while (num6 < cur + lenRes2)
                this._optimum[++num6].Price = 268435455U;
            uint num21 = 0;
            while (num12 > this._matchDistances[num21])
                num21 += 2U;
            uint len3 = num12;
            while (true)
            {
                uint matchDistance = this._matchDistances[(num21 + 1U)];
                uint num5 = num20 + this.GetPosLenPrice(matchDistance, len3, posState2);
                Encoder.Optimal optimal2 = this._optimum[(cur + len3)];
                if (num5 < optimal2.Price)
                {
                    optimal2.Price = num5;
                    optimal2.PosPrev = cur;
                    optimal2.BackPrev = matchDistance + 4U;
                    optimal2.Prev1IsChar = false;
                }
                if ((int)len3 == (int)this._matchDistances[num21])
                {
                    if (len3 < num11)
                    {
                        uint limit = Math.Min(num11 - 1U - len3, this._numFastBytes);
                        uint matchLen = this._matchFinder.GetMatchLen((int)len3, matchDistance, limit);
                        if (matchLen >= 2U)
                        {
                            Base.State state2 = state1;
                            state2.UpdateMatch();
                            uint num8 = position + len3 & this._posStateMask;
                            int num13 = (int)num5 + (int)this._isMatch[((state2.Index << 4) + num8)].GetPrice0();
                            subCoder = this._literalEncoder.GetSubCoder(position + len3, this._matchFinder.GetIndexByte((int)len3 - 1 - 1));
                            int price2 = (int)subCoder.GetPrice(true, this._matchFinder.GetIndexByte((int)len3 - ((int)matchDistance + 1) - 1), this._matchFinder.GetIndexByte((int)len3 - 1));
                            uint num14 = (uint)(num13 + price2);
                            state2.UpdateChar();
                            uint posState3 = (uint)((int)position + (int)len3 + 1) & this._posStateMask;
                            uint num15 = num14 + this._isMatch[((state2.Index << 4) + posState3)].GetPrice1() + this._isRep[state2.Index].GetPrice1();
                            uint num16 = len3 + 1U + matchLen;
                            while (num6 < cur + num16)
                                this._optimum[++num6].Price = 268435455U;
                            uint num17 = num15 + this.GetRepPrice(0U, matchLen, state2, posState3);
                            Encoder.Optimal optimal3 = this._optimum[(cur + num16)];
                            if (num17 < optimal3.Price)
                            {
                                optimal3.Price = num17;
                                optimal3.PosPrev = (uint)((int)cur + (int)len3 + 1);
                                optimal3.BackPrev = 0U;
                                optimal3.Prev1IsChar = true;
                                optimal3.Prev2 = true;
                                optimal3.PosPrev2 = cur;
                                optimal3.BackPrev2 = matchDistance + 4U;
                            }
                        }
                    }
                    num21 += 2U;
                    if ((int)num21 == (int)numDistancePairs)
                        goto label_45;
                }
                ++len3;
            }
        }

        private bool ChangePair(uint smallDist, uint bigDist)
        {
            return smallDist < 33554432U && bigDist >= smallDist << 7;
        }

        private void WriteEndMarker(uint posState)
        {
            if (!this._writeEndMark)
                return;
            this._isMatch[((this._state.Index << 4) + posState)].Encode(this._rangeEncoder, 1U);
            this._isRep[this._state.Index].Encode(this._rangeEncoder, 0U);
            this._state.UpdateMatch();
            uint len = 2;
            this._lenEncoder.Encode(this._rangeEncoder, len - 2U, posState);
            uint symbol = 63;
            this._posSlotEncoder[Base.GetLenToPosState(len)].Encode(this._rangeEncoder, symbol);
            int num1 = 30;
            uint num2 = (uint)((1 << num1) - 1);
            this._rangeEncoder.EncodeDirectBits(num2 >> 4, num1 - 4);
            this._posAlignEncoder.ReverseEncode(this._rangeEncoder, num2 & 15U);
        }

        private void Flush(uint nowPos)
        {
            this.ReleaseMFStream();
            this.WriteEndMarker(nowPos & this._posStateMask);
            this._rangeEncoder.FlushData();
            this._rangeEncoder.FlushStream();
        }

        public void CodeOneBlock(out long inSize, out long outSize, out bool finished)
        {
            inSize = 0L;
            outSize = 0L;
            finished = true;
            if (this._inStream != null)
            {
                this._matchFinder.SetStream(this._inStream);
                this._matchFinder.Init();
                this._needReleaseMFStream = true;
                this._inStream = (Stream)null;
                if (this._trainSize > 0U)
                    this._matchFinder.Skip(this._trainSize);
            }
            if (this._finished)
                return;
            this._finished = true;
            long nowPos64 = this.nowPos64;
            if (this.nowPos64 == 0L)
            {
                if (this._matchFinder.GetNumAvailableBytes() == 0U)
                {
                    this.Flush((uint)this.nowPos64);
                    return;
                }
                this.ReadMatchDistances(out uint _, out uint _);
                this._isMatch[((this._state.Index << 4) + ((uint)this.nowPos64 & this._posStateMask))].Encode(this._rangeEncoder, 0U);
                this._state.UpdateChar();
                byte indexByte = this._matchFinder.GetIndexByte(-(int)this._additionalOffset);
                this._literalEncoder.GetSubCoder((uint)this.nowPos64, this._previousByte).Encode(this._rangeEncoder, indexByte);
                this._previousByte = indexByte;
                --this._additionalOffset;
                ++this.nowPos64;
            }
            if (this._matchFinder.GetNumAvailableBytes() == 0U)
            {
                this.Flush((uint)this.nowPos64);
            }
            else
            {
                do
                {
                    do
                    {
                        uint backRes;
                        uint optimum = this.GetOptimum((uint)this.nowPos64, out backRes);
                        uint posState = (uint)this.nowPos64 & this._posStateMask;
                        uint num1 = (this._state.Index << 4) + posState;
                        if (optimum == 1U && backRes == uint.MaxValue)
                        {
                            this._isMatch[num1].Encode(this._rangeEncoder, 0U);
                            byte indexByte1 = this._matchFinder.GetIndexByte(-(int)this._additionalOffset);
                            Encoder.LiteralEncoder.Encoder2 subCoder = this._literalEncoder.GetSubCoder((uint)this.nowPos64, this._previousByte);
                            if (!this._state.IsCharState())
                            {
                                byte indexByte2 = this._matchFinder.GetIndexByte(-(int)this._repDistances[0] - 1 - (int)this._additionalOffset);
                                subCoder.EncodeMatched(this._rangeEncoder, indexByte2, indexByte1);
                            }
                            else
                                subCoder.Encode(this._rangeEncoder, indexByte1);
                            this._previousByte = indexByte1;
                            this._state.UpdateChar();
                        }
                        else
                        {
                            this._isMatch[num1].Encode(this._rangeEncoder, 1U);
                            if (backRes < 4U)
                            {
                                this._isRep[this._state.Index].Encode(this._rangeEncoder, 1U);
                                if (backRes == 0U)
                                {
                                    this._isRepG0[this._state.Index].Encode(this._rangeEncoder, 0U);
                                    if (optimum == 1U)
                                        this._isRep0Long[num1].Encode(this._rangeEncoder, 0U);
                                    else
                                        this._isRep0Long[num1].Encode(this._rangeEncoder, 1U);
                                }
                                else
                                {
                                    this._isRepG0[this._state.Index].Encode(this._rangeEncoder, 1U);
                                    if (backRes == 1U)
                                    {
                                        this._isRepG1[this._state.Index].Encode(this._rangeEncoder, 0U);
                                    }
                                    else
                                    {
                                        this._isRepG1[this._state.Index].Encode(this._rangeEncoder, 1U);
                                        this._isRepG2[this._state.Index].Encode(this._rangeEncoder, backRes - 2U);
                                    }
                                }
                                if (optimum == 1U)
                                {
                                    this._state.UpdateShortRep();
                                }
                                else
                                {
                                    this._repMatchLenEncoder.Encode(this._rangeEncoder, optimum - 2U, posState);
                                    this._state.UpdateRep();
                                }
                                uint repDistance = this._repDistances[backRes];
                                if (backRes != 0U)
                                {
                                    for (uint index = backRes; index >= 1U; --index)
                                        this._repDistances[index] = this._repDistances[(index - 1U)];
                                    this._repDistances[0] = repDistance;
                                }
                            }
                            else
                            {
                                this._isRep[this._state.Index].Encode(this._rangeEncoder, 0U);
                                this._state.UpdateMatch();
                                this._lenEncoder.Encode(this._rangeEncoder, optimum - 2U, posState);
                                backRes -= 4U;
                                uint posSlot = Encoder.GetPosSlot(backRes);
                                this._posSlotEncoder[Base.GetLenToPosState(optimum)].Encode(this._rangeEncoder, posSlot);
                                if (posSlot >= 4U)
                                {
                                    int NumBitLevels = (int)(posSlot >> 1) - 1;
                                    uint num2 = (uint)((2 | (int)posSlot & 1) << NumBitLevels);
                                    uint symbol = backRes - num2;
                                    if (posSlot < 14U)
                                    {
                                        BitTreeEncoder.ReverseEncode(this._posEncoders, (uint)((int)num2 - (int)posSlot - 1), this._rangeEncoder, NumBitLevels, symbol);
                                    }
                                    else
                                    {
                                        this._rangeEncoder.EncodeDirectBits(symbol >> 4, NumBitLevels - 4);
                                        this._posAlignEncoder.ReverseEncode(this._rangeEncoder, symbol & 15U);
                                        ++this._alignPriceCount;
                                    }
                                }
                                uint num3 = backRes;
                                for (uint index = 3; index >= 1U; --index)
                                    this._repDistances[index] = this._repDistances[(index - 1U)];
                                this._repDistances[0] = num3;
                                ++this._matchPriceCount;
                            }
                            this._previousByte = this._matchFinder.GetIndexByte((int)optimum - 1 - (int)this._additionalOffset);
                        }
                        this._additionalOffset -= optimum;
                        this.nowPos64 += (long)optimum;
                    }
                    while (this._additionalOffset != 0U);
                    if (this._matchPriceCount >= 128U)
                        this.FillDistancesPrices();
                    if (this._alignPriceCount >= 16U)
                        this.FillAlignPrices();
                    inSize = this.nowPos64;
                    outSize = this._rangeEncoder.GetProcessedSizeAdd();
                    if (this._matchFinder.GetNumAvailableBytes() == 0U)
                    {
                        this.Flush((uint)this.nowPos64);
                        return;
                    }
                }
                while (this.nowPos64 - nowPos64 < 4096L);
                this._finished = false;
                finished = false;
            }
        }

        private void ReleaseMFStream()
        {
            if (this._matchFinder == null || !this._needReleaseMFStream)
                return;
            this._matchFinder.ReleaseStream();
            this._needReleaseMFStream = false;
        }

        private void SetOutStream(Stream outStream)
        {
            this._rangeEncoder.SetStream(outStream);
        }

        private void ReleaseOutStream()
        {
            this._rangeEncoder.ReleaseStream();
        }

        private void ReleaseStreams()
        {
            this.ReleaseMFStream();
            this.ReleaseOutStream();
        }

        private void SetStreams(Stream inStream, Stream outStream, long inSize, long outSize)
        {
            this._inStream = inStream;
            this._finished = false;
            this.Create();
            this.SetOutStream(outStream);
            this.Init();
            this.FillDistancesPrices();
            this.FillAlignPrices();
            this._lenEncoder.SetTableSize((uint)((int)this._numFastBytes + 1 - 2));
            this._lenEncoder.UpdateTables((uint)(1 << this._posStateBits));
            this._repMatchLenEncoder.SetTableSize((uint)((int)this._numFastBytes + 1 - 2));
            this._repMatchLenEncoder.UpdateTables((uint)(1 << this._posStateBits));
            this.nowPos64 = 0L;
        }

        public void Code(
          Stream inStream,
          Stream outStream,
          long inSize,
          long outSize,
          ICodeProgress progress)
        {
            this._needReleaseMFStream = false;
            try
            {
                this.SetStreams(inStream, outStream, inSize, outSize);
                while (true)
                {
                    long inSize1;
                    long outSize1;
                    do
                    {
                        bool finished;
                        this.CodeOneBlock(out inSize1, out outSize1, out finished);
                        if (finished)
                            goto label_3;
                    }
                    while (progress == null);
                    progress.SetProgress(inSize1, outSize1);
                }
            label_3:;
            }
            finally
            {
                this.ReleaseStreams();
            }
        }

        public void WriteCoderProperties(Stream outStream)
        {
            this.properties[0] = (byte)((this._posStateBits * 5 + this._numLiteralPosStateBits) * 9 + this._numLiteralContextBits);
            for (int index = 0; index < 4; ++index)
                this.properties[1 + index] = (byte)(this._dictionarySize >> 8 * index);
            outStream.Write(this.properties, 0, 5);
        }

        private void FillDistancesPrices()
        {
            for (uint pos = 4; pos < 128U; ++pos)
            {
                uint posSlot = Encoder.GetPosSlot(pos);
                int NumBitLevels = (int)(posSlot >> 1) - 1;
                uint num = (uint)((2 | (int)posSlot & 1) << NumBitLevels);
                this.tempPrices[pos] = BitTreeEncoder.ReverseGetPrice(this._posEncoders, (uint)((int)num - (int)posSlot - 1), NumBitLevels, pos - num);
            }
            for (uint index1 = 0; index1 < 4U; ++index1)
            {
                BitTreeEncoder bitTreeEncoder = this._posSlotEncoder[index1];
                uint num1 = index1 << 6;
                for (uint symbol = 0; symbol < this._distTableSize; ++symbol)
                    this._posSlotPrices[(num1 + symbol)] = bitTreeEncoder.GetPrice(symbol);
                for (uint index2 = 14; index2 < this._distTableSize; ++index2)
                    this._posSlotPrices[(num1 + index2)] += (uint)((int)(index2 >> 1) - 1 - 4 << 6);
                uint num2 = index1 * 128U;
                uint pos;
                for (pos = 0U; pos < 4U; ++pos)
                    this._distancesPrices[(num2 + pos)] = this._posSlotPrices[(num1 + pos)];
                for (; pos < 128U; ++pos)
                    this._distancesPrices[(num2 + pos)] = this._posSlotPrices[(num1 + Encoder.GetPosSlot(pos))] + this.tempPrices[pos];
            }
            this._matchPriceCount = 0U;
        }

        private void FillAlignPrices()
        {
            for (uint symbol = 0; symbol < 16U; ++symbol)
                this._alignPrices[symbol] = this._posAlignEncoder.ReverseGetPrice(symbol);
            this._alignPriceCount = 0U;
        }

        private static int FindMatchFinder(string s)
        {
            for (int index = 0; index < Encoder.kMatchFinderIDs.Length; ++index)
            {
                if (s == Encoder.kMatchFinderIDs[index])
                    return index;
            }
            return -1;
        }

        public void SetCoderProperties(CoderPropID[] propIDs, object[] properties)
        {
            for (UInt32 i = 0; i < properties.Length; i++)
            {
                object prop = properties[i];
                switch (propIDs[i])
                {
                    case CoderPropID.NumFastBytes:
                        {
                            if (!(prop is Int32))
                                throw new InvalidParamException();
                            Int32 numFastBytes = (Int32)prop;
                            if (numFastBytes < 5 || numFastBytes > Base.kMatchMaxLen)
                                throw new InvalidParamException();
                            _numFastBytes = (UInt32)numFastBytes;
                            break;
                        }
                    case CoderPropID.Algorithm:
                        {
                            /*
                            if (!(prop is Int32))
                                throw new InvalidParamException();
                            Int32 maximize = (Int32)prop;
                            _fastMode = (maximize == 0);
                            _maxMode = (maximize >= 2);
                            */
                            break;
                        }
                    case CoderPropID.MatchFinder:
                        {
                            if (!(prop is String))
                                throw new InvalidParamException();
                            EMatchFinderType matchFinderIndexPrev = _matchFinderType;
                            int m = FindMatchFinder(((string)prop).ToUpper());
                            if (m < 0)
                                throw new InvalidParamException();
                            _matchFinderType = (EMatchFinderType)m;
                            if (_matchFinder != null && matchFinderIndexPrev != _matchFinderType)
                            {
                                _dictionarySizePrev = 0xFFFFFFFF;
                                _matchFinder = null;
                            }
                            break;
                        }
                    case CoderPropID.DictionarySize:
                        {
                            const int kDicLogSizeMaxCompress = 30;
                            if (!(prop is Int32))
                                throw new InvalidParamException(); ;
                            Int32 dictionarySize = (Int32)prop;
                            if (dictionarySize < (UInt32)(1 << Base.kDicLogSizeMin) ||
                                dictionarySize > (UInt32)(1 << kDicLogSizeMaxCompress))
                                throw new InvalidParamException();
                            _dictionarySize = (UInt32)dictionarySize;
                            int dicLogSize;
                            for (dicLogSize = 0; dicLogSize < (UInt32)kDicLogSizeMaxCompress; dicLogSize++)
                                if (dictionarySize <= ((UInt32)(1) << dicLogSize))
                                    break;
                            _distTableSize = (UInt32)dicLogSize * 2;
                            break;
                        }
                    case CoderPropID.PosStateBits:
                        {
                            if (!(prop is Int32))
                                throw new InvalidParamException();
                            Int32 v = (Int32)prop;
                            if (v < 0 || v > (UInt32)Base.kNumPosStatesBitsEncodingMax)
                                throw new InvalidParamException();
                            _posStateBits = (int)v;
                            _posStateMask = (((UInt32)1) << (int)_posStateBits) - 1;
                            break;
                        }
                    case CoderPropID.LitPosBits:
                        {
                            if (!(prop is Int32))
                                throw new InvalidParamException();
                            Int32 v = (Int32)prop;
                            if (v < 0 || v > (UInt32)Base.kNumLitPosStatesBitsEncodingMax)
                                throw new InvalidParamException();
                            _numLiteralPosStateBits = (int)v;
                            break;
                        }
                    case CoderPropID.LitContextBits:
                        {
                            if (!(prop is Int32))
                                throw new InvalidParamException();
                            Int32 v = (Int32)prop;
                            if (v < 0 || v > (UInt32)Base.kNumLitContextBitsMax)
                                throw new InvalidParamException(); ;
                            _numLiteralContextBits = (int)v;
                            break;
                        }
                    case CoderPropID.EndMarker:
                        {
                            if (!(prop is Boolean))
                                throw new InvalidParamException();
                            SetWriteEndMarkerMode((Boolean)prop);
                            break;
                        }
                    default:
                        throw new InvalidParamException();
                }
            }
        }

        public void SetTrainSize(uint trainSize)
        {
            this._trainSize = trainSize;
        }

        private enum EMatchFinderType
        {
            BT2,
            BT4,
        }

        private class LiteralEncoder
        {
            private Encoder.LiteralEncoder.Encoder2[] m_Coders;
            private int m_NumPrevBits;
            private int m_NumPosBits;
            private uint m_PosMask;

            public void Create(int numPosBits, int numPrevBits)
            {
                if (this.m_Coders != null && this.m_NumPrevBits == numPrevBits && this.m_NumPosBits == numPosBits)
                    return;
                this.m_NumPosBits = numPosBits;
                this.m_PosMask = (uint)((1 << numPosBits) - 1);
                this.m_NumPrevBits = numPrevBits;
                uint num = (uint)(1 << this.m_NumPrevBits + this.m_NumPosBits);
                this.m_Coders = new Encoder.LiteralEncoder.Encoder2[num];
                for (uint index = 0; index < num; ++index)
                    this.m_Coders[index].Create();
            }

            public void Init()
            {
                uint num = (uint)(1 << this.m_NumPrevBits + this.m_NumPosBits);
                for (uint index = 0; index < num; ++index)
                    this.m_Coders[index].Init();
            }

            public Encoder.LiteralEncoder.Encoder2 GetSubCoder(uint pos, byte prevByte)
            {
                return this.m_Coders[(uint)((((int)pos & (int)this.m_PosMask) << this.m_NumPrevBits) + ((int)prevByte >> 8 - this.m_NumPrevBits))];
            }

            public struct Encoder2
            {
                private BitEncoder[] m_Encoders;

                public void Create()
                {
                    this.m_Encoders = new BitEncoder[768];
                }

                public void Init()
                {
                    for (int index = 0; index < 768; ++index)
                        this.m_Encoders[index].Init();
                }

                public void Encode(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, byte symbol)
                {
                    uint num = 1;
                    for (int index = 7; index >= 0; --index)
                    {
                        uint symbol1 = (uint)((int)symbol >> index & 1);
                        this.m_Encoders[num].Encode(rangeEncoder, symbol1);
                        num = num << 1 | symbol1;
                    }
                }

                public void EncodeMatched(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, byte matchByte, byte symbol)
                {
                    uint num1 = 1;
                    bool flag = true;
                    for (int index = 7; index >= 0; --index)
                    {
                        uint symbol1 = (uint)((int)symbol >> index & 1);
                        uint num2 = num1;
                        if (flag)
                        {
                            uint num3 = (uint)((int)matchByte >> index & 1);
                            num2 += (uint)(1 + (int)num3 << 8);
                            flag = (int)num3 == (int)symbol1;
                        }
                        this.m_Encoders[num2].Encode(rangeEncoder, symbol1);
                        num1 = num1 << 1 | symbol1;
                    }
                }

                public uint GetPrice(bool matchMode, byte matchByte, byte symbol)
                {
                    uint num1 = 0;
                    uint num2 = 1;
                    int num3 = 7;
                    if (matchMode)
                    {
                        for (; num3 >= 0; --num3)
                        {
                            uint num4 = (uint)((int)matchByte >> num3 & 1);
                            uint symbol1 = (uint)((int)symbol >> num3 & 1);
                            num1 += this.m_Encoders[((uint)(1 + (int)num4 << 8) + num2)].GetPrice(symbol1);
                            num2 = num2 << 1 | symbol1;
                            if ((int)num4 != (int)symbol1)
                            {
                                --num3;
                                break;
                            }
                        }
                    }
                    for (; num3 >= 0; --num3)
                    {
                        uint symbol1 = (uint)((int)symbol >> num3 & 1);
                        num1 += this.m_Encoders[num2].GetPrice(symbol1);
                        num2 = num2 << 1 | symbol1;
                    }
                    return num1;
                }
            }
        }

        private class LenEncoder
        {
            private BitEncoder _choice = new BitEncoder();
            private BitEncoder _choice2 = new BitEncoder();
            private BitTreeEncoder[] _lowCoder = new BitTreeEncoder[(16)];
            private BitTreeEncoder[] _midCoder = new BitTreeEncoder[(16)];
            private BitTreeEncoder _highCoder = new BitTreeEncoder(8);

            public LenEncoder()
            {
                for (uint index = 0; index < 16U; ++index)
                {
                    this._lowCoder[index] = new BitTreeEncoder(3);
                    this._midCoder[index] = new BitTreeEncoder(3);
                }
            }

            public void Init(uint numPosStates)
            {
                this._choice.Init();
                this._choice2.Init();
                for (uint index = 0; index < numPosStates; ++index)
                {
                    this._lowCoder[index].Init();
                    this._midCoder[index].Init();
                }
                this._highCoder.Init();
            }

            public void Encode(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, uint symbol, uint posState)
            {
                if (symbol < 8U)
                {
                    this._choice.Encode(rangeEncoder, 0U);
                    this._lowCoder[posState].Encode(rangeEncoder, symbol);
                }
                else
                {
                    symbol -= 8U;
                    this._choice.Encode(rangeEncoder, 1U);
                    if (symbol < 8U)
                    {
                        this._choice2.Encode(rangeEncoder, 0U);
                        this._midCoder[posState].Encode(rangeEncoder, symbol);
                    }
                    else
                    {
                        this._choice2.Encode(rangeEncoder, 1U);
                        this._highCoder.Encode(rangeEncoder, symbol - 8U);
                    }
                }
            }

            public void SetPrices(uint posState, uint numSymbols, uint[] prices, uint st)
            {
                uint price0 = this._choice.GetPrice0();
                uint price1 = this._choice.GetPrice1();
                uint num1 = price1 + this._choice2.GetPrice0();
                uint num2 = price1 + this._choice2.GetPrice1();
                uint symbol;
                for (symbol = 0U; symbol < 8U; ++symbol)
                {
                    if (symbol >= numSymbols)
                        return;
                    prices[(st + symbol)] = price0 + this._lowCoder[posState].GetPrice(symbol);
                }
                for (; symbol < 16U; ++symbol)
                {
                    if (symbol >= numSymbols)
                        return;
                    prices[(st + symbol)] = num1 + this._midCoder[posState].GetPrice(symbol - 8U);
                }
                for (; symbol < numSymbols; ++symbol)
                    prices[(st + symbol)] = num2 + this._highCoder.GetPrice((uint)((int)symbol - 8 - 8));
            }
        }

        private class LenPriceTableEncoder : Encoder.LenEncoder
        {
            private uint[] _prices = new uint[(4352)];
            private uint[] _counters = new uint[(16)];
            private uint _tableSize;

            public void SetTableSize(uint tableSize)
            {
                this._tableSize = tableSize;
            }

            public uint GetPrice(uint symbol, uint posState)
            {
                return this._prices[(posState * 272U + symbol)];
            }

            private void UpdateTable(uint posState)
            {
                this.SetPrices(posState, this._tableSize, this._prices, posState * 272U);
                this._counters[posState] = this._tableSize;
            }

            public void UpdateTables(uint numPosStates)
            {
                for (uint posState = 0; posState < numPosStates; ++posState)
                    this.UpdateTable(posState);
            }

            public new void Encode(SevenZip.Compression.RangeCoder.Encoder rangeEncoder, uint symbol, uint posState)
            {
                base.Encode(rangeEncoder, symbol, posState);
                if (--this._counters[posState] != 0U)
                    return;
                this.UpdateTable(posState);
            }
        }

        private class Optimal
        {
            public Base.State State;
            public bool Prev1IsChar;
            public bool Prev2;
            public uint PosPrev2;
            public uint BackPrev2;
            public uint Price;
            public uint PosPrev;
            public uint BackPrev;
            public uint Backs0;
            public uint Backs1;
            public uint Backs2;
            public uint Backs3;

            public void MakeAsChar()
            {
                this.BackPrev = uint.MaxValue;
                this.Prev1IsChar = false;
            }

            public void MakeAsShortRep()
            {
                this.BackPrev = 0U;
                this.Prev1IsChar = false;
            }

            public bool IsShortRep()
            {
                return this.BackPrev == 0U;
            }
        }
    }
}
