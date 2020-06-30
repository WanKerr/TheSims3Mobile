// Decompiled with JetBrains decompiler
// Type: m3g.AnimationTrack
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  public class AnimationTrack : Object3D
  {
    public const int ALPHA = 256;
    public const int AMBIENT_COLOR = 257;
    public const int COLOR = 258;
    public const int CROP = 259;
    public const int DENSITY = 260;
    public const int DIFFUSE_COLOR = 261;
    public const int EMISSIVE_COLOR = 262;
    public const int FAR_DISTANCE = 263;
    public const int FIELD_OF_VIEW = 264;
    public const int INTENSITY = 265;
    public const int MORPH_WEIGHTS = 266;
    public const int NEAR_DISTANCE = 267;
    public const int ORIENTATION = 268;
    public const int PICKABILITY = 269;
    public const int SCALE = 270;
    public const int SHININESS = 271;
    public const int SPECULAR_COLOR = 272;
    public const int SPOT_ANGLE = 273;
    public const int SPOT_EXPONENT = 274;
    public const int TRANSLATION = 275;
    public const int VISIBILITY = 276;
    public new const int M3G_UNIQUE_CLASS_ID = 2;
    private KeyframeSequence m_keyframeSequence;
    private AnimationController m_controller;
    private int m_property;
    private float[] m_value;
    private float[] m_null;

    public AnimationTrack()
    {
      this.m_keyframeSequence = (KeyframeSequence) null;
      this.m_controller = (AnimationController) null;
      this.m_property = 0;
      this.m_value = (float[]) null;
      this.m_null = (float[]) null;
    }

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      AnimationTrack animationTrack = (AnimationTrack) ret;
      animationTrack.setProperty(this.getTargetProperty());
      animationTrack.setController(this.getController());
      animationTrack.setKeyframeSequence(this.getKeyframeSequence());
    }

    public override int getReferences(ref Object3D[] references)
    {
      int references1 = base.getReferences(ref references);
      int num1 = references1;
      if (this.m_keyframeSequence != null)
        ++references1;
      if (this.m_controller != null)
        ++references1;
      if (references != null)
      {
        if (this.m_keyframeSequence != null)
          references[num1++] = (Object3D) this.m_keyframeSequence;
        if (this.m_controller != null)
        {
          Object3D[] object3DArray = references;
          int index = num1;
          int num2 = index + 1;
          AnimationController controller = this.m_controller;
          object3DArray[index] = (Object3D) controller;
        }
      }
      return references1;
    }

    public AnimationTrack(KeyframeSequence sequence, int property)
    {
      this.m_keyframeSequence = (KeyframeSequence) null;
      this.m_controller = (AnimationController) null;
      this.m_property = 0;
      this.m_value = (float[]) null;
      this.m_null = (float[]) null;
      this.setKeyframeSequence(sequence);
      this.setProperty(property);
    }

    public void setKeyframeSequence(KeyframeSequence sequence)
    {
      this.m_keyframeSequence = sequence;
      this.m_value = new float[this.m_keyframeSequence.getComponentCount()];
    }

    public void setProperty(int property)
    {
      this.m_property = property;
    }

    public float[] getSampleValue(int worldTime)
    {
      if (this.m_controller == null)
        return (float[]) null;
      this.m_keyframeSequence.sample(this.m_controller.getPosition(worldTime), 0, ref this.m_value);
      float weight = this.m_controller.getWeight();
      for (int index = 0; index < this.m_value.Length; ++index)
        this.m_value[index] *= weight;
      return this.m_value;
    }

    public AnimationController getController()
    {
      return this.m_controller;
    }

    public KeyframeSequence getKeyframeSequence()
    {
      return this.m_keyframeSequence;
    }

    public int getTargetProperty()
    {
      return this.m_property;
    }

    public void setController(AnimationController controller)
    {
      this.m_controller = controller;
    }

    protected override void findReferences(ref Object3DFinder finder)
    {
      base.findReferences(ref finder);
      if (finder.getFound() != null)
        return;
      finder.find((Object3D) this.getKeyframeSequence());
      finder.find((Object3D) this.getController());
    }

    public override int animateReferences(int time)
    {
      return this.animateReferencesObject3D(time);
    }

    public override int getM3GUniqueClassID()
    {
      return 2;
    }
  }
}
