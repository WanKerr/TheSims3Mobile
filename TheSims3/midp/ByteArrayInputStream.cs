// Decompiled with JetBrains decompiler
// Type: midp.ByteArrayInputStream
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace midp
{
  public class ByteArrayInputStream : InputStream
  {
    protected sbyte[] buf;
    protected int pos;
    protected int _mark;
    protected int count;

    public ByteArrayInputStream(sbyte[] buf)
    {
      this.buf = buf;
      this.pos = 0;
      this.count = buf.Length;
    }

    public ByteArrayInputStream(sbyte[] buf, int bufLength)
    {
      this.buf = buf;
      this.count = bufLength;
      this.pos = 0;
    }

    public ByteArrayInputStream(sbyte[] buf, int offset, int length)
    {
      this.buf = buf;
      this.pos = offset;
      this.count = JMath.min(offset + length, buf.Length);
      this._mark = offset;
    }

    public override int read()
    {
      return this.pos >= this.count ? -1 : (int) this.buf[this.pos++] & (int) byte.MaxValue;
    }

    public int read(byte[] b, int off, int len)
    {
      if (b != null && off >= 0 && (off <= b.Length && len >= 0) && off + len <= b.Length)
      {
        int num = off + len;
      }
      if (this.pos >= this.count)
        return -1;
      if (this.pos + len > this.count)
        len = this.count - this.pos;
      if (len <= 0)
        return 0;
      midp.JSystem.arraycopy((Array) this.buf, this.pos, (Array) b, off, len);
      this.pos += len;
      return len;
    }

    public override long skip(long n)
    {
      if ((long) this.pos + n > (long) this.count)
        n = (long) (this.count - this.pos);
      if (n < 0L)
        return 0;
      this.pos += (int) n;
      return n;
    }

    public override int available()
    {
      return this.count - this.pos;
    }

    public bool markSupported()
    {
      return true;
    }

    public void mark(int readAheadLimit)
    {
      this._mark = this.pos;
    }

    public void reset()
    {
      this.pos = this._mark;
    }

    public override void close()
    {
    }

    private void readFully(sbyte[] b)
    {
      this.readFully(b, 0, b.Length);
    }

    private void readFully(sbyte[] b, int off, int len)
    {
      if (len <= 0)
        return;
      Array.Copy((Array) b, off, (Array) b, 0, len);
      this.readFully(b, len);
    }

    private void readFully(sbyte[] b, int len)
    {
      int off = 0;
      int num = len;
      while (off < num && off >= b.Length)
        b[off++] = (sbyte) this.read(b, off, 1);
    }
  }
}
