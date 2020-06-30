// Decompiled with JetBrains decompiler
// Type: TextManager
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using midp;
using sims3;

public class TextManager : StringConstants
{
  private Vector m_stringsFilenames = new Vector();
  private Vector m_stringRenderers = new Vector();
  private string m_wrapString = "";
  public const int USE_SUPPLIED_GRAPHICS = 256;
  public const int DYNAMIC_STRING_COUNT = 10;
  public const int DYNAMIC_STRING_LAST = -2;
  public const int DYNAMIC_STRING_FIRST = -12;
  public const int STRING_BUFFER_SIZE = 100;
  public const int MAX_STRING_BUFFERS = 25;
  private const short WRAP_CHAR = 124;
  private const int MAX_WRAP_OFFSETS = 255;
  public const int MAX_WRAP_CHUNKS = 20;
  private const int MAX_WRAP_CHUNK_OFFSETS = 10;
  private string temp_str;
  private string temp_str2;
  private string[] temp_strArr;
  private StringRenderer temp_sr;
  private short[] temp_shortArr;
  private string[] m_dynamicStrings;
  private string[] m_replaceStrings;
  private StringBuffer m_tempStringBuffer;
  private StringBuffer[] m_tempStringBuffers;
  private int m_tempBufferIndex;
  private short[] m_wrapOffsets;
  private short[][] m_wrapChunkOffsets;
  private string[] m_wrapChunkStrings;
  private int[] m_wrapChunkStringIds;

  public TextManager()
  {
    this.m_stringsFilenames = new Vector();
    this.m_stringRenderers = new Vector();
    this.m_dynamicStrings = new string[10];
    this.m_replaceStrings = new string[3];
    this.m_tempStringBuffer = (StringBuffer) null;
    this.m_tempStringBuffers = (StringBuffer[]) null;
    this.m_tempBufferIndex = 0;
    this.m_wrapOffsets = (short[]) null;
    this.m_wrapString = (string) null;
    this.m_wrapChunkOffsets = (short[][]) null;
    this.m_wrapChunkStrings = (string[]) null;
    this.m_wrapChunkStringIds = (int[]) null;
  }

  public virtual void Dispose()
  {
  }

  public void init()
  {
    LocaleManager instance = LocaleManager.getInstance();
    instance.setStringIdBits(11);
    this.temp_strArr = instance.getSupportedLocales();
    this.temp_str2 = "strings_hdr.bin";
    for (int index = 0; index < this.temp_strArr.Length; ++index)
    {
      this.temp_str = this.temp_strArr[index];
      string[] pool = instance.loadStrings(this.temp_str2, this.temp_str);
      instance.setStringPool(0, pool, this.temp_strArr[index]);
    }
    this.addStringsFile("strings_generic.bin");
    this.loadStrings();
    this.initWraps();
    this.initStringBuffers();
    this.initFonts();
  }

  public string getString(int stringid)
  {
    return stringid < -2 ? this.m_dynamicStrings[stringid - -12] : LocaleManager.getInstance().getString(stringid);
  }

  public string getLangString(int stringId, int languageIndex)
  {
    this.temp_strArr = LocaleManager.getInstance().getSupportedLocales();
    this.temp_str = this.temp_strArr[languageIndex];
    this.temp_str2 = LocaleManager.getString(stringId, this.temp_str);
    return this.temp_str2;
  }

  public int getLanguageCount()
  {
    return LocaleManager.getInstance().getSupportedLocales().Length;
  }

  public int getCurrentLanguage()
  {
    LocaleManager instance = LocaleManager.getInstance();
    this.temp_strArr = instance.getSupportedLocales();
    this.temp_str = instance.getLocale();
    for (int index = 0; index < this.temp_strArr.Length; ++index)
    {
      if (this.temp_str.Equals(this.temp_strArr[index]))
        return index;
    }
    return -1;
  }

  public void setCurrentLanguage(int index)
  {
    if (index == this.getCurrentLanguage())
      return;
    this.temp_strArr = LocaleManager.getInstance().getSupportedLocales();
    this.temp_str = this.temp_strArr[index];
    this.setCurrentLocale(this.temp_str);
  }

