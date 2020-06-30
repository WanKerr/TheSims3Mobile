// Decompiled with JetBrains decompiler
// Type: m3g.PolygonMode
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class PolygonMode : Object3D
  {
    public const int CULL_BACK = 160;
    public const int CULL_FRONT = 161;
    public const int CULL_NONE = 162;
    public const int SHADE_FLAT = 164;
    public const int SHADE_SMOOTH = 165;
    public const int WINDING_CCW = 168;
    public const int WINDING_CW = 169;
    internal const int m3gPolygonMode_CULL_BACK = 160;
    internal const int m3gPolygonMode_CULL_FRONT = 161;
    internal const int m3gPolygonMode_CULL_NONE = 162;
    internal const int m3gPolygonMode_SHADE_FLAT = 164;
    internal const int m3gPolygonMode_SHADE_SMOOTH = 165;
    internal const int m3gPolygonMode_WINDING_CCW = 168;
    internal const int m3gPolygonMode_WINDING_CW = 169;
    public new const int M3G_UNIQUE_CLASS_ID = 8;
    private int m_culling;
    private int m_winding;
    private int m_shading;
    private bool m_twoSidedLighting;
    private bool m_localCameraLighting;
    private bool m_perspectiveCorrection;

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      PolygonMode polygonMode = (PolygonMode) ret;
      polygonMode.setCulling(this.getCulling());
      polygonMode.setWinding(this.getWinding());
      polygonMode.setShading(this.getShading());
      polygonMode.setTwoSidedLightingEnable(this.isTwoSidedLightingEnabled());
      polygonMode.setLocalCameraLightingEnable(this.isLocalCameraLightingEnabled());
      polygonMode.setPerspectiveCorrectionEnable(this.isPerspectiveCorrectionEnabled());
    }

    public PolygonMode()
    {
      this.m_culling = 160;
      this.m_winding = 168;
      this.m_shading = 165;
      this.m_twoSidedLighting = false;
      this.m_localCameraLighting = false;
      this.m_perspectiveCorrection = false;
    }

    public void setCulling(int mode)
    {
      this.m_culling = mode;
    }

    public int getCulling()
    {
      return this.m_culling;
    }

    public void setWinding(int mode)
    {
      this.m_winding = mode;
    }

    public int getWinding()
    {
      return this.m_winding;
    }

    public void setShading(int mode)
    {
      this.m_shading = mode;
    }

    public int getShading()
    {
      return this.m_shading;
    }

    public void setTwoSidedLightingEnable(bool enable)
    {
      this.m_twoSidedLighting = enable;
    }

    public bool isTwoSidedLightingEnabled()
    {
      return this.m_twoSidedLighting;
    }

    public void setLocalCameraLightingEnable(bool enable)
    {
      this.m_localCameraLighting = enable;
    }

    public bool isLocalCameraLightingEnabled()
    {
      return this.m_localCameraLighting;
    }

    public void setPerspectiveCorrectionEnable(bool enable)
    {
      this.m_perspectiveCorrection = enable;
    }

    public bool isPerspectiveCorrectionEnabled()
    {
      return this.m_perspectiveCorrection;
    }

    public override int getM3GUniqueClassID()
    {
      return 8;
    }

    public static PolygonMode m3g_cast(Object3D obj)
    {
      return obj.getM3GUniqueClassID() == 8 ? (PolygonMode) obj : (PolygonMode) null;
    }
  }
}
