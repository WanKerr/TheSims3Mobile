// Decompiled with JetBrains decompiler
// Type: m3g.Camera
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace m3g
{
  public class Camera : Node
  {
    private float[] cachedMat = new float[16];
    private Transform m_projectionTransform = new Transform();
    public const int GENERIC = 48;
    public const int PARALLEL = 49;
    public const int PERSPECTIVE = 50;
    public new const int M3G_UNIQUE_CLASS_ID = 5;
    private int m_projectionMode;
    private float m_fovy;
    private float m_aspectRatio;
    private float m_near;
    private float m_far;
    private bool m_cachedTransformIsValid;

    public Camera()
    {
      this.m_projectionMode = 48;
      this.m_fovy = 0.0f;
      this.m_aspectRatio = 0.0f;
      this.m_near = 0.0f;
      this.m_far = 0.0f;
      this.m_projectionTransform = new Transform();
      this.m_cachedTransformIsValid = true;
    }

    public int getProjection(ref float[] @params)
    {
      if (@params != null)
      {
        @params[0] = this.m_fovy;
        @params[1] = this.m_aspectRatio;
        @params[2] = this.m_near;
        @params[3] = this.m_far;
      }
      return this.m_projectionMode;
    }

    public int getProjection(Transform transform)
    {
      if (transform != null)
      {
        this.updateCachedProjectionTransform();
        transform.set(this.m_projectionTransform);
      }
      return this.m_projectionMode;
    }

    public void setGeneric(Transform transform)
    {
      this.m_projectionMode = 48;
      this.m_projectionTransform.set(transform);
      this.m_cachedTransformIsValid = true;
    }

    public void setParallel(float fovy, float aspectRatio, float nearClip, float farClip)
    {
      this.m_fovy = fovy;
      this.m_aspectRatio = aspectRatio;
      this.m_near = nearClip;
      this.m_far = farClip;
      this.m_projectionMode = 49;
      this.m_cachedTransformIsValid = false;
    }

    public void setPerspective(float fovy, float aspectRatio, float nearClip, float farClip)
    {
      this.m_fovy = fovy;
      this.m_aspectRatio = aspectRatio;
      this.m_near = nearClip;
      this.m_far = farClip;
      this.m_projectionMode = 50;
      this.m_cachedTransformIsValid = false;
    }

    public void setPerspectivex(int fovy, int aspectRatio, int nearClip, int farClip)
    {
      this.setPerspective((float) fovy * 1.525879E-05f, (float) aspectRatio * 1.525879E-05f, (float) nearClip * 1.525879E-05f, (float) farClip * 1.525879E-05f);
    }

    private void updateCachedProjectionTransform()
    {
      switch (this.m_projectionMode)
      {
        case 49:
          float fovy = this.m_fovy;
          float num1 = this.m_aspectRatio * fovy;
          float num2 = this.m_far - this.m_near;
          this.cachedMat[0] = 2f / num1;
          this.cachedMat[1] = 0.0f;
          this.cachedMat[2] = 0.0f;
          this.cachedMat[3] = 0.0f;
          this.cachedMat[4] = 0.0f;
          this.cachedMat[5] = 2f / fovy;
          this.cachedMat[6] = 0.0f;
          this.cachedMat[7] = 0.0f;
          this.cachedMat[8] = 0.0f;
          this.cachedMat[9] = 0.0f;
          this.cachedMat[10] = -2f / num2;
          this.cachedMat[11] = (float) -((double) this.m_near + (double) this.m_far) / num2;
          this.cachedMat[12] = 0.0f;
          this.cachedMat[13] = 0.0f;
          this.cachedMat[14] = 0.0f;
          this.cachedMat[15] = 1f;
          this.m_projectionTransform.set(this.cachedMat);
          break;
        case 50:
          float num3 = (float) Math.Tan((double) (this.m_fovy * ((float) Math.PI / 360f)));
          float num4 = this.m_aspectRatio * num3;
          float num5 = this.m_far - this.m_near;
          float num6 = 1f / num4;
          float num7 = 1f / num3;
          float num8 = (float) -((double) this.m_near + (double) this.m_far) / num5;
          float num9 = (float) -(2.0 * (double) this.m_near * (double) this.m_far) / num5;
          this.cachedMat[0] = num6;
          this.cachedMat[1] = 0.0f;
          this.cachedMat[2] = 0.0f;
          this.cachedMat[3] = 0.0f;
          this.cachedMat[4] = 0.0f;
          this.cachedMat[5] = num7;
          this.cachedMat[6] = 0.0f;
          this.cachedMat[7] = 0.0f;
          this.cachedMat[8] = 0.0f;
          this.cachedMat[9] = 0.0f;
          this.cachedMat[10] = num8;
          this.cachedMat[11] = num9;
          this.cachedMat[12] = 0.0f;
          this.cachedMat[13] = 0.0f;
          this.cachedMat[14] = -1f;
          this.cachedMat[15] = 0.0f;
          this.m_projectionTransform.set(this.cachedMat);
          break;
      }
      this.m_cachedTransformIsValid = true;
    }

    public override int getM3GUniqueClassID()
    {
      return 5;
    }

    public static Camera m3g_cast(Object3D obj)
    {
      return obj.getM3GUniqueClassID() == 5 ? (Camera) obj : (Camera) null;
    }
  }
}
