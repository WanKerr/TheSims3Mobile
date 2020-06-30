// Decompiled with JetBrains decompiler
// Type: midp.RecordStore
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace midp
{
  public class RecordStore
  {
    public const int AUTHMODE_PRIVATE = 0;
    public const int AUTHMODE_ANY = 1;
    private string m_id;
    protected sbyte[][] m_data;
    private bool m_writable;
    private long m_lastModified;
    private int m_version;

    protected RecordStore(string storeId)
    {
      this.m_id = storeId;
      this.m_data = new sbyte[0][];
      this.m_writable = true;
      this.m_lastModified = 0L;
      this.m_version = 0;
    }

    protected RecordStore(string storeId, sbyte[][] dataArray, bool writable)
    {
      this.m_id = storeId;
      this.m_data = dataArray;
      this.m_writable = writable;
      this.m_lastModified = 0L;
      this.m_version = 0;
    }

    public void Dispose()
    {
    }

    public int addRecord(sbyte[] data, int offset, int numBytes)
    {
      if (!this.m_writable)
        return -1;
      this.m_lastModified = midp.JSystem.currentTimeMillis();
      ++this.m_version;
      sbyte[] numArray = new sbyte[numBytes];
      midp.JSystem.arraycopy((Array) data, 0, (Array) numArray, 0, numBytes, 1);
      int length = this.m_data.Length;
      for (int index = 0; index != length; ++index)
      {
        if (this.m_data == null)
        {
          this.m_data[index] = numArray;
          return index + 1;
        }
      }
      int index1 = length;
      sbyte[][] data1 = this.m_data;
      this.m_data = new sbyte[index1 + 1][];
      for (int index2 = 0; index2 != index1; ++index2)
        this.m_data[index2] = data1[index2];
      this.m_data[index1] = numArray;
      return index1 + 1;
    }

    public void closeRecordStore()
    {
      IsolatedStorageFile storeForApplication = IsolatedStorageFile.GetUserStoreForAssembly();
      IsolatedStorageFileStream storageFileStream1 = (IsolatedStorageFileStream) null;
      IsolatedStorageFileStream storageFileStream2 = storeForApplication.OpenFile(this.m_id, FileMode.OpenOrCreate);
      ByteArrayOutputStream arrayOutputStream = new ByteArrayOutputStream();
      DataOutputStream dataOutputStream = new DataOutputStream((OutputStream) arrayOutputStream);
      int length1 = this.m_data.Length;
      dataOutputStream.writeInt(length1);
      for (int index = 0; index != length1; ++index)
      {
        sbyte[] arr = this.m_data[index];
        int length2 = arr.Length;
        dataOutputStream.writeInt(length2);
        if (length2 > 0)
          dataOutputStream.write(arr, length2);
      }
      byte[] unsignedByteArray = arrayOutputStream.toUnsignedByteArray();
      storageFileStream2.Write(arrayOutputStream.toUnsignedByteArray(), 0, unsignedByteArray.Length);
      storageFileStream2.Close();
      storageFileStream1 = (IsolatedStorageFileStream) null;
    }

    public void deleteRecord(int recordId)
    {
      if (!this.m_writable)
        return;
      this.m_lastModified = midp.JSystem.currentTimeMillis();
      ++this.m_version;
      sbyte[] numArray = (sbyte[]) null;
      this.m_data[recordId - 1] = numArray;
    }

    public long getLastModified()
    {
      return this.m_lastModified;
    }

    public string getName()
    {
      return this.m_id;
    }

    public int getNextRecordID()
    {
      return this.m_data.Length;
    }

    public int getNumRecords()
    {
      return this.m_data.Length;
    }

    public sbyte[] getRecord(int recordId)
    {
      sbyte[] numArray1 = this.m_data[recordId - 1];
      int length = numArray1.Length;
      sbyte[] numArray2 = new sbyte[length];
      midp.JSystem.arraycopy((Array) numArray1, 0, (Array) numArray2, 0, length, 1);
      return numArray2;
    }

    public int getRecord(int recordId, sbyte[] buffer, int offset)
    {
      sbyte[] numArray1 = this.m_data[recordId - 1];
      int length = JMath.min(buffer.Length - offset, numArray1.Length);
      sbyte[] numArray2 = new sbyte[buffer.Length - offset];
      Array.Copy((Array) buffer, offset, (Array) numArray2, 0, numArray2.Length);
      midp.JSystem.arraycopy((Array) numArray1, 0, (Array) numArray2, 0, length, 1);
      return length;
    }

    public int getRecordSize(int recordId)
    {
      return this.m_data[recordId].Length;
    }

    public int getSize()
    {
      int num = 0;
      for (int index = 0; index != this.m_data.Length; ++index)
        num += this.m_data[index].Length;
      return num;
    }

    public int getSizeAvailable()
    {
      return int.MaxValue;
    }

    public int getVersion()
    {
      return this.m_version;
    }

    public static RecordStore openRecordStore(
      string recordStoreName,
      bool createIfNecessary)
    {
      return RecordStore.openRecordStore(recordStoreName, createIfNecessary, 1, true);
    }

    public static RecordStore openRecordStore(
      string recordStoreName,
      bool createIfNecessary,
      int authmode,
      bool writable)
    {
      RecordStore recordStore = (RecordStore) null;
      InputStream input = (InputStream) null;
      try
      {
        IsolatedStorageFileStream storageFileStream = IsolatedStorageFile.GetUserStoreForAssembly().OpenFile(recordStoreName, FileMode.Open);
        try
        {
          input = (InputStream) new MemoryInputStream((Stream) storageFileStream);
        }
        finally
        {
          storageFileStream.Close();
        }
      }
      catch (Exception ex)
      {
        midp.JSystem.println("Previous Record Store not found");
      }
      if (input != null && input.available() >= 4)
      {
        DataInputStream dataInputStream = new DataInputStream(input);
        int length = dataInputStream.readInt();
        sbyte[][] dataArray = new sbyte[length][];
        for (int index = 0; index != length; ++index)
        {
          int len = dataInputStream.readInt();
          if (len > 0)
          {
            sbyte[] b = new sbyte[len];
            dataInputStream.readFully(b, len);
            dataArray[index] = b;
          }
        }
        recordStore = new RecordStore(recordStoreName, dataArray, writable);
        dataInputStream.close();
      }
      if (recordStore == null && createIfNecessary)
        recordStore = new RecordStore(recordStoreName);
      return recordStore;
    }

    public void setMode(int authmode, bool writable)
    {
      this.m_writable = writable;
    }

    public void setRecord(int recordId, sbyte[] newData, int offset, int numBytes)
    {
      sbyte[] numArray = new sbyte[numBytes];
      midp.JSystem.arraycopy((Array) newData, 0, (Array) numArray, 0, numBytes);
      this.m_data[recordId - 1] = numArray;
      this.m_lastModified = midp.JSystem.currentTimeMillis();
      ++this.m_version;
    }
  }
}
