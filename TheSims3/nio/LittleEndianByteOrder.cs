// Decompiled with JetBrains decompiler
// Type: nio.LittleEndianByteOrder
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace nio
{
  public class LittleEndianByteOrder : ByteOrder
  {
    public override void putInt(sbyte[] data, int value)
    {
      data[0] = (sbyte) (value & (int) byte.MaxValue);
      data[1] = (sbyte) (value >> 8 & (int) byte.MaxValue);
      data[2] = (sbyte) (value >> 16 & (int) byte.MaxValue);
      data[3] = (sbyte) (value >> 24 & (int) byte.MaxValue);
    }

    public override int getInt(sbyte[] data, int startIndex)
    {
      return (int) data[startIndex] & (int) byte.MaxValue | (int) data[startIndex + 1] << 8 & (int) byte.MaxValue | (int) data[startIndex + 2] << 16 & (int) byte.MaxValue | (int) data[startIndex + 3] << 24 & (int) byte.MaxValue;
    }
  }
}
