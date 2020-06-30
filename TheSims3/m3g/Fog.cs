// Decompiled with JetBrains decompiler
// Type: m3g.Fog
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class Fog : Object3D
  {
    public const int EXPONENTIAL = 80;
    public const int LINEAR = 81;
    public new const int M3G_UNIQUE_CLASS_ID = 7;
    private int m_mode;
    private float m_density;
    private float m_near;
    private float m_far;
    private int m_color;

    public Fog()
    {
      this.m_mode = 81;
      this.m_density = 1f;
      this.m_near = 0.0f;
      this.m_far = 1f;
      this.m_color = 0;
    }

    public int getColor()
    {
      return this.m_color;
    }

    public float getDensity()
    {
      return this.m_density;
    }

    public int getDensityx()
    {
      return (int) ((double) this.m_density * 65536.0);
    }

    public float getFarDistance()
    {
      return this.m_far;
    }

    public int getFarDistancex()
    {
      return (int) ((double) this.m_far * 65536.0);
    }

    public int getMode()
    {
      return this.m_mode;
    }

    public float getNearDistance()
    {
      return this.m_near;
    }

    public int getNearDistancex()
    {
      return (int) ((double) this.m_near * 65536.0);
    }

    public void setColor(int RGB)
    {
      this.m_color = RGB;
    }

    public void setDensity(float density)
    {
      this.m_density = density;
    }

    public void setLinear(float _near, float _far)
    {
      this.m_near = _near;
      this.m_far = _far;
    }

    public void setMode(int mode)
    {
      this.m_mode = mode;
    }

    public override int getM3GUniqueClassID()
    {
      return 7;
    }

    public static Fog m3g_cast(Object3D obj)
    {
      return obj.getM3GUniqueClassID() == 7 ? (Fog) obj : (Fog) null;
    }
  }
}
