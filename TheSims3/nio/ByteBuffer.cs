// Decompiled with JetBrains decompiler
// Type: nio.ByteBuffer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace nio
{
  public abstract class ByteBuffer : Buffer
  {
    private ByteOrder m_order;

    protected ByteBuffer(int _capacity)
      : base(_capacity)
    {
      this.m_order = ByteOrder.BIG_ENDIAN;
      this.limit(_capacity);
    }

    public new void Dispose()
    {
      base.Dispose();
    }

    public static ByteBuffer wrap(sbyte[] data)
    {
      return ByteBuffer.wrap(data, 0, data.Length);
    }

    public static ByteBuffer wrap(sbyte[] data, int offset, int length)
    {
      return (ByteBuffer) new IndirectByteBuffer(data, offset, length);
    }

    public static ByteBuffer allocateDirect(int _capacity)
    {
      return (ByteBuffer) new DirectByteBuffer(_capacity);
    }

    public ByteOrder order()
    {
      return this.m_order;
    }

    public void order(ByteOrder byteOrder)
    {
      this.m_order = byteOrder;
    }

    public abstract FloatBuffer asFloatBuffer();

    public abstract ByteBuffer put(ref sbyte[] b, int length);

    public abstract ByteBuffer putInt(int value);

    public abstract ByteBuffer get(ref sbyte[] b, int length);

    public abstract int getInt();
  }
}
