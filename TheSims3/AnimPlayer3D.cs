// Decompiled with JetBrains decompiler
// Type: AnimPlayer3D
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;

public class AnimPlayer3D
{
  public const int ANIMFLAG_NONE = 0;
  private const int ANIMFLAG_INITIALISED = 1;
  private const int ANIMFLAG_ANIMATING = 2;
  public const int ANIMFLAG_LOOP = 4;
  public const int ANIMFLAG_REVERSE = 8;
  public const int ANIMFLAG_RESTART = 16;
  public const int ANIMFLAG_RESTART_LOOP = 20;
  public const short DEFAULT_PLAYBACKSPEED = 128;
  public const sbyte DEFAULT_PLAYBACKSPEED_SHIFT = 7;
  public const sbyte DEFAULT_FRAME_TIME = 40;
  private AnimationManager3D m_animMgr3D;
  private int m_animID;
  private int m_frameTime;
  private int m_animTime;
  private int m_animStartTime;
  private int m_animEndTime;
  private int m_playbackSpeed;
  private int m_flags;
  private Node m_node;

  public AnimPlayer3D(AnimationManager3D animMgr3D)
  {
    this.m_animMgr3D = animMgr3D;
    this.m_animID = -1;
    this.m_frameTime = 40;
    this.m_animTime = 0;
    this.m_animStartTime = 0;
    this.m_animEndTime = 0;
    this.m_playbackSpeed = 128;
    this.m_flags = 1;
    this.m_node = (Node) null;
  }

  public void Dispose()
  {
    this.m_node = (Node) null;
  }

  public void updateAnim(int interval)
  {
    int flags = this.m_flags;
    if ((flags & 1) == 0 || (flags & 2) == 0)
      return;
    int animTime = this.m_animTime;
    int num = interval * this.m_playbackSpeed >> 7;
    int animStartTime = this.m_animStartTime;
    int animEndTime = this.m_animEndTime;
    int time;
    if ((flags & 8) != 0)
    {
      time = animTime - num;
      if (time < animStartTime)
      {
        if ((flags & 4) != 0)
        {
          time = num >= animEndTime - animStartTime ? animEndTime : time + animEndTime + animStartTime;
        }
        else
        {
          time = animStartTime;
          flags &= -3;
        }
      }
    }
    else
    {
      time = animTime + num;
      if (time > animEndTime)
      {
        if ((flags & 4) != 0)
        {
          time = num >= animEndTime - animStartTime ? animEndTime : time - animEndTime + animStartTime;
        }
        else
        {
          time = animEndTime;
          flags &= -3;
        }
      }
    }
    this.m_animTime = time;
    this.m_flags = flags;
    if (this.m_node == null)
      return;
    this.m_node.animate(time);
  }

  public void startAnim(int animID, int animFlags)
  {
    bool flag1 = (animFlags & 16) != 0;
    bool flag2 = (animFlags & 4) != 0;
    if ((this.m_flags & 1) == 0 || animID >= this.m_animMgr3D.getNumAnimations() || animID < 0)
      return;
    if (flag1 || this.m_animID != animID)
    {
      this.m_animID = (int) (short) animID;
      int animStartFrame = this.m_animMgr3D.getAnimStartFrame(animID);
      int animEndFrame = this.m_animMgr3D.getAnimEndFrame(animID);
      this.m_animStartTime = animStartFrame * this.m_frameTime;
      this.m_animEndTime = animEndFrame * this.m_frameTime;
      this.m_animTime = (this.m_flags & 8) == 0 ? this.m_animStartTime : this.m_animEndTime;
    }
    else if (this.m_animTime > this.m_animEndTime)
      this.m_animTime = this.m_animEndTime;
    else if (this.m_animTime < this.m_animStartTime)
      this.m_animTime = this.m_animStartTime;
    int num = 3;
    if (flag2)
      num |= 4;
    this.m_flags = num | this.m_flags & 8;
    if (this.m_node == null)
      return;
    this.m_node.animate(this.m_animTime);
  }

  public int getAnimID()
  {
    return this.m_animID;
  }

  public bool isAnimating()
  {
    return (this.m_flags & 2) != 0;
  }

  public bool isReverse()
  {
    return (this.m_flags & 8) != 0;
  }

  public bool isLooping()
  {
    return (this.m_flags & 4) != 0;
  }

  public int getAnimTime()
  {
    return (this.m_flags & 1) == 0 ? 0 : this.m_animTime - this.m_animStartTime;
  }

  public int getAnimWorldTime()
  {
    return this.m_animTime;
  }

  public int getAnimWorldFrame()
  {
    return this.m_animTime / this.m_frameTime;
  }

  public int getAnimDuration()
  {
    return (this.m_flags & 1) == 0 ? 0 : (this.m_animEndTime - this.m_animStartTime) * 128 / this.m_playbackSpeed;
  }

