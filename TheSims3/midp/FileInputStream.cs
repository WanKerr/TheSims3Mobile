// Decompiled with JetBrains decompiler
// Type: midp.FileInputStream
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace midp
{
  public class FileInputStream : InputStream
  {
    private FileStream fileStream;
    private MemoryInputStream in_stream;

    public FileInputStream(string name)
    {
      try
      {
        IsolatedStorageFileStream storageFileStream = IsolatedStorageFile.GetUserStoreForAssembly().OpenFile(name, FileMode.Open);
        try
        {
          this.in_stream = new MemoryInputStream((Stream) storageFileStream);
        }
        finally
        {
          storageFileStream.Close();
        }
      }
      catch (Exception ex)
      {
      }
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public bool loadSuccessful()
    {
      return this.in_stream != null;
    }

    public override int available()
    {
      throw new NotImplementedException();
    }

    public override void close()
    {
      base.close();
      this.in_stream.close();
    }

    public void mark(int readLimit)
    {
      throw new NotImplementedException();
    }

    public bool markSupported()
    {
      throw new NotImplementedException();
    }

    public override int read()
    {
      return this.in_stream.read();
    }

    public int read(ref string b, int len)
    {
      throw new NotImplementedException();
    }

    public void reset()
    {
      throw new NotImplementedException();
    }

    public int getPosition()
    {
      throw new NotImplementedException();
    }

    public bool seek(int offset, int from)
    {
      throw new NotImplementedException();
    }

    public int size()
    {
      return this.in_stream.size();
    }
  }
}
