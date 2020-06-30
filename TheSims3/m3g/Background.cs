// Decompiled with JetBrains decompiler
// Type: m3g.Background
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class Background : Object3D
  {
    public new const int M3G_UNIQUE_CLASS_ID = 4;
    private int m_color;
    private bool m_colorClearEnabled;
    private bool m_depthClearEnabled;

    public Background()
    {
      this.m_color = 0;
      this.m_colorClearEnabled = true;
      this.m_depthClearEnabled = true;
    }

    public int getColor()
    {
      return this.m_color;
    }

    public bool isColorClearEnabled()
    {
      return this.m_colorClearEnabled;
    }

    public bool isDepthClearEnabled()
    {
      return this.m_depthClearEnabled;
    }

    public void setColor(int rgba)
    {
      this.m_color = rgba;
    }

    public void setColorClearEnable(bool onoff)
    {
      this.m_colorClearEnabled = onoff;
    }

    public void setDepthClearEnable(bool onoff)
    {
      this.m_depthClearEnabled = onoff;
    }

    public override int getM3GUniqueClassID()
    {
      return 4;
    }
  }
}
