// Decompiled with JetBrains decompiler
// Type: midp.Timer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace midp
{
  public class Timer
  {
    private TimerTask m_task;
    private int m_delay;
    private int m_period;
    private bool m_isFixedRate;

    public Timer()
    {
      this.m_task = (TimerTask) null;
      this.m_delay = 0;
      this.m_period = 0;
      this.m_isFixedRate = false;
    }

    public void Dispose()
    {
      this.m_task = (TimerTask) null;
    }

    protected void setTask(TimerTask task)
    {
      this.m_task = task;
    }

    public TimerTask getTask()
    {
      return this.m_task;
    }

    public void cancel()
    {
      TimerTask task = this.m_task;
      this.setTask((TimerTask) null);
      task?.cancel();
    }

    public void schedule(TimerTask task, int delay)
    {
      this.setTask(task);
      this.m_delay = delay;
      this.m_period = 0;
      this.m_isFixedRate = false;
      Runtime.getRuntime().scheduleTimer(this, delay);
    }

    public void schedule(TimerTask task, int delay, int period)
    {
      this.setTask(task);
      this.m_delay = delay;
      this.m_period = period;
      this.m_isFixedRate = false;
      Runtime.getRuntime().scheduleTimer(this, delay, period);
    }

    public void scheduleAtFixedRate(TimerTask task, int delay, int period)
    {
      this.setTask(task);
      this.m_delay = delay;
      this.m_period = period;
      this.m_isFixedRate = true;
      Runtime.getRuntime().scheduleTimerAtFixedRate(this, delay, period);
    }

    public int getPeriod()
    {
      return this.m_period;
    }

    protected int getDelay()
    {
      return this.m_delay;
    }

    protected bool isFixedRate()
    {
      return this.m_isFixedRate;
    }
  }
}