  public string getCurrentLocale()
  {
    return LocaleManager.getInstance().getLocale();
  }

  public void setCurrentLocale(string locale)
  {
    LocaleManager instance = LocaleManager.getInstance();
    this.temp_strArr = instance.getSupportedLocales();
    if (this.getCurrentLanguage() >= 0)
      this.unloadStrings();
    instance.setLocale(locale);
    this.loadStrings();
    this.clearWrapChunks();
  }

  public int addStringsFile(string filename)
  {
    this.m_stringsFilenames.addElement((object) filename);
    return 1 + this.m_stringsFilenames.size() - 1;
  }

  private void loadStrings()
  {
    LocaleManager instance = LocaleManager.getInstance();
    int num = this.m_stringsFilenames.size();
    for (int index = 0; index < num; ++index)
    {
      this.temp_str = (string) this.m_stringsFilenames.elementAt(index);
      this.temp_strArr = instance.loadStrings(this.temp_str);
      instance.setStringPool(1 + index, this.temp_strArr);
    }
  }

  private void unloadStrings()
  {
    LocaleManager instance = LocaleManager.getInstance();
    this.temp_strArr = new string[0];
    int num = this.m_stringsFilenames.size();
    for (int index = 0; index < num; ++index)
    {
      this.temp_str = (string) this.m_stringsFilenames.elementAt(index);
      instance.setStringPool(1 + index, this.temp_strArr);
    }
  }

  public void drawString(Graphics g, int strId, int font, int x, int y, int anchor)
  {
    this.temp_str = this.getString(strId);
    this.drawString(g, this.temp_str, font, x, y, anchor);
  }

  public void drawString(Graphics g, string str, int font, int x, int y, int anchor)
  {
    this.temp_sr = this.getStringRenderer(font);
    this.temp_sr.drawString(g, str, x, y, anchor);
  }

  public void drawString(Graphics g, StringBuffer strBuffer, int font, int x, int y, int anchor)
  {
    this.temp_str = strBuffer.toString();
    this.drawString(g, this.temp_str, font, x, y, anchor);
  }

  public void drawSubString(
    Graphics g,
    string str,
    int start,
    int end,
    int font,
    int x,
    int y,
    int anchor)
  {
    this.temp_sr = this.getStringRenderer(font);
    this.temp_sr.drawSubstring(g, str, start, end, x, y, anchor);
  }

  public int getLineHeight(int font)
  {
    this.temp_sr = this.getStringRenderer(font);
    return this.temp_sr.getHeight();
  }

  public int getStringWidth(int stringid, int font)
  {
    this.temp_sr = this.getStringRenderer(font);
    this.temp_str = this.getString(stringid);
    return this.temp_sr.stringWidth(this.temp_str);
  }

  public int getStringWidth(string str, int font)
  {
    this.temp_sr = this.getStringRenderer(font);
    return this.temp_sr.stringWidth(str);
  }

  public int getStringWidth(StringBuffer str, int font)
  {
    this.temp_sr = this.getStringRenderer(font);
    this.temp_str = str.toString();
    return this.temp_sr.stringWidth(this.temp_str);
  }

