// Decompiled with JetBrains decompiler
// Type: midp.TimerTask
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace midp
{
  public class TimerTask : Runnable
  {
    private long m_lastScheduledTime;
    private bool m_repeatScheduled;
    private bool m_hasRun;
    private bool m_cancelFlag;

    protected TimerTask()
    {
      this.m_lastScheduledTime = 0L;
      this.m_repeatScheduled = false;
      this.m_hasRun = false;
      this.m_cancelFlag = false;
    }

    public new void Dispose()
    {
    }

    public bool cancel()
    {
      if (this.m_cancelFlag)
        return false;
      this.m_cancelFlag = true;
      return !this.m_repeatScheduled && !this.m_hasRun || this.m_repeatScheduled;
    }

    public override void run()
    {
      this.m_hasRun = true;
    }

    public long scheduledExecutionTime()
    {
      return this.m_lastScheduledTime;
    }

    public bool wantsToCancel()
    {
      return this.m_cancelFlag;
    }

    public void setLastScheduledExecutionTime(long time)
    {
      this.m_lastScheduledTime = time;
    }
  }
}
