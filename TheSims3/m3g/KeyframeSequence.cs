// Decompiled with JetBrains decompiler
// Type: m3g.KeyframeSequence
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace m3g
{
  public class KeyframeSequence : Object3D
  {
    public const int CONSTANT = 192;
    public const int LINEAR = 176;
    public const int LOOP = 193;
    public const int SLERP = 177;
    public const int SPLINE = 178;
    public const int SQUAD = 179;
    public const int STEP = 180;
    private const int CURRENT = 0;
    private const int NEXT = 1;
    private const int NEXT_NEXT = 2;
    private const int PREV = 3;
    public new const int M3G_UNIQUE_CLASS_ID = 19;
    private int m_keyframeCount;
    private int m_componentCount;
    private int m_interpolation;
    private int m_duration;
    private int m_repeatMode;
    private int m_validRangeFirst;
    private int m_validRangeLast;
    private int[] m_times;
    private float[] m_values;
    private int[] m_calcIndices;
    private float[] m_deltaTimeCache;
    private float[] m_tangentCache;
    private int m_validRangeFirstTime;
    private int m_validRangeLastTime;
    private bool m_deltaTimeCacheValid;
    private bool m_tangentCacheValid;

    public KeyframeSequence()
    {
      this.m_keyframeCount = 0;
      this.m_componentCount = 0;
      this.m_interpolation = 0;
      this.m_duration = 0;
      this.m_repeatMode = 0;
      this.m_validRangeFirst = 0;
      this.m_validRangeLast = 0;
      this.m_times = (int[]) null;
      this.m_values = (float[]) null;
      this.m_calcIndices = new int[2];
      this.m_deltaTimeCache = (float[]) null;
      this.m_tangentCache = (float[]) null;
      this.m_deltaTimeCacheValid = false;
      this.m_tangentCacheValid = false;
      this.m_validRangeFirstTime = 0;
      this.m_validRangeLastTime = 0;
    }

    public KeyframeSequence(int numKeyframes, int numComponents, int interpolation)
    {
      this.m_keyframeCount = 0;
      this.m_componentCount = 0;
      this.m_interpolation = 0;
      this.m_duration = 0;
      this.m_repeatMode = 0;
      this.m_validRangeFirst = 0;
      this.m_validRangeLast = 0;
      this.m_times = (int[]) null;
      this.m_values = (float[]) null;
      this.m_calcIndices = new int[2];
      this.m_deltaTimeCache = (float[]) null;
      this.m_tangentCache = (float[]) null;
      this.m_deltaTimeCacheValid = false;
      this.m_tangentCacheValid = false;
      this.m_validRangeFirstTime = 0;
      this.m_validRangeLastTime = 0;
      this.setInterpolation(interpolation);
      this.setKeyframeSize(numKeyframes, numComponents);
      this.setRepeatMode(192);
      this.setValidRange(0, numKeyframes - 1);
    }

    private void validateIndex(int index)
    {
    }

    private void validateValueArrayNotNull(float[] value)
    {
    }

    private void validateValueArrayLength(float[] value)
    {
    }

    public void setInterpolation(int interpolation)
    {
      this.m_interpolation = interpolation;
      this.invalidateDeltaTimeCache();
    }

    public void setKeyframeSize(int numKeyframes, int numComponents)
    {
      this.m_keyframeCount = numKeyframes;
      this.m_componentCount = numComponents;
      if (this.m_times != null)
        this.m_times = (int[]) null;
      this.m_times = new int[numKeyframes];
      if (this.m_values != null)
        this.m_values = (float[]) null;
      this.m_values = new float[numKeyframes * numComponents];
      this.invalidateDeltaTimeCache();
    }

    protected override void updateAnimationProperty(int property, float[] value)
    {
    }

    protected override void updateAnimationProperty(int property, int[] value)
    {
    }

    public int getKeyframeTime(int index)
    {
      this.validateIndex(index);
      return this.m_times[index];
    }

    public float[] getKeyframeValue(int index)
    {
      this.validateIndex(index);
      float[] numArray = new float[this.m_values.Length - index * this.getComponentCount()];
      Array.Copy((Array) this.m_values, index * this.getComponentCount(), (Array) numArray, 0, this.m_values.Length - index * this.getComponentCount());
      return numArray;
    }

    public void getKeyframeValue(int index, ref float[] value)
    {
      Array.Copy((Array) this.getKeyframeValue(index), 0, (Array) value, 0, this.getComponentCount());
    }

    public int getKeyframe(int index, ref float[] value)
    {
      if (value != null)
        this.getKeyframeValue(index, ref value);
      return this.getKeyframeTime(index);
    }

    public void setDuration(int duration)
    {
      if (duration == this.m_duration)
        return;
      this.m_duration = duration;
      this.invalidateDeltaTimeCache();
    }

    public void setKeyframeTime(int index, int time)
    {
      int keyframeTime = this.getKeyframeTime(index);
      if (time == keyframeTime)
        return;
      this.m_times[index] = time;
      this.invalidateDeltaTimeCache();
    }

    public void setKeyframeValue(int index, float[] value)
    {
      Array.Copy((Array) value, 0, (Array) this.m_values, index * this.getComponentCount(), this.getComponentCount());
      this.invalidateTangentCache();
    }

    public void setKeyframe(int index, int time, float[] value)
    {
      this.validateIndex(index);
      this.setKeyframeTime(index, time);
      this.setKeyframeValue(index, value);
    }

    public void setRepeatMode(int mode)
    {
      if (mode == this.m_repeatMode)
        return;
      this.m_repeatMode = mode;
      this.invalidateDeltaTimeCache();
    }

    public void setValidRange(int first, int last)
    {
      this.validateIndex(first);
      this.validateIndex(last);
      if (first != this.m_validRangeFirst)
      {
        this.m_validRangeFirst = first;
        this.invalidateDeltaTimeCache();
      }
      if (last == this.m_validRangeLast)
        return;
      this.m_validRangeLast = last;
      this.invalidateDeltaTimeCache();
    }

    public int calcCurrentIndex(
      int sequenceTimeInt,
      int validRangeFirst,
      int validRangeLast,
      int[] times)
    {
      int num1 = validRangeLast;
      int num2 = validRangeFirst;
      int num3 = num1 - num2;
      for (int index1 = 5; num3 > index1; num3 = num1 - num2)
      {
        int index2 = num1 + num2 >> 1;
        if (times[index2] > sequenceTimeInt)
          num1 = index2;
        else
          num2 = index2;
      }
      int index = num1;
      while (index > num2 && times[index] > sequenceTimeInt)
        --index;
      return index;
    }

    public int calcPrevIndex(int index, int validRangeFirst, int validRangeLast, int repeatMode)
    {
      if (index != validRangeFirst)
        return index - 1;
      return repeatMode == 193 ? validRangeLast : validRangeFirst;
    }

    public int calcNextIndex(int index, int validRangeFirst, int validRangeLast, int repeatMode)
    {
      if (index != validRangeLast)
        return index + 1;
      return repeatMode == 193 ? validRangeFirst : validRangeLast;
    }

    public void calcIndicesAndTimes(KeyframeSequence self, int sequenceTimeInt, int repeatMode)
    {
      self.updateDeltaTimeCache();
      int validRangeFirst = self.getValidRangeFirst();
      int validRangeLast = self.getValidRangeLast();
      int[] times = self.m_times;
      int[] calcIndices = self.m_calcIndices;
      if (validRangeFirst > validRangeLast)
        return;
      int index;
      int num;
      if (sequenceTimeInt < self.m_validRangeFirstTime || sequenceTimeInt >= self.m_validRangeLastTime)
      {
        index = validRangeLast;
        num = validRangeFirst;
      }
      else
      {
        index = this.calcCurrentIndex(sequenceTimeInt, validRangeFirst, validRangeLast, times);
        num = this.calcNextIndex(index, validRangeFirst, validRangeLast, repeatMode);
      }
      calcIndices[0] = index;
      calcIndices[1] = num;
    }

    public float getInterpolant(
      KeyframeSequence self,
      int current,
      float sequenceTime,
      int repeatMode)
    {
      int keyframeTime = self.getKeyframeTime(current);
      float num = sequenceTime - (float) keyframeTime;
      if ((double) num < 0.0)
        num += (float) self.getDuration();
      float deltaTime = self.getDeltaTime(current);
      return (double) num < (double) deltaTime ? num / deltaTime : 1f;
    }

    public float sample(float sequenceTime, int channel)
    {
      float[] numArray = new float[1];
      this.sample(sequenceTime, channel, ref numArray);
      return numArray[0];
    }

    public void sample(float sequenceTime, int channel, ref float[] value)
    {
      this.validateValueArrayNotNull(value);
      this.validateValueArrayLength(value);
      int sequenceTimeInt = (int) sequenceTime;
      int repeatMode = this.getRepeatMode();
      int componentCount = this.getComponentCount();
      if (repeatMode == 192)
      {
        if (sequenceTimeInt < this.getKeyframeTime(this.getValidRangeFirst()))
        {
          Array.Copy((Array) this.getKeyframeValue(this.getValidRangeFirst()), 0, (Array) value, 0, componentCount);
          return;
        }
        if (sequenceTimeInt >= this.getKeyframeTime(this.getValidRangeLast()))
        {
          Array.Copy((Array) this.getKeyframeValue(this.getValidRangeLast()), 0, (Array) value, 0, componentCount);
          return;
        }
      }
      if (repeatMode == 193)
      {
        int duration = this.getDuration();
        if (sequenceTimeInt >= duration)
        {
          int num = sequenceTimeInt / duration;
          sequenceTime -= (float) (duration * num);
          sequenceTimeInt = (int) sequenceTime;
        }
      }
      this.calcIndicesAndTimes(this, sequenceTimeInt, repeatMode);
      int[] calcIndices = this.m_calcIndices;
      int current = calcIndices[0];
      float[] values1 = this.m_values;
      int interpolationType = this.getInterpolationType();
      if (interpolationType == 180)
      {
        Array.Copy((Array) values1, current * this.getComponentCount(), (Array) value, 0, componentCount);
      }
      else
      {
        int num = calcIndices[1];
        float[] values2 = this.m_values;
        float interpolant = this.getInterpolant(this, current, sequenceTime, repeatMode);
        switch (interpolationType - 176)
        {
          case 0:
            this.interpolateValueLINEAR(interpolant, values1, values2, value, componentCount, current * this.getComponentCount(), num * this.getComponentCount());
            break;
          case 1:
            this.interpolateValueSLERP(interpolant, values1, values2, value, current * this.getComponentCount(), num * this.getComponentCount());
            break;
          case 2:
            this.updateTangentCache();
            this.interpolateValueSPLINE(interpolant, values1, values2, this.m_tangentCache, this.m_tangentCache, value, componentCount, current * this.getComponentCount(), num * this.getComponentCount(), current * 2 * this.getComponentCount(), (num * 2 + 1) * this.getComponentCount());
            break;
          case 3:
            this.updateTangentCache();
            this.interpolateValueSPLINE(interpolant, values1, values2, this.m_tangentCache, this.m_tangentCache, value, componentCount, current * this.getComponentCount(), num * this.getComponentCount(), current * 2 * this.getComponentCount(), (num * 2 + 1) * this.getComponentCount());
            break;
        }
      }
    }

    public float getDeltaTime(int index)
    {
      return this.m_deltaTimeCache[index];
    }

    public void invalidateDeltaTimeCache()
    {
      this.m_deltaTimeCacheValid = false;
      this.invalidateTangentCache();
    }

    private void updateDeltaTimeCache()
    {
      if (this.m_deltaTimeCacheValid)
        return;
      int keyframeCount = this.getKeyframeCount();
      if (this.m_deltaTimeCache == null)
        this.m_deltaTimeCache = new float[keyframeCount];
      int validRangeFirst = this.getValidRangeFirst();
      int validRangeLast = this.getValidRangeLast();
      if (validRangeFirst < validRangeLast)
      {
        int num1 = this.getKeyframeTime(0);
        for (int index = 0; index < keyframeCount; ++index)
        {
          int num2 = 0;
          if (index >= validRangeFirst)
          {
            if (index < validRangeLast)
            {
              int keyframeTime = this.getKeyframeTime(index + 1);
              num2 = keyframeTime - num1;
              num1 = keyframeTime;
            }
            else if (index == validRangeLast && this.getRepeatMode() == 193)
              num2 = this.getDuration() - num1 + this.getKeyframeTime(validRangeFirst);
          }
          this.m_deltaTimeCache[index] = (float) num2;
        }
      }
      else if (validRangeFirst == validRangeLast)
        this.m_deltaTimeCache[validRangeFirst] = this.getRepeatMode() != 193 ? 0.0f : (float) this.getDuration();
      this.m_validRangeFirstTime = this.getKeyframeTime(this.getValidRangeFirst());
      this.m_validRangeLastTime = this.getKeyframeTime(this.getValidRangeLast());
      this.m_deltaTimeCacheValid = true;
    }

    private void invalidateTangentCache()
    {
      this.m_tangentCacheValid = false;
    }

    public int getComponentCount()
    {
      return this.m_componentCount;
    }

    public int getDuration()
    {
      return this.m_duration;
    }

    public int getInterpolationType()
    {
      return this.m_interpolation;
    }

    public float[] getIncomingTangent(int current)
    {
      int sourceIndex = current * 2 * this.getComponentCount();
      int length = this.m_tangentCache.Length - sourceIndex;
      float[] numArray = new float[length];
      Array.Copy((Array) this.m_tangentCache, sourceIndex, (Array) numArray, 0, length);
      return numArray;
    }

    public float[] getOutgoingTangent(int next)
    {
      int sourceIndex = (next * 2 + 1) * this.getComponentCount();
      int length = this.m_tangentCache.Length - sourceIndex;
      float[] numArray = new float[length];
      Array.Copy((Array) this.m_tangentCache, sourceIndex, (Array) numArray, 0, length);
      return numArray;
    }

    public void updateTangentCache()
    {
      this.updateDeltaTimeCache();
      if (this.m_tangentCacheValid)
        return;
      int keyframeCount = this.getKeyframeCount();
      int componentCount = this.getComponentCount();
      if (this.m_tangentCache == null)
        this.m_tangentCache = new float[keyframeCount * 2 * this.getComponentCount()];
      int validRangeFirst = this.getValidRangeFirst();
      int validRangeLast = this.getValidRangeLast();
      int repeatMode = this.getRepeatMode();
      if (validRangeFirst <= validRangeLast)
      {
        for (int index1 = 0; index1 < keyframeCount; ++index1)
        {
          float num1 = 0.0f;
          float num2 = 0.0f;
          int index2;
          int num3;
          if (index1 < validRangeFirst || index1 > validRangeLast)
          {
            index2 = index1;
            num3 = index1;
          }
          else
          {
            index2 = this.calcPrevIndex(index1, validRangeFirst, validRangeLast, repeatMode);
            num3 = this.calcNextIndex(index1, validRangeFirst, validRangeLast, repeatMode);
            bool flag1 = index1 == validRangeFirst && repeatMode == 192;
            bool flag2 = index1 == validRangeLast && repeatMode == 192;
            if (!flag1 && !flag2)
            {
              float deltaTime1 = this.getDeltaTime(index1);
              float deltaTime2 = this.getDeltaTime(index2);
              float num4 = deltaTime1 + deltaTime2;
              if ((double) deltaTime1 > 0.0 && (double) num4 > 0.0)
                num1 = 2f * deltaTime1 / num4;
              if ((double) deltaTime2 > 0.0 && (double) num4 > 0.0)
                num2 = 2f * deltaTime2 / num4;
            }
          }
          int num5 = index1 * 2 * this.getComponentCount();
          int num6 = (index1 * 2 + 1) * this.getComponentCount();
          int num7 = index2 * this.getComponentCount();
          int num8 = num3 * this.getComponentCount();
          for (int index3 = 0; index3 < componentCount; ++index3)
          {
            float num4 = (float) (0.5 * ((double) this.m_values[index3 + num8] - (double) this.m_values[index3 + num7]));
            this.m_tangentCache[index3 + num5] = num4 * num1;
            this.m_tangentCache[index3 + num6] = num4 * num2;
          }
        }
      }
      this.m_tangentCacheValid = true;
    }

    public void interpolateValue(
      float currentInterpolant,
      float nextInterpolant,
      float[] current,
      float[] next,
      float[] value,
      int componentCount,
      int currentStartIndex,
      int nextStartIndex)
    {
      for (int index = 0; index < componentCount; ++index)
        value[index] = (float) ((double) currentInterpolant * (double) current[index + currentStartIndex] + (double) nextInterpolant * (double) next[index + nextStartIndex]);
    }

    public void interpolateValueLINEAR(
      float t,
      float[] current,
      float[] next,
      float[] value,
      int componentCount,
      int currentStartIndex,
      int nextStartIndex)
    {
      this.interpolateValue(1f - t, t, current, next, value, componentCount, currentStartIndex, nextStartIndex);
    }

    public void interpolateValueSPLINE(
      float t,
      float[] current,
      float[] next,
      float[] incomingTangent,
      float[] outgoingTangent,
      float[] value,
      int componentCount,
      int currentStartIndex,
      int nextStartIndex,
      int incomingIndex,
      int outgoingIndex)
    {
      float num1 = t * t;
      float num2 = num1 * t;
      float num3 = (float) (2.0 * (double) num2 - 3.0 * (double) num1 + 1.0);
      float num4 = 1f - num3;
      float num5 = num2 - num1;
      float num6 = num5 - num1 + t;
      for (int index = 0; index < componentCount; ++index)
        value[index] = (float) ((double) current[index + currentStartIndex] * (double) num3 + (double) incomingTangent[index + incomingIndex] * (double) num6 + (double) next[index + nextStartIndex] * (double) num4 + (double) outgoingTangent[index + outgoingIndex] * (double) num5);
    }

    private void interpolateValueSLERP(
      float t,
      float[] current,
      float[] next,
      float[] value,
      int currentStartIndex,
      int nextStartIndex)
    {
      float num = (float) ((double) current[currentStartIndex] * (double) next[nextStartIndex] + (double) current[1 + currentStartIndex] * (double) next[1 + nextStartIndex] + (double) current[2 + currentStartIndex] * (double) next[2 + nextStartIndex] + (double) current[3 + currentStartIndex] * (double) next[3 + nextStartIndex]);
      float currentInterpolant = 1f - t;
      float nextInterpolant = t;
      if ((double) num < 0.0)
        nextInterpolant = -nextInterpolant;
      int componentCount = 4;
      this.interpolateValue(currentInterpolant, nextInterpolant, current, next, value, componentCount, currentStartIndex, nextStartIndex);
    }

    public int getKeyframeCount()
    {
      return this.m_keyframeCount;
    }

    public int getRepeatMode()
    {
      return this.m_repeatMode;
    }

    public int getValidRangeFirst()
    {
      return this.m_validRangeFirst;
    }

    public int getValidRangeLast()
    {
      return this.m_validRangeLast;
    }

    public override int getM3GUniqueClassID()
    {
      return 19;
    }
  }
}
