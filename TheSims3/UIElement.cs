// Decompiled with JetBrains decompiler
// Type: UIElement
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

public abstract class UIElement
{
  public const int FLAG_SETUP = 1;
  public const int FLAG_INIT = 2;
  private int m_flags;

  public UIElement()
  {
    this.m_flags = 0;
  }

  public void Dispose()
  {
  }

  protected Scene getScene()
  {
    return AppEngine.getCanvas().getScene();
  }

  protected void setup()
  {
    this.setFlag(1);
  }

  public void setFlag(int flag)
  {
    this.m_flags |= flag;
  }

  public void unsetFlag(int flag)
  {
    this.m_flags &= ~flag;
  }

  public bool getFlag(int flag)
  {
    return (this.m_flags & flag) != 0;
  }

  public void clear()
  {
    this.unsetFlag(1);
  }

  public abstract void processInput(int _event, int[] args);

  public abstract void update(int timeStep);

  public virtual void onLostInput()
  {
  }

  public static bool isInRadius(int x, int y, int centerX, int centerY, int radius)
  {
    int num1 = x - centerX;
    int num2 = y - centerY;
    int num3 = num1 * num1 + num2 * num2;
    return radius * radius >= num3;
  }

  public static bool isInBox(int x, int y, int rectX, int rectY, int rectW, int rectH)
  {
    return x >= rectX && y >= rectY && x < rectX + rectW && y < rectY + rectH;
  }
}
