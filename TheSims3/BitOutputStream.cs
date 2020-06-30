// Decompiled with JetBrains decompiler
// Type: BitOutputStream
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

public class BitOutputStream
{
  private BitSet m_bits = new BitSet();
  public const int STRING_LENGTH_BITS = 8;
  private int m_bitPosition;

  public BitOutputStream()
  {
    this.m_bits = new BitSet();
    this.m_bitPosition = 0;
  }

  public virtual void Dispose()
  {
  }

  public void writeInt(int value, int numBits)
  {
    for (int index = 0; index < numBits; ++index)
    {
      this.m_bits.set(this.m_bitPosition, (value & 1 << index) != 0);
      ++this.m_bitPosition;
    }
  }

  public void writeString(string str)
  {
    char[] charArray = str.ToCharArray();
    int length = charArray.Length;
    this.writeInt(length, 8);
    for (int index = 0; index < length; ++index)
      this.writeInt((int) charArray[index], 8);
  }

  public byte[] toArray()
  {
    int length = this.m_bitPosition / 8 + (this.m_bitPosition % 8 != 0 ? 1 : 0);
    byte[] numArray = new byte[length];
    for (int index1 = 0; index1 < length; ++index1)
    {
      numArray[index1] = (byte) 0;
      for (int index2 = 0; index2 < 8; ++index2)
      {
        if (this.m_bits.get(index1 * 8 + index2))
          numArray[index1] |= (byte) (1 << index2);
      }
    }
    return numArray;
  }
}
