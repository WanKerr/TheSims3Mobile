// Decompiled with JetBrains decompiler
// Type: BufferedStringRenderer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using sims3;

public class BufferedStringRenderer : StringRenderer
{
  private StringRenderer m_stringRenderer;
  private StringRect[] m_stringRects;
  private short[] m_stringRectHistory;
  private int m_stringRectsCount;
  private Image m_bufferImage;
  private Graphics m_bufferGraphics;
  private int m_bufferLineHeight;
  private string temp_str;

  public BufferedStringRenderer(StringRenderer sr)
  {
    this.m_stringRenderer = sr;
    this.m_stringRects = (StringRect[]) null;
    this.m_stringRectHistory = (short[]) null;
    this.m_stringRectsCount = 0;
    this.m_bufferImage = (Image) null;
    this.m_bufferGraphics = (Graphics) null;
    this.m_bufferLineHeight = 0;
    this.m_bufferImage = Image.createImage(512, 512);
    this.m_bufferGraphics = this.m_bufferImage.getGraphics();
    int x0 = 0;
    int x1 = 0;
    int y0 = 0;
    int y1 = 0;
    this.m_stringRenderer.getStringTexturePadding(ref x0, ref x1, ref y0, ref y1);
    this.m_bufferLineHeight = this.m_stringRenderer.getHeight() + y0 + y1;
    this.m_stringRectsCount = this.m_bufferImage.getHeight() / this.m_bufferLineHeight;
    this.m_stringRects = new StringRect[this.m_stringRectsCount];
    this.m_stringRectHistory = new short[this.m_stringRectsCount];
    for (int index = 0; index < this.m_stringRectsCount; ++index)
      this.m_stringRectHistory[index] = (short) (this.m_stringRectsCount - 1 - index);
  }

  public void Dispose()
  {
    if (this.m_stringRects == null)
      return;
    this.m_stringRects = (StringRect[]) null;
    this.m_stringRects = (StringRect[]) null;
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
    int width1 = this.m_stringRenderer.stringWidth(str);
    int height1 = this.m_stringRenderer.getHeight();
    int x0 = 0;
    int x1 = 0;
    int y0 = 0;
    int y1 = 0;
    this.m_stringRenderer.getStringTexturePadding(ref x0, ref x1, ref y0, ref y1);
    int width2 = x0 + x1 + width1;
    int height2 = y0 + y1 + height1;
    if (width1 <= 0 || height1 <= 0)
      return;
    int index1 = -1;
    for (int index2 = 0; index2 < this.m_stringRectsCount; ++index2)
    {
      if (this.m_stringRects[index2].equals(str))
      {
        index1 = index2;
        break;
      }
    }
    int index3 = -1;
    if (index1 == -1)
    {
      index3 = this.m_stringRectsCount - 1;
      index1 = (int) this.m_stringRectHistory[index3];
      this.m_stringRects[index1].set(str, width1);
      int num = index1 * this.m_bufferLineHeight;
      this.m_stringRenderer.drawString(this.m_bufferGraphics, str, x0, num + y0, 9);
    }
    else
    {
      for (int index2 = 0; index2 < this.m_stringRectsCount; ++index2)
      {
        if ((int) this.m_stringRectHistory[index2] == index1)
        {
          index3 = index2;
          break;
        }
      }
    }
    if (index3 != 0)
    {
      for (int index2 = 0; index2 < index3; ++index2)
        this.m_stringRectHistory[index2 + 1] = this.m_stringRectHistory[index2];
      this.m_stringRectHistory[0] = (short) index1;
    }
    int y_src = index1 * this.m_bufferLineHeight;
    int x_dest = x - x0;
    int y_dest = y - y0;
    if ((anchor & 16) != 0)
      x_dest -= width1 / 2;
    else if ((anchor & 32) != 0)
      x_dest -= width1;
    if ((anchor & 2) != 0)
      y_dest -= height1 / 2;
    else if ((anchor & 4) != 0)
      y_dest -= height1;
    g.drawRegion(this.m_bufferImage, 0, y_src, width2, height2, 0, x_dest, y_dest, 9);
  }
}
