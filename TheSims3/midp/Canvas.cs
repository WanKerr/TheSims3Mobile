// Decompiled with JetBrains decompiler
// Type: midp.Canvas
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace midp
{
  public abstract class Canvas : Displayable
  {
    public const int UP = 1;
    public const int LEFT = 2;
    public const int RIGHT = 5;
    public const int DOWN = 6;
    public const int FIRE = 8;
    public const int GAME_A = 9;
    public const int GAME_B = 10;
    public const int GAME_C = 11;
    public const int GAME_D = 12;
    public const int KEY_POUND = 35;
    public const int KEY_STAR = 42;
    public const int KEY_NUM0 = 48;
    public const int KEY_NUM1 = 49;
    public const int KEY_NUM2 = 50;
    public const int KEY_NUM3 = 51;
    public const int KEY_NUM4 = 52;
    public const int KEY_NUM5 = 53;
    public const int KEY_NUM6 = 54;
    public const int KEY_NUM7 = 55;
    public const int KEY_NUM8 = 56;
    public const int KEY_NUM9 = 57;

    internal override void OnPaint(Graphics g)
    {
      this.paint(g);
    }

    internal override void OnKeyPressed(int key)
    {
      this.keyPressed(key);
    }

    internal override void OnKeyReleased(int key)
    {
      this.keyReleased(key);
    }

    internal override void OnKeyRepeated(int key)
    {
      this.keyRepeated(key);
    }

    internal override void OnPointerPressed(int x, int y, int pointerNum, int tapCount)
    {
      this.pointerPressed(x, y, pointerNum, tapCount);
    }

    internal override void OnPointerReleased(int x, int y, int pointerNum, int tapCount)
    {
      this.pointerReleased(x, y, pointerNum, tapCount);
    }

    internal override void OnPointerDragged(int x, int y, int pointerNum, int tapCount)
    {
      this.pointerDragged(x, y, pointerNum, tapCount);
    }

    public abstract void pointerPressed(int x, int y, int pointerNum, int tapCount);

    public abstract void pointerReleased(int x, int y, int pointerNum, int tapCount);

    public abstract void pointerDragged(int x, int y, int pointerNum, int tapCount);

    public void serviceRepaints()
    {
      this.currentDisplay.serviceRepaints();
    }

    protected abstract void paint(Graphics g);

    public int getGameAction(int keyCode)
    {
      switch (keyCode)
      {
        case 1:
        case 2:
        case 5:
        case 6:
        case 8:
        case 9:
        case 10:
        case 11:
        case 12:
          return keyCode;
        case 35:
        case 42:
        case 48:
        case 49:
        case 51:
        case 55:
        case 57:
          return 0;
        case 50:
          return 1;
        case 52:
          return 2;
        case 53:
          return 8;
        case 54:
          return 5;
        case 56:
          return 6;
        default:
          return 0;
      }
    }

    internal virtual void pointerDragged(int x, int y)
    {
    }

    public virtual bool hasPointerEvents()
    {
      return true;
    }

    public virtual bool hasPointerMotionEvents()
    {
      return true;
    }

    public void repaint()
    {
      this.repaint(0, 0, this.getWidth(), this.getHeight());
    }

    public void repaint(int x, int y, int width, int height)
    {
      this.currentDisplay.repaint(x, y, width, height);
    }
  }
}
