// Decompiled with JetBrains decompiler
// Type: nio.NativeDirectFloatBuffer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace nio
{
  public class NativeDirectFloatBuffer : FloatBuffer
  {
    private DirectByteBuffer m_buffer;
    private float[] m_data;
    private int m_lockCount;

    public NativeDirectFloatBuffer(DirectByteBuffer buffer)
      : base(buffer.remaining() >> 2)
    {
      this.m_buffer = buffer;
      this.m_data = new float[(buffer.m_data.Length - (buffer.position() >> 2)) / 4];
      int index1 = buffer.position() >> 2;
      for (int index2 = 0; index2 < this.m_data.Length; ++index2)
      {
        byte[] numArray = new byte[4];
        for (int index3 = 0; index3 < numArray.Length; ++index3)
        {
          numArray[index3] = (byte) buffer.m_data[index1];
          ++index1;
        }
        this.m_data[index2] = BitConverter.ToSingle(numArray, 0);
      }
      this.m_lockCount = 0;
    }

    public new void Dispose()
    {
      this.m_buffer = (DirectByteBuffer) null;
      base.Dispose();
    }

    public override bool isReadOnly()
    {
      return false;
    }

    public override ByteOrder order()
    {
      return ByteOrder.nativeOrder();
    }

    public override FloatBuffer put(float f)
    {
      this.requireNotLocked();
      int index = this.position();
      this.position(index + 1);
      this.m_data[index] = f;
      return (FloatBuffer) this;
    }

    public override FloatBuffer put(int index, float f)
    {
      this.requireNotLocked();
      this.requireValidIndex(index);
      this.m_data[index] = f;
      return (FloatBuffer) this;
    }

    public override FloatBuffer put(ref float[] src, int offset, int length)
    {
      this.requireNotLocked();
      int num = this.position();
      this.position(num + length);
      for (int index = 0; index < length; ++index)
        this.m_data[num + index] = src[offset + index];
      return (FloatBuffer) this;
    }

    public override float[] lockBuffer()
    {
      ++this.m_lockCount;
      return this.m_data;
    }

    public override void unlock()
    {
      --this.m_lockCount;
    }

    private void requireNotLocked()
    {
    }
  }
}