  private void initFonts()
  {
    Font font1 = Font.getFont(0, 0, 9f);
    SystemStringRendererIPhone stringRendererIphone1 = new SystemStringRendererIPhone(font1);
    stringRendererIphone1.setIPhoneRenderingStyle(1);
    stringRendererIphone1.setStrokeColor(-16777216);
    stringRendererIphone1.useIPhoneFontDropShadow(true);
    stringRendererIphone1.setIPhoneDropShadowParameters(0, 0, 0);
    stringRendererIphone1.setIPhoneDropShadowColor(-16777216);
    stringRendererIphone1.setColor(16777215);
    font1.Color = new Color(stringRendererIphone1.getColor() >> 16 & (int) byte.MaxValue, stringRendererIphone1.getColor() >> 8 & (int) byte.MaxValue, stringRendererIphone1.getColor() & (int) byte.MaxValue);
    this.m_stringRenderers.addElement((object) new BucketStringRenderer((StringRenderer) stringRendererIphone1, 5));
    Font font2 = Font.getFont(0, 0, 12f);
    SystemStringRendererIPhone stringRendererIphone2 = new SystemStringRendererIPhone(font2);
    stringRendererIphone2.setIPhoneRenderingStyle(1);
    stringRendererIphone2.setStrokeColor(-16777216);
    stringRendererIphone2.useIPhoneFontDropShadow(false);
    stringRendererIphone2.setIPhoneDropShadowParameters(0, 0, 0);
    stringRendererIphone2.setIPhoneDropShadowColor(-16777216);
    stringRendererIphone2.setColor(16777215);
    font2.Color = new Color(stringRendererIphone2.getColor() >> 16 & (int) byte.MaxValue, stringRendererIphone2.getColor() >> 8 & (int) byte.MaxValue, stringRendererIphone2.getColor() & (int) byte.MaxValue);
    this.m_stringRenderers.addElement((object) new BucketStringRenderer((StringRenderer) stringRendererIphone2, 20));
    Font font3 = Font.getFont(0, 0, 12f);
    SystemStringRendererIPhone stringRendererIphone3 = new SystemStringRendererIPhone(font3);
    stringRendererIphone3.setIPhoneRenderingStyle(1);
    stringRendererIphone3.setStrokeColor(-16777216);
    stringRendererIphone3.useIPhoneFontDropShadow(false);
    stringRendererIphone3.setIPhoneDropShadowParameters(0, 0, 0);
    stringRendererIphone3.setIPhoneDropShadowColor(-16777216);
    stringRendererIphone3.setColor(-16777216);
    font3.Color = new Color(stringRendererIphone3.getColor() >> 16 & (int) byte.MaxValue, stringRendererIphone3.getColor() >> 8 & (int) byte.MaxValue, stringRendererIphone3.getColor() & (int) byte.MaxValue);
    this.m_stringRenderers.addElement((object) new BucketStringRenderer((StringRenderer) stringRendererIphone3, 20));
    Font font4 = Font.getFont(0, 1, 12f);
    SystemStringRendererIPhone stringRendererIphone4 = new SystemStringRendererIPhone(font4);
    stringRendererIphone4.setIPhoneRenderingStyle(1);
    stringRendererIphone4.setStrokeColor(-16777216);
    stringRendererIphone4.useIPhoneFontDropShadow(false);
    stringRendererIphone4.setIPhoneDropShadowParameters(0, 0, 0);
    stringRendererIphone4.setIPhoneDropShadowColor(-16777216);
    stringRendererIphone4.setColor(-16777216);
    font4.Color = new Color(stringRendererIphone4.getColor() >> 16 & (int) byte.MaxValue, stringRendererIphone4.getColor() >> 8 & (int) byte.MaxValue, stringRendererIphone4.getColor() & (int) byte.MaxValue);
    this.m_stringRenderers.addElement((object) new BucketStringRenderer((StringRenderer) stringRendererIphone4, 30));
    Font font5 = Font.getFont(0, 1, 12f);
    SystemStringRendererIPhone stringRendererIphone5 = new SystemStringRendererIPhone(font5);
    stringRendererIphone5.setIPhoneRenderingStyle(1);
    stringRendererIphone5.setStrokeColor(-16777216);
    stringRendererIphone5.useIPhoneFontDropShadow(false);
    stringRendererIphone5.setIPhoneDropShadowParameters(0, 0, 0);
    stringRendererIphone5.setIPhoneDropShadowColor(-16777216);
    stringRendererIphone5.setColor(794969);
    font5.Color = new Color(stringRendererIphone5.getColor() >> 16 & (int) byte.MaxValue, stringRendererIphone5.getColor() >> 8 & (int) byte.MaxValue, stringRendererIphone5.getColor() & (int) byte.MaxValue);
    this.m_stringRenderers.addElement((object) new BucketStringRenderer((StringRenderer) stringRendererIphone5, 30));
    Font font6 = Font.getFont(0, 1, 12f);
    SystemStringRendererIPhone stringRendererIphone6 = new SystemStringRendererIPhone(font6);
    stringRendererIphone6.setIPhoneRenderingStyle(1);
    stringRendererIphone6.setStrokeColor(-16777216);
    stringRendererIphone6.useIPhoneFontDropShadow(true);
    stringRendererIphone6.setIPhoneDropShadowParameters(2, 2, 6);
    stringRendererIphone6.setIPhoneDropShadowColor(-16777216);
    stringRendererIphone6.setColor(16777215);
    font6.Color = new Color(stringRendererIphone6.getColor() >> 16 & (int) byte.MaxValue, stringRendererIphone6.getColor() >> 8 & (int) byte.MaxValue, stringRendererIphone6.getColor() & (int) byte.MaxValue);
    this.m_stringRenderers.addElement((object) new BucketStringRenderer((StringRenderer) stringRendererIphone6, 5));
    Font font7 = Font.getFont(0, 1, 15f);
    SystemStringRendererIPhone stringRendererIphone7 = new SystemStringRendererIPhone(font7);
    stringRendererIphone7.setIPhoneRenderingStyle(1);
    stringRendererIphone7.setStrokeColor(-16777216);
    stringRendererIphone7.useIPhoneFontDropShadow(false);
    stringRendererIphone7.setIPhoneDropShadowParameters(0, 0, 0);
    stringRendererIphone7.setIPhoneDropShadowColor(-16777216);
    stringRendererIphone7.setColor(794969);
    font7.Color = new Color(stringRendererIphone7.getColor() >> 16 & (int) byte.MaxValue, stringRendererIphone7.getColor() >> 8 & (int) byte.MaxValue, stringRendererIphone7.getColor() & (int) byte.MaxValue);
    this.m_stringRenderers.addElement((object) new BucketStringRenderer((StringRenderer) stringRendererIphone7, 5));
    Font font8 = Font.getFont(0, 1, 15f);
    SystemStringRendererIPhone stringRendererIphone8 = new SystemStringRendererIPhone(font8);
    stringRendererIphone8.setIPhoneRenderingStyle(1);
    stringRendererIphone8.setStrokeColor(-16777216);
    stringRendererIphone8.useIPhoneFontDropShadow(false);
    stringRendererIphone8.setIPhoneDropShadowParameters(0, 0, 0);
    stringRendererIphone8.setIPhoneDropShadowColor(-16777216);
    stringRendererIphone8.setColor(0);
    font8.Color = new Color(stringRendererIphone8.getColor() >> 16 & (int) byte.MaxValue, stringRendererIphone8.getColor() >> 8 & (int) byte.MaxValue, stringRendererIphone8.getColor() & (int) byte.MaxValue);
    this.m_stringRenderers.addElement((object) new BucketStringRenderer((StringRenderer) stringRendererIphone8, 5));
  }

