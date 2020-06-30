// Decompiled with JetBrains decompiler
// Type: m3g.Object3D
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace m3g
{
  public class Object3D
  {
    private Object3DFinder cachedFinder = new Object3DFinder(0);
    public const int M3G_UNIQUE_CLASS_ID = 0;
    private int m_userID;
    private List<object> m_animationTracks;
    private Object3D[] m_animationReferenceArray;
    public long createdTime;
    public static long curCreated;

    public Object3D()
    {
      this.createdTime = Object3D.curCreated;
      ++Object3D.curCreated;
    }

    public void addAnimationTrack(AnimationTrack animationTrack)
    {
      if (this.m_animationTracks == null)
        this.m_animationTracks = new List<object>();
      this.m_animationTracks.Add((object) animationTrack);
    }

    public int animate(int time)
    {
      int num = this.animateReferences(time);
      for (int index = this.getAnimationTrackCount() - 1; index >= 0; --index)
      {
        AnimationTrack animationTrack = this.getAnimationTrack(index);
        animationTrack.getController();
        this.updateAnimationProperty(animationTrack.getTargetProperty(), animationTrack.getSampleValue(time));
      }
      this.postAnimate(time);
      return num;
    }

    protected virtual void postAnimate(int time)
    {
    }

    protected virtual void updateAnimationProperty(int property, float[] value)
    {
    }

    protected virtual void updateAnimationProperty(int property, int[] value)
    {
    }

    public Object3D duplicate()
    {
      Object3D instance = (Object3D) Activator.CreateInstance(this.GetType());
      this.duplicateTo(ref instance);
      return instance;
    }

    protected virtual void duplicateTo(ref Object3D ret)
    {
      ret.setUserID(this.getUserID());
      int animationTrackCount = this.getAnimationTrackCount();
      for (int index = 0; index < animationTrackCount; ++index)
      {
        AnimationTrack animationTrack = this.getAnimationTrack(index);
        ret.addAnimationTrack(animationTrack);
      }
    }

    public Object3D find(int userID)
    {
      if (this.getUserID() == userID)
        return this;
      this.cachedFinder.resetTo(userID);
      this.findReferences(ref this.cachedFinder);
      return this.cachedFinder.getFound();
    }

    public AnimationTrack getAnimationTrack(int index)
    {
      return (AnimationTrack) this.m_animationTracks.ElementAt<object>(index);
    }

    public int getAnimationTrackCount()
    {
      return this.m_animationTracks == null ? 0 : this.m_animationTracks.Count;
    }

    public int animateReferencesObject3D(int time)
    {
      int num1 = int.MaxValue;
      int animationTrackCount = this.getAnimationTrackCount();
      while (--animationTrackCount >= 0)
      {
        int num2 = this.getAnimationTrack(animationTrackCount).animate(time);
        if (num2 < num1)
          num1 = num2;
      }
      return num1;
    }

    protected virtual void findReferences(ref Object3DFinder finder)
    {
      for (int index = this.getAnimationTrackCount() - 1; index >= 0; --index)
        finder.find((Object3D) this.getAnimationTrack(index));
    }

    public virtual int animateReferences(int time)
    {
      return this.animateReferencesObject3D(time);
    }

    public virtual int getReferences(ref Object3D[] references)
    {
      int num1 = 0;
      int num2 = num1;
      int num3 = num1 + this.getAnimationTrackCount();
      if (references != null && references.Length != 0)
      {
        int animationTrackCount = this.getAnimationTrackCount();
        for (int index = 0; index < animationTrackCount; ++index)
          references[num2++] = (Object3D) this.getAnimationTrack(index);
      }
      return num3;
    }

    public int getUserID()
    {
      return this.m_userID;
    }

    public void removeAnimationTrack(AnimationTrack animationTrack)
    {
      this.m_animationTracks.Remove((object) animationTrack);
    }

    public void setUserID(int userID)
    {
      this.m_userID = userID;
    }

    public virtual int getM3GUniqueClassID()
    {
      return 0;
    }
  }
}
