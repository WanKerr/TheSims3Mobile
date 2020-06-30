// Decompiled with JetBrains decompiler
// Type: midp.Player
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;

namespace midp
{
  public class Player
  {
    private static Player playerToResume;
    private Song curSong;
    private SoundEffectInstance curSoundInstance;
    private SoundEffect curSoundEffect;
    private bool isSong;
    private bool playing;
    private int repeat;
    private long duration;
    private float m_volume;
    private float m_pitch;

    public float Volume
    {
      get
      {
        return this.m_volume;
      }
      set
      {
        double num = (double) MathHelper.Clamp(value, 0.0f, 1f);
        this.m_volume = value;
        if (this.isSong)
          MediaPlayer.Volume = this.m_volume;
        else
          this.curSoundInstance.Volume = this.m_volume;
      }
    }

    public float Pitch
    {
      get
      {
        return this.m_pitch;
      }
      set
      {
        double num = (double) MathHelper.Clamp(value, 0.0f, 1f);
        this.m_pitch = value;
        if (this.isSong)
          return;
        this.curSoundInstance.Pitch = this.m_pitch;
      }
    }

    public Player(SoundEffect snd)
    {
      this.curSoundEffect = snd;
      this.curSoundInstance = this.curSoundEffect.CreateInstance();
      this.isSong = false;
      this.duration = (long) snd.Duration.TotalMilliseconds;
      MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>(this.MediaPlayer_MediaStateChanged);
    }

    public Player(Song song)
    {
      this.curSong = song;
      this.isSong = true;
      this.duration = (long) song.Duration.TotalMilliseconds;
      MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>(this.MediaPlayer_MediaStateChanged);
    }

    private void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
    {
      if (MediaPlayer.State == MediaState.Stopped)
        this.playing = false;
      if (!MediaPlayer.GameHasControl || Player.playerToResume == null)
        return;
      Player.playerToResume.start();
    }

    public void start()
    {
      try
      {
        if (this.isSong)
        {
          if (MediaPlayer.GameHasControl)
          {
            MediaPlayer.Play(this.curSong);
            MediaPlayer.Volume = this.Volume;
            MediaPlayer.IsRepeating = this.repeat == -1;
            Player.playerToResume = (Player) null;
          }
          else
            Player.playerToResume = this;
        }
        else
        {
          this.curSoundInstance = this.curSoundEffect.CreateInstance();
          this.curSoundInstance.Volume = this.Volume;
          this.curSoundInstance.Play();
        }
        this.playing = true;
      }
      catch (Exception ex)
      {
      }
    }

    public void stop()
    {
      if (this.isSong)
      {
        if (MediaPlayer.GameHasControl)
          MediaPlayer.Stop();
      }
      else if (this.curSoundInstance != null && !this.curSoundInstance.IsDisposed)
        this.curSoundInstance.Stop();
      this.playing = false;
    }

    public void close()
    {
      if (!this.playing)
        this.stop();
      if (!this.isSong)
      {
        if (this.curSoundInstance != null && !this.curSoundInstance.IsDisposed)
          this.curSoundInstance.Dispose();
        if (this.curSoundEffect == null || this.curSoundEffect.IsDisposed)
          return;
        this.curSoundEffect.Dispose();
      }
      else
        this.curSong.Dispose();
    }

    public void setLoopCount(int count)
    {
      this.repeat = count;
    }

    public bool isPlaying()
    {
      if (this.isSong)
        return this.playing;
      return this.curSoundInstance != null && this.curSoundInstance.State == SoundState.Playing;
    }

    internal long getDuration()
    {
      return this.duration;
    }
  }
}
