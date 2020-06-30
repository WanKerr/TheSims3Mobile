// Decompiled with JetBrains decompiler
// Type: midp.OutputStream
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace midp
{
  public abstract class OutputStream
  {
    public abstract void write(int b);

    public virtual void write(sbyte[] b, int off, int len)
    {
      for (int index = off; index < off + len; ++index)
        this.write((int) b[index]);
    }

    public virtual void write(byte[] b, int off, int len)
    {
      for (int index = off; index < off + len; ++index)
        this.write((int) b[index]);
    }

    public void write(sbyte[] b)
    {
      this.write(b, 0, b.Length);
    }

    internal static OutputStream getResourceAsStream(string fileName)
    {
      throw new NotImplementedException();
    }
  }
}
