// Decompiled with JetBrains decompiler
// Type: midp.Displayable
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace midp
{
  public abstract class Displayable
  {
    internal Display currentDisplay;

    internal abstract void OnPaint(Graphics g);

    internal abstract void OnKeyPressed(int key);

    internal abstract void OnKeyRepeated(int key);

    internal abstract void OnKeyReleased(int key);

    internal abstract void OnPointerPressed(int x, int y, int pointerNum, int tapCount);

    internal abstract void OnPointerReleased(int x, int y, int pointerNum, int tapCount);

    internal abstract void OnPointerDragged(int x, int y, int pointerNum, int tapCount);

    internal virtual void keyPressed(int key)
    {
    }

    internal virtual void keyRepeated(int key)
    {
    }

    internal virtual void keyReleased(int key)
    {
    }

    internal virtual void pointerPressed(int x, int y)
    {
    }

    internal virtual void pointerReleased(int x, int y)
    {
    }

    public bool isShown()
    {
      return this.currentDisplay != null;
    }

    public virtual int getWidth()
    {
      switch (this.currentDisplay.orientation)
      {
        case 0:
        case 1:
          return this.currentDisplay.width;
        case 2:
        case 3:
          return this.currentDisplay.height;
        default:
          return this.currentDisplay.width;
      }
    }

    public virtual int getHeight()
    {
      switch (this.currentDisplay.orientation)
      {
        case 0:
        case 1:
          return this.currentDisplay.height;
        case 2:
        case 3:
          return this.currentDisplay.width;
        default:
          return this.currentDisplay.height;
      }
    }

    public virtual int getOrientation()
    {
      return this.currentDisplay.orientation;
    }

    public virtual void transformRect(ref int[] rect)
    {
      int num1 = rect[0];
      int num2 = rect[1];
      int num3 = rect[2];
      int num4 = rect[3];
      switch (this.getOrientation())
      {
        case 1:
          rect[0] = this.currentDisplay.width - num1 - num3;
          rect[1] = this.currentDisplay.height - num2 - num4;
          break;
        case 2:
          rect[0] = this.currentDisplay.width - num2 - num4;
          rect[1] = num1;
          rect[2] = num4;
          rect[3] = num3;
          break;
        case 3:
          rect[0] = num2;
          rect[1] = this.currentDisplay.height - num1 - num3;
          rect[2] = num4;
          rect[3] = num3;
          break;
      }
    }

    public virtual void orientationChanged(int orientation)
    {
      this.currentDisplay.orientation = orientation;
    }

    public virtual void showNotify()
    {
      this.orientationChanged(2);
    }

    public virtual void hideNotify()
    {
    }

    public Display getDisplay()
    {
      return this.currentDisplay;
    }
  }
}
