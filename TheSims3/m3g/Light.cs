// Decompiled with JetBrains decompiler
// Type: m3g.Light
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class Light : Node
  {
    public const int AMBIENT = 128;
    public const int DIRECTIONAL = 129;
    public const int OMNI = 130;
    public const int SPOT = 131;
    public new const int M3G_UNIQUE_CLASS_ID = 12;
    private int mMode;
    private int mColor;
    private float mIntensity;
    private float mConstantAttenuation;
    private float mLinearAttenuation;
    private float mQuadraticAttenuation;
    private float mSpotAngle;
    private float mSpotExponent;

    public Light()
    {
      this.mMode = 129;
      this.mColor = 16777215;
      this.mIntensity = 1f;
      this.mConstantAttenuation = 1f;
      this.mLinearAttenuation = 0.0f;
      this.mQuadraticAttenuation = 0.0f;
      this.mSpotAngle = 45f;
      this.mSpotExponent = 0.0f;
    }

    public int getColor()
    {
      return this.mColor;
    }

    public float getConstantAttenuation()
    {
      return this.mConstantAttenuation;
    }

    public float getIntensity()
    {
      return this.mIntensity;
    }

    public float getLinearAttenuation()
    {
      return this.mLinearAttenuation;
    }

    public float getQuadraticAttenuation()
    {
      return this.mQuadraticAttenuation;
    }

    public float getSpotAngle()
    {
      return this.mSpotAngle;
    }

    public float getSpotExponent()
    {
      return this.mSpotExponent;
    }

    public void setAttenuation(float constant, float linear, float quadratic)
    {
      this.mConstantAttenuation = constant;
      this.mLinearAttenuation = linear;
      this.mQuadraticAttenuation = quadratic;
    }

    public void setColor(int RGB)
    {
      this.mColor = RGB;
    }

    public void setIntensity(float intensity)
    {
      this.mIntensity = intensity;
    }

    public void setSpotAngle(float angle)
    {
      this.mSpotAngle = angle;
    }

    public void setSpotExponent(float exponent)
    {
      this.mSpotExponent = exponent;
    }

    public override int getM3GUniqueClassID()
    {
      return 12;
    }
  }
}
