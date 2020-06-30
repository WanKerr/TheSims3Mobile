// Decompiled with JetBrains decompiler
// Type: midp.Display
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sims3;

namespace midp
{
  public class Display
  {
    private int[] clip = new int[4];
    public const int ORIENTATION_PORTRAIT_RIGHT = 0;
    public const int ORIENTATION_PORTRAIT_LEFT = 1;
    public const int ORIENTATION_LANDSCAPE_RIGHT = 2;
    public const int ORIENTATION_LANDSCAPE_LEFT = 3;
    private midp.Graphics backBuffer;
    private GraphicsDevice device;
    private SpriteBatch spriteBatch;
    private Texture2D backgroundTexture;
    internal int width;
    internal int height;
    internal Displayable current;
    internal int orientation;

    internal Display(GraphicsDevice device)
    {
      this.device = device;            
      this.height = TheSims3.target.Height;
      this.width = TheSims3.target.Width;
      this.spriteBatch = new SpriteBatch(device);
      this.backBuffer = new midp.Graphics(JavaLibGame.GraphicsDeviceManager, this.spriteBatch, this.width, this.height);
      this.clip[0] = 0;
      this.clip[1] = 0;
      this.clip[2] = this.width;
      this.clip[3] = this.height;
      this.backgroundTexture = new Texture2D(device, this.width, this.height);
      device.SetRenderTarget(TheSims3.currentTarget);
      device.Clear(Color.Black);
      this.orientation = 2;
      this.backBuffer.isLandscape = true;
    }

    public void repaint(int x, int y, int width, int height)
    {
      this.clip[0] = System.Math.Min(this.clip[0], x);
      this.clip[1] = System.Math.Min(this.clip[1], y);
      this.clip[2] = System.Math.Max(this.clip[2], width);
      this.clip[3] = System.Math.Max(this.clip[3], height);
    }

    public void serviceRepaints()
    {
      if (this.current != null)
        this.current.OnPaint(this.backBuffer);
      if (this.backBuffer == null)
        return;
      this.device.Textures[0] = (Texture) null;
    }

    public bool vibrate(int duration)
    {
      return true;
    }

    public static Display getDisplay(MIDlet midlet)
    {
      return midlet.Display;
    }

    public void setCurrent(Displayable nextDisplayable)
    {
      if (this.current != null)
        this.current.hideNotify();
      this.current = nextDisplayable;
      if (this.current == null)
        return;
      this.current.currentDisplay = this;
      this.current.showNotify();
    }

    public Displayable getCurrent()
    {
      return this.current;
    }

    public SpriteBatch getSpriteBatch()
    {
      return this.spriteBatch;
    }

    public void setOrientation(int orientation)
    {
      this.orientation = orientation;
    }

    public int getOrientation()
    {
      return this.orientation;
    }
  }
}
