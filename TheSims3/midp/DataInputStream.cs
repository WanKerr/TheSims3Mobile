// Decompiled with JetBrains decompiler
// Type: midp.DataInputStream
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace midp
{
  public class DataInputStream : InputStream, DataInput
  {
    protected InputStream input;

    public DataInputStream(InputStream input)
    {
      this.input = input;
    }

    public static string readUTF(DataInput input)
    {
      return input.readUTF();
    }

    public override int available()
    {
      return this.input.available();
    }

    public override int read()
    {
      return this.input.read();
    }

    public override int read(sbyte[] b)
    {
      return this.input.read(b, 0, b.Length);
    }

    public override int read(sbyte[] b, int off, int len)
    {
      return this.input.read(b, off, len);
    }

    public bool readBoolean()
    {
      return this.readByte() != (sbyte) 0;
    }

    public sbyte readByte()
    {
      return (sbyte) this.read();
    }

    public int readUnsignedByte()
    {
      return this.read();
    }

    public char readChar()
    {
      return (char) this.readUnsignedShort();
    }

    public short readShort()
    {
      return (short) this.readUnsignedShort();
    }

    public float readFloat()
    {
      return BitConverter.ToSingle(BitConverter.GetBytes(this.readInt()), 0);
    }

    public int readUnsignedShort()
    {
      return (int) (byte) this.read() << 8 | (int) (byte) this.read();
    }

    public int readInt()
    {
      return this.read() << 24 | (int) (byte) this.read() << 16 | (int) (byte) this.read() << 8 | (int) (byte) this.read();
    }

    public long readLong()
    {
      return (long) (this.readInt() | this.readInt());
    }

    public string readUTF()
    {
      int len = this.readUnsignedShort();
      char[] chArray = new char[len];
      sbyte[] b = new sbyte[len];
      int index = 0;
      int length = 0;
      this.readFully(b, 0, len);
      while (index < len)
      {
        int num1 = (int) b[index] & (int) byte.MaxValue;
        switch (num1 >> 4)
        {
          case 0:
          case 1:
          case 2:
          case 3:
          case 4:
          case 5:
          case 6:
          case 7:
            ++index;
            chArray[length++] = (char) num1;
            continue;
          case 12:
          case 13:
            index += 2;
            int num2 = (int) b[index - 1];
            chArray[length++] = (char) ((num1 & 31) << 6 | num2 & 63);
            continue;
          case 14:
            index += 3;
            int num3 = (int) b[index - 2];
            int num4 = (int) b[index - 1];
            chArray[length++] = (char) ((num1 & 31) << 12 | (num3 & 63) << 6 | num4 & 63);
            continue;
          default:
            continue;
        }
      }
      return new string(chArray, 0, length);
    }

    public void readFully(sbyte[] b)
    {
      this.readFully(b, 0, b.Length);
    }

    public void readFully(sbyte[] b, int len)
    {
      this.readFully(b, 0, len);
    }

    public void readFully(sbyte[] b, int off, int len)
    {
      int num;
      for (int index = 0; index < len; index += num)
        num = this.read(b, off + index, len - index);
    }

    public int skipBytes(int n)
    {
      return (int) this.input.skip((long) n);
    }
  }
}