  private static void readFontDefStringRenderers(ref DataInputStream din, ref Vector fontDefs)
  {
  }

  private void initFontsFromData(ref DataInputStream din, Vector fontDefs)
  {
    int num = din.readInt();
    for (int index1 = 0; index1 < num; ++index1)
    {
      int index2 = din.readInt();
      this.m_stringRenderers.addElement(fontDefs.elementAt(index2));
    }
  }

  private StringRenderer getStringRenderer(int font)
  {
    return (StringRenderer) this.m_stringRenderers.elementAt(font);
  }

  private string replaceFirst(string baseString, string string0)
  {
    this.m_replaceStrings[0] = string0;
    return this.replace(baseString, ref this.m_replaceStrings);
  }

  private string replace(string baseString, ref string[] strings)
  {
    int length = baseString.Length;
    StringBuffer stringBuffer = this.clearStringBuffer();
    bool flag = false;
    for (int index1 = 0; index1 < length; ++index1)
    {
      ushort str = (ushort) baseString[index1];
      if (flag)
      {
        if (str == (ushort) 92)
        {
          stringBuffer.append((ushort) 92);
        }
        else
        {
          int index2 = (int) str - 48;
          this.temp_str = strings[index2];
          stringBuffer.append(this.temp_str);
        }
        flag = false;
      }
      else if (str == (ushort) 92)
        flag = true;
      else
        stringBuffer.append(str);
    }
    return stringBuffer.toString();
  }

