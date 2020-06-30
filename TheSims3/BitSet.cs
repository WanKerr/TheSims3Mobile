// Decompiled with JetBrains decompiler
// Type: BitSet
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

public class BitSet
{
  internal const int INTBITS = 32;
  internal const int SHIFT = 5;
  internal const int MODMASK = 31;
  private int[] m_bits;

  public BitSet()
  {
    this.m_bits = new int[1];
  }

  public BitSet(int nbits)
  {
    this.m_bits = new int[(nbits >> 5) + ((nbits & 31) != 0 ? 1 : 0)];
  }

  public void resizeArray(int newSize)
  {
    int[] numArray = new int[newSize];
    int length = newSize > this.m_bits.Length ? this.m_bits.Length : newSize;
    midp.JSystem.arraycopy((Array) this.m_bits, 0, (Array) numArray, 0, length);
    this.m_bits = numArray;
  }

  public void _and(ref BitSet bitset)
  {
  }

  public void andNot(ref BitSet bitset)
  {
  }

  public int cardinality()
  {
    return 0;
  }

  public void clear()
  {
    for (int index = 0; index < this.m_bits.Length; ++index)
      this.m_bits[index] = 0;
  }

  public void clear(int bitIndex)
  {
    this.set(bitIndex, false);
  }

  public void clear(int fromIndex, int toIndex)
  {
    for (int bitIndex = fromIndex; bitIndex < toIndex; ++bitIndex)
      this.clear(bitIndex);
  }

  public object clone()
  {
    BitSet bitSet = new BitSet();
    int[] numArray = new int[this.m_bits.Length];
    midp.JSystem.arraycopy((Array) numArray, 0, (Array) this.m_bits, 0, this.m_bits.Length);
    bitSet.m_bits = numArray;
    return (object) bitSet;
  }

  public bool equals(ref object obj)
  {
    return false;
  }

  public void flip(int bitIndex)
  {
    this.set(bitIndex, !this.get(bitIndex));
  }

  public void flip(int fromIndex, int toIndex)
  {
    for (int bitIndex = fromIndex; bitIndex < toIndex; ++bitIndex)
      this.flip(bitIndex);
  }

  public bool get(int bitIndex)
  {
    int index = bitIndex >> 5;
    return index < this.m_bits.Length && (this.m_bits[index] & 1 << bitIndex) != 0;
  }

  public BitSet get(int fromIndex, int toIndex)
  {
    BitSet bitSet = new BitSet();
    for (int bitIndex = fromIndex; bitIndex < toIndex; ++bitIndex)
      bitSet.set(bitIndex, this.get(bitIndex));
    return bitSet;
  }

  public int hashCode()
  {
    return 0;
  }

  public bool intersects(ref BitSet bitset)
  {
    int num = bitset.m_bits.Length < this.m_bits.Length ? bitset.m_bits.Length : this.m_bits.Length;
    for (int index = 0; index < num; ++index)
    {
      if ((bitset.m_bits[index] & this.m_bits[index]) != 0)
        return true;
    }
    return false;
  }

  public bool isEmpty()
  {
    int length = this.m_bits.Length;
    for (int index = 0; index < length; ++index)
    {
      if (this.m_bits[index] != 0)
        return false;
    }
    return true;
  }

  public int length()
  {
    for (int index1 = this.m_bits.Length - 1; index1 >= 0; --index1)
    {
      for (int index2 = 31; index2 >= 0; --index2)
      {
        if ((this.m_bits[index1] & 1 << index2) != 0)
          return (index1 << 5) + index2;
      }
    }
    return 0;
  }

  public int nextClearBit(int fromIndex)
  {
    return 0;
  }

  public int nextSetBit(int fromIndex)
  {
    return 0;
  }

  public void _or(ref BitSet bitset)
  {
  }

  public void set(int bitIndex)
  {
    this.set(bitIndex, true);
  }

  public void set(int bitIndex, bool value)
  {
    int index = bitIndex >> 5;
    if (index >= this.m_bits.Length)
      this.resizeArray(index + 1);
    int num1 = bitIndex & 31;
    int bit = this.m_bits[index];
    int num2 = !value ? bit & ~(1 << num1) : bit | 1 << num1;
    this.m_bits[index] = num2;
  }

  public void set(int fromIndex, int toIndex)
  {
    for (int bitIndex = fromIndex; bitIndex < toIndex; ++bitIndex)
      this.set(bitIndex, true);
  }

  public void set(int fromIndex, int toIndex, bool value)
  {
    for (int bitIndex = fromIndex; bitIndex < toIndex; ++bitIndex)
      this.set(bitIndex, value);
  }

  public int size()
  {
    return this.m_bits.Length << 5;
  }

  public string toString()
  {
    return (string) null;
  }

  public void _xor(ref BitSet bitset)
  {
  }
}
