// Decompiled with JetBrains decompiler
// Type: ea_sdk.SDKFont
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace ea_sdk
{
  public class SDKFont
  {
    public const int HEADER_SIZE = 12;
    public const int FONT_LEFT_TO_RIGHT = 1;
    public const int FONT_TOP_TO_BOTTOM = 2;
    public const int FONT_RIGHT_TO_LEFT = 4;
    public const int FONT_BOTTOM_TO_TOP = 8;
    public const int FONT_HORIZONTAL_DIRECTION = 5;
    public const int FONT_VERTICAL_DIRECTION = 10;
    private object m_image;
    private int m_textDirection;
    private int m_lineDirection;
    private int m_leading;
    private int m_ascent;
    private int m_descent;
    private int m_spaceSpace;
    private int m_charSpace;
    private int m_numChars;
    private int m_numGlyphs;
    private ushort[] m_utfCodeArray;
    private ushort[] m_charDataOffsetArray;
    private ushort[] m_ISOOffsetMap;
    private int m_transform;
    private int m_transTextDirection;

    public sbyte[] m_charData { get; private set; }

    public int m_isoCodeIndex { get; private set; }

    public int m_transLineDirection { get; private set; }

    public SDKFont()
    {
      this.m_image = (object) null;
      this.m_textDirection = 0;
      this.m_lineDirection = 0;
      this.m_leading = 0;
      this.m_ascent = 0;
      this.m_descent = 0;
      this.m_spaceSpace = 0;
      this.m_charSpace = 0;
      this.m_numChars = 0;
      this.m_numGlyphs = 0;
      this.m_utfCodeArray = new ushort[0];
      this.m_charDataOffsetArray = new ushort[0];
      this.m_charData = new sbyte[0];
      this.m_ISOOffsetMap = new ushort[0];
      this.m_isoCodeIndex = 1;
      this.m_transform = 0;
      this.m_transTextDirection = 0;
      this.m_transLineDirection = 0;
    }

    protected SDKFont(SDKFont font)
    {
      this.m_image = font.m_image;
      this.m_textDirection = font.m_textDirection;
      this.m_lineDirection = font.m_lineDirection;
      this.m_leading = font.m_leading;
      this.m_ascent = font.m_ascent;
      this.m_descent = font.m_descent;
      this.m_spaceSpace = font.m_spaceSpace;
      this.m_charSpace = font.m_charSpace;
      this.m_numChars = font.m_numChars;
      this.m_numGlyphs = font.m_numGlyphs;
      this.m_utfCodeArray = font.m_utfCodeArray;
      this.m_charDataOffsetArray = font.m_charDataOffsetArray;
      this.m_charData = font.m_charData;
      this.m_ISOOffsetMap = font.m_ISOOffsetMap;
      this.m_isoCodeIndex = 1;
      this.m_transform = font.m_transform;
      this.m_transTextDirection = font.m_transTextDirection;
      this.m_transLineDirection = font.m_transLineDirection;
    }

    public void Dispose()
    {
    }

    public object getFontImage()
    {
      return this.m_image;
    }

    public void setFontImage(object image)
    {
      this.m_image = image;
    }

    public void setFontData(sbyte[] data)
    {
      if (data == null)
      {
        this.m_textDirection = 0;
        this.m_lineDirection = 0;
        this.m_leading = 0;
        this.m_ascent = 0;
        this.m_descent = 0;
        this.m_spaceSpace = 0;
        this.m_charSpace = 0;
        this.m_numChars = 0;
        this.m_numGlyphs = 0;
        this.m_utfCodeArray = new ushort[0];
        this.m_charDataOffsetArray = new ushort[0];
        this.m_charData = new sbyte[0];
        this.m_ISOOffsetMap = new ushort[0];
      }
      else
      {
        DataInputStream dataInputStream1 = new DataInputStream((InputStream) new ByteArrayInputStream(data, 12));
        int num = (int) dataInputStream1.readByte();
        this.m_textDirection = (int) dataInputStream1.readByte();
        this.m_lineDirection = (int) dataInputStream1.readByte();
        this.m_leading = (int) dataInputStream1.readByte();
        this.m_ascent = (int) dataInputStream1.readByte();
        this.m_descent = (int) dataInputStream1.readByte();
        this.m_spaceSpace = (int) dataInputStream1.readByte();
        this.m_charSpace = (int) dataInputStream1.readByte();
        this.m_numChars = (int) dataInputStream1.readShort();
        this.m_numGlyphs = (int) dataInputStream1.readShort();
        dataInputStream1.close();
        this.m_utfCodeArray = new ushort[this.m_numChars];
        this.m_charDataOffsetArray = new ushort[this.m_numChars + 1];
        this.m_charData = new sbyte[2 * this.m_numChars + 6 * this.m_numGlyphs];
        int bufLength = 12 + (this.m_utfCodeArray.Length + this.m_charDataOffsetArray.Length) * 2 + this.m_charData.Length;
        DataInputStream dataInputStream2 = new DataInputStream((InputStream) new ByteArrayInputStream(data, bufLength));
        dataInputStream2.skip(12L);
        for (int index = 0; index != this.m_numChars; ++index)
          this.m_utfCodeArray[index] = (ushort) dataInputStream2.readShort();
        for (int index = 0; index != this.m_numChars; ++index)
          this.m_charDataOffsetArray[index] = (ushort) dataInputStream2.readShort();
        this.m_charDataOffsetArray[this.m_numChars] = ushort.MaxValue;
        for (int index = 0; index != this.m_charData.Length; ++index)
          this.m_charData[index] = dataInputStream2.readByte();
        dataInputStream2.close();
        this.setTransform(this.m_transform);
        this.m_ISOOffsetMap = new ushort[256];
        for (int index = 0; index != 128; ++index)
          this.m_ISOOffsetMap[index] = (ushort) SDKTextUtils.getCodePos(this.m_utfCodeArray, (ushort) index, this.m_numChars);
      }
    }

    public void refreshISOOffsets()
    {
      for (int index = 128; index != 256; ++index)
        this.m_ISOOffsetMap[index] = (ushort) SDKTextUtils.getCodePos(this.m_utfCodeArray, SDKTextUtils.iso2utf((ushort) index), this.m_numChars);
      this.m_isoCodeIndex = SDKTextUtils.getCurrentEncoding();
    }

    public void setTransform(int transform)
    {
      if (this.m_charData == null)
        return;
      this.m_transform = transform;
      sbyte num1 = (sbyte) (this.m_textDirection << (int) (sbyte) ((transform & 2) + (transform >> 2 & 1)));
      this.m_transTextDirection = (int) (sbyte) ((int) num1 & 15 | (int) num1 >> 4);
      sbyte num2 = (sbyte) (this.m_lineDirection << (int) (sbyte) (((transform >> 2 ^ transform & 1) << 1) + (transform >> 2 & 1)));
      this.m_transLineDirection = (int) (sbyte) ((int) num2 & 15 | (int) num2 >> 4);
    }

    public int getLineSize()
    {
      return this.m_charData != null ? this.m_ascent + this.m_descent + this.m_leading : 0;
    }

    public int getCharAdvance(ushort off)
    {
      return off == ushort.MaxValue ? this.m_spaceSpace + this.m_charSpace : (int) this.m_charData[(int) off] & (int) byte.MaxValue;
    }

    public void advance(int[] p, int val)
    {
      switch (this.m_transTextDirection)
      {
        case 1:
          p[0] += val;
          break;
        case 2:
          p[1] += val;
          break;
        case 4:
          p[0] -= val;
          break;
        case 8:
          p[1] -= val;
          break;
      }
    }

    public int getTextDir()
    {
      return this.m_transTextDirection;
    }

    public int getLineDir()
    {
      return this.m_transLineDirection;
    }

    public int getLeading()
    {
      return this.m_leading;
    }

    public void setLeading(int leading)
    {
      if (this.m_charData == null)
        return;
      this.m_leading = (int) (sbyte) leading;
    }

    public int getAscent()
    {
      return this.m_ascent;
    }

    public int getBaselinePosition()
    {
      return this.m_ascent;
    }

    public int getSpaceSpacing()
    {
      return this.m_spaceSpace;
    }

    public void setSpaceSpacing(int spaceSpacing)
    {
      if (this.m_charData == null)
        return;
      this.m_spaceSpace = (int) (sbyte) spaceSpacing;
    }

    public int getCharSpacing()
    {
      return this.m_charSpace;
    }

    public void setCharSpacing(int charSpacing)
    {
      if (this.m_charData == null)
        return;
      this.m_charSpace = (int) (sbyte) charSpacing;
    }

    public ushort getUTFCharOffset(ushort code)
    {
      return this.m_charDataOffsetArray[SDKTextUtils.getCodePos(this.m_utfCodeArray, code, this.m_numChars)];
    }

    public ushort getISOCharOffset(ushort code)
    {
      return this.m_charDataOffsetArray[(int) this.m_ISOOffsetMap[(int) code] & (int) ushort.MaxValue];
    }
  }
}
