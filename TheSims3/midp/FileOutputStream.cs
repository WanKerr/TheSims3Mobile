// Decompiled with JetBrains decompiler
// Type: midp.FileOutputStream
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace midp
{
  public class FileOutputStream : OutputStream
  {
    private IsolatedStorageFileStream fileStream;

    public FileOutputStream(string filename)
    {
      IsolatedStorageFile storeForApplication = IsolatedStorageFile.GetUserStoreForAssembly();
      try
      {
        this.fileStream = (IsolatedStorageFileStream) null;
        this.fileStream = storeForApplication.OpenFile(filename, FileMode.OpenOrCreate);
      }
      catch (Exception ex)
      {
      }
    }

    public void Dispose()
    {
      this.fileStream = (IsolatedStorageFileStream) null;
    }

    public void write(byte writeByte)
    {
      this.fileStream.WriteByte(writeByte);
    }

    public override void write(int writeInt)
    {
      this.write((byte) writeInt);
    }

    public void write(IntPtr b, int len)
    {
      throw new NotImplementedException();
    }

    public void clear()
    {
      this.fileStream.SetLength(0L);
    }

    public bool close()
    {
      this.fileStream.Close();
      return this.fileStream == null;
    }

    public bool loadSuccessful()
    {
      return this.fileStream != null;
    }

    public int size()
    {
      return (int) this.fileStream.Length;
    }

    public int getPosition()
    {
      return (int) this.fileStream.Position;
    }

    public bool seek(int offset, int from)
    {
      throw new NotImplementedException();
    }
  }
}
