// Decompiled with JetBrains decompiler
// Type: m3g.AppearanceBase
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class AppearanceBase : Object3D
  {
    private int m_layer;
    private LineMode m_lineMode;
    private PolygonMode m_polygonMode;
    private CompositingMode m_compositingMode;

    protected AppearanceBase()
    {
      this.m_layer = 0;
      this.m_lineMode = (LineMode) null;
      this.m_polygonMode = (PolygonMode) null;
      this.m_compositingMode = (CompositingMode) null;
    }

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      AppearanceBase appearanceBase = (AppearanceBase) ret;
      appearanceBase.setLayer(this.getLayer());
      appearanceBase.setCompositingMode(this.getCompositingMode());
      appearanceBase.setPolygonMode(this.getPolygonMode());
      appearanceBase.setLineMode(this.getLineMode());
    }

    public override int getReferences(ref Object3D[] references)
    {
      int references1 = base.getReferences(ref references);
      int num1 = references1;
      if (this.m_compositingMode != null)
        ++references1;
      if (this.m_polygonMode != null)
        ++references1;
      if (this.m_lineMode != null)
        ++references1;
      if (references != null)
      {
        if (this.m_compositingMode != null)
          references[num1++] = (Object3D) this.m_compositingMode;
        if (this.m_polygonMode != null)
          references[num1++] = (Object3D) this.m_polygonMode;
        if (this.m_lineMode != null)
        {
          Object3D[] object3DArray = references;
          int index = num1;
          int num2 = index + 1;
          LineMode lineMode = this.m_lineMode;
          object3DArray[index] = (Object3D) lineMode;
        }
      }
      return references1;
    }

    public void setLayer(int layer)
    {
      this.m_layer = layer;
    }

    public int getLayer()
    {
      return this.m_layer;
    }

    public void setCompositingMode(CompositingMode compositingMode)
    {
      this.m_compositingMode = compositingMode;
    }

    public CompositingMode getCompositingMode()
    {
      return this.m_compositingMode;
    }

    public void setPolygonMode(PolygonMode polygonMode)
    {
      this.m_polygonMode = polygonMode;
    }

    public PolygonMode getPolygonMode()
    {
      return this.m_polygonMode;
    }

    public void setLineMode(LineMode lineMode)
    {
      this.m_lineMode = lineMode;
    }

    public LineMode getLineMode()
    {
      return this.m_lineMode;
    }
  }
}
