// Decompiled with JetBrains decompiler
// Type: ea_sdk.SDKStringData
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace ea_sdk
{
  public class SDKStringData
  {
    private SDKString m_sdkString;

    public SDKStringData(SDKString sdkString)
    {
      this.m_sdkString = sdkString;
    }

    public SDKStringData(string value, int offset, int strLength)
    {
      this.m_sdkString = (SDKString) null;
      string str = new string(new char[strLength]);
      for (int charindex = 0; charindex != strLength; ++charindex)
        str = StringFunctions.ChangeCharacter(str, charindex, value[offset + charindex]);
      this.m_sdkString = new SDKString(str);
    }

    public SDKStringData(int strCapacity, int encoding)
    {
      this.m_sdkString = (SDKString) null;
      this.m_sdkString = new SDKString(strCapacity, encoding);
    }

    public SDKStringData(string str)
    {
      this.m_sdkString = (SDKString) null;
      this.m_sdkString = new SDKString(str);
    }

    public void Dispose()
    {
      SDKString sdkString = this.m_sdkString;
      this.m_sdkString = (SDKString) null;
      sdkString?.Dispose();
    }

    public void append(int number)
    {
      this.m_sdkString.append(number);
    }

    public void append(SDKStringData str)
    {
      this.m_sdkString.append(str.m_sdkString);
    }

    public void append(string str)
    {
      this.m_sdkString.append(str);
    }

    public int capacity()
    {
      return this.m_sdkString.capacity();
    }

    public short charAt(int index)
    {
      return (short) this.m_sdkString.charAt(index);
    }

    public int compareTo(SDKStringData str)
    {
      return this.m_sdkString.compareTo(str.m_sdkString);
    }

    public SDKStringData concat(int i)
    {
      return new SDKStringData(this.m_sdkString.concat(i));
    }

    public SDKStringData concat(SDKStringData other)
    {
      return new SDKStringData(this.m_sdkString.concat(other.m_sdkString));
    }

    public SDKStringData concat(string str)
    {
      return new SDKStringData(this.m_sdkString.concat(str));
    }

    public int getEncoding()
    {
      return this.m_sdkString.getEncoding();
    }

    public int indexOf(SDKStringData str, int fromIndex)
    {
      return this.m_sdkString.indexOf(str.m_sdkString, fromIndex);
    }

    public bool isMutable()
    {
      return this.m_sdkString.isMutable();
    }

    public int length()
    {
      return this.m_sdkString.Length();
    }

    public SDKStringData replace(SDKStringIM[] repl)
    {
      int length = repl.Length;
      SDKString[] repl1 = new SDKString[length];
      for (int index = 0; index != length; ++index)
        repl1[index] = repl[index].getEAString();
      return new SDKStringData(this.m_sdkString.replace(repl1));
    }

    public SDKStringData replaceFirst(int i)
    {
      return new SDKStringData(this.m_sdkString.replaceFirst(i));
    }

    public SDKStringData replaceFirst(SDKStringData str)
    {
      return new SDKStringData(this.m_sdkString.replaceFirst(str.m_sdkString));
    }

    public SDKStringData replaceFirst(string str)
    {
      return new SDKStringData(this.m_sdkString.replaceFirst(str));
    }

    public void setCharAt(int index, short ch)
    {
      this.m_sdkString.setCharAt(index, (ushort) ch);
    }

    public void setLength(int newLength)
    {
      this.m_sdkString.setLength(newLength);
    }

    public SDKStringData substring(int startIndex, int endIndex)
    {
      return new SDKStringData(this.m_sdkString.substring(startIndex, endIndex));
    }

    public SDKStringData toSDKString()
    {
      return new SDKStringData(this.m_sdkString.toSDKString());
    }

    public string toString()
    {
      return this.m_sdkString.toString();
    }

    public SDKStringData trim()
    {
      this.m_sdkString.trim();
      return this;
    }

    public SDKString getSDKString()
    {
      return this.m_sdkString;
    }
  }
}
