// Decompiled with JetBrains decompiler
// Type: m3g.Blender
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class Blender : Object3D
  {
    public const int ADD = 88;
    public const int CONSTANT_ALPHA = 125;
    public const int CONSTANT_COLOR = 123;
    public const int DST_ALPHA = 118;
    public const int DST_COLOR = 120;
    public const int ONE = 113;
    public const int ONE_MINUS_CONSTANT_ALPHA = 126;
    public const int ONE_MINUS_CONSTANT_COLOR = 124;
    public const int ONE_MINUS_DST_ALPHA = 119;
    public const int ONE_MINUS_DST_COLOR = 121;
    public const int ONE_MINUS_SRC_ALPHA = 117;
    public const int ONE_MINUS_SRC_COLOR = 115;
    public const int REVERSE_SUBTRACT = 90;
    public const int SRC_ALPHA = 116;
    public const int SRC_ALPHA_SATURATE = 122;
    public const int SRC_COLOR = 114;
    public const int SUBTRACT = 89;
    public const int ZERO = 112;
    public new const int M3G_UNIQUE_CLASS_ID = 32;
    private int m_blendColor;
    private int m_srcColorBlendFactor;
    private int m_srcAlphaBlendFactor;
    private int m_dstColorBlendFactor;
    private int m_dstAlphaBlendFactor;
    private int m_colorBlendFunc;
    private int m_alphaBlendFunc;

    public Blender()
    {
      this.m_blendColor = 0;
      this.m_srcColorBlendFactor = 113;
      this.m_srcAlphaBlendFactor = 113;
      this.m_dstColorBlendFactor = 112;
      this.m_dstAlphaBlendFactor = 112;
      this.m_colorBlendFunc = 88;
      this.m_alphaBlendFunc = 88;
    }

    public int getBlendColor()
    {
      return this.m_blendColor;
    }

    public int getBlendFactor(int component)
    {
      switch (component)
      {
        case 114:
          return this.m_srcColorBlendFactor;
        case 116:
          return this.m_srcAlphaBlendFactor;
        case 118:
          return this.m_dstAlphaBlendFactor;
        case 120:
          return this.m_dstColorBlendFactor;
        default:
          return -1;
      }
    }

    public int getBlendFunction(int channel)
    {
      switch (channel)
      {
        case 114:
          return this.m_colorBlendFunc;
        case 116:
          return this.m_alphaBlendFunc;
        default:
          return -1;
      }
    }

    public void setBlendColor(int ARGB)
    {
      this.m_blendColor = ARGB;
    }

    public void setBlendFactors(int srcColor, int srcAlpha, int dstColor, int dstAlpha)
    {
      this.m_srcColorBlendFactor = srcColor;
      this.m_srcAlphaBlendFactor = srcAlpha;
      this.m_dstColorBlendFactor = dstColor;
      this.m_dstAlphaBlendFactor = dstAlpha;
    }

    public void setBlendFunctions(int funcColor, int funcAlpha)
    {
      this.m_colorBlendFunc = funcColor;
      this.m_alphaBlendFunc = funcAlpha;
    }

    public override int getM3GUniqueClassID()
    {
      return 32;
    }
  }
}
