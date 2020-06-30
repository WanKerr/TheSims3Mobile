// Decompiled with JetBrains decompiler
// Type: midp.MIDlet
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework.Graphics;

namespace midp
{
  public abstract class MIDlet
  {
    internal Display Display { get; set; }

    internal void Load(GraphicsDevice device)
    {
      this.Display = new Display(device);
    }

    public void notifyDestroyed()
    {
      JavaLib.Game.Exit();
    }

    protected internal abstract void startApp();

    protected internal abstract void pauseApp();

    protected internal abstract void destroyApp(bool unconditional);

    internal void setDisplay(Display display)
    {
      this.Display = display;
    }

    internal Display getDisplay()
    {
      return this.Display;
    }
  }
}
