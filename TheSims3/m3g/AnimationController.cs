// Decompiled with JetBrains decompiler
// Type: m3g.AnimationController
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class AnimationController : Object3D
  {
    public new const int M3G_UNIQUE_CLASS_ID = 1;
    private int m_activeIntervalStart;
    private int m_activeIntervalEnd;
    private float m_weight;
    private float m_speed;
    private float m_referenceSequenceTime;
    private int m_referenceWorldTime;

    public AnimationController()
    {
      this.m_activeIntervalStart = 0;
      this.m_activeIntervalEnd = 0;
      this.m_weight = 1f;
      this.m_speed = 1f;
      this.m_referenceSequenceTime = 0.0f;
      this.m_referenceWorldTime = 0;
    }

    public new Object3D duplicate()
    {
      AnimationController animationController = new AnimationController();
      Object3D ret = (Object3D) animationController;
      this.duplicateTo(ref ret);
      animationController.m_activeIntervalStart = this.m_activeIntervalStart;
      animationController.m_activeIntervalEnd = this.m_activeIntervalEnd;
      animationController.m_weight = this.m_weight;
      animationController.m_speed = this.m_speed;
      animationController.m_referenceSequenceTime = this.m_referenceSequenceTime;
      animationController.m_referenceWorldTime = this.m_referenceWorldTime;
      return (Object3D) animationController;
    }

    protected override void updateAnimationProperty(int property, float[] value)
    {
    }

    protected override void updateAnimationProperty(int property, int[] value)
    {
    }

    public int getActiveIntervalEnd()
    {
      return this.m_activeIntervalEnd;
    }

    public int getActiveIntervalStart()
    {
      return this.m_activeIntervalStart;
    }

    public float getPosition(int worldTime)
    {
      return this.m_referenceSequenceTime + this.m_speed * (float) (worldTime - this.m_referenceWorldTime);
    }

    public int getRefWorldTime()
    {
      return this.m_referenceWorldTime;
    }

    public float getSpeed()
    {
      return this.m_speed;
    }

    public float getWeight()
    {
      return this.m_weight;
    }

    public bool isZeroWeight()
    {
      return (double) this.m_weight == 0.0;
    }

    public void setActiveInterval(int start, int end)
    {
      this.m_activeIntervalStart = start;
      this.m_activeIntervalEnd = end;
    }

    public void setPosition(float sequenceTime, int worldTime)
    {
      this.m_referenceSequenceTime = sequenceTime;
      this.m_referenceWorldTime = worldTime;
    }

    public void setSpeed(float speed, int worldTime)
    {
      this.m_referenceSequenceTime = this.getPosition(worldTime);
      this.m_referenceWorldTime = worldTime;
      this.m_speed = speed;
    }

    public void setWeight(float weight)
    {
      this.m_weight = weight;
    }

    public override int getM3GUniqueClassID()
    {
      return 1;
    }
  }
}
