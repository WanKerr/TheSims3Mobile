// Decompiled with JetBrains decompiler
// Type: ea_sdk.SDKTextUtils
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace ea_sdk
{
  public class SDKTextUtils
  {
    private static SDKFont s_currentFont = (SDKFont) null;
    private static sbyte s_chunkConfig = 0;
    private static sbyte s_numActualChunks = 0;
    private static sbyte s_numStorageChunks = 0;
    private static sbyte s_langIndex = 0;
    private static sbyte s_numLangs = 0;
    private static uint s_textEncodings = 0;
    private static ushort[] s_charMapISO = new ushort[128];
    private static bool s_hdrLoaded = false;
    private static bool s_forceChunkLoad = false;
    public const int HEADER_CHUNKANDGROUP_INDEX = 0;
    public const int CHAR_CODE_SPACE = 32;
    public const int CHAR_CODE_SOFT_HYPHEN = 173;
    public const int DEFAULT_CHARACTER_OFFSET = 65535;
    private const int CHUNK_CONFIG_CONCAT = 0;
    private const int CHUNK_CONFIG_SEPERATE = 1;
    private const int CHUNK_FLAG_UTF16BE = 128;
    private const int CHUNK_FLAG_MULTILANGUAGE = 64;
    public const int ISO_START_INDEX = 128;
    public const int ISO_INDEX_RANGE = 128;
    public const int ISO_END_INDEX = 256;
    private const int WRAPPED_OFFSETS_INCREMENT_SIZE = 50;
    private static SDKStringLanguage[] s_languageArray;
    private static SDKStringGroup[] s_groupArray;
    private static SDKStringActualChunk[] s_actualChunkArray;
    private static SDKStringStorageChunk[] s_storageChunkArray;
    private static SDKStringLanguage s_currentLanguage;
    private static short[] s_wrapOffsets;

    public static int getCurrentEncoding()
    {
      return SDKTextUtils.s_languageArray[(int) SDKTextUtils.s_langIndex].encoding;
    }

    public static ushort utf2iso(ushort code)
    {
      return (ushort) (SDKTextUtils.getCodePos(SDKTextUtils.s_charMapISO, code, 128) + 128);
    }

    public static ushort iso2utf(ushort code)
    {
      return SDKTextUtils.s_charMapISO[(int) code - 128];
    }

    public static int getCodePos(ushort[] codeArray, ushort code, int codeArrayLength)
    {
      return SDKTextUtils.getCodePos(codeArray, code, 0, codeArrayLength - 1, codeArrayLength);
    }

    private static int getCodePos(
      ushort[] codeArray,
      ushort code,
      int startIndex,
      int endIndex,
      int codeArrayLength)
    {
      if (startIndex > endIndex)
        return codeArrayLength;
      int index = startIndex + endIndex >> 1;
      ushort code1 = codeArray[index];
      if ((int) code == (int) code1)
        return index;
      return (int) code < (int) code1 ? SDKTextUtils.getCodePos(codeArray, code, startIndex, index - 1, codeArrayLength) : SDKTextUtils.getCodePos(codeArray, code, index + 1, endIndex, codeArrayLength);
    }

    public static ushort getCharOffset(ushort code, int enc)
    {
      if (SDKTextUtils.s_currentFont != null)
      {
        if (enc == 0)
          return SDKTextUtils.s_currentFont.getUTFCharOffset(code);
        if (code < (ushort) 128 || enc == SDKTextUtils.s_currentLanguage.encoding)
          return SDKTextUtils.s_currentFont.getISOCharOffset(code);
      }
      return ushort.MaxValue;
    }

    public static SDKFont loadFont(object fontImage, sbyte[] fontChunk)
    {
      SDKFont sdkFont = new SDKFont();
      sdkFont.setFontImage(fontImage);
      sdkFont.setFontData(fontChunk);
      return sdkFont;
    }

    public static void setFont(SDKFont font)
    {
      SDKTextUtils.s_currentFont = font;
      int encoding = SDKTextUtils.s_currentLanguage.encoding;
      if (font == null || SDKTextUtils.s_languageArray == null || (SDKTextUtils.s_currentFont.m_isoCodeIndex == encoding || encoding <= 1))
        return;
      font.refreshISOOffsets();
    }

    public static SDKFont setFontImage(object fontImage)
    {
      if (SDKTextUtils.s_currentFont != null)
        SDKTextUtils.s_currentFont.setFontImage(fontImage);
      return SDKTextUtils.s_currentFont;
    }

    public static SDKFont setFontChunk(sbyte[] fontChunk)
    {
      if (SDKTextUtils.s_currentFont != null)
        SDKTextUtils.s_currentFont.setFontData(fontChunk);
      return SDKTextUtils.s_currentFont;
    }

    public static SDKFont getFont()
    {
      return SDKTextUtils.s_currentFont;
    }

    public static void setCharSpacing(int val)
    {
      if (SDKTextUtils.s_currentFont == null)
        return;
      SDKTextUtils.s_currentFont.setCharSpacing(val);
    }

    public static int getCharSpacing()
    {
      return SDKTextUtils.s_currentFont == null ? 0 : SDKTextUtils.s_currentFont.getCharSpacing();
    }

    public static void setTransform(int transform)
    {
      if (SDKTextUtils.s_currentFont == null)
        return;
      SDKTextUtils.s_currentFont.setTransform(transform);
    }

    public static void setSpaceSpacing(int val)
    {
      if (SDKTextUtils.s_currentFont == null)
        return;
      SDKTextUtils.s_currentFont.setSpaceSpacing(val);
    }

    public static int getSpaceSpacing()
    {
      return SDKTextUtils.s_currentFont != null ? SDKTextUtils.s_currentFont.getSpaceSpacing() : 0;
    }

    public static void setLeadingSpacing(int val)
    {
      if (SDKTextUtils.s_currentFont == null)
        return;
      SDKTextUtils.s_currentFont.setLeading(val);
    }

    public static int getLeadingSpacing()
    {
      return SDKTextUtils.s_currentFont != null ? SDKTextUtils.s_currentFont.getLeading() : 0;
    }

    public static int getBaselinePosition()
    {
      return SDKTextUtils.s_currentFont == null ? 0 : SDKTextUtils.s_currentFont.getBaselinePosition();
    }

    public static int getLineSize()
    {
      return SDKTextUtils.s_currentFont == null ? 0 : SDKTextUtils.s_currentFont.getLineSize();
    }

    public static void drawString(
      SDKString _string,
      int x,
      int y,
      int anchor,
      SDKTextUtils.DrawRegionRoutineDelegate DrawRegionRoutine)
    {
      SDKTextUtils.drawSubString(_string, 0, _string.Length(), x, y, anchor, DrawRegionRoutine);
    }

    public static void drawSubString(
      SDKString _string,
      int offset,
      int len,
      int xConst,
      int yConst,
      int anchor,
      SDKTextUtils.DrawRegionRoutineDelegate DrawRegionRoutine)
    {
      int num1 = xConst;
      int num2 = yConst;
      if (SDKTextUtils.s_currentFont == null)
        return;
      object fontImage = SDKTextUtils.s_currentFont.getFontImage();
      int ascent = SDKTextUtils.s_currentFont.getAscent();
      int lineSize = SDKTextUtils.s_currentFont.getLineSize();
      int textDir = SDKTextUtils.s_currentFont.getTextDir();
      int lineDir = SDKTextUtils.s_currentFont.getLineDir();
      if (SDKTextUtils.s_currentFont.m_charData == null)
        return;
      int num3 = 0;
      int num4 = 0;
      if ((anchor & 32) != 0)
        num3 -= SDKTextUtils.getSubStringSize(_string, offset, len);
      else if ((anchor & 16) != 0)
        num3 -= SDKTextUtils.getSubStringSize(_string, offset, len) >> 1;
      if ((anchor & 64) != 0)
        num4 -= ascent;
      else if ((anchor & 4) != 0)
        num4 -= lineSize;
      switch (textDir)
      {
        case 1:
          num1 += num3;
          num2 += num4;
          break;
        case 2:
          num1 -= num4;
          num2 += num3;
          break;
        case 4:
          num1 -= num3;
          num2 -= num4;
          break;
        case 8:
          num1 -= num4;
          num2 -= num3;
          break;
      }
      int[] p = new int[2]{ num1, num2 };
      int encoding = _string.getEncoding();
      switch (encoding)
      {
        case 0:
        case 1:
          bool flag1 = (textDir & 5) != 0;
          sbyte num5 = (sbyte) ((textDir & 4) >> 1);
          sbyte num6 = (sbyte) (((lineDir & 1) << 1) + ((~lineDir & 2) >> 1));
          sbyte num7 = flag1 ? num5 : num6;
          bool flag2 = (textDir & 10) != 0;
          sbyte num8 = (sbyte) ((textDir & 8) >> 2);
          sbyte num9 = (sbyte) ((lineDir & 2) + (~lineDir & 1));
          sbyte num10 = flag2 ? num8 : num9;
          for (int index1 = offset; index1 != offset + len; ++index1)
          {
            ushort code = _string.charCodeAt(index1);
            if (code != (ushort) 173 || index1 == offset + len - 1)
            {
              ushort charOffset = SDKTextUtils.getCharOffset(code, encoding);
              int charAdvance = SDKTextUtils.s_currentFont.getCharAdvance(charOffset);
              if (charOffset == ushort.MaxValue)
              {
                if (code == (ushort) 32)
                  ;
              }
              else
              {
                ushort num11 = (ushort) ((uint) charOffset + 1U);
                sbyte[] mCharData1 = SDKTextUtils.s_currentFont.m_charData;
                int index2 = (int) num11;
                ushort num12 = (ushort) (index2 + 1);
                int num13 = (int) mCharData1[index2] & (int) byte.MaxValue;
                for (int index3 = 0; index3 != num13; ++index3)
                {
                  sbyte[] mCharData2 = SDKTextUtils.s_currentFont.m_charData;
                  int index4 = (int) num12;
                  ushort num14 = (ushort) (index4 + 1);
                  int num15 = (int) mCharData2[index4] & (int) byte.MaxValue;
                  sbyte[] mCharData3 = SDKTextUtils.s_currentFont.m_charData;
                  int index5 = (int) num14;
                  ushort num16 = (ushort) (index5 + 1);
                  int num17 = (int) mCharData3[index5] & (int) byte.MaxValue;
                  sbyte[] mCharData4 = SDKTextUtils.s_currentFont.m_charData;
                  int index6 = (int) num16;
                  ushort num18 = (ushort) (index6 + 1);
                  int num19 = (int) mCharData4[index6];
                  sbyte[] mCharData5 = SDKTextUtils.s_currentFont.m_charData;
                  int index7 = (int) num18;
                  ushort num20 = (ushort) (index7 + 1);
                  int num21 = (int) mCharData5[index7];
                  sbyte[] mCharData6 = SDKTextUtils.s_currentFont.m_charData;
                  int index8 = (int) num20;
                  ushort num22 = (ushort) (index8 + 1);
                  int num23 = (int) mCharData6[index8] & (int) byte.MaxValue;
                  sbyte[] mCharData7 = SDKTextUtils.s_currentFont.m_charData;
                  int index9 = (int) num22;
                  num12 = (ushort) (index9 + 1);
                  int num24 = (int) mCharData7[index9] & (int) byte.MaxValue;
                  int[] numArray = new int[4]
                  {
                    num19,
                    num21 - ascent,
                    -num19 - num23,
                    ascent - num21 - num24
                  };
                  int num25 = p[0] + numArray[(int) num7];
                  int num26 = p[1] + numArray[(int) num10];
                  DrawRegionRoutine(fontImage, (short) num25, (short) num26, (short) num23, (short) num24, (short) num15, (short) num17);
                }
              }
              SDKTextUtils.s_currentFont.advance(p, charAdvance);
            }
          }
          break;
        default:
          if (encoding != SDKTextUtils.s_currentLanguage.encoding)
          {
            JSystem.println("ERROR: SDKTextUtils::drawString: SDKString has encoding " + encoding.ToString() + ", but the currently set language has encoding " + SDKTextUtils.s_currentLanguage.encoding.ToString());
            goto case 0;
          }
          else
            goto case 0;
      }
    }

    public static void drawWrappedString(
      SDKString _string,
      short[] offsets,
      int startLine,
      int lineCount,
      int xConst,
      int yConst,
      int anchorConst,
      SDKTextUtils.DrawRegionRoutineDelegate DrawRegionRoutine)
    {
      int xConst1 = xConst;
      int yConst1 = yConst;
      int anchor = anchorConst;
      int lineSize = SDKTextUtils.getLineSize();
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if ((anchor & 2) != 0)
        num3 = (int) offsets[0] * lineSize - SDKTextUtils.s_currentFont.getLeading() >> 1;
      else if ((anchor & 4) != 0)
      {
        num3 = (int) offsets[0] * lineSize - SDKTextUtils.s_currentFont.getLeading();
        anchor ^= 4;
      }
      switch (SDKTextUtils.s_currentFont.m_transLineDirection)
      {
        case 1:
          xConst1 -= num3;
          num1 = lineSize;
          break;
        case 2:
          yConst1 -= num3;
          num2 = lineSize;
          break;
        case 4:
          xConst1 += num3;
          num1 = -lineSize;
          break;
        default:
          yConst1 += num3;
          num2 = -lineSize;
          break;
      }
      int offset1 = (int) offsets[(int) offsets[0] + 2];
      for (int index = startLine; index < startLine + lineCount; ++index)
      {
        int offset2 = (int) offsets[index];
        int len = (int) offsets[index + 1] - offset2;
        int num4 = (int) _string.charCodeAt((int) offsets[index + 1] - 1);
        if (num4 == offset1 || num4 == 32)
          --len;
        SDKTextUtils.drawSubString(_string, offset2, len, xConst1, yConst1, anchor, DrawRegionRoutine);
        xConst1 += num1;
        yConst1 += num2;
      }
    }

    public static short[] wrapString(
      SDKString _string,
      short[] offsets,
      int wrapLimit,
      short newline)
    {
      return SDKTextUtils.wrapSubString(_string, 0, _string.Length(), offsets, wrapLimit, newline);
    }

    public static short[] wrapSubString(
      SDKString _string,
      int offset,
      int len,
      short[] offsetsConst,
      int wrapLimit,
      short newline)
    {
      short[] numArray1 = offsetsConst;
      bool flag = false;
      if (numArray1 == null)
      {
        if (SDKTextUtils.s_wrapOffsets == null)
          SDKTextUtils.s_wrapOffsets = new short[50];
        numArray1 = SDKTextUtils.s_wrapOffsets;
        flag = true;
      }
      int encoding = _string.getEncoding();
      int num1 = 0;
      int num2 = 0;
      int num3 = -1;
      numArray1[1] = (short) offset;
      int index1 = 2;
      for (int index2 = offset; index2 != len + offset; ++index2)
      {
        ushort code = _string.charCodeAt(index2);
        if (flag && index1 + 3 >= SDKTextUtils.s_wrapOffsets.Length)
        {
          short[] wrapOffsets = SDKTextUtils.s_wrapOffsets;
          SDKTextUtils.s_wrapOffsets = new short[SDKTextUtils.s_wrapOffsets.Length + 50];
          for (int index3 = 0; index3 != wrapOffsets.Length; ++index3)
            SDKTextUtils.s_wrapOffsets[index3] = wrapOffsets[index3];
          numArray1 = SDKTextUtils.s_wrapOffsets;
        }
        if ((int) code == (int) newline)
        {
          numArray1[index1++] = (short) (index2 + 1);
          num1 = 0;
          num2 = 0;
          num3 = -1;
        }
        else
        {
          ushort charOffset = SDKTextUtils.getCharOffset(code, encoding);
          int charAdvance = SDKTextUtils.s_currentFont.getCharAdvance(charOffset);
          num1 += charAdvance;
          num2 += charAdvance;
          if (num1 > wrapLimit)
          {
            if (num3 == -1)
            {
              numArray1[index1++] = (short) index2;
              num1 = charAdvance;
              num2 = 0;
            }
            else
            {
              numArray1[index1++] = (short) (num3 + 1);
              num3 = code == (ushort) 32 || code == (ushort) 173 ? index2 : -1;
              num1 = num2;
              num2 = 0;
            }
          }
          else if (code == (ushort) 32 || code == (ushort) 173)
          {
            num3 = index2;
            num2 = 0;
          }
        }
      }
      numArray1[0] = (short) (index1 - 1);
      numArray1[index1] = (short) (len + offset);
      numArray1[index1 + 1] = newline;
      if (flag)
      {
        short[] numArray2 = new short[index1 + 2];
        for (int index2 = 0; index2 != index1 + 2; ++index2)
          numArray2[index2] = numArray1[index2];
        numArray1 = numArray2;
      }
      return numArray1;
    }

    public static int getStringSize(SDKString _string)
    {
      return SDKTextUtils.getSubStringSize(_string, 0, _string.Length());
    }

    public static int getSubStringSize(SDKString _string, int offset, int len)
    {
      int num = 0;
      int encoding = _string.getEncoding();
      for (int index = offset; index < offset + len; ++index)
        num += SDKTextUtils.s_currentFont.getCharAdvance(SDKTextUtils.getCharOffset(_string.charCodeAt(index), encoding));
      return num;
    }

    public static bool isLoadedStringsChunk(int chunkID)
    {
      int group = (int) SDKTextUtils.s_actualChunkArray[chunkID].group;
      return SDKTextUtils.s_storageChunkArray[group].stringData != null && (int) SDKTextUtils.s_groupArray[group].map == chunkID;
    }

    public static void loadStringsChunk(int chunkID)
    {
      if (SDKTextUtils.isLoadedStringsChunk(chunkID) && !SDKTextUtils.s_forceChunkLoad)
        return;
      SDKStringActualChunk actualChunk1 = SDKTextUtils.s_actualChunkArray[chunkID];
      int index1 = ((int) actualChunk1.flags & 64) == 0 ? (int) SDKTextUtils.s_langIndex : 0;
      string str1 = "";
      InputStream resourceAsStream;
      switch (SDKTextUtils.s_chunkConfig)
      {
        case 0:
          string str2 = str1 + "t_";
          string sourcestring1 = new string(new char[6]);
          int index2 = -1;
          sbyte num1;
          do
          {
            ++index2;
            num1 = index2 != 5 ? SDKTextUtils.s_languageArray[index1].isoCodeArray[index2] : (sbyte) 32;
            sourcestring1 = StringFunctions.ChangeCharacter(sourcestring1, index2, (char) num1);
          }
          while (num1 != (sbyte) 32);
          string str3 = sourcestring1.Substring(0, index2);
          resourceAsStream = JavaLib.getResourceAsStream(str2 + str3, false);
          ushort[] chunkSizeArray = SDKTextUtils.s_languageArray[index1].chunkSizeArray;
          for (int index3 = 1; index3 != chunkID; ++index3)
          {
            SDKStringActualChunk actualChunk2 = SDKTextUtils.s_actualChunkArray[index3];
            if (((int) actualChunk2.flags & 64) == 0 || index1 == 0)
              resourceAsStream.skip((long) ((actualChunk2.numStrings + 1 << 1) + (int) chunkSizeArray[index3]));
          }
          break;
        case 1:
          string str4 = str1 + "t_";
          string sourcestring2 = new string(new char[6]);
          int charindex = -1;
          sbyte num2;
          do
          {
            ++charindex;
            num2 = charindex != 5 ? SDKTextUtils.s_languageArray[index1].isoCodeArray[charindex] : (sbyte) 32;
            sourcestring2 = StringFunctions.ChangeCharacter(sourcestring2, charindex, (char) num2);
          }
          while (num2 != (sbyte) 32);
          string str5 = StringFunctions.ChangeCharacter(sourcestring2, charindex, char.MinValue);
          resourceAsStream = JavaLib.getResourceAsStream(str4 + str5 + (object) chunkID, false);
          break;
        default:
          return;
      }
      DataInputStream dataInputStream = new DataInputStream(resourceAsStream);
      int num3 = actualChunk1.numStrings + 1;
      int group1 = (int) actualChunk1.group;
      SDKStringGroup group2 = SDKTextUtils.s_groupArray[group1];
      SDKStringStorageChunk storageChunk = SDKTextUtils.s_storageChunkArray[group1];
      if (storageChunk.stringOffsetArray == null)
        storageChunk.stringOffsetArray = new ushort[(int) group2.maxNumOffsets];
      for (int index3 = 0; index3 != num3; ++index3)
        storageChunk.stringOffsetArray[index3] = (ushort) dataInputStream.readShort();
      if (storageChunk.stringData == null)
        storageChunk.stringData = new sbyte[(int) group2.maxSize];
      dataInputStream.readFully(storageChunk.stringData, (int) SDKTextUtils.s_languageArray[index1].chunkSizeArray[chunkID]);
      group2.map = (sbyte) chunkID;
      dataInputStream.close();
    }

    public static void freeStringsChunk(int chunkID)
    {
      if (chunkID <= 0)
        return;
      int group = (int) SDKTextUtils.s_actualChunkArray[chunkID].group;
      SDKTextUtils.s_storageChunkArray[group].stringData = new sbyte[0];
      SDKTextUtils.s_storageChunkArray[group].stringOffsetArray = new ushort[0];
    }

    public static int loadTextHeader(sbyte[] textHeader)
    {
      DataInputStream dataInputStream = new DataInputStream((InputStream) new ByteArrayInputStream(textHeader, 1024));
      int num1 = (int) dataInputStream.readByte();
      SDKTextUtils.s_chunkConfig = dataInputStream.readByte();
      SDKTextUtils.s_textEncodings = (uint) ((int) dataInputStream.readByte() << 16 | (int) dataInputStream.readByte() << 8) | (uint) dataInputStream.readByte();
      int num2 = (int) dataInputStream.readShort();
      SDKTextUtils.s_numLangs = dataInputStream.readByte();
      sbyte num3 = dataInputStream.readByte();
      sbyte num4 = dataInputStream.readByte();
      SDKTextUtils.s_numStorageChunks = (sbyte) ((int) num3 + 1);
      SDKTextUtils.s_numActualChunks = (sbyte) ((int) num4 + 1);
      SDKTextUtils.s_languageArray = new SDKStringLanguage[(int) SDKTextUtils.s_numLangs];
      SDKTextUtils.s_groupArray = new SDKStringGroup[(int) SDKTextUtils.s_numActualChunks];
      SDKTextUtils.s_actualChunkArray = new SDKStringActualChunk[(int) SDKTextUtils.s_numActualChunks];
      for (int index = 0; index < (int) SDKTextUtils.s_numActualChunks; ++index)
      {
        SDKTextUtils.s_groupArray[index] = new SDKStringGroup();
        SDKTextUtils.s_actualChunkArray[index] = new SDKStringActualChunk();
      }
      SDKTextUtils.s_storageChunkArray = new SDKStringStorageChunk[(int) SDKTextUtils.s_numStorageChunks];
      for (int index = 0; index < (int) SDKTextUtils.s_numStorageChunks; ++index)
        SDKTextUtils.s_storageChunkArray[index] = new SDKStringStorageChunk();
      SDKStringActualChunk actualChunk1 = SDKTextUtils.s_actualChunkArray[0];
      SDKStringStorageChunk storageChunk = SDKTextUtils.s_storageChunkArray[0];
      actualChunk1.numStrings = num2;
      actualChunk1.flags = sbyte.MinValue;
      actualChunk1.group = (sbyte) 0;
      for (int index = 0; index != (int) SDKTextUtils.s_numLangs; ++index)
      {
        SDKTextUtils.s_languageArray[index] = new SDKStringLanguage();
        SDKTextUtils.s_languageArray[index].chunkSizeArray = new ushort[(int) SDKTextUtils.s_numActualChunks];
      }
      int num5 = num2 + 1;
      for (int index1 = 0; index1 != (int) SDKTextUtils.s_numLangs; ++index1)
      {
        SDKStringLanguage language = SDKTextUtils.s_languageArray[index1];
        language.isoCodeArray = new sbyte[5];
        for (int index2 = 0; index2 != 5; ++index2)
          language.isoCodeArray[index2] = dataInputStream.readByte();
        language.encoding = (int) dataInputStream.readByte();
        language.fontDifferentiator = dataInputStream.readByte();
        if (num2 > 0)
        {
          if (storageChunk.stringOffsetArray == null)
            storageChunk.stringOffsetArray = new ushort[(int) SDKTextUtils.s_numLangs * num5];
          for (int index2 = 0; index2 != num5; ++index2)
            storageChunk.stringOffsetArray[index1 * num5 + index2] = (ushort) dataInputStream.readShort();
        }
      }
      if (num2 > 0)
      {
        int stringOffset = (int) storageChunk.stringOffsetArray[(int) SDKTextUtils.s_numLangs * num5 - 1];
        storageChunk.stringData = new sbyte[stringOffset];
        dataInputStream.readFully(storageChunk.stringData, stringOffset);
      }
      for (int index1 = 1; index1 != (int) SDKTextUtils.s_numActualChunks; ++index1)
      {
        SDKStringActualChunk actualChunk2 = SDKTextUtils.s_actualChunkArray[index1];
        int num6 = (int) dataInputStream.readByte();
        actualChunk2.flags = (sbyte) (num6 & 192);
        actualChunk2.group = (sbyte) (num6 & 63);
        actualChunk2.numStrings = (int) dataInputStream.readShort();
        SDKStringGroup group = SDKTextUtils.s_groupArray[(int) actualChunk2.group];
        ushort num7 = (ushort) (actualChunk2.numStrings + 1);
        if ((int) num7 > (int) group.maxNumOffsets)
          group.maxNumOffsets = num7;
        for (int index2 = 0; index2 != (int) SDKTextUtils.s_numLangs; ++index2)
        {
          int num8 = dataInputStream.readUnsignedShort();
          SDKTextUtils.s_languageArray[index2].chunkSizeArray[index1] = (ushort) num8;
          if (num8 > (int) group.maxSize)
            group.maxSize = (ushort) num8;
        }
      }
      SDKTextUtils.s_currentLanguage = SDKTextUtils.s_languageArray[(int) SDKTextUtils.s_langIndex];
      if (SDKTextUtils.s_currentLanguage.encoding > 1)
        SDKTextUtils.loadCharMap((sbyte) SDKTextUtils.s_currentLanguage.encoding);
      SDKTextUtils.s_hdrLoaded = true;
      dataInputStream.close();
      return (int) SDKTextUtils.s_numLangs;
    }

    private static void loadCharMap(sbyte enc)
    {
      int num = 0;
      for (int index = 1; index < (int) enc; ++index)
      {
        if (((long) SDKTextUtils.s_textEncodings & (long) (1 << index)) != 0L)
          ++num;
      }
      DataInputStream dataInputStream = new DataInputStream(JavaLib.getResourceAsStream("charmap", false));
      dataInputStream.skip((long) (num << 8));
      for (int index = 0; index != 128; ++index)
        SDKTextUtils.s_charMapISO[index] = (ushort) dataInputStream.readShort();
      dataInputStream.close();
      if (SDKTextUtils.s_currentFont == null)
        return;
      SDKTextUtils.s_currentFont.refreshISOOffsets();
    }

    public static SDKString getHeaderString(
      int langIndex,
      int stringID,
      SDKString stringConst)
    {
      SDKString sdkString = stringConst;
      SDKStringActualChunk actualChunk = SDKTextUtils.s_actualChunkArray[0];
      if (stringID >= actualChunk.numStrings)
        return stringConst;
      int index1 = stringID + (actualChunk.numStrings + 1) * langIndex;
      if (sdkString == null)
        sdkString = new SDKString();
      SDKStringStorageChunk storageChunk = SDKTextUtils.s_storageChunkArray[0];
      sbyte[] stringData = storageChunk.stringData;
      int stringOffset = (int) storageChunk.stringOffsetArray[index1];
      ushort num = (ushort) ((uint) storageChunk.stringOffsetArray[index1 + 1] - (uint) stringOffset);
      char[] chArray = new char[stringData.Length];
      for (int index2 = 0; index2 < chArray.Length; ++index2)
        chArray[index2] = (char) stringData[index2];
      sdkString.setCharData(new string(chArray), stringOffset, (int) num, (sbyte) 0);
      return sdkString;
    }

    public static SDKString getString(int stringID, SDKString stringConst)
    {
      SDKString sdkString = stringConst;
      int index1 = -1;
      int num1 = 0;
      for (int index2 = 0; index2 != (int) SDKTextUtils.s_numActualChunks; ++index2)
      {
        num1 += SDKTextUtils.s_actualChunkArray[index2].numStrings;
        if (stringID < num1)
        {
          index1 = index2;
          break;
        }
      }
      SDKStringActualChunk actualChunk = SDKTextUtils.s_actualChunkArray[index1];
      int index3 = stringID - (num1 - actualChunk.numStrings);
      int group = (int) actualChunk.group;
      SDKStringStorageChunk storageChunk = SDKTextUtils.s_storageChunkArray[group];
      if (sdkString == null)
        sdkString = new SDKString();
      char[] chArray = new char[storageChunk.stringData.Length];
      for (int index2 = 0; index2 < chArray.Length; ++index2)
        chArray[index2] = (char) storageChunk.stringData[index2];
      string data = new string(chArray);
      int stringOffset = (int) storageChunk.stringOffsetArray[index3];
      ushort num2 = (ushort) ((uint) storageChunk.stringOffsetArray[index3 + 1] - (uint) stringOffset);
      sbyte encoding = (sbyte) SDKTextUtils.s_currentLanguage.encoding;
      if (((int) actualChunk.flags & 192) != 0)
        encoding = (sbyte) 0;
      sdkString.setCharData(data, stringOffset, (int) num2, encoding);
      return sdkString;
    }

    public static int getCurrentLanguage()
    {
      return (int) SDKTextUtils.s_langIndex;
    }

    public static bool setCurrentLanguage(int index)
    {
      sbyte langIndex = SDKTextUtils.s_langIndex;
      if (SDKTextUtils.s_languageArray != null && index >= 0 && index < (int) SDKTextUtils.s_numLangs)
      {
        SDKTextUtils.s_langIndex = (sbyte) index;
        SDKTextUtils.s_currentLanguage = SDKTextUtils.s_languageArray[index];
      }
      if ((int) SDKTextUtils.s_langIndex != (int) langIndex)
      {
        SDKTextUtils.s_forceChunkLoad = true;
        for (int chunkID = 1; chunkID != (int) SDKTextUtils.s_numActualChunks; ++chunkID)
        {
          if (SDKTextUtils.isLoadedStringsChunk(chunkID) && ((int) SDKTextUtils.s_actualChunkArray[chunkID].flags & 64) == 0)
            SDKTextUtils.loadStringsChunk(chunkID);
        }
        SDKTextUtils.s_forceChunkLoad = false;
        sbyte encoding1 = (sbyte) SDKTextUtils.s_languageArray[(int) langIndex].encoding;
        sbyte encoding2 = (sbyte) SDKTextUtils.s_languageArray[index].encoding;
        if ((int) encoding1 != (int) encoding2 && encoding2 > (sbyte) 1)
          SDKTextUtils.loadCharMap(encoding2);
      }
      return (int) SDKTextUtils.s_langIndex != index;
    }

    public delegate void DrawRegionRoutineDelegate(
      object img,
      short xdst,
      short ydst,
      short w,
      short h,
      short xsrc,
      short ysrc);
  }
}
