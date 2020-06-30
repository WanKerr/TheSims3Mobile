// Decompiled with JetBrains decompiler
// Type: nio.IndirectByteBuffer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace nio
{
  public class IndirectByteBuffer : ByteBuffer
  {
    private sbyte[] m_data;
    private readonly int m_offset;

    private sbyte[] getDataPtr()
    {
      sbyte[] numArray = new sbyte[this.m_data.Length - (this.position() + this.m_offset)];
      midp.JSystem.arraycopy((Array) this.m_data, this.position() + this.m_offset, (Array) numArray, 0, this.m_data.Length - (this.position() + this.m_offset));
      return numArray;
    }

    public IndirectByteBuffer(sbyte[] data, int offset, int length)
      : base(length)
    {
      this.m_data = data;
      this.m_offset = offset;
    }

    public new void Dispose()
    {
      base.Dispose();
    }

    public override bool isReadOnly()
    {
      return false;
    }

    public override FloatBuffer asFloatBuffer()
    {
      return (FloatBuffer) null;
    }

    public override ByteBuffer put(ref sbyte[] b, int length)
    {
      sbyte[] dataPtr = this.getDataPtr();
      midp.JSystem.arraycopy((Array) b, 0, (Array) dataPtr, 0, length);
      this.position(this.position() + length);
      return (ByteBuffer) this;
    }

    public override ByteBuffer putInt(int value)
    {
      this.order().putInt(this.getDataPtr(), value);
      this.position(this.position() + 4);
      return (ByteBuffer) this;
    }

    public override ByteBuffer get(ref sbyte[] b, int length)
    {
      return (ByteBuffer) this;
    }

    public override int getInt()
    {
      int num = this.order().getInt(this.getDataPtr(), 0);
      this.position(this.position() + 4);
      return num;
    }
  }
}
