// Decompiled with JetBrains decompiler
// Type: midp.Font
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace midp
{
  public class Font
  {
    private readonly List<Vector2> lineMeasurements = new List<Vector2>();
    private Vector2 temp = Vector2.Zero;
    public const int FACE_SYSTEM = 0;
    public const int FACE_MONOSPACE = 32;
    public const int FACE_PROPORTIONAL = 64;
    public const int FONT_STATIC_TEXT = 0;
    public const int FONT_INPUT_TEXT = 1;
    public const int SIZE_MEDIUM = 0;
    public const int SIZE_SMALL = 8;
    public const int SIZE_LARGE = 16;
    public const int STYLE_PLAIN = 0;
    public const int STYLE_BOLD = 1;
    public const int STYLE_ITALIC = 2;
    public const int STYLE_UNDERLINED = 4;
    private string temp_str;
    private string[] temp_strArr;
    private StringBuffer temp_sbuff;
    private Vector2 temp_v2;
    private StringBuilder temp_sbuild;

    public int LineSpacing
    {
      get
      {
        return this.spriteFont.LineSpacing;
      }
    }

    public SpriteFont spriteFont { get; set; }

    public Color Color { get; set; }

    public Font(SpriteFont fnt)
    {
      this.spriteFont = fnt;
      this.Color = Color.White;
    }

    public void DrawString(midp.Graphics g, string text, Vector2 position, int anchor)
    {
      this.DrawString(g, text, position.X, position.Y, anchor, this.Color);
    }

    public void DrawString(midp.Graphics g, string text, float x, float y, int anchor)
    {
      this.DrawString(g, text, x, y, anchor, this.Color);
    }

    public void DrawString(midp.Graphics g, string text, float x, float y, int anchor, Color color)
    {
      x += (float) g.Translate.X;
      y += (float) g.Translate.Y;
      this.temp_v2 = this.spriteFont.MeasureString(text);
      int lineSpacing = this.spriteFont.LineSpacing;
      float num1 = x;
      float num2 = y;
      if ((anchor & 16) != 0)
        num1 -= this.temp_v2.X / 2f;
      else if ((anchor & 32) != 0)
        num1 -= this.temp_v2.X;
      if ((anchor & 2) != 0)
        num2 -= this.temp_v2.Y / 2f;
      else if ((anchor & 4) != 0)
        num2 -= this.temp_v2.Y;
      this.temp.X = num1 + -1f;
      this.temp.Y = num2 + -1f;
      g.spriteBatch.DrawString(this.spriteFont, text, this.temp, new Color((int) Color.Black.R, (int) Color.Black.G, (int) Color.Black.B) * (float) ((double) color.A * 1.0 / (double) byte.MaxValue));
    }

    public void DrawMultiLineString(midp.Graphics g, string text, float x, float y, int anchor)
    {
      this.DrawMultiLineString(g, text, x, y, anchor, this.Color);
    }

    public void DrawMultiLineString(
      midp.Graphics g,
      string text,
      float x,
      float y,
      int anchor,
      Color color)
    {
      x += (float) g.Translate.X;
      y += (float) g.Translate.Y;
      this.temp_strArr = text.Split('\n');
      float num1 = 0.0f;
      this.lineMeasurements.Capacity = this.temp_strArr.Length;
      foreach (string text1 in this.temp_strArr)
      {
        this.lineMeasurements.Add(this.spriteFont.MeasureString(text1));
        num1 += (float) this.spriteFont.LineSpacing;
      }
      if ((anchor & 4) != 0)
        y -= num1;
      if ((anchor & 2) != 0)
        y -= num1 / 2f;
      for (int index = 0; index < this.temp_strArr.Length; ++index)
      {
        float num2 = x;
        float num3 = y;
        if ((anchor & 16) != 0)
          num2 -= this.lineMeasurements[index].X / 2f;
        else if ((anchor & 32) != 0)
          num2 -= this.lineMeasurements[index].X;
        this.temp.X = (float) ((int) num2 + 1);
        this.temp.Y = (float) ((int) num3 + 1);
        g.spriteBatch.DrawString(this.spriteFont, text, this.temp, new Color((int) Color.Black.R, (int) Color.Black.G, (int) Color.Black.B) * (float) ((double) color.A * 1.0 / (double) byte.MaxValue));
        y += (float) this.spriteFont.LineSpacing;
      }
      this.lineMeasurements.Clear();
    }

    public string WrapString(string text, int width)
    {
      int length = text.Length;
      float num1 = 0.0f;
      float x = this.spriteFont.MeasureString(" ").X;
      this.temp_sbuild = new StringBuilder(text);
      for (int index1 = 0; index1 < length; ++index1)
      {
        if (this.temp_sbuild[index1] == ' ')
        {
          int index2 = index1 + 1;
          float num2 = 0.0f;
          if (index2 < length)
          {
            while (this.temp_sbuild[index2] != ' ' && this.temp_sbuild[index2] != '\n' && (double) num1 + (double) num2 <= (double) width)
            {
              Vector2 vector2 = this.spriteFont.MeasureString(this.temp_sbuild[index2].ToString());
              num2 += vector2.X + this.spriteFont.Spacing;
              if (++index2 >= length)
                break;
            }
          }
          if ((double) num1 + (double) num2 + (double) x + (double) this.spriteFont.Spacing > (double) width)
            this.temp_sbuild[index1] = '\n';
          else
            num1 += x + this.spriteFont.Spacing;
        }
        if (this.temp_sbuild[index1] != ' ' && this.temp_sbuild[index1] != '\n')
        {
          Vector2 vector2 = this.spriteFont.MeasureString(this.temp_sbuild[index1].ToString());
          num1 += vector2.X + this.spriteFont.Spacing;
        }
        else if (this.temp_sbuild[index1] == '\n')
          num1 = 0.0f;
      }
      return this.temp_sbuild.ToString();
    }

    public Vector2 MeasureString(string text)
    {
      return this.spriteFont.MeasureString(text);
    }

    public int stringWidth(string str)
    {
      return (int) this.MeasureString(str).X;
    }

    internal static Font getDefaultFont()
    {
      return new Font(JavaLib.contentManager.Load<SpriteFont>("HelveticaPlain9"));
    }

    public static Font getFont(int face, int style, float size)
    {
      if (face == 0)
      {
        switch (style)
        {
          case 0:
            switch ((int) size)
            {
              case 9:
                return new Font(JavaLib.contentManager.Load<SpriteFont>("HelveticaPlain9"));
              case 12:
                return new Font(JavaLib.contentManager.Load<SpriteFont>("HelveticaPlain12"));
            }
            break;
          case 1:
            switch ((int) size)
            {
              case 12:
                return new Font(JavaLib.contentManager.Load<SpriteFont>("HelveticaBold12"));
              case 15:
                return new Font(JavaLib.contentManager.Load<SpriteFont>("HelveticaBold15"));
            }
            break;
        }
      }
      return Font.getDefaultFont();
    }

    public int charsWidth(ushort[] ch, int offset, int length)
    {
      return 0;
    }

    public int charWidth(ushort chr)
    {
      return (int) this.spriteFont.MeasureString(((char) chr).ToString()).X + (int) this.spriteFont.Spacing;
    }

    public int getBaselinePosition()
    {
      return 0;
    }

    public int substringWidth(string str, int offset, int length)
    {
      this.temp_str = str.Substring(offset, length);
      this.temp_sbuild = new StringBuilder(this.temp_str);
      return (int) this.spriteFont.MeasureString(this.temp_sbuild).X;
    }

    public int getHeight()
    {
      return this.spriteFont.LineSpacing;
    }
  }
}
