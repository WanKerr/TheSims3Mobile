// Decompiled with JetBrains decompiler
// Type: ea_sdk.EASpywareManager
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

namespace ea_sdk
{
  public class EASpywareManager
  {
    private static EASpywareManager instance;
    private object m_impl;
    private bool enabled;

    private EASpywareManager()
    {
    }

    public static EASpywareManager getInstance()
    {
      if (EASpywareManager.instance == null)
        EASpywareManager.instance = new EASpywareManager();
      return EASpywareManager.instance;
    }

    public bool isEnabled()
    {
      return this.enabled;
    }

    public void setEnabled(bool e)
    {
      this.enabled = e;
    }

    internal void logEvent(int eventId, string str)
    {
      JSystem.println("TODO: Figure out what EASpywaremanager.logEvent() is supposed to do");
    }

    internal void logEvent(int EVT_SIMS3_NEWGAME, string simName, string slotStr)
    {
      JSystem.println("TODO: Figure out what EASpywaremanager.logEvent() is supposed to do");
    }

    internal void logEvent(int EVT_SIMS3_RESETDATA)
    {
      JSystem.println("TODO: Figure out what EASpywaremanager.logEvent() is supposed to do");
    }

    internal void logEventDuration(int EVT_SIMS3_PLAYTIME, int duration)
    {
      JSystem.println("TODO: Figure out what EASpywaremanager.logEvent() is supposed to do");
    }

    internal void logEvent(int EVT_SIMS3_CAS_SKIN, int skin)
    {
      JSystem.println("TODO: Figure out what EASpywaremanager.logEvent() is supposed to do");
    }

    internal void logEvent(int EVT_SIMS3_CAS_HAIR, int hairType, int hairColor)
    {
      JSystem.println("TODO: Figure out what EASpywaremanager.logEvent() is supposed to do");
    }
  }
}
