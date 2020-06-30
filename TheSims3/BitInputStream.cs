// Decompiled with JetBrains decompiler
// Type: BitInputStream
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

public class BitInputStream
{
  private BitSet m_bits = new BitSet();
  private int m_bitPosition;

  public BitInputStream(byte[] bits)
  {
    this.m_bits = new BitSet();
    this.m_bitPosition = 0;
    for (int index1 = 0; index1 < bits.Length; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        if (((int) bits[index1] & 1 << index2) != 0)
          this.m_bits.set(index1 * 8 + index2);
      }
    }
  }

  public virtual void Dispose()
  {
  }

  public int readInt(int numBits)
  {
    int num = 0;
    for (int index = 0; index < numBits; ++index)
    {
      if (this.m_bits.get(this.m_bitPosition))
        num |= 1 << index;
      ++this.m_bitPosition;
    }
    return num;
  }

  public string readString()
  {
    int num = this.readInt(8);
    char[] chArray = new char[num + 1];
    for (int index = 0; index < num; ++index)
      chArray[index] = (char) this.readInt(8);
    return new string(chArray);
  }
}
