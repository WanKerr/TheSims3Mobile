// Decompiled with JetBrains decompiler
// Type: midp.ByteArrayOutputStream
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System.IO;

namespace midp
{
  public class ByteArrayOutputStream : OutputStream
  {
    private MemoryStream stream;

    public ByteArrayOutputStream()
    {
      this.stream = new MemoryStream();
    }

    public override void write(int b)
    {
      this.stream.WriteByte((byte) b);
    }

    public void reset()
    {
      this.stream.Position = 0L;
    }

    public sbyte[] toByteArray()
    {
      byte[] array = this.stream.ToArray();
      sbyte[] numArray = new sbyte[array.Length];
      for (int index = 0; index < array.Length; ++index)
        numArray[index] = (sbyte) array[index];
      return numArray;
    }

    public byte[] toUnsignedByteArray()
    {
      return this.stream.ToArray();
    }

    public void close()
    {
      this.stream.Dispose();
    }
  }
}
