// Decompiled with JetBrains decompiler
// Type: house.PlaceableObject
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace house
{
  public abstract class PlaceableObject : HouseEditorObject
  {
    private int m_x;
    private int m_y;
    private int m_width;
    private int m_height;

    public static void requireValidPosition(int x, int y)
    {
    }

    public static void requireValidSize(int width, int height)
    {
    }

    public PlaceableObject()
    {
      this.m_x = 0;
      this.m_y = 0;
      this.m_width = 1;
      this.m_height = 1;
    }

    public PlaceableObject(int x, int y)
    {
      this.m_x = 0;
      this.m_y = 0;
      this.m_width = 1;
      this.m_height = 1;
      this.setPosition(x, y);
    }

    public PlaceableObject(int x, int y, int width, int height)
    {
      this.m_x = 0;
      this.m_y = 0;
      this.m_width = 1;
      this.m_height = 1;
      this.setPosition(x, y);
      this.setSize(width, height);
    }

    public new void Dispose()
    {
      base.Dispose();
    }

    public int getX()
    {
      return this.m_x;
    }

    public int getY()
    {
      return this.m_y;
    }

    public int getWidth()
    {
      return this.m_width;
    }

    public int getHeight()
    {
      return this.m_height;
    }

    public void setPosition(int x, int y)
    {
      PlaceableObject.requireValidPosition(x, y);
      this.m_x = x;
      this.m_y = y;
    }

    public virtual void setSize(int width, int height)
    {
      width = JMath.max(1, width);
      height = JMath.max(1, height);
      PlaceableObject.requireValidSize(width, height);
      this.m_width = width;
      this.m_height = height;
    }

    public abstract void writexml(OutputStream _out);
  }
}
