// Decompiled with JetBrains decompiler
// Type: m3g.Transformable
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace m3g
{
  public class Transformable : Object3D
  {
    private float[] m_translationAccumulator = new float[3];
    private float[] m_scaleAccumulator = new float[3];
    private float[] m_orientationAccumulator = new float[4];
    private Transform m_cachedTransform = new Transform();
    private float m_translationX;
    private float m_translationY;
    private float m_translationZ;
    private float m_scaleX;
    private float m_scaleY;
    private float m_scaleZ;
    private int m_qx;
    private int m_qy;
    private int m_qz;
    private int m_qw;
    private bool m_animateTranslation;
    private bool m_animateScale;
    private bool m_animateOrientation;
    private Transform m_transform;
    private bool m_cachedTransformIsValid;

    public Transformable()
    {
      this.m_translationX = 0.0f;
      this.m_translationY = 0.0f;
      this.m_translationZ = 0.0f;
      this.m_scaleX = 1f;
      this.m_scaleY = 1f;
      this.m_scaleZ = 1f;
      this.m_qx = 0;
      this.m_qy = 0;
      this.m_qz = 0;
      this.m_qw = 65536;
      this.m_transform = (Transform) null;
      this.m_cachedTransform = new Transform();
      this.m_cachedTransformIsValid = false;
      this.m_translationAccumulator = new float[3];
      this.m_scaleAccumulator = new float[3];
      this.m_orientationAccumulator = new float[4];
      this.m_animateTranslation = false;
      this.m_animateScale = false;
      this.m_animateOrientation = false;
    }

    private void verifyValues(float[] values, int length)
    {
    }

    private void verifyValues(float[] values)
    {
    }

    private void verifyValues(int[] values, int length)
    {
    }

    private void verifyValues(int[] values)
    {
    }

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      Transformable transformable = (Transformable) ret;
      float[] values1 = new float[3];
      this.getTranslation(ref values1);
      transformable.setTranslation(values1[0], values1[1], values1[2]);
      float[] values2 = new float[3];
      this.getScale(ref values2);
      transformable.setScale(values2[0], values2[1], values2[2]);
      int[] values3 = new int[4];
      this.getOrientationQuatx(ref values3);
      transformable.setOrientationQuatx(values3[0], values3[1], values3[2], values3[3]);
      transformable.setTransform(this.m_transform);
    }

    protected override void updateAnimationProperty(int property, int[] value)
    {
      base.updateAnimationProperty(property, value);
    }

    protected override void updateAnimationProperty(int property, float[] value)
    {
      base.updateAnimationProperty(property, value);
      switch (property)
      {
        case 268:
          this.m_animateOrientation = true;
          if ((double) this.m_orientationAccumulator[0] * (double) value[0] + (double) this.m_orientationAccumulator[1] * (double) value[1] + (double) this.m_orientationAccumulator[2] * (double) value[2] + (double) this.m_orientationAccumulator[3] * (double) value[3] < 0.0)
          {
            this.m_orientationAccumulator[0] -= value[0];
            this.m_orientationAccumulator[1] -= value[1];
            this.m_orientationAccumulator[2] -= value[2];
            this.m_orientationAccumulator[3] -= value[3];
            break;
          }
          this.m_orientationAccumulator[0] += value[0];
          this.m_orientationAccumulator[1] += value[1];
          this.m_orientationAccumulator[2] += value[2];
          this.m_orientationAccumulator[3] += value[3];
          break;
        case 270:
          this.m_animateScale = true;
          this.m_scaleAccumulator[0] += value[0];
          this.m_scaleAccumulator[1] += value[1];
          this.m_scaleAccumulator[2] += value[2];
          break;
        case 275:
          this.m_animateTranslation = true;
          this.m_translationAccumulator[0] += value[0];
          this.m_translationAccumulator[1] += value[1];
          this.m_translationAccumulator[2] += value[2];
          break;
      }
    }

    protected override void postAnimate(int time)
    {
      base.postAnimate(time);
      if (this.m_animateTranslation)
        this.setTranslation(this.m_translationAccumulator[0], this.m_translationAccumulator[1], this.m_translationAccumulator[2]);
      if (this.m_animateScale)
        this.setScale(this.m_scaleAccumulator[0], this.m_scaleAccumulator[1], this.m_scaleAccumulator[2]);
      if (this.m_animateOrientation && (double) this.m_orientationAccumulator[0] * (double) this.m_orientationAccumulator[0] + (double) this.m_orientationAccumulator[1] * (double) this.m_orientationAccumulator[1] + (double) this.m_orientationAccumulator[2] * (double) this.m_orientationAccumulator[2] + (double) this.m_orientationAccumulator[3] * (double) this.m_orientationAccumulator[3] != 0.0)
        this.setOrientationQuat(this.m_orientationAccumulator[0], this.m_orientationAccumulator[1], this.m_orientationAccumulator[2], this.m_orientationAccumulator[3]);
      for (int index = 0; index < 3; ++index)
      {
        this.m_translationAccumulator[index] = 0.0f;
        this.m_scaleAccumulator[index] = 0.0f;
      }
      for (int index = 0; index < 4; ++index)
        this.m_orientationAccumulator[index] = 0.0f;
      this.m_animateTranslation = false;
      this.m_animateOrientation = false;
      this.m_animateScale = false;
    }

    public void setTransform(Transform transform)
    {
      if (transform != null)
      {
        if (this.m_transform == null)
          this.m_transform = new Transform(transform);
        else
          this.m_transform.set(transform);
      }
      else
        this.m_transform = (Transform) null;
      this.m_cachedTransformIsValid = false;
    }

    public void getTransform(ref Transform transform)
    {
      if (this.m_transform == null)
        transform.setIdentity();
      else
        transform.set(this.m_transform);
    }

    public void getTranslation(ref float[] values)
    {
      this.verifyValues(values);
      values[0] = this.m_translationX;
      values[1] = this.m_translationY;
      values[2] = this.m_translationZ;
    }

    public void getTranslationx(ref int[] values)
    {
      this.verifyValues(values, 3);
      values[0] = (int) ((double) this.m_translationX * 65536.0);
      values[1] = (int) ((double) this.m_translationY * 65536.0);
      values[2] = (int) ((double) this.m_translationZ * 65536.0);
    }

    public float getXTranslation()
    {
      return this.m_translationX;
    }

    public float getYTranslation()
    {
      return this.m_translationY;
    }

    public float getZTranslation()
    {
      return this.m_translationZ;
    }

    public int getXTranslationx()
    {
      return (int) ((double) this.m_translationX * 65536.0);
    }

    public int getYTranslationx()
    {
      return (int) ((double) this.m_translationY * 65536.0);
    }

    public int getZTranslationx()
    {
      return (int) ((double) this.m_translationZ * 65536.0);
    }

    public void getScale(ref float[] values)
    {
      this.verifyValues(values, 3);
      values[0] = this.m_scaleX;
      values[1] = this.m_scaleY;
      values[2] = this.m_scaleZ;
    }

    public void getScalex(ref int[] values)
    {
      this.verifyValues(values, 3);
      values[0] = (int) ((double) this.m_scaleX * 65536.0 + 0.5);
      values[1] = (int) ((double) this.m_scaleY * 65536.0 + 0.5);
      values[2] = (int) ((double) this.m_scaleZ * 65536.0 + 0.5);
    }

    public void getOrientation(ref float[] values)
    {
      throw new NotImplementedException("Transformable::getOrientation() is not implemented since Transform::quatToAngleAxisx() isn't implemented");
    }

    public void getOrientation(float values)
    {
      throw new NotImplementedException("Transformable::getOrientation() is not implemented since Transform::quatToAngleAxisx() isn't implemented");
    }

    public void getOrientationx(ref int[] values)
    {
      throw new NotImplementedException("Transformable::getOrientationx() is not implemented since Transform::quatToAngleAxisx() isn't implemented");
    }

    public void getOrientationx(int values)
    {
      throw new NotImplementedException("Transformable::getOrientationx() is not implemented since Transform::quatToAngleAxisx() isn't implemented");
    }

    public void getOrientationQuat(ref float[] values)
    {
      this.verifyValues(values, 4);
      values[0] = (float) this.m_qx * 1.525879E-05f;
      values[1] = (float) this.m_qy * 1.525879E-05f;
      values[2] = (float) this.m_qz * 1.525879E-05f;
      values[3] = (float) this.m_qw * 1.525879E-05f;
    }

    public void getOrientationQuatx(ref int[] values)
    {
      this.verifyValues(values, 4);
      values[0] = this.m_qx;
      values[1] = this.m_qy;
      values[2] = this.m_qz;
      values[3] = this.m_qw;
    }

    public void setOrientation(float degrees, float x, float y, float z)
    {
      this.setOrientationx((int) ((double) degrees * 65536.0 + 0.5), (int) ((double) x * 65536.0 + 0.5), (int) ((double) y * 65536.0 + 0.5), (int) ((double) z * 65536.0 + 0.5));
    }

    public void setOrientationx(int degrees, int x, int y, int z)
    {
      int qX;
      int qY;
      int qZ;
      int qW;
      Transform.angleAxisToQuatx(degrees, x, y, z, out qX, out qY, out qZ, out qW);
      this.setOrientationQuatx(qX, qY, qZ, qW);
    }

    public void setOrientationQuat(float qx, float qy, float qz, float qw)
    {
      this.setOrientationQuatx((int) ((double) qx * 65536.0 + 0.5), (int) ((double) qy * 65536.0 + 0.5), (int) ((double) qz * 65536.0 + 0.5), (int) ((double) qw * 65536.0 + 0.5));
    }

    public void setOrientationQuatx(int qxConst, int qyConst, int qzConst, int qwConst)
    {
      int num1 = qxConst;
      int num2 = qyConst;
      int num3 = qzConst;
      int num4 = qwConst;
      float num5 = (float) num1 * 1.525879E-05f;
      float num6 = (float) num2 * 1.525879E-05f;
      float num7 = (float) num3 * 1.525879E-05f;
      float num8 = (float) num4 * 1.525879E-05f;
      long num9 = (long) (65536.0 / Math.Sqrt((double) num5 * (double) num5 + (double) num6 * (double) num6 + (double) num7 * (double) num7 + (double) num8 * (double) num8));
      int num10 = (int) (num9 * (long) num1 >> 16);
      int num11 = (int) (num9 * (long) num2 >> 16);
      int num12 = (int) (num9 * (long) num3 >> 16);
      int num13 = (int) (num9 * (long) num4 >> 16);
      if (this.m_qx == num10 && this.m_qy == num11 && (this.m_qz == num12 && this.m_qw == num13))
        return;
      this.m_qx = num10;
      this.m_qy = num11;
      this.m_qz = num12;
      this.m_qw = num13;
      this.m_cachedTransformIsValid = false;
    }

    public void setScale(float sx, float sy, float sz)
    {
      if ((double) this.m_scaleX == (double) sx && (double) this.m_scaleY == (double) sy && (double) this.m_scaleZ == (double) sz)
        return;
      this.m_scaleX = sx;
      this.m_scaleY = sy;
      this.m_scaleZ = sz;
      this.m_cachedTransformIsValid = false;
    }

    public void setScalex(int sx, int sy, int sz)
    {
      this.setScale((float) sx * 1.525879E-05f, (float) sy * 1.525879E-05f, (float) sz * 1.525879E-05f);
    }

    public void setTranslation(float x, float y, float z)
    {
      if ((double) this.m_translationX == (double) x && (double) this.m_translationY == (double) y && (double) this.m_translationZ == (double) z)
        return;
      this.m_translationX = x;
      this.m_translationY = y;
      this.m_translationZ = z;
      this.m_cachedTransformIsValid = false;
    }

    public void setTranslationx(int x, int y, int z)
    {
      this.setTranslation((float) x * 1.525879E-05f, (float) y * 1.525879E-05f, (float) z * 1.525879E-05f);
    }

    public void translate(float x, float y, float z)
    {
      if ((double) x == 0.0 && (double) y == 0.0 && (double) z == 0.0)
        return;
      this.m_translationX += x;
      this.m_translationY += y;
      this.m_translationZ += z;
      this.m_cachedTransformIsValid = false;
    }

    public void translatex(int x, int y, int z)
    {
      this.translate((float) x * 1.525879E-05f, (float) y * 1.525879E-05f, (float) z * 1.525879E-05f);
    }

    public void getCompositeTransform(ref Transform transform)
    {
      this.updateCachedTransform();
      transform.set(this.m_cachedTransform);
    }

    public void getCompositeTransformCumulative(ref Transform transform)
    {
      this.updateCachedTransform();
      transform.postMultiply(ref this.m_cachedTransform);
    }

    public void getCompositeTransformCumulative(ref Transform transform, int depth)
    {
      this.updateCachedTransform();
      transform.postMultiply(ref this.m_cachedTransform);
    }

    private void updateCachedTransform()
    {
      if (this.m_cachedTransformIsValid)
        return;
      Transform cachedTransform = this.m_cachedTransform;
      cachedTransform.setIdentity();
      if ((double) this.m_translationX != 0.0 || (double) this.m_translationY != 0.0 || (double) this.m_translationZ != 0.0)
        cachedTransform.postTranslate(this.m_translationX, this.m_translationY, this.m_translationZ);
      if (this.m_qw != 65536 || this.m_qx != 0 || (this.m_qy != 0 || this.m_qz != 0))
        cachedTransform.postRotateQuatx(this.m_qx, this.m_qy, this.m_qz, this.m_qw);
      if ((double) this.m_scaleX != 1.0 || (double) this.m_scaleY != 1.0 || (double) this.m_scaleZ != 1.0)
        cachedTransform.postScale(this.m_scaleX, this.m_scaleY, this.m_scaleZ);
      if (this.m_transform != null)
        cachedTransform.postMultiply(ref this.m_transform);
      this.m_cachedTransformIsValid = true;
    }
  }
}
