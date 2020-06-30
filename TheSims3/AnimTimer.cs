// Decompiled with JetBrains decompiler
// Type: AnimTimer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

public class AnimTimer
{
  public const int TIMERFLAG_NONE = 0;
  private const int TIMERFLAG_INITIALISED = 1;
  private const int TIMERFLAG_ANIMATING = 2;
  public const int TIMERFLAG_LOOP = 4;
  public const int TIMERFLAG_RESTART = 16;
  public const int TIMERFLAG_RESTART_LOOP = 20;
  private int m_timerID;
  private int m_time;
  private int m_timeMax;
  private int m_flags;

  public AnimTimer()
  {
    this.m_timerID = -1;
    this.m_time = 0;
    this.m_timeMax = 0;
    this.m_flags = 0;
  }

  public void startTimer(int timerID, int bitflag)
  {
    if ((bitflag & 16) != 0 || this.m_timerID != timerID)
    {
      this.m_timerID = timerID;
      this.m_time = 0;
      switch (timerID)
      {
        case 0:
          this.m_timeMax = 400;
          break;
        case 1:
          this.m_timeMax = 300;
          break;
        case 2:
          this.m_timeMax = 500;
          break;
        case 3:
          this.m_timeMax = 1000;
          break;
        case 4:
          this.m_timeMax = 1000;
          break;
        case 5:
          this.m_timeMax = 1000;
          break;
        case 6:
          this.m_timeMax = 1500;
          break;
      }
    }
    this.m_flags = 3 | bitflag & 4;
  }

  public bool updateTimer(int interval)
  {
    if ((this.m_flags & 2) == 0)
      return false;
    this.m_time += interval;
    if (this.m_time <= this.m_timeMax)
      return false;
    if ((this.m_flags & 4) != 0)
    {
      this.m_time %= this.m_timeMax;
      return false;
    }
    this.setAnimating(false);
    return true;
  }

  public int getTimerID()
  {
    return this.m_timerID;
  }

  public bool isInitialised()
  {
    return (this.m_flags & 1) != 0;
  }

  public bool isAnimating()
  {
    return (this.m_flags & 2) != 0;
  }

  public bool isLooping()
  {
    return (this.m_flags & 4) != 0;
  }

  public void setAnimating(bool b)
  {
    if (b)
      this.m_flags |= 2;
    else
      this.m_flags &= -3;
  }

  public float getValue()
  {
    switch (this.m_timerID)
    {
      case 0:
        return this.getValueSelectFlash();
      case 1:
        return this.getValueToggleFlash();
      case 2:
        return this.getValuePopup();
      case 3:
        return this.getValueGrowBounce();
      case 4:
        return (float) (1.0 + (double) this.getValueLinear() * 2.0);
      case 5:
        return this.getValueLinearInv();
      case 6:
        return this.getValueThreeFlashes();
      default:
        return 0.0f;
    }
  }

  public float getValueLinear()
  {
    return (float) this.m_time / (float) this.m_timeMax;
  }

  public float getValueLinearInv()
  {
    return (float) (1.0 - (double) this.m_time / (double) this.m_timeMax);
  }

  public float getValueSmooth()
  {
    return MathExt.smoothstep(0.0f, (float) this.m_timeMax, (float) this.m_time);
  }

  public float getValueSelectFlash()
  {
    int num = this.m_timeMax >> 1;
    return (float) (1.0 - (double) ((float) (this.m_time % num) / (float) num) * 0.75);
  }

  public float getValueToggleFlash()
  {
    return 1f + (float) Math.Sin((double) ((float) this.m_time * 3.141593f / (float) this.m_timeMax));
  }

  public float getValuePopup()
  {
    float valueLinear = this.getValueLinear();
    if ((double) valueLinear < 0.5)
      return (float) Math.Sin((double) (valueLinear * 2f * 1.570796f)) * 1.1f;
    float num = (float) (((double) valueLinear - 0.5) * 2.0);
    return (float) (Math.Cos((double) num * 3.0 * 3.14159274101257) * (0.100000001490116 - 0.100000001490116 * (double) num) + 1.0);
  }

  public float getValueGrowBounce()
  {
    float valueLinear = this.getValueLinear();
    if ((double) valueLinear < 0.5)
      return (float) Math.Sin((double) (valueLinear * 2f * 1.570796f)) * 1.5f;
    float num = (float) (((double) valueLinear - 0.5) * 2.0);
    return (float) (Math.Cos((double) num * 0.5 * 3.14159274101257) * (0.5 - 0.5 * (double) num) + 1.0);
  }

  public float getValueThreeFlashes()
  {
    int num = this.m_timeMax / 3;
    return 1f - (float) (this.m_time % num) / (float) num;
  }
}
