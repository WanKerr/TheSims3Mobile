// Decompiled with JetBrains decompiler
// Type: ea_sdk.SDKString
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace ea_sdk
{
  public class SDKString
  {
    public const int CHAR_ENCODING_UTF16BE = 0;
    public const int CHAR_ENCODING_ASCII = 1;
    public const int CHAR_ENCODING_ISO8859_1 = 2;
    public const int CHAR_ENCODING_ISO8859_2 = 3;
    public const int CHAR_ENCODING_ISO8859_3 = 4;
    public const int CHAR_ENCODING_ISO8859_4 = 5;
    public const int CHAR_ENCODING_ISO8859_5 = 6;
    public const int CHAR_ENCODING_ISO8859_6 = 7;
    public const int CHAR_ENCODING_ISO8859_7 = 8;
    public const int CHAR_ENCODING_ISO8859_8 = 9;
    public const int CHAR_ENCODING_ISO8859_9 = 10;
    public const int CHAR_ENCODING_ISO8859_10 = 11;
    public const int CHAR_ENCODING_ISO8859_11 = 12;
    public const int CHAR_ENCODING_ISO8859_12 = 13;
    public const int CHAR_ENCODING_ISO8859_13 = 14;
    public const int CHAR_ENCODING_ISO8859_14 = 15;
    public const int CHAR_ENCODING_ISO8859_15 = 16;
    public const int CHAR_ENCODING_ISO8859_16 = 17;
    public const int CHAR_ENCODING_KOI8R = 18;
    public const int NUM_ENCODINGS = 19;
    private sbyte[] m_buffer;
    private string m_data;
    private int m_offset;
    private ushort m_length;
    private ushort m_capacity;
    private sbyte m_encoding;
    private bool m_mutable;

    public SDKString()
    {
      this.m_buffer = new sbyte[0];
      this.m_data = (string) null;
      this.m_offset = 0;
      this.m_length = (ushort) 0;
      this.m_capacity = (ushort) 0;
      this.m_encoding = (sbyte) 0;
      this.m_mutable = false;
    }

    public SDKString(string s)
    {
      this.m_buffer = new sbyte[0];
      this.m_data = (string) null;
      this.m_offset = 0;
      this.m_length = (ushort) 0;
      this.m_capacity = (ushort) 0;
      this.m_encoding = (sbyte) 1;
      this.m_mutable = false;
      this.m_length = (ushort) s.Length;
      this.m_buffer = new sbyte[(int) this.m_length];
      this.m_data = new string(s.ToCharArray());
    }

    public SDKString(int number)
    {
      this.m_buffer = new sbyte[0];
      this.m_data = (string) null;
      this.m_offset = 0;
      this.m_length = (ushort) 0;
      this.m_capacity = (ushort) 0;
      this.m_encoding = (sbyte) 1;
      this.m_mutable = false;
      int num1 = number;
      if (number < 0)
      {
        ++this.m_length;
        num1 = -number;
      }
      int num2 = num1;
      int num3 = 1;
      while (num2 >= 1000)
      {
        this.m_length += (ushort) 3;
        num2 /= 1000;
        num3 *= 1000;
      }
      while (num2 >= 10)
      {
        ++this.m_length;
        num2 /= 10;
        num3 *= 10;
      }
      ++this.m_length;
      this.m_buffer = new sbyte[(int) this.m_length];
      this.m_data = string.Concat((object) number);
    }

    public SDKString(int strCapacity, int encoding)
    {
      this.m_buffer = new sbyte[0];
      this.m_data = (string) null;
      this.m_offset = 0;
      this.m_length = (ushort) 0;
      this.m_capacity = (ushort) strCapacity;
      this.m_encoding = (sbyte) encoding;
      this.m_mutable = true;
      this.m_buffer = new sbyte[strCapacity * this.bytesPerChar()];
      this.m_data = "";
    }

    public void Dispose()
    {
    }

    public void setCharData(string data, int offset, int dataLength, sbyte encoding)
    {
      this.m_buffer = new sbyte[0];
      this.m_data = data;
      this.m_offset = offset;
      this.m_length = (ushort) dataLength;
      this.m_capacity = (ushort) dataLength;
      this.m_encoding = encoding;
      this.m_mutable = false;
      if (encoding != (sbyte) 0)
        return;
      this.m_offset >>= 1;
      this.m_length >>= 1;
    }

    private void allocNewData(int numChars)
    {
      this.m_buffer = new sbyte[numChars * this.bytesPerChar()];
      this.m_data = "";
      this.m_offset = 0;
      this.m_length = (ushort) numChars;
      this.m_capacity = (ushort) numChars;
    }

    private int bytesPerChar()
    {
      return SDKString.bytesPerChar((int) this.m_encoding);
    }

    private static int bytesPerChar(int encoding)
    {
      return encoding != 0 ? 1 : 2;
    }

    private static int copyStringData(
      SDKString srcString,
      int srcOffset,
      SDKString dstString,
      int dstOffset,
      int numChars)
    {
      int numChars1 = JMath.min(numChars, JMath.min((int) srcString.m_length - srcOffset, (int) dstString.m_capacity - dstOffset));
      return SDKString.copyCharArray(srcString.m_data, srcString.m_offset + srcOffset, (int) srcString.m_encoding, dstString.m_data, dstString.m_offset + dstOffset, (int) dstString.m_encoding, numChars1);
    }

    private static int copyCharArray(
      string srcArray,
      int srcOffset,
      int srcEncoding,
      string dstArray,
      int dstOffset,
      int dstEncoding,
      int numChars)
    {
      if (srcEncoding == dstEncoding || srcEncoding == 1 && dstEncoding != 0)
      {
        dstArray = srcArray ?? "";
        return numChars;
      }
      if (srcEncoding != 1 && dstEncoding != 0)
      {
        JSystem.println("Cannot copy characters from a non ASCII string to a non UTF string.");
        return 0;
      }
      dstArray = srcArray ?? "";
      return numChars;
    }

    public bool isMutable()
    {
      return this.m_mutable;
    }

    public SDKString append(SDKString str)
    {
      if (!this.m_mutable)
        return this;
      JMath.min((int) this.m_capacity - (int) this.m_length, (int) str.m_length);
      this.m_length += (ushort) str.Length();
      this.m_data += str.m_data;
      return this;
    }

    public SDKString append(string str)
    {
      if (!this.m_mutable)
        return this;
      int a = 0;
      while (str[a] != char.MinValue)
        ++a;
      int num = JMath.min(a, (int) this.m_capacity - (int) this.m_length);
      for (int index = 0; index != num; ++index)
        this.setCharAt((int) this.m_length++, (ushort) str[index]);
      return this;
    }

    public SDKString append(int number)
    {
      this.append(new SDKString(number));
      return this;
    }

    public void setCharAt(int index, ushort ch)
    {
      if (!this.m_mutable)
        return;
      SDKString sdkString;
      for (; this.m_data.Length <= index; sdkString.m_data += " ")
        sdkString = this;
      char[] charArray = this.m_data.ToCharArray();
      charArray[index] = (char) ch;
      this.m_data = new string(charArray);
    }

    public ushort charAt(int index)
    {
      ushort code = this.charCodeAt(index);
      return code > (ushort) sbyte.MaxValue && this.getEncoding() != 0 ? SDKTextUtils.iso2utf(code) : code;
    }

    public ushort charCodeAt(int index)
    {
      return (ushort) ((uint) this.m_data[this.m_offset + index] & (uint) byte.MaxValue);
    }

    public SDKString replace(SDKString[] repl)
    {
      SDKString dstString = new SDKString();
      dstString.m_encoding = (sbyte) this.getEncoding();
      dstString.m_offset = 0;
      int num1 = 0;
      for (int index1 = 0; index1 != (int) this.m_length; ++index1)
      {
        if (this.charCodeAt(index1) == (ushort) 92)
        {
          ++index1;
          if (index1 < (int) this.m_length)
          {
            short num2 = (short) this.charCodeAt(index1);
            if (num2 == (short) 92)
              --num1;
            else if (num2 >= (short) 48 && num2 <= (short) 90)
            {
              int index2 = (int) num2 - 48;
              if (repl[index2].getEncoding() != dstString.getEncoding())
                dstString.m_encoding = (sbyte) 0;
              num1 += repl[index2].Length() - 2;
            }
          }
        }
      }
      dstString.allocNewData((int) this.m_length + num1);
      int srcOffset = 0;
      int dstOffset = 0;
      for (int index1 = 0; index1 != (int) this.m_length; ++index1)
      {
        if (this.charCodeAt(index1) == (ushort) 92)
        {
          dstOffset += SDKString.copyStringData(this, srcOffset, dstString, dstOffset, index1 - srcOffset);
          srcOffset = index1++;
          if (index1 < (int) this.m_length)
          {
            short num2 = (short) this.charCodeAt(index1);
            if (num2 == (short) 92)
              srcOffset = index1;
            else if (num2 >= (short) 48 && num2 <= (short) 90)
            {
              int index2 = (int) num2 - 48;
              SDKString srcString = repl[index2];
              dstOffset += SDKString.copyStringData(srcString, 0, dstString, dstOffset, (int) srcString.m_length);
              srcOffset = index1 + 1;
            }
          }
        }
      }
      SDKString.copyStringData(this, srcOffset, dstString, dstOffset, (int) this.m_length - srcOffset);
      return dstString;
    }

    public SDKString replaceFirst(SDKString str)
    {
      return this.replace(new SDKString[1]{ str });
    }

    public SDKString replaceFirst(string str)
    {
      SDKString[] repl = new SDKString[1]
      {
        new SDKString(str)
      };
      SDKString sdkString = this.replace(repl);
      repl[0].Dispose();
      return sdkString;
    }

    public SDKString replaceFirst(int integer)
    {
      SDKString[] repl = new SDKString[1]
      {
        new SDKString(integer)
      };
      SDKString sdkString = this.replace(repl);
      repl[0].Dispose();
      return sdkString;
    }

    public SDKString concat(SDKString str)
    {
      sbyte encoding1 = (sbyte) this.getEncoding();
      sbyte encoding2 = (sbyte) str.getEncoding();
      SDKString dstString = new SDKString();
      dstString.m_encoding = (int) encoding1 == (int) encoding2 || encoding2 == (sbyte) 1 ? encoding1 : (sbyte) 0;
      dstString.allocNewData((int) this.m_length + (int) str.m_length);
      int dstOffset = SDKString.copyStringData(this, 0, dstString, 0, (int) this.m_length);
      SDKString.copyStringData(str, 0, dstString, dstOffset, (int) str.m_length);
      return dstString;
    }

    public SDKString concat(string str)
    {
      SDKString str1 = new SDKString(str);
      SDKString sdkString = this.concat(str1);
      str1.Dispose();
      return sdkString;
    }

    public SDKString concat(int integer)
    {
      SDKString str = new SDKString(integer);
      SDKString sdkString = this.concat(str);
      str.Dispose();
      return sdkString;
    }

    public int length()
    {
      return (int) this.m_length;
    }

    public int Length()
    {
      return this.length();
    }

    public int capacity()
    {
      return (int) this.m_capacity;
    }

    public int getEncoding()
    {
      return (int) this.m_encoding;
    }

    public SDKString substring(int startIndex, int endIndex)
    {
      SDKString sdkString = new SDKString();
      sdkString.m_encoding = this.m_encoding;
      sdkString.allocNewData(endIndex - startIndex);
      int num1 = this.bytesPerChar();
      string data = sdkString.m_data;
      int num2 = (this.m_offset + startIndex) * num1;
      int num3 = (this.m_offset + endIndex) * num1;
      int num4 = 0;
      char[] charArray = data.ToCharArray();
      for (int index = num2; index != num3; ++index)
        charArray[num4++] = this.m_data[index];
      string str = new string(charArray);
      return sdkString;
    }

    public void setLength(int newLength)
    {
      if (!this.m_mutable)
        return;
      this.m_length = (ushort) newLength;
      if (newLength != 0)
        return;
      this.m_data = "";
    }

    public string toString()
    {
      return this.m_data;
    }

    public SDKString toSDKString()
    {
      return this.substring(0, (int) this.m_length);
    }

    public SDKString trim()
    {
      for (; this.m_length > (ushort) 0 && this.charCodeAt(0) == (ushort) 32; --this.m_length)
        ++this.m_offset;
      while (this.m_length > (ushort) 0 && this.charCodeAt((int) this.m_length - 1) == (ushort) 32)
        --this.m_length;
      return this;
    }

    public int indexOf(SDKString str, int fromIndex)
    {
      int num = str.Length();
      for (int index1 = fromIndex; index1 != (int) this.m_length - (num - 1); ++index1)
      {
        for (int index2 = 0; index2 != num && (int) this.charCodeAt(index1 + index2) == (int) str.charCodeAt(index2); ++index2)
        {
          if (index2 != num - 1)
            return index1;
        }
      }
      return -1;
    }

    public int compareTo(SDKString str)
    {
      int num = JMath.min((int) this.m_length, (int) str.m_length);
      for (int index = 0; index != num; ++index)
      {
        if ((int) this.charCodeAt(index) != (int) str.charCodeAt(index))
          return (int) this.charCodeAt(index) - (int) str.charCodeAt(index);
      }
      return (int) this.m_length - (int) str.m_length;
    }
  }
}
