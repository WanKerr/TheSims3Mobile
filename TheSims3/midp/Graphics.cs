// Decompiled with JetBrains decompiler
// Type: midp.Graphics
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace midp
{
  public class Graphics
  {
    private Matrix rotationMatrix = Matrix.Identity;
    public const int BASELINE = 64;
    public const int TOP = 1;
    public const int VCENTER = 2;
    public const int BOTTOM = 4;
    public const int LEFT = 8;
    public const int HCENTER = 16;
    public const int RIGHT = 32;
    public const int TRANS_MIRROR = 64;
    public const int TRANS_FLIP = 128;
    public const int IPHONE_FONT_RENDERING_DROPSHADOW = 1;
    public const int IPHONE_FONT_RENDERING_OUTLINE = 2;
    private Font m_font;
    public bool isLandscape;
    public Matrix lanscapeTransform;
    public GraphicsDeviceManager graphicsManager;
    public SpriteBatch spriteBatch;
    private BasicEffect effect;
    private Rectangle clip;
    private Texture2D blankTexture;
    private RasterizerState rs;
    private Color fadeColor;
    private float fadeNormal;
    private int m_currentDropShadowX;
    private int m_currentDropShadowY;
    private int m_currentDropShadowRadius;
    private int m_dropShadowColour;
    private Image imgTimer;

    public Color Color { get; set; }

    public Point Translate { get; set; }

    public Color FadeColor
    {
      set
      {
        this.fadeColor = value;
      }
      get
      {
        return this.fadeColor;
      }
    }

    public float FadeNormal
    {
      set
      {
        this.fadeNormal = MathHelper.Clamp(value, 0.0f, 1f);
      }
      get
      {
        return this.fadeNormal;
      }
    }

    internal Graphics(GraphicsDeviceManager graphicsManager, SpriteBatch spriteBatch)
    {
      Texture2D texture = new Texture2D(graphicsManager.GraphicsDevice, 1, 1);
      texture.SetData<Color>(new Color[1]
      {
        Color.White
      });
      this.init(graphicsManager, spriteBatch, 1, 1, texture);
    }

    internal Graphics(
      GraphicsDeviceManager graphicsManager,
      SpriteBatch spriteBatch,
      int width,
      int height)
    {
      Texture2D texture = new Texture2D(graphicsManager.GraphicsDevice, width, height);
      Color[] data = new Color[width * height];
      for (int index = 0; index < data.Length; ++index)
        data[index] = Color.White;
      texture.SetData<Color>(data);
      this.init(graphicsManager, spriteBatch, width, height, texture);
    }

    internal Graphics(
      GraphicsDeviceManager graphicsManager,
      SpriteBatch spriteBatch,
      int width,
      int height,
      Texture2D texture)
    {
      this.init(graphicsManager, spriteBatch, width, height, texture);
    }

    private void init(
      GraphicsDeviceManager graphicsManager,
      SpriteBatch spriteBatch,
      int width,
      int height,
      Texture2D texture)
    {
      this.graphicsManager = graphicsManager;
      this.spriteBatch = spriteBatch;
      this.effect = new BasicEffect(graphicsManager.GraphicsDevice);
      this.lanscapeTransform = Matrix.CreateRotationZ(1.570796f) * Matrix.CreateTranslation((float) width, 0.0f, 0.0f);
      this.blankTexture = texture;
      this.setClip(0, 0, graphicsManager.GraphicsDevice.Viewport.Width, graphicsManager.GraphicsDevice.Viewport.Height);
      this.Color = Color.White;
      this.rs = new RasterizerState();
      this.rs.ScissorTestEnable = true;
    }

    public void Begin()
    {
      if (this.isLandscape)
        this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, (SamplerState) null, (DepthStencilState) null, this.rs, (Effect) null, this.lanscapeTransform);
      else
        this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
    }

    public void Begin(Matrix transformMatrix)
    {
      this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
    }

    public void End()
    {
      this.spriteBatch.End();
    }

    internal void setClip(int x, int y, int w, int h)
    {
      this.clip = new Rectangle(x, y, w, h);
      x = JMath.max(0, x);
      y = JMath.max(0, y);
      w = x + w > 320 ? 320 - x : w;
      h = y + h > 533 ? 533 - y : h;
      JavaLib.GraphicsDevice.ScissorRectangle = new Rectangle(x, y, w, h);
    }

    internal void setClip(Rectangle rect)
    {
      this.setClip(rect.X, rect.Y, rect.Width, rect.Height);
    }

    internal void clipRect(int x, int y, int w, int h)
    {
      this.setClip(x, y, w, h);
    }

    public Rectangle getClip()
    {
      return new Rectangle(this.clip.X, this.clip.Y, this.clip.Width, this.clip.Height);
    }

    public int getClipX()
    {
      return this.clip.X;
    }

    public int getClipY()
    {
      return this.clip.Y;
    }

    public int getClipWidth()
    {
      return this.clip.Width;
    }

    public int getClipHeight()
    {
      return this.clip.Height;
    }

    internal void drawImage(Image image, float x, float y, int anchor)
    {
      float x1 = x;
      float y1 = y;
      if ((anchor & 16) != 0)
        x1 -= (float) (image.getWidth() / 2);
      else if ((anchor & 32) != 0)
        x1 -= (float) image.getWidth();
      if ((anchor & 2) != 0)
        y1 -= (float) (image.getHeight() / 2);
      else if ((anchor & 4) != 0)
        y1 -= (float) image.getHeight();
      this.spriteBatch.Draw(image.texture2D, new Vector2(x1, y1), Color.White);
    }

    internal void drawImage(Image image, Vector2 point, int anchor)
    {
      this.drawImage(image, point.X, point.Y, new Rectangle(0, 0, image.getWidth(), image.getHeight()), anchor, byte.MaxValue);
    }

    internal void drawImage(Image image, float x, float y, int anchor, byte alpha)
    {
      this.drawImage(image, x, y, new Rectangle(0, 0, image.getWidth(), image.getHeight()), anchor, alpha);
    }

    internal void drawImage(Image image, float x, float y, Rectangle clip, int anchor)
    {
      this.drawImage(image, x, y, clip, anchor, byte.MaxValue);
    }

    internal void drawImage(
      Image image,
      float x,
      float y,
      Rectangle clip,
      int anchor,
      byte alpha)
    {
      if (alpha <= (byte) 0)
        return;
      this.drawImage(image, x, y, clip, anchor, 16777215, 0.0f, alpha);
    }

    internal void drawImage(
      Image image,
      float x,
      float y,
      int anchor,
      float rotation,
      byte alpha)
    {
      if ((double) rotation == 0.0 && alpha == byte.MaxValue)
      {
        this.drawImage(image, x, y, anchor);
      }
      else
      {
        if (alpha <= (byte) 0)
          return;
        this.drawImage(image, x, y, new Rectangle(0, 0, image.getWidth(), image.getHeight()), anchor, 16777215, rotation, alpha);
      }
    }

    internal void drawImage(
      Image image,
      float x,
      float y,
      int anchor,
      int color,
      float rotation,
      byte alpha)
    {
      if (alpha <= (byte) 0)
        return;
      this.drawImage(image, x, y, new Rectangle(0, 0, image.getWidth(), image.getHeight()), anchor, color, rotation, alpha);
    }

    internal void drawImage(
      Image image,
      float x,
      float y,
      Rectangle clip,
      int anchor,
      int color,
      byte alpha)
    {
      if (alpha <= (byte) 0)
        return;
      this.drawImage(image, x, y, clip, anchor, color, 0.0f, alpha);
    }

    internal void drawImage(Image image, Rectangle destination, Color color)
    {
      destination.Offset(this.Translate.X, this.Translate.Y);
      this.spriteBatch.Draw(image.texture2D, destination, color);
    }

    internal void drawImage(Image image, Rectangle destination, Rectangle source, Color color)
    {
      destination.Offset(this.Translate.X, this.Translate.Y);
      this.spriteBatch.Draw(image.texture2D, destination, new Rectangle?(source), color);
    }

    internal void drawImage(
      Image image,
      float x,
      float y,
      Rectangle clip,
      int anchor,
      int color,
      float rotation,
      byte alpha)
    {
      if (alpha == (byte) 0)
        return;
      x += (float) this.Translate.X;
      y += (float) this.Translate.Y;
      SpriteEffects effects = SpriteEffects.None;
      if ((anchor & 16) != 0)
        x -= (float) (clip.Width / 2);
      else if ((anchor & 32) != 0)
        x -= (float) clip.Width;
      if ((anchor & 2) != 0)
        y -= (float) (clip.Height / 2);
      else if ((anchor & 4) != 0)
        y -= (float) clip.Height;
      if ((anchor & 64) != 0)
        effects = SpriteEffects.FlipHorizontally;
      if ((anchor & 128) != 0)
        effects = SpriteEffects.FlipVertically;
      Rectangle rectangle = new Rectangle(clip.X, clip.Y, System.Math.Min(clip.Width, image.getWidth()), System.Math.Min(clip.Height, image.getHeight()));
      byte num1 = (byte) (color >> 16 & (int) byte.MaxValue);
      byte num2 = (byte) (color >> 8 & (int) byte.MaxValue);
      byte num3 = (byte) (color & (int) byte.MaxValue);
      Vector2 vector2_1 = new Vector2((float) (rectangle.Width / 2), (float) (rectangle.Height / 2));
      Vector2 vector2_2 = new Vector2((float) (int) x, (float) (int) y);
      this.spriteBatch.Draw(image.texture2D, new Rectangle((int) vector2_2.X, (int) vector2_2.Y, rectangle.Width, rectangle.Height), new Rectangle?(rectangle), new Color((int) num1, (int) num2, (int) num3, (int) alpha), rotation, new Vector2(0.0f, 0.0f), effects, 1f);
    }

    internal void fillRect(float x, float y, float w, float h)
    {
      this.fillRect(new Rectangle((int) x, (int) y, (int) w, (int) h));
    }

    internal void fillRect(int x, int y, int w, int h)
    {
      this.fillRect(new Rectangle(x, y, w, h));
    }

    internal void fillRect(Rectangle rect)
    {
      rect.X += this.Translate.X;
      rect.Y += this.Translate.Y;
      this.spriteBatch.Draw(this.blankTexture, rect, this.Color);
    }

    internal void drawLine(float x1, float y1, float x2, float y2)
    {
      x1 += (float) this.Translate.X;
      y1 += (float) this.Translate.Y;
      x2 += (float) this.Translate.X;
      y2 += (float) this.Translate.Y;
      float num1 = System.Math.Max(System.Math.Abs(x2 - x1), 1f);
      float num2 = System.Math.Max(System.Math.Abs(y2 - y1), 1f);
      this.spriteBatch.Draw(this.blankTexture, new Rectangle((int) System.Math.Min(x1, x2), (int) System.Math.Min(y1, y2), (int) num1, (int) num2), this.Color);
    }

    internal void drawRect(Rectangle rect)
    {
      this.drawRect((float) rect.X, (float) rect.Y, (float) rect.Width, (float) rect.Height);
    }

    internal void drawRect(float x1, float y1, float w, float h)
    {
      float num1 = x1 + w;
      float num2 = y1 + h;
      this.drawLine(x1, y1, num1, y1);
      this.drawLine(num1, y1, num1, num2);
      this.drawLine(x1, num2, num1, num2);
      this.drawLine(x1, y1, x1, num2);
    }

    internal void Prepare(Color color)
    {
    }

    public void StartRotation(Matrix matrix)
    {
      this.rotationMatrix = matrix;
    }

    public void EndRotation()
    {
      this.rotationMatrix = Matrix.Identity;
    }

    public int getColor()
    {
      return ((int) this.Color.R << 24) + ((int) this.Color.G << 16) + ((int) this.Color.B << 8) + (int) this.Color.A;
    }

    public void setColor(int colorRGB)
    {
      this.Color = new Color(colorRGB >> 16 & (int) byte.MaxValue, colorRGB >> 8 & (int) byte.MaxValue, colorRGB & (int) byte.MaxValue);
    }

    public void setColor(int R, int G, int B)
    {
      this.Color = new Color(R, G, B);
    }

    public void setColor(int R, int G, int B, int A)
    {
      this.Color = new Color(R, G, B, A);
    }

    internal void drawArc(int posX, int posY, int width, int height, int p, int p_2)
    {
      throw new NotImplementedException();
    }

    internal void drawRegion(
      Image img,
      int x_src,
      int y_src,
      int width,
      int height,
      int transform,
      int x_dest,
      int y_dest,
      int anchor)
    {
      this.drawImage(img, (float) x_dest, (float) y_dest, new Rectangle(x_src, y_src, width, height), anchor, 16777215, 0.0f, byte.MaxValue);
    }

    internal void fillArc(
      int posX,
      int posY,
      int width,
      int height,
      int angleStart,
      int angleEnd)
    {
      this.drawTimer(posX, posY, JMath.abs(angleEnd - angleStart));
    }

    internal void drawTimer(int posX, int posY, int angle)
    {
      if (this.imgTimer == null)
        this.imgTimer = JavaLib.createImage("timer");
      int num = 7 - angle * 8 / 360;
      int width = this.imgTimer.getWidth() / 8;
      int height = this.imgTimer.getHeight();
      this.drawImage(this.imgTimer, new Rectangle(posX, posY, width, height), new Rectangle(num * width, 0, width, height), Color.White);
    }

    internal void fillTriangle(
      int posX1,
      int posY1,
      int posX2,
      int posY2,
      int posX1_2,
      int posY2_2)
    {
      throw new NotImplementedException();
    }

    public void setFont(Font font)
    {
      if (font == null)
        font = Font.getDefaultFont();
      this.m_font = font;
    }

    internal void drawString(string str, int x, int y, int anchor)
    {
      throw new NotImplementedException();
    }

    internal void drawString(string str, int x, int y, int anchor, int flags)
    {
      this.m_font.DrawString(this, str, (float) x, (float) y, anchor);
    }

    internal void drawSubstring(string str, int offset, int length, int x, int y, int anchor)
    {
      throw new NotImplementedException();
    }

    internal void drawSubstring(
      string str,
      int offset,
      int length,
      int x,
      int y,
      int anchor,
      int flags)
    {
      throw new NotImplementedException();
    }

    public void setFontDropShadowParameters(int xoffset, int yoffset, int radius, int colour)
    {
      this.m_currentDropShadowX = xoffset;
      this.m_currentDropShadowY = yoffset;
      this.m_currentDropShadowRadius = radius;
      this.m_dropShadowColour = colour;
    }
  }
}
