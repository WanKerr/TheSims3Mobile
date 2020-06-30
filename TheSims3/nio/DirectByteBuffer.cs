// Decompiled with JetBrains decompiler
// Type: nio.DirectByteBuffer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace nio
{
  public class DirectByteBuffer : ByteBuffer
  {
    public sbyte[] m_data;

    public DirectByteBuffer(int _capacity)
      : base(_capacity)
    {
      this.m_data = new sbyte[_capacity];
    }

    public new void Dispose()
    {
      this.m_data = (sbyte[]) null;
      base.Dispose();
    }

    public override bool isReadOnly()
    {
      return false;
    }

    public override FloatBuffer asFloatBuffer()
    {
      return this.order() == ByteOrder.nativeOrder() ? (FloatBuffer) new NativeDirectFloatBuffer(this) : (FloatBuffer) null;
    }

    public override ByteBuffer put(ref sbyte[] b, int length)
    {
      return (ByteBuffer) this;
    }

    public override ByteBuffer putInt(int value)
    {
      return (ByteBuffer) this;
    }

    public override ByteBuffer get(ref sbyte[] b, int length)
    {
      return (ByteBuffer) this;
    }

    public override int getInt()
    {
      int num = this.order().getInt(this.m_data, this.position());
      this.position(this.position() + 4);
      return num;
    }
  }
}