  public void dynamicString(int slotid, int baseString, int string0)
  {
    this.temp_str = this.getString(baseString);
    this.m_dynamicStrings[slotid - -12] = this.replaceFirst(this.temp_str, this.getString(string0));
  }

  public void dynamicString(int slotid, int baseString, int string0, int string1)
  {
    this.temp_str = this.getString(baseString);
    string[] replaceStrings = this.m_replaceStrings;
    replaceStrings[0] = this.getString(string0);
    replaceStrings[1] = this.getString(string1);
    this.m_dynamicStrings[slotid - -12] = this.replace(this.temp_str, ref replaceStrings);
  }

  public void dynamicString(int slotid, int baseString, string string1)
  {
    this.temp_str = this.getString(baseString);
    this.m_dynamicStrings[slotid - -12] = this.replaceFirst(this.temp_str, string1);
  }

  public void dynamicString(int slotid, int baseString, string string0, string string1)
  {
    this.temp_str = this.getString(baseString);
    string[] replaceStrings = this.m_replaceStrings;
    replaceStrings[0] = string0;
    replaceStrings[1] = string1;
    this.temp_str2 = this.replace(this.temp_str, ref replaceStrings);
    this.m_dynamicStrings[slotid - -12] = this.temp_str2;
  }

  public void dynamicString(
    int slotid,
    int baseString,
    string string0,
    string string1,
    string string2)
  {
    this.temp_str = this.getString(baseString);
    string[] replaceStrings = this.m_replaceStrings;
    replaceStrings[0] = string0;
    replaceStrings[1] = string1;
    replaceStrings[2] = string2;
    this.m_dynamicStrings[slotid - -12] = this.replace(this.temp_str, ref replaceStrings);
  }

  public void dynamicString(int slotid, string str)
  {
    this.m_dynamicStrings[slotid - -12] = str;
  }

  public void dynamicString(int slotid, StringBuffer str)
  {
    this.m_dynamicStrings[slotid - -12] = str.toString();
  }

  private void initStringBuffers()
  {
    this.m_tempStringBuffers = new StringBuffer[25];
    for (int index = 0; index < 25; ++index)
      this.m_tempStringBuffers[index] = new StringBuffer(100);
    this.m_tempStringBuffer = (StringBuffer) null;
    this.m_tempBufferIndex = 0;
  }

  public StringBuffer clearStringBuffer()
  {
    ++this.m_tempBufferIndex;
    if (this.m_tempBufferIndex >= 25)
      this.m_tempBufferIndex = 0;
    this.m_tempStringBuffer = this.m_tempStringBuffers[this.m_tempBufferIndex];
    this.m_tempStringBuffer.setLength(0);
    return this.m_tempStringBuffer;
  }

  public void appendStringIdToBuffer(int stringId)
  {
    this.m_tempStringBuffer.append(this.getString(stringId));
  }

  public void appendStringToBuffer(string stringToAppend)
  {
    this.m_tempStringBuffer.append(stringToAppend);
  }

  public void appendIntToBuffer(int num)
  {
    StringBuffer tempStringBuffer = this.m_tempStringBuffer;
    if (num == 0)
    {
      tempStringBuffer.append((ushort) 48);
    }
    else
    {
      if (num < 0)
      {
        tempStringBuffer.append((ushort) 45);
        num = -num;
      }
      int num1 = 1000000000;
      bool flag = false;
      for (; num1 > 0; num1 /= 10)
      {
        int num2 = num / num1;
        if (num2 != 0 || flag)
        {
          flag = true;
          tempStringBuffer.append((ushort) (48 + num2));
        }
        num -= num2 * num1;
      }
    }
  }

  public void appendIntToBufferWithThousandSep(int num)
  {
    StringBuffer tempStringBuffer = this.m_tempStringBuffer;
    if (num == 0)
    {
      tempStringBuffer.append((ushort) 48);
    }
    else
    {
      if (num < 0)
      {
        tempStringBuffer.append((ushort) 45);
        num = -num;
      }
      int num1 = 1000000000;
      bool flag = false;
      for (; num1 > 0; num1 /= 10)
      {
        int num2 = num / num1;
        if (num2 != 0 || flag)
        {
          flag = true;
          tempStringBuffer.append((ushort) (48 + num2));
          if (num1 == 1000000000 || num1 == 1000000 || num1 == 1000)
            tempStringBuffer.append(this.getString(15));
        }
        num -= num2 * num1;
      }
    }
  }

