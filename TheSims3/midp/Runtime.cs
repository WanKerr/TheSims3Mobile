// Decompiled with JetBrains decompiler
// Type: midp.Runtime
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace midp
{
  public abstract class Runtime
  {
    private Vector m_timers = new Vector();
    private int[] m_pointerStatus0 = new int[4];
    private int[] m_pointerStatus1 = new int[4];
    private int[] m_pointerStatus2 = new int[4];
    protected Vector m_midlets = new Vector();
    private static Runtime Runtime_instance;

    protected Runtime()
    {
      if (Runtime.Runtime_instance == null)
        return;
      this.m_timers = new Vector();
      this.m_midlets = new Vector();
      this.m_pointerStatus0[0] = 0;
      this.m_pointerStatus1[0] = 0;
      this.m_pointerStatus2[0] = 0;
      Runtime.Runtime_instance = this;
    }

    public void Dispose()
    {
      for (int index = this.m_midlets.size(); index > 0; index = this.m_midlets.size())
        this.destroyMIDlet(true);
      Vector vector = new Vector();
      for (int index = 0; index < this.m_timers.size(); ++index)
        vector.addElement(this.m_timers.elementAt(index));
      this.m_timers.removeAllElements();
      for (int index = 0; index < vector.size(); ++index)
        ((Timer) vector.elementAt(index))?.cancel();
    }

    public abstract int freeMemory();

    public abstract int totalMemory();

    public void setMIDlet(MIDlet midlet, Display display)
    {
      this.getCurrentMIDlet()?.pauseApp();
      midlet.setDisplay(display);
      this.addMIDlet(midlet);
    }

    public void startMIDlet()
    {
      this.getCurrentMIDlet().startApp();
    }

    public void pauseMIDlet()
    {
      this.getCurrentMIDlet().pauseApp();
    }

    public void destroyMIDlet(bool unconditional)
    {
      MIDlet currentMiDlet = this.getCurrentMIDlet();
      if (currentMiDlet == null)
        return;
      currentMiDlet.destroyApp(unconditional);
      this.removeMIDlet(currentMiDlet);
    }

    public virtual bool eventLoop()
    {
      return this.m_midlets.size() != 0;
    }

    public abstract void scheduleTimer(Timer timer, int delay);

    public abstract void scheduleTimer(Timer timer, int delay, int period);

    public abstract void scheduleTimerAtFixedRate(Timer timer, int delay, int period);

    public void keyPressed(int keyCode)
    {
      this.getCurrentDisplayable()?.keyPressed(keyCode);
    }

    public void keyReleased(int keyCode)
    {
      this.getCurrentDisplayable()?.keyReleased(keyCode);
    }

    public void pointerPressed(int x, int y, int pointerNum, int tapCount)
    {
      int[] pointerStatus = this.getPointerStatus(pointerNum);
      pointerStatus[0] = 1;
      pointerStatus[1] = x;
      pointerStatus[2] = y;
      pointerStatus[3] = tapCount;
      this.getCurrentDisplayable()?.pointerPressed(x, y);
    }

    public void pointerDragged(int x, int y, int pointerNum)
    {
    }

    public void pointerReleased(int x, int y, int pointerNum)
    {
      int[] pointerStatus = this.getPointerStatus(pointerNum);
      pointerStatus[0] = 0;
      pointerStatus[1] = x;
      pointerStatus[2] = y;
      this.getCurrentDisplayable()?.pointerReleased(x, y);
    }

    public int[] getPointerStatus(int pointerNum)
    {
      switch (pointerNum)
      {
        case 0:
          return this.m_pointerStatus0;
        case 1:
          return this.m_pointerStatus1;
        case 2:
          return this.m_pointerStatus2;
        default:
          return this.m_pointerStatus0;
      }
    }

    protected Displayable getCurrentDisplayable()
    {
      MIDlet currentMiDlet = this.getCurrentMIDlet();
      if (currentMiDlet != null)
      {
        Display display = currentMiDlet.getDisplay();
        if (display != null)
          return display.getCurrent();
      }
      return (Displayable) null;
    }

    protected void destroyMIDlet(MIDlet midlet)
    {
      if (midlet == null)
        return;
      this.removeMIDlet(midlet);
    }

    protected MIDlet getCurrentMIDlet()
    {
      return this.m_midlets.size() > 0 ? (MIDlet) this.m_midlets.lastElement() : (MIDlet) null;
    }

    protected void addMIDlet(MIDlet midlet)
    {
      this.m_midlets.addElement((object) midlet);
    }

    protected virtual void removeMIDlet(MIDlet midlet)
    {
      this.m_midlets.removeElement((object) midlet);
    }

    protected void addTimer(Timer timer)
    {
      this.m_timers.addElement((object) timer);
    }

    public void removeTimer(Timer timer)
    {
      this.m_timers.removeElement((object) timer);
    }

    public static Runtime getRuntime()
    {
      return Runtime.Runtime_instance;
    }
  }
}
