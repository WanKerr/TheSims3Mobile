// Decompiled with JetBrains decompiler
// Type: SystemStringRenderer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using sims3;

public class SystemStringRenderer : StringRenderer
{
  protected Font m_font;
  protected int m_color;

  public SystemStringRenderer()
  {
    this.m_font = (Font) null;
    this.m_color = 16777215;
    this.m_font = Font.getDefaultFont();
  }

  public SystemStringRenderer(Font font)
  {
    this.m_font = font;
    this.m_color = 16777215;
  }

  public void Dispose()
  {
    this.m_font = (Font) null;
  }

  public void setColor(int color)
  {
    this.m_color = color;
  }

  public int getColor()
  {
    return this.m_color;
  }

  public override void drawString(Graphics g, string str, int x, int y, int anchor)
  {
    g.setFont(this.m_font);
    g.setColor(this.m_color);
    g.drawString(str, x, y, anchor);
  }

  public override void drawString(Graphics g, StringBuffer str, int x, int y, int anchor)
  {
    g.setFont(this.m_font);
    g.setColor(this.m_color);
    g.drawString(str.toString(), x, y, anchor);
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
    g.setFont(this.m_font);
    g.setColor(this.m_color);
    g.drawSubstring(str, offset, len, x, y, anchor);
  }

  public override int charsWidth(ushort[] ch, int offset, int length)
  {
    return this.m_font.charsWidth(ch, offset, length);
  }

  public override int charWidth(ushort chr)
  {
    return this.m_font.charWidth(chr);
  }

  public override int getBaselinePosition()
  {
    return this.m_font.getBaselinePosition();
  }

  public override int getHeight()
  {
    return this.m_font.getHeight();
  }

  public override int stringWidth(string str)
  {
    return this.m_font.stringWidth(str);
  }

  public override int substringWidth(string str, int offset, int length)
  {
    return this.m_font.substringWidth(str, offset, length);
  }
}
