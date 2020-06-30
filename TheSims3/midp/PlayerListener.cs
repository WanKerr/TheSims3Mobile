// Decompiled with JetBrains decompiler
// Type: midp.PlayerListener
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace midp
{
  public class PlayerListener
  {
    public const string CLOSED = "closed";
    public const string DEVICE_AVAILABLE = "deviceAvailable";
    public const string DEVICE_UNAVAILABLE = "deviceUnavailable";
    public const string DURATION_UPDATED = "durationUpdated";
    public const string END_OF_MEDIA = "endOfMedia";
    public const string ERROR = "error";
    public const string STARTED = "started";
    public const string STOPPED = "stopped";
    public const string VOLUME_CHANGED = "volumeChanged";

    protected PlayerListener()
    {
    }

    public virtual void playerUpdate(Player player, string _event, object eventData)
    {
    }
  }
}
