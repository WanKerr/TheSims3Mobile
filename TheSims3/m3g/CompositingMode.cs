// Decompiled with JetBrains decompiler
// Type: m3g.CompositingMode
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class CompositingMode : Object3D
  {
    public const int ADD = 69;
    public const int ALPHA = 64;
    public const int ALPHA_ADD = 65;
    public const int ALPHA_DARKEN = 70;
    public const int ALPHA_PREMULTIPLIED = 71;
    public const int MODULATE = 66;
    public const int MODULATE_INV = 72;
    public const int MODULATE_X2 = 67;
    public const int REPLACE = 68;
    public new const int M3G_UNIQUE_CLASS_ID = 6;
    private int m_blending;
    private Blender m_blender;
    private int m_alphaThreshold;
    private bool m_depthTestEnabled;
    private bool m_depthWriteEnabled;
    private bool m_colorWriteEnabled;
    private bool m_alphaWriteEnabled;
    private int m_depthOffsetFactor;
    private int m_depthOffsetUnits;

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      CompositingMode compositingMode = (CompositingMode) ret;
      compositingMode.setBlending(this.getBlending());
      compositingMode.setBlender(this.getBlender());
      compositingMode.setAlphaThreshold(this.getAlphaThreshold());
      compositingMode.setColorWriteEnable(this.isColorWriteEnabled());
      compositingMode.setDepthWriteEnable(this.isDepthWriteEnabled());
      compositingMode.setDepthTestEnable(this.isDepthTestEnabled());
      compositingMode.setDepthOffsetx(this.getDepthOffsetFactorx(), this.getDepthOffsetUnitsx());
    }

    public CompositingMode()
    {
      this.m_blending = 68;
      this.m_blender = (Blender) null;
      this.m_alphaThreshold = 0;
      this.m_depthTestEnabled = true;
      this.m_depthWriteEnabled = true;
      this.m_colorWriteEnabled = true;
      this.m_alphaWriteEnabled = true;
      this.m_depthOffsetFactor = 0;
      this.m_depthOffsetUnits = 0;
    }

    public void setBlending(int mode)
    {
      this.m_blending = mode;
    }

    public int getBlending()
    {
      return this.m_blending;
    }

    public void setBlender(Blender blender)
    {
      this.m_blender = blender;
    }

    public Blender getBlender()
    {
      return this.m_blender;
    }

    public void setAlphaThreshold(float threshold)
    {
      this.setAlphaThresholdx((int) ((double) threshold * 65536.0));
    }

    public void setAlphaThresholdx(int threshold)
    {
      this.m_alphaThreshold = threshold;
    }

    public float getAlphaThreshold()
    {
      return (float) this.getAlphaThresholdx() / 65536f;
    }

    public int getAlphaThresholdx()
    {
      return this.m_alphaThreshold;
    }

    public void setAlphaWriteEnable(bool enable)
    {
      this.m_alphaWriteEnabled = enable;
    }

    public bool isAlphaWriteEnabled()
    {
      return this.m_alphaWriteEnabled;
    }

    public void setColorWriteEnable(bool enable)
    {
      this.m_colorWriteEnabled = enable;
    }

    public bool isColorWriteEnabled()
    {
      return this.m_colorWriteEnabled;
    }

    public void setDepthWriteEnable(bool enable)
    {
      this.m_depthWriteEnabled = enable;
    }

    public bool isDepthWriteEnabled()
    {
      return this.m_depthWriteEnabled;
    }

    public void setDepthTestEnable(bool enable)
    {
      this.m_depthTestEnabled = enable;
    }

    public bool isDepthTestEnabled()
    {
      return this.m_depthTestEnabled;
    }

    public void setDepthOffset(float factor, float units)
    {
      this.setDepthOffsetx((int) ((double) factor * 65536.0), (int) ((double) units * 65536.0));
    }

    public void setDepthOffsetx(int factor, int units)
    {
      this.m_depthOffsetFactor = factor;
      this.m_depthOffsetUnits = units;
    }

    public float getDepthOffsetFactor()
    {
      return (float) this.getDepthOffsetFactorx() * 1.525879E-05f;
    }

    public int getDepthOffsetFactorx()
    {
      return this.m_depthOffsetFactor;
    }

    public float getDepthOffsetUnits()
    {
      return (float) this.getDepthOffsetUnitsx() * 1.525879E-05f;
    }

    public int getDepthOffsetUnitsx()
    {
      return this.m_depthOffsetUnits;
    }

    public override int getM3GUniqueClassID()
    {
      return 6;
    }

    public static CompositingMode m3g_cast(Object3D obj)
    {
      return obj.getM3GUniqueClassID() == 6 ? (CompositingMode) obj : (CompositingMode) null;
    }
  }
}
