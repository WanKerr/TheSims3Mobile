// Decompiled with JetBrains decompiler
// Type: BGMusic
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class BGMusic : PlayerListener
{
  public static readonly int[] STEREO_TRACKS = new int[6]
  {
    6,
    7,
    8,
    9,
    10,
    11
  };
  private const int NUM_STEREO_TRACKS = 6;
  public const int RESUME = 0;
  public const int RESTART = 1;
  public const int LOOP = 2;
  private SoundManager m_soundManager;
  private bool m_playing;
  private bool m_enabled;
  private int m_eventPlaying;
  private int m_stereoTrackCurrent;
  private bool m_looped;

  public BGMusic(SoundManager soundManager)
  {
    this.m_soundManager = soundManager;
    this.m_playing = false;
    this.m_eventPlaying = -1;
    this.m_stereoTrackCurrent = -1;
    this.m_looped = false;
    this.m_enabled = true;
  }

  public void Dispose()
  {
  }

  public bool getEnabled()
  {
    return this.m_enabled;
  }

  public void setEnabled(bool enabled)
  {
    this.m_enabled = enabled;
    this.refreshVolume();
  }

  private void refreshVolume()
  {
    this.m_soundManager.setVolumeMusic(!this.m_enabled || !this.m_playing ? 0.0f : 1f);
  }

  public void playMusic(int eventId, int flags)
  {
    if (this.m_eventPlaying != eventId)
      this.m_soundManager.stopEvent(this.m_eventPlaying);
    this.m_playing = true;
    this.m_looped = (flags & 2) != 0;
    this.m_eventPlaying = eventId;
    if (!this.m_soundManager.isEventLoaded(this.m_eventPlaying))
      this.m_soundManager.loadEvent(this.m_eventPlaying);
    this.refreshVolume();
    this.m_soundManager.setLoopCountEvent(this.m_eventPlaying, -1);
    this.m_soundManager.playEvent(this.m_eventPlaying);
  }

  public void playStereo()
  {
    int index = AppEngine.getCanvas().rand(0, 5);
    this.playMusic(BGMusic.STEREO_TRACKS[index], 0);
    this.m_stereoTrackCurrent = index;
  }

  public void playStereoNextTrack()
  {
    if (this.m_stereoTrackCurrent == -1)
    {
      this.playStereo();
    }
    else
    {
      this.m_soundManager.stopEvent(BGMusic.STEREO_TRACKS[this.m_stereoTrackCurrent]);
      this.m_stereoTrackCurrent = (this.m_stereoTrackCurrent + 1) % 6;
      this.playMusic(BGMusic.STEREO_TRACKS[this.m_stereoTrackCurrent], 0);
    }
  }

  public void beQuiet()
  {
    this.m_playing = false;
    this.refreshVolume();
    this.m_stereoTrackCurrent = -1;
  }

  private void restartMusic()
  {
    if (this.m_playing)
      this.m_soundManager.stopEvent(this.m_stereoTrackCurrent);
    this.m_soundManager.playEvent(this.m_eventPlaying);
  }

  public void setLooped(bool looped)
  {
    this.m_looped = looped;
  }

  public void update(int timeStep)
  {
  }

  public void suspend()
  {
    if (!this.m_playing)
      return;
    this.m_soundManager.stopEvent(this.m_eventPlaying);
  }

  public void resume()
  {
    if (this.m_eventPlaying == -1)
      return;
    this.m_soundManager.playEvent(this.m_eventPlaying);
  }

  public bool isPlaying()
  {
    return this.m_playing;
  }
}
