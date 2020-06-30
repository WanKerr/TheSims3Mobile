// Decompiled with JetBrains decompiler
// Type: midp.InputStream
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace midp
{
  public abstract class InputStream
  {
    public string name;

    public virtual int available()
    {
      return 0;
    }

    public abstract int read();

    public virtual int read(sbyte[] b, int off, int len)
    {
      if (len == 0)
        return 0;
      int num1 = this.read();
      if (num1 == -1)
        return -1;
      b[off] = (sbyte) num1;
      int num2;
      for (num2 = 1; num2 < len; ++num2)
      {
        int num3 = this.read();
        if (num3 != -1)
          b[off + num2] = (sbyte) num3;
        else
          break;
      }
      return num2;
    }

    public virtual int read(sbyte[] b)
    {
      return this.read(b, 0, b.Length);
    }

    public virtual long skip(long n)
    {
      long num = n;
      while (num > 0L && this.read() >= 0)
        --num;
      return n - num;
    }

    public virtual void close()
    {
    }
  }
}
