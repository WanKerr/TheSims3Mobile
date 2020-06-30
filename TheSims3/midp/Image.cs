// Decompiled with JetBrains decompiler
// Type: midp.Image
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework.Graphics;
using System;

namespace midp
{
  public class Image
  {
    public string Name = "?";
    private int[] pixelData;
    private midp.Graphics graphics;

    public Texture2D texture2D { get; set; }

    public int[] PixelData
    {
      get
      {
        if (this.pixelData == null)
        {
          this.pixelData = new int[this.getWidth() * this.getHeight()];
          try
          {
            this.texture2D.GetData<int>(this.pixelData);
          }
          catch (Exception ex)
          {
          }
        }
        return this.pixelData;
      }
    }

    public Image(int width, int height)
    {
      this.texture2D = new Texture2D(JavaLib.GraphicsDevice, width, height);
    }

    public Image(Texture2D texture)
    {
      this.texture2D = texture;
    }

    public Image()
    {
    }

    public virtual int getWidth()
    {
      return this.texture2D.Width;
    }

    public virtual int getHeight()
    {
      return this.texture2D.Height;
    }

    public virtual midp.Graphics getGraphics()
    {
      if (this.graphics == null)
        this.graphics = new midp.Graphics(JavaLibGame.GraphicsDeviceManager, Display.getDisplay(JavaLib.MIDlet).getSpriteBatch(), this.getWidth(), this.getHeight(), this.texture2D);
      return this.graphics;
    }

    internal void getRGB(
      ref int[] rgbData,
      int offset,
      int scanlength,
      int x,
      int y,
      int width,
      int height)
    {
      if (rgbData == null)
        rgbData = new int[this.getWidth() * this.getHeight()];
      for (int index1 = y; index1 < y + height; ++index1)
      {
        int[] numArray = new int[this.getWidth()];
        Array.Copy((Array) this.PixelData, index1 * this.getWidth(), (Array) numArray, 0, this.getWidth());
        for (int index2 = x; index2 < x + width; ++index2)
        {
          int num = numArray[index2];
          rgbData[offset + (index2 - x) + (index1 - y) * scanlength] = num;
        }
      }
    }

    public static Image createImage(string name)
    {
      return JavaLib.createImage(name);
    }

    public static Image createImage(int width, int height)
    {
      return new Image(width, height);
    }

    internal static Image createRGBImage(int[] imageData, int width, int height, bool p)
    {
      Image image = new Image(width, height);
      image.texture2D.SetData<int>(imageData);
      return image;
    }
  }
}