  public void appendIntToBufferWithLeadingZeros(int num, int digits)
  {
    StringBuffer tempStringBuffer = this.m_tempStringBuffer;
    int index1 = tempStringBuffer.length();
    int num1 = 0;
    if (num < 0)
    {
      tempStringBuffer.setLength(index1 + 1);
      tempStringBuffer.setCharAt(index1, (ushort) 45);
      ++num1;
      num = -num;
    }
    int num2 = index1 + num1 - 1;
    tempStringBuffer.setLength(index1 + digits);
    for (int index2 = index1 + digits - 1; index2 != num2; --index2)
    {
      tempStringBuffer.setCharAt(index2, (ushort) (48 + num % 10));
      num /= 10;
    }
  }

  public void appendMoneyToBuffer(int num)
  {
    int tempBufferIndex = this.m_tempBufferIndex;
    StringBuffer tempStringBuffer = this.m_tempStringBuffer;
    StringBuffer stringBuffer = this.clearStringBuffer();
    this.appendIntToBufferWithThousandSep(JMath.abs(num));
    this.temp_str = this.replaceFirst(this.getString(14), stringBuffer.toString());
    if (num < 0)
      tempStringBuffer.append("-");
    tempStringBuffer.append(this.temp_str);
    this.m_tempStringBuffer = tempStringBuffer;
    this.m_tempBufferIndex = tempBufferIndex;
  }

  public void appendTimeToBuffer24Hour(int minutesSinceMidnight)
  {
    int num1 = minutesSinceMidnight / 60;
    int num2 = minutesSinceMidnight - num1 * 60;
    int num3 = num1;
    StringBuffer tempStringBuffer = this.m_tempStringBuffer;
    ushort str = 48;
    if (num3 >= 20)
    {
      str = (ushort) 50;
      num3 -= 20;
    }
    else if (num3 >= 10)
    {
      str = (ushort) 49;
      num3 -= 10;
    }
    tempStringBuffer.append(str);
    tempStringBuffer.append((ushort) (48 + num3));
    tempStringBuffer.append((ushort) 58);
    int num4 = num2 / 10;
    tempStringBuffer.append((ushort) (48 + num4));
    tempStringBuffer.append((ushort) (48 + (num2 - num4 * 10)));
  }

  public void appendTimeToBufferLap(int minutesSinceMidnight)
  {
    int num1 = minutesSinceMidnight;
    int num2 = 2;
    bool flag1 = false;
    if (num1 < 0)
    {
      num1 = -num1;
      flag1 = true;
    }
    int num3 = num1 / 1000;
    int num4 = num3 / 60;
    int num5 = num4 / 60;
    int num6 = num1 % 1000;
    int num7 = num3 % 60;
    int num8 = num4 % 60;
    int num9 = 1000;
    for (int index = 0; index < num2; ++index)
      num9 /= 10;
    int num10 = num6 / num9;
    StringBuffer tempStringBuffer = this.m_tempStringBuffer;
    if (flag1)
      tempStringBuffer.append((ushort) 45);
    if (num5 > 0)
    {
      int num11 = 1000000000;
      bool flag2 = false;
      for (; num11 > 0; num11 /= 10)
      {
        int num12 = num5 / num11;
        if (num12 != 0 || flag2 || num11 == 10)
        {
          flag2 = true;
          tempStringBuffer.append((ushort) (48 + num12));
        }
        num5 -= num12 * num11;
      }
      tempStringBuffer.append((ushort) 58);
    }
    if (num8 > 0)
    {
      int num11 = 1000000000;
      bool flag2 = false;
      for (; num11 > 0; num11 /= 10)
      {
        int num12 = num8 / num11;
        if (num12 != 0 || flag2 || num11 == 10)
        {
          flag2 = true;
          tempStringBuffer.append((ushort) (48 + num12));
        }
        num8 -= num12 * num11;
      }
    }
    else
      tempStringBuffer.append("00");
    tempStringBuffer.append((ushort) 58);
    if (num7 > 0)
    {
      int num11 = 1000000000;
      bool flag2 = false;
      for (; num11 > 0; num11 /= 10)
      {
        int num12 = num7 / num11;
        if (num12 != 0 || flag2 || num11 == 10)
        {
          flag2 = true;
          tempStringBuffer.append((ushort) (48 + num12));
        }
        num7 -= num12 * num11;
      }
    }
    else
      tempStringBuffer.append("00");
    tempStringBuffer.append((ushort) 58);
    if (num10 > 0)
    {
      int num11 = 1000000000;
      bool flag2 = false;
      for (; num11 > 0; num11 /= 10)
      {
        int num12 = num10 / num11;
        if (num12 != 0 || flag2 || num11 == 10)
        {
          flag2 = true;
          tempStringBuffer.append((ushort) (48 + num12));
        }
        num10 -= num12 * num11;
      }
    }
    else
      tempStringBuffer.append("00");
  }

