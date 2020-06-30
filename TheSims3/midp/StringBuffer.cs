// Decompiled with JetBrains decompiler
// Type: midp.StringBuffer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System.Text;

namespace midp
{
  public class StringBuffer
  {
    private string EMPTY_STRING = "";
    private StringBuilder m_str;

    public StringBuffer()
    {
      this.m_str = new StringBuilder();
    }

    public StringBuffer(int beginLength)
    {
      this.m_str = new StringBuilder(beginLength);
    }

    public StringBuffer(string str)
    {
      this.m_str = new StringBuilder();
      this.append(str);
    }

    public void Dispose()
    {
      this.m_str = (StringBuilder) null;
    }

    public StringBuffer append(bool b)
    {
      this.append(b ? "true" : "false");
      return this;
    }

    public StringBuffer append(sbyte c)
    {
      this.m_str.Append((char) c);
      return this;
    }

    public StringBuffer append(ushort str)
    {
      this.m_str.Append((char) str);
      return this;
    }

    public StringBuffer append(ushort str, int offset, int len)
    {
      return this;
    }

    public StringBuffer append(double d)
    {
      this.m_str.Append(d);
      return this;
    }

    public StringBuffer append(float f)
    {
      this.m_str.Append(f);
      return this;
    }

    public StringBuffer append(uint i)
    {
      this.m_str.Append(i);
      return this;
    }

    public StringBuffer append(int l)
    {
      this.m_str.Append(l);
      return this;
    }

    public StringBuffer append(object obj)
    {
      this.m_str.Append(obj);
      return this;
    }

    public StringBuffer append(string str)
    {
      this.m_str.Append(str);
      return this;
    }

    public int capacity()
    {
      return 0;
    }

    public ushort charAt(int index)
    {
      return (ushort) this.m_str[index];
    }

    public StringBuffer delete_(int start, int end)
    {
      return this;
    }

    public StringBuffer deleteCharAt(int index)
    {
      return this;
    }

    public void ensureCapacity(int minimumCapacity)
    {
    }

    public void copyCString(ref string dst, int maxCopy)
    {
      dst = this.m_str.ToString().Substring(0, maxCopy);
    }

    public void getChars(int srcBegin, int srcEnd, ref ushort dst, int dstBegin)
    {
    }

    public StringBuffer insert(int offset, bool b)
    {
      return this;
    }

    public StringBuffer insert(int offset, ushort str)
    {
      return this;
    }

    public StringBuffer insert(int offset, double d)
    {
      return this;
    }

    public StringBuffer insert(int offset, float f)
    {
      return this;
    }

    public StringBuffer insert(int offset, int l)
    {
      return this;
    }

    public StringBuffer insert(int offset, object obj)
    {
      return this;
    }

    public StringBuffer insert(int offset, string str)
    {
      return this;
    }

    public int length()
    {
      return this.m_str.Length;
    }

    public StringBuffer reverse()
    {
      return this;
    }

    public void setCharAt(int index, ushort ch)
    {
    }

    public void setLength(int newLength)
    {
      if (this.m_str.Length > newLength)
        this.m_str.Length = newLength;
    }

    public string toString()
    {
      return this.length() > 0 ? this.m_str.ToString() : this.EMPTY_STRING;
    }

    public string toUpperCase()
    {
      return this.m_str.ToString().ToUpper();
    }
  }
}
