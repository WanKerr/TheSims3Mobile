// Decompiled with JetBrains decompiler
// Type: nio.ByteOrder
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace nio
{
  public abstract class ByteOrder
  {
    public static readonly LittleEndianByteOrder s_LittleEndianByteOrder = new LittleEndianByteOrder();
    public static readonly BigEndianByteOrder s_BigEndianByteOrder = new BigEndianByteOrder();
    public static readonly NativeByteOrder s_NativeByteOrder = new NativeByteOrder();
    public static readonly ByteOrder LITTLE_ENDIAN = (ByteOrder) ByteOrder.s_LittleEndianByteOrder;
    public static readonly ByteOrder BIG_ENDIAN = (ByteOrder) ByteOrder.s_BigEndianByteOrder;
    public static readonly ByteOrder NATIVE = (ByteOrder) ByteOrder.s_NativeByteOrder;

    public abstract void putInt(sbyte[] data, int value);

    public abstract int getInt(sbyte[] data, int startIndex);

    public virtual void Dispose()
    {
    }

    public static ByteOrder nativeOrder()
    {
      return ByteOrder.NATIVE;
    }
  }
}
