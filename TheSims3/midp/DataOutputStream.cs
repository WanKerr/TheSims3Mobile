// Decompiled with JetBrains decompiler
// Type: midp.DataOutputStream
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace midp
{
  public class DataOutputStream : OutputStream
  {
    private OutputStream os;

    public DataOutputStream(OutputStream ostream)
    {
      this.os = ostream;
    }

    public override void write(int b)
    {
      this.os.write(b);
    }

    public void writeBoolean(bool v)
    {
      this.writeByte(v ? 1 : 0);
    }

    public void writeByte(int v)
    {
      this.os.write(v);
    }

    public void write(sbyte[] arr, int length)
    {
      for (int index = 0; index < length; ++index)
        this.write((int) arr[index]);
    }

    public void writeBytes(string str)
    {
      int length = str.Length;
      for (int index = 0; index < length; ++index)
        this.writeByte((int) str[index]);
    }

    public void writeShort(int v)
    {
      this.os.write(v >> 8 & (int) byte.MaxValue);
      this.os.write(v & (int) byte.MaxValue);
    }

    public void writeChar(int v)
    {
      this.os.write(v >> 8 & (int) byte.MaxValue);
      this.os.write(v & (int) byte.MaxValue);
    }

    public void writeInt(int v)
    {
      this.os.write(v >> 24 & (int) byte.MaxValue);
      this.os.write(v >> 16 & (int) byte.MaxValue);
      this.os.write(v >> 8 & (int) byte.MaxValue);
      this.os.write(v & (int) byte.MaxValue);
    }

    public void writeLong(long v)
    {
      this.os.write((int) (v >> 56) & (int) byte.MaxValue);
      this.os.write((int) (v >> 48) & (int) byte.MaxValue);
      this.os.write((int) (v >> 40) & (int) byte.MaxValue);
      this.os.write((int) (v >> 32) & (int) byte.MaxValue);
      this.os.write((int) (v >> 24) & (int) byte.MaxValue);
      this.os.write((int) (v >> 16) & (int) byte.MaxValue);
      this.os.write((int) (v >> 8) & (int) byte.MaxValue);
      this.os.write((int) v & (int) byte.MaxValue);
    }

    public void writeFloat(float f)
    {
      byte[] bytes = BitConverter.GetBytes(f);
      for (int index = bytes.Length - 1; index >= 0; --index)
        this.os.write((int) bytes[index]);
    }

    public void writeUTF(string str)
    {
      int length = str.Length;
      this.writeShort(length);
      for (int index = 0; index < length; ++index)
        this.writeByte((int) str[index]);
    }

    public bool close()
    {
      return true;
    }
  }
}