  public void appendCurrencyToBuffer(double number)
  {
    this.temp_str = LocaleManager.getInstance().formatCurrency(number);
    this.m_tempStringBuffer.append(this.temp_str);
  }

  private void initWraps()
  {
    this.m_wrapOffsets = new short[(int) byte.MaxValue];
    this.m_wrapOffsets[0] = (short) 0;
    this.m_wrapChunkOffsets = new short[20][];
    for (int index = 0; index < 20; ++index)
    {
      this.m_wrapChunkOffsets[index] = new short[10];
      this.m_wrapChunkOffsets[index][0] = (short) 0;
    }
    this.m_wrapChunkStrings = new string[20];
    this.m_wrapChunkStringIds = new int[20];
  }

  public void clearWrapChunks()
  {
    for (int index = 0; index < this.m_wrapChunkStringIds.Length; ++index)
      this.m_wrapChunkStringIds[index] = -1;
  }

  private int wrapString(string str, int font, int lineWidth, ref short[] offsets)
  {
    StringRenderer stringRenderer = this.getStringRenderer(font);
    int length = str.Length;
    int num1 = length;
    int num2 = 0;
    int num3 = 0;
    int num4 = -1;
    int num5 = 1;
    short[] numArray = offsets;
    int index1 = num5;
    int index2 = index1 + 1;
    numArray[index1] = (short) 0;
    for (int index3 = 0; index3 != num1; ++index3)
    {
      int num6 = (int) str[index3];
      switch (num6)
      {
        case 10:
        case 124:
          offsets[index2++] = (short) (index3 + 1);
          num2 = 0;
          num3 = 0;
          num4 = -1;
          break;
        default:
          int num7 = stringRenderer.charWidth((ushort) num6);
          num2 += num7;
          num3 += num7;
          if (num2 > lineWidth)
          {
            if (num4 == -1)
            {
              offsets[index2++] = (short) index3;
              num2 = num7;
              num3 = 0;
              break;
            }
            offsets[index2++] = (short) (num4 + 1);
            num4 = num6 == 32 || num6 == 45 ? index3 : -1;
            num2 = num3;
            num3 = 0;
            break;
          }
          if (num6 == 32 || num6 == 45)
          {
            num4 = index3;
            num3 = 0;
            break;
          }
          break;
      }
    }
    offsets[0] = (short) (index2 - 1);
    offsets[index2] = (short) length;
    offsets[index2 + 1] = (short) 10;
    return (int) offsets[0];
  }

  private void drawWrappedStringLines(
    Graphics g,
    string str,
    ref short[] offsets,
    int font,
    int x,
    int y,
    int anchor,
    int startLine,
    int numLines)
  {
    if (str.Length == 0)
      return;
    StringRenderer stringRenderer = this.getStringRenderer(font);
    int num1 = 320 - g.getClipX() - g.getClipWidth();
    int num2 = num1 + g.getClipWidth();
    int x1 = x;
    int y1 = y;
    int anchor1 = anchor;
    int height = stringRenderer.getHeight();
    int num3 = 0;
    int num4 = startLine + numLines - 1;
    if ((anchor & 2) != 0)
    {
      y1 -= numLines * height >> 1;
      anchor1 = anchor1 & -3 | 1;
    }
    else if ((anchor & 4) != 0)
    {
      y1 -= numLines * height;
      anchor1 = anchor1 & -5 | 1;
    }
    int num5 = height;
    for (int index = startLine; index <= num4; ++index)
    {
      int start = (int) offsets[index + 1];
      int end = (int) offsets[index + 2] - start;
      switch (str[(int) offsets[index + 2] - 1])
      {
        case '\n':
        case ' ':
        case '|':
          --end;
          break;
      }
      if (end > 0 && y1 + num5 > num1 && y1 < num2)
        this.drawSubString(g, str, start, end, font, x1, y1, anchor1);
      x1 += num3;
      y1 += num5;
    }
  }

