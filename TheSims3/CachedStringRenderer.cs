// Decompiled with JetBrains decompiler
// Type: CachedStringRenderer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using sims3;
using System;

public class CachedStringRenderer : StringRenderer
{
  private StringRenderer m_stringRenderer;
  private StringRecord[] m_stringRecords;
  private short[] m_stringRecordHistory;
  private int m_stringRecordsCount;
  private string temp_str;
  private Image temp_img;
  private Graphics temp_g;

  public CachedStringRenderer(StringRenderer sr, int bufferCount)
  {
    this.m_stringRenderer = sr;
    this.m_stringRecords = (StringRecord[]) null;
    this.m_stringRecordHistory = (short[]) null;
    this.m_stringRecordsCount = bufferCount;
    this.m_stringRecords = new StringRecord[this.m_stringRecordsCount];
    this.m_stringRecordHistory = new short[this.m_stringRecordsCount];
    for (int index = 0; index < this.m_stringRecordsCount; ++index)
      this.m_stringRecordHistory[index] = (short) (this.m_stringRecordsCount - 1 - index);
  }

  public void Dispose()
  {
    if (this.m_stringRecords == null)
      return;
    this.m_stringRecords = (StringRecord[]) null;
    this.m_stringRecords = (StringRecord[]) null;
  }

  public override void drawString(Graphics g, string str, int x, int y, int anchor)
  {
    this.bufferedDrawString(g, str, x, y, anchor);
  }

  public override void drawString(Graphics g, StringBuffer str, int x, int y, int anchor)
  {
    this.drawString(g, str.toString(), x, y, anchor);
  }

  public override void drawSubstring(
    Graphics g,
    string str,
    int offset,
    int len,
    int x,
    int y,
    int anchor)
  {
    this.temp_str = str.Substring(offset, offset + len);
    this.bufferedDrawString(g, this.temp_str, x, y, anchor);
  }

  public override int charsWidth(ushort[] ch, int offset, int length)
  {
    return this.m_stringRenderer.charsWidth(ch, offset, length);
  }

  public override int charWidth(ushort chr)
  {
    return this.m_stringRenderer.charWidth(chr);
  }

  public override int getBaselinePosition()
  {
    return this.m_stringRenderer.getBaselinePosition();
  }

  public override int getHeight()
  {
    return this.m_stringRenderer.getHeight();
  }

  public override int stringWidth(string str)
  {
    return this.m_stringRenderer.stringWidth(str);
  }

  public override int substringWidth(string str, int offset, int length)
  {
    return this.m_stringRenderer.substringWidth(str, offset, length);
  }

  private void bufferedDrawString(Graphics g, string str, int x, int y, int anchor)
  {
    this.temp_str = str;
    int num = this.m_stringRenderer.stringWidth(str);
    int height1 = this.m_stringRenderer.getHeight();
    int x0 = -1;
    int x1 = -1;
    int y0 = -1;
    int y1 = -1;
    this.m_stringRenderer.getStringTexturePadding(ref x0, ref x1, ref y0, ref y1);
    int width = x0 + x1 + num;
    int height2 = y0 + y1 + height1;
    if (num <= 0 || height1 <= 0)
      return;
    int x_dest = x - x0;
    int y_dest = y - y0;
    if ((anchor & 16) != 0)
      x_dest -= num / 2;
    else if ((anchor & 32) != 0)
      x_dest -= num;
    if ((anchor & 2) != 0)
      y_dest -= height1 / 2;
    else if ((anchor & 4) != 0)
      y_dest -= height1;
    int index1 = -1;
    for (int index2 = 0; index2 < this.m_stringRecordsCount; ++index2)
    {
      if (this.m_stringRecords[index2].equals(str))
      {
        index1 = index2;
        break;
      }
    }
    int index3 = -1;
    if (index1 == -1)
    {
      index3 = this.m_stringRecordsCount - 1;
      index1 = (int) this.m_stringRecordHistory[index3];
      this.temp_img = Image.createImage(width, height2);
      this.temp_g = this.temp_img.getGraphics();
      this.m_stringRecords[index1].set(str, this.temp_img);
      this.m_stringRenderer.drawString(this.temp_g, str, x0, y0, 9);
    }
    else
    {
      for (int index2 = 0; index2 < this.m_stringRecordsCount; ++index2)
      {
        if ((int) this.m_stringRecordHistory[index2] == index1)
        {
          index3 = index2;
          break;
        }
      }
    }
    if (index3 != 0)
    {
      short[] numArray = new short[this.m_stringRecordHistory.Length + 1];
      Array.Copy((Array) this.m_stringRecordHistory, 0, (Array) numArray, 1, this.m_stringRecordHistory.Length);
      this.m_stringRecordHistory = numArray;
      this.m_stringRecordHistory[0] = (short) index1;
    }
    this.temp_img = this.m_stringRecords[index1].getImage();
    g.drawRegion(this.temp_img, 0, 0, width, height2, 0, x_dest, y_dest, 9);
  }
}
