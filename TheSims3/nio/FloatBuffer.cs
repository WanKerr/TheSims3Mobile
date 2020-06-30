// Decompiled with JetBrains decompiler
// Type: nio.FloatBuffer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace nio
{
  public abstract class FloatBuffer : Buffer
  {
    protected FloatBuffer(int _capacity)
      : base(_capacity)
    {
    }

    public new void Dispose()
    {
      base.Dispose();
    }

    public abstract ByteOrder order();

    public abstract FloatBuffer put(float f);

    public abstract FloatBuffer put(int index, float f);

    public FloatBuffer put(float[] src)
    {
      return this.put(src, 0, src.Length);
    }

    public FloatBuffer put(float[] src, int offset, int length)
    {
      return this.put(ref src, offset, length);
    }

    public abstract FloatBuffer put(ref float[] src, int offset, int length);

    public abstract float[] lockBuffer();

    public abstract void unlock();
  }
}
