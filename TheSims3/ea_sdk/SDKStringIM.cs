// Decompiled with JetBrains decompiler
// Type: ea_sdk.SDKStringIM
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace ea_sdk
{
  public class SDKStringIM
  {
    public const int CHAR_ENCODING_UTF16BE = 0;
    public const int CHAR_ENCODING_ASCII = 1;
    private SDKStringData m_data;

    public SDKStringIM()
    {
      this.m_data = (SDKStringData) null;
    }

    public SDKString getEAString()
    {
      return this.m_data != null ? this.m_data.getSDKString() : (SDKString) null;
    }

    public SDKStringIM append(int number)
    {
      this.m_data.append(number);
      return this;
    }

    public SDKStringIM append(SDKStringIM str)
    {
      this.m_data.append(str.m_data);
      return this;
    }

    public SDKStringIM append(string str)
    {
      this.m_data.append(str);
      return this;
    }

    private int capacity()
    {
      return this.m_data.capacity();
    }

    public short charAt(int index)
    {
      return this.m_data.charAt(index);
    }

    public int compareTo(SDKStringIM str)
    {
      return this.m_data.compareTo(str.m_data);
    }

    private SDKStringIM concat(string str)
    {
      return this.concat(str);
    }

    public int getEncoding()
    {
      return this.m_data.getEncoding();
    }

    public int indexOf(SDKStringData str, int fromIndex)
    {
      return this.m_data.indexOf(str, fromIndex);
    }

    public bool isMutable()
    {
      return this.m_data.isMutable();
    }

    public int length()
    {
      return this.m_data.length();
    }

    private SDKStringIM replaceFirst(string str)
    {
      return this.replaceFirst(str);
    }

    public void setCharAt(int index, short ch)
    {
      this.m_data.setCharAt(index, ch);
    }

    public void setLength(int newLength)
    {
      this.m_data.setLength(newLength);
    }

    private string toString()
    {
      return this.m_data.toString();
    }

    public SDKStringIM(SDKStringIM other)
    {
      this.m_data = other.m_data;
    }

    public SDKStringIM(SDKStringData data)
    {
      this.m_data = data;
    }

    public SDKStringIM(SDKString _string)
    {
      this.m_data = (SDKStringData) null;
      this.m_data = new SDKStringData(_string);
    }

    public SDKStringIM(string value, int offset, int strLength)
    {
      this.m_data = (SDKStringData) null;
      this.m_data = new SDKStringData(value, offset, strLength);
    }

    public SDKStringIM(int strCapacity, int encoding)
    {
      this.m_data = (SDKStringData) null;
      this.m_data = new SDKStringData(strCapacity, encoding);
    }

    public SDKStringIM(string str)
    {
      this.m_data = (SDKStringData) null;
      this.m_data = new SDKStringData(str);
    }

    public void Dispose()
    {
      this.m_data = (SDKStringData) null;
    }

    public SDKStringIM CopyFrom(SDKStringIM other)
    {
      this.m_data = other.m_data;
      return this;
    }

    public void setEAString(SDKString eaString)
    {
      this.m_data = new SDKStringData(eaString);
    }

    public SDKStringIM concat(int i)
    {
      return new SDKStringIM(this.m_data.concat(i));
    }

    public SDKStringIM concat(SDKStringData other)
    {
      return new SDKStringIM(this.m_data.concat(other));
    }

    public SDKStringIM replace(SDKStringIM[] repl)
    {
      return new SDKStringIM(this.m_data.replace(repl));
    }

    public SDKStringIM replaceFirst(int i)
    {
      return new SDKStringIM(this.m_data.replaceFirst(i));
    }

    public SDKStringIM replaceFirst(SDKStringIM str)
    {
      return new SDKStringIM(this.m_data.replaceFirst(str.m_data));
    }

    public SDKStringIM substring(int startIndex, int endIndex)
    {
      return new SDKStringIM(this.m_data.substring(startIndex, endIndex));
    }

    public SDKStringIM toSDKString()
    {
      return new SDKStringIM(this.m_data.toSDKString());
    }

    public SDKStringIM trim()
    {
      this.m_data.trim();
      return this;
    }

    internal void setCharAt(int p, char p_2)
    {
      this.setCharAt(p, (short) p_2);
    }
  }
}
