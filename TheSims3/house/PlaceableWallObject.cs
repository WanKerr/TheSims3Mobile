// Decompiled with JetBrains decompiler
// Type: house.PlaceableWallObject
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace house
{
  public abstract class PlaceableWallObject : PlaceableObject
  {
    private int m_type;

    public static void requireValidType(int type)
    {
    }

    public PlaceableWallObject(int x, int y, int width, int type)
      : base(x, y, width, 2)
    {
      this.m_type = 0;
      this.setType(type);
    }

    public new void Dispose()
    {
      base.Dispose();
    }

    public int getType()
    {
      return this.m_type;
    }

    public void setType(int type)
    {
      PlaceableWallObject.requireValidType(type);
      this.m_type = type;
    }
  }
}