  public int getWindowIndex()
  {
    if ((this.m_flags & 1) == 0)
      return -1;
    int num = this.m_animTime / this.m_frameTime;
    int animNumWindows = this.m_animMgr3D.getAnimNumWindows(this.m_animID);
    for (int windowIndex = 0; windowIndex < animNumWindows; ++windowIndex)
    {
      int windowStartFrame = this.m_animMgr3D.getAnimWindowStartFrame(this.m_animID, windowIndex);
      int animWindowEndFrame = this.m_animMgr3D.getAnimWindowEndFrame(this.m_animID, windowIndex);
      if (num >= windowStartFrame && num <= animWindowEndFrame)
        return windowIndex;
    }
    return -1;
  }

  public bool isWithinWindow()
  {
    return this.getWindowIndex() != -1;
  }

  public int getWindowFlags()
  {
    if ((this.m_flags & 1) == 0)
      return -1;
    int num1 = 0;
    int num2 = this.m_animTime / this.m_frameTime;
    int animNumWindows = this.m_animMgr3D.getAnimNumWindows(this.m_animID);
    for (int windowIndex = 0; windowIndex < animNumWindows; ++windowIndex)
    {
      int windowStartFrame = this.m_animMgr3D.getAnimWindowStartFrame(this.m_animID, windowIndex);
      int animWindowEndFrame = this.m_animMgr3D.getAnimWindowEndFrame(this.m_animID, windowIndex);
      if (num2 >= windowStartFrame && num2 <= animWindowEndFrame)
        num1 |= this.m_animMgr3D.getAnimWindowFlags(this.m_animID, windowIndex);
    }
    return num1;
  }

  public bool isWithinWindow(int windowid)
  {
    if ((this.m_flags & 1) == 0)
      return false;
    int animNumWindows = this.m_animMgr3D.getAnimNumWindows(this.m_animID);
    if (windowid >= 0 && windowid < animNumWindows)
    {
      int num = this.m_animTime / this.m_frameTime;
      int windowStartFrame = this.m_animMgr3D.getAnimWindowStartFrame(this.m_animID, windowid);
      int animWindowEndFrame = this.m_animMgr3D.getAnimWindowEndFrame(this.m_animID, windowid);
      if (num >= windowStartFrame && num <= animWindowEndFrame)
        return true;
    }
    return false;
  }

  public bool hasPassedWindow()
  {
    if ((this.m_flags & 1) == 0)
      return false;
    int num = this.m_animTime / this.m_frameTime;
    int animNumWindows = this.m_animMgr3D.getAnimNumWindows(this.m_animID);
    for (int windowIndex = 0; windowIndex < animNumWindows; ++windowIndex)
    {
      int animWindowEndFrame = this.m_animMgr3D.getAnimWindowEndFrame(this.m_animID, windowIndex);
      if (num >= animWindowEndFrame)
        return true;
    }
    return false;
  }

  public bool hasPassedWindow(int windowid)
  {
    if ((this.m_flags & 1) == 0)
      return false;
    int animNumWindows = this.m_animMgr3D.getAnimNumWindows(this.m_animID);
    return windowid >= 0 && windowid < animNumWindows && this.m_animTime / this.m_frameTime >= this.m_animMgr3D.getAnimWindowEndFrame(this.m_animID, windowid);
  }

  public void setReverse(bool reverse)
  {
    if (reverse)
      this.m_flags |= 8;
    else
      this.m_flags &= -9;
  }

  public void setAnimating(bool animating)
  {
    if (animating)
      this.m_flags |= 2;
    else
      this.m_flags &= -3;
  }

  public void setAnimTime(int time)
  {
    this.m_animTime = this.m_animStartTime + time;
    if (this.m_node == null)
      return;
    this.m_node.animate(this.m_animTime);
  }

  public void setAnimWorldTime(int time)
  {
    this.m_animTime = time;
    if (this.m_node == null)
      return;
    this.m_node.animate(this.m_animTime);
  }

  public void setFrameTime(int frameTime)
  {
    this.m_frameTime = frameTime;
  }

  public int getFrameTime()
  {
    return this.m_frameTime;
  }

  public void setFramesPerSecond(int fps)
  {
    this.m_frameTime = 1000 / fps;
  }

  public void setPlaybackSpeed(int speed)
  {
    this.m_playbackSpeed = speed;
  }

  public int getPlaybackSpeed()
  {
    return this.m_playbackSpeed;
  }

  public void setDuration(int time)
  {
    this.m_playbackSpeed = (this.m_animEndTime - this.m_animStartTime) * 128 / time;
  }

  public int getStartTime()
  {
    return this.m_animStartTime;
  }

  public int getEndTime()
  {
    return this.m_animEndTime;
  }

  public void setNode(Node node)
  {
    this.m_node = node;
  }

  public Node getNode()
  {
    return this.m_node;
  }
}
