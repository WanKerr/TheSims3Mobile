// Decompiled with JetBrains decompiler
// Type: SystemStringRendererIPhone
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class SystemStringRendererIPhone : SystemStringRenderer
{
  public const int IPHONE_FONT_RENDERING_STYLE_FILL = 1;
  public const int IPHONE_FONT_RENDERING_STYLE_OUTLINE = 2;
  public const int IPHONE_FONT_RENDERING_STYLE_STROKE = 3;
  private int m_iPhoneRenderingStyle;
  private int m_dropShadowX;
  private int m_dropShadowY;
  private int m_dropShadowRadius;
  private int m_strokeColor;
  private int m_dropShadowColor;
  private bool m_enableDropShadow;

  public SystemStringRendererIPhone()
  {
    this.m_strokeColor = 16777215;
    this.m_iPhoneRenderingStyle = 1;
    this.m_dropShadowX = 0;
    this.m_dropShadowY = 0;
    this.m_dropShadowRadius = 0;
    this.m_enableDropShadow = false;
    this.m_dropShadowColor = 805306368;
  }

  public SystemStringRendererIPhone(Font font)
    : base(font)
  {
    this.m_strokeColor = 16777215;
    this.m_iPhoneRenderingStyle = 1;
    this.m_dropShadowX = 0;
    this.m_dropShadowY = 0;
    this.m_dropShadowRadius = 0;
    this.m_enableDropShadow = false;
    this.m_dropShadowColor = 805306368;
  }

  public new void Dispose()
  {
    base.Dispose();
  }

  public override void drawString(Graphics g, string str, int x, int y, int anchor)
  {
    g.setFont(this.m_font);
    g.setColor(this.m_color);
    int flags1 = 0;
    if (this.m_enableDropShadow)
    {
      g.setFontDropShadowParameters(this.m_dropShadowX, this.m_dropShadowY, this.m_dropShadowRadius, this.m_dropShadowColor);
      flags1 |= 1;
    }
    if (this.m_iPhoneRenderingStyle == 2)
      flags1 |= 2;
    else if (this.m_iPhoneRenderingStyle == 3)
    {
      g.drawString(str, x, y, anchor, flags1);
      int flags2 = 2;
      g.setColor(this.m_strokeColor);
      g.drawString(str, x, y, anchor, flags2);
      return;
    }
    g.drawString(str, x, y, anchor, flags1);
  }

  public override void drawString(Graphics g, StringBuffer str, int x, int y, int anchor)
  {
    g.setFont(this.m_font);
    g.setColor(this.m_color);
    int flags1 = 0;
    if (this.m_enableDropShadow)
    {
      g.setFontDropShadowParameters(this.m_dropShadowX, this.m_dropShadowY, this.m_dropShadowRadius, this.m_dropShadowColor);
      flags1 |= 1;
    }
    if (this.m_iPhoneRenderingStyle == 2)
      flags1 |= 2;
    else if (this.m_iPhoneRenderingStyle == 3)
    {
      g.drawString(str.toString(), x, y, anchor, flags1);
      int flags2 = 2;
      g.setColor(this.m_strokeColor);
      g.drawString(str.toString(), x, y, anchor, flags2);
      return;
    }
    g.drawString(str.toString(), x, y, anchor, flags1);
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
    int flags1 = 0;
    if (this.m_enableDropShadow)
    {
      g.setFontDropShadowParameters(this.m_dropShadowX, this.m_dropShadowY, this.m_dropShadowRadius, this.m_dropShadowColor);
      flags1 |= 1;
    }
    if (this.m_iPhoneRenderingStyle == 2)
      flags1 |= 2;
    else if (this.m_iPhoneRenderingStyle == 3)
    {
      g.drawSubstring(str, offset, len, x, y, anchor, flags1);
      int flags2 = 2;
      g.setColor(this.m_strokeColor);
      g.drawSubstring(str, offset, len, x, y, anchor, flags2);
      return;
    }
    g.drawSubstring(str, offset, len, x, y, anchor, flags1);
  }

  public override int stringWidth(string str)
  {
    return this.m_font.stringWidth(str);
  }

  public override int substringWidth(string str, int offset, int length)
  {
    return this.m_font.substringWidth(str, offset, length);
  }

  public override int getHeight()
  {
    return this.m_font.getHeight();
  }

  public override void getStringTexturePadding(ref int x0, ref int x1, ref int y0, ref int y1)
  {
    if (this.m_enableDropShadow)
    {
      if (this.m_dropShadowX > 0)
      {
        x0 = this.m_dropShadowRadius - this.m_dropShadowX;
        if (x0 < 0)
          x0 = 0;
        x1 = this.m_dropShadowX + this.m_dropShadowRadius;
      }
      else
      {
        x0 = this.m_dropShadowRadius - this.m_dropShadowX;
        x1 = this.m_dropShadowRadius + this.m_dropShadowX;
        if (x1 < 0)
          x1 = 0;
      }
      if (this.m_dropShadowY > 0)
      {
        y1 = this.m_dropShadowRadius - this.m_dropShadowY;
        y0 = this.m_dropShadowY + this.m_dropShadowRadius;
        if (y1 >= 0)
          return;
        y1 = 0;
      }
      else
      {
        y1 = this.m_dropShadowRadius - this.m_dropShadowY;
        y0 = this.m_dropShadowRadius + this.m_dropShadowY;
        if (y0 >= 0)
          return;
        y0 = 0;
      }
    }
    else
    {
      x0 = 0;
      x1 = 0;
      y0 = 0;
      y1 = 0;
    }
  }

  public virtual void setIPhoneRenderingStyle(int renderingstyle)
  {
    if (renderingstyle != 1 && renderingstyle != 2 && renderingstyle != 3)
      return;
    this.m_iPhoneRenderingStyle = renderingstyle;
  }

  public virtual void useIPhoneFontDropShadow(bool enabled)
  {
    this.m_enableDropShadow = enabled;
  }

  public virtual void setIPhoneDropShadowParameters(int xoffset, int yoffset, int blurradius)
  {
    this.m_dropShadowX = xoffset;
    this.m_dropShadowY = -yoffset;
    this.m_dropShadowRadius = blurradius;
  }

  public virtual void setIPhoneDropShadowColor(int colour)
  {
    this.m_dropShadowColor = colour;
  }

  public void setStrokeColor(int color)
  {
    this.m_strokeColor = color;
  }

  public int getStrokeColor()
  {
    return this.m_strokeColor;
  }
}
