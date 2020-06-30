// Decompiled with JetBrains decompiler
// Type: midp.MemoryInputStream
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;
using System.IO;

namespace midp
{
  internal class MemoryInputStream : InputStream
  {
    private byte[] buffer;
    private long position;

    public MemoryInputStream(Stream stream)
    {
      this.buffer = new byte[stream.Length - stream.Position];
      stream.Read(this.buffer, 0, this.buffer.Length);
    }

    public override int available()
    {
      return (int) ((long) this.buffer.Length - this.position);
    }

    public override int read()
    {
      return this.position >= (long) this.buffer.Length ? -1 : (int) this.buffer[this.position++];
    }

    public override void close()
    {
      this.buffer = (byte[]) null;
    }

    public int size()
    {
      return this.buffer.Length;
    }
  }
}