  public int wrapString(int stringId, int font, int lineWidth)
  {
    this.temp_str = this.getString(stringId);
    this.m_wrapString = this.temp_str;
    this.temp_shortArr = this.m_wrapOffsets;
    return this.wrapString(this.temp_str, font, lineWidth, ref this.temp_shortArr);
  }

  public int wrapString(string str, int font, int lineWidth)
  {
    this.m_wrapString = str;
    this.temp_shortArr = this.m_wrapOffsets;
    return this.wrapString(str, font, lineWidth, ref this.temp_shortArr);
  }

  public int getNumWrappedLines()
  {
    return (int) this.m_wrapOffsets[0];
  }

  public void drawWrappedString(Graphics g, int font, int x, int y, int anchor)
  {
    this.drawWrappedStringLines(g, this.m_wrapString, ref this.m_wrapOffsets, font, x, y, anchor, 0, this.getNumWrappedLines());
  }

  public void drawPartWrappedString(
    Graphics g,
    int font,
    int x,
    int y,
    int anchor,
    int startLine,
    int numLines)
  {
    this.drawWrappedStringLines(g, this.m_wrapString, ref this.m_wrapOffsets, font, x, y, anchor, startLine, numLines);
  }

  public int wrapStringChunk(int chunk, int stringId, int font, int lineWidth)
  {
    this.m_wrapChunkStringIds[chunk] = stringId;
    if (stringId == -1)
      return 0;
    this.temp_str = this.getString(stringId);
    this.m_wrapChunkStrings[chunk] = this.temp_str;
    this.temp_shortArr = this.m_wrapChunkOffsets[chunk];
    return this.wrapString(this.temp_str, font, lineWidth, ref this.temp_shortArr);
  }

  public int wrapStringChunk(int chunk, string str, int font, int lineWidth)
  {
    this.m_wrapChunkStrings[chunk] = str;
    this.temp_shortArr = this.m_wrapChunkOffsets[chunk];
    return this.wrapString(str, font, lineWidth, ref this.temp_shortArr);
  }

  public int getNumWrappedLinesChunk(int chunk)
  {
    return (int) this.m_wrapChunkOffsets[chunk][0];
  }

  public void drawWrappedStringChunk(Graphics g, int chunk, int font, int x, int y, int anchor)
  {
    this.temp_str = this.m_wrapChunkStrings[chunk];
    this.temp_shortArr = this.m_wrapChunkOffsets[chunk];
    this.drawWrappedStringLines(g, this.temp_str, ref this.temp_shortArr, font, x, y, anchor, 0, this.getNumWrappedLinesChunk(chunk));
  }

  public void drawWrappedStringChunk(
    Graphics g,
    int chunk,
    int stringId,
    int font,
    int lineWidth,
    int x,
    int y,
    int anchor)
  {
    if (stringId != this.m_wrapChunkStringIds[chunk])
    {
      this.wrapStringChunk(chunk, stringId, font, lineWidth);
      this.m_wrapChunkStringIds[chunk] = stringId;
    }
    this.drawWrappedStringChunk(g, chunk, font, x, y, anchor);
  }

  public void drawWrappedStringChunk(
    Graphics g,
    int chunk,
    string str,
    int font,
    int lineWidth,
    int x,
    int y,
    int anchor)
  {
    this.wrapStringChunk(chunk, str, font, lineWidth);
    this.drawWrappedStringChunk(g, chunk, font, x, y, anchor);
  }
}
