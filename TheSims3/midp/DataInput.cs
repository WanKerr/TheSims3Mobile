// Decompiled with JetBrains decompiler
// Type: midp.DataInput
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace midp
{
  public interface DataInput
  {
    bool readBoolean();

    sbyte readByte();

    int readUnsignedByte();

    char readChar();

    short readShort();

    int readUnsignedShort();

    int readInt();

    long readLong();

    string readUTF();

    void readFully(sbyte[] b);

    void readFully(sbyte[] b, int off, int len);

    int skipBytes(int n);
  }
}
