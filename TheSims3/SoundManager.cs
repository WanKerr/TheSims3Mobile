// Decompiled with JetBrains decompiler
// Type: SoundManager
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class SoundManager
{
  private byte[] d_groupFlags;
  private short[] d_eventResources;
  private byte[] d_eventGroups;
  private byte[] d_eventInstances;
  private byte[] d_eventFlags;
  private float m_globalVolume;
  private float m_musicVolume;
  private float m_sfxVolume;
  private Player[][] m_players;
  private float[][] m_volumes;
  private float[] m_groupVolumes;
  private string m_volumeString;
  private string m_positionString;
  private string m_pitchString;

  public int getEventGroup(int eventID)
  {
    return (int) this.d_eventGroups[eventID];
  }

  public SoundManager()
  {
    this.d_groupFlags = (byte[]) null;
    this.d_eventResources = (short[]) null;
    this.d_eventGroups = (byte[]) null;
    this.d_eventInstances = (byte[]) null;
    this.d_eventFlags = (byte[]) null;
    this.m_globalVolume = 1f;
    this.m_musicVolume = 1f;
    this.m_sfxVolume = 1f;
    this.m_players = (Player[][]) null;
    this.m_volumes = (float[][]) null;
    this.m_groupVolumes = (float[]) null;
    this.m_volumeString = (string) null;
    this.m_positionString = (string) null;
    this.m_pitchString = (string) null;
    this.m_volumeString = "VolumeControl";
    this.m_positionString = "PositionControl";
    this.m_pitchString = "PitchControl";
  }

  public virtual void Dispose()
  {
    int length = this.d_eventResources.Length;
    for (int eventID = 0; eventID < length; ++eventID)
      this.unloadEvent(eventID);
  }

  public void loadData()
  {
    AppEngine.getResourceManager();
    DataInputStream dataInputStream = new DataInputStream(ResourceManager.loadBinaryFile(182));
    int length1 = (int) dataInputStream.readByte();
    byte[] numArray1 = new byte[length1];
    for (int index = 0; index < length1; ++index)
      numArray1[index] = (byte) dataInputStream.readByte();
    int length2 = (int) dataInputStream.readShort();
    short[] numArray2 = new short[length2];
    byte[] numArray3 = new byte[length2];
    byte[] numArray4 = new byte[length2];
    byte[] numArray5 = new byte[length2];
    for (int index = 0; index < length2; ++index)
    {
      numArray2[index] = (short) GlobalConstants.SOUND_DATA_SETS[(int) dataInputStream.readShort()];
      numArray3[index] = (byte) dataInputStream.readByte();
      numArray4[index] = (byte) dataInputStream.readByte();
      numArray5[index] = (byte) dataInputStream.readByte();
    }
    this.d_groupFlags = numArray1;
    this.d_eventResources = numArray2;
    this.d_eventGroups = numArray3;
    this.d_eventInstances = numArray4;
    this.d_eventFlags = numArray5;
    this.m_players = new Player[length2][];
    this.m_volumes = new float[length2][];
    this.m_groupVolumes = new float[length1];
    for (int index = 0; index < length1; ++index)
      this.m_groupVolumes[index] = 1f;
  }

  private Player loadPlayer(int eventID)
  {
    string filename = ResourceManager.ID_TO_FILENAME((int) this.d_eventResources[eventID]);
    bool flag = false;
    if (filename.EndsWith(".m4v") || filename.EndsWith(".caf"))
      flag = true;
    Player player = Manager.createPlayer(filename);
    if (player != null)
    {
      int num = flag ? 1 : 0;
    }
    return player;
  }

  public void loadEvent(int eventID)
  {
    this.unloadEvent(eventID);
    int dEventInstance = (int) this.d_eventInstances[eventID];
    Player[] playerArray = new Player[dEventInstance];
    float[] numArray = new float[dEventInstance];
    this.m_players[eventID] = playerArray;
    this.m_volumes[eventID] = numArray;
    Player player1 = (Player) null;
    for (int instance = 0; instance < dEventInstance; ++instance)
    {
      Player player2;
      if (instance == 0)
      {
        player1 = this.loadPlayer(eventID);
        player2 = player1;
      }
      else
        player2 = player1;
      playerArray[instance] = player2;
      numArray[instance] = 1f;
      this.applyVolume(eventID, instance);
    }
  }

  public bool isEventLoaded(int eventID)
  {
    return this.m_players[eventID] != null;
  }

  public void unloadEvent(int eventID)
  {
    Player[] player1 = this.m_players[eventID];
    if (player1 != null)
    {
      for (int index = 0; index < player1.Length; ++index)
      {
        Player player2 = player1[index];
        if (player2 != null)
        {
          player2.stop();
          player2.close();
        }
      }
    }
    this.m_players[eventID] = (Player[]) null;
    this.m_volumes[eventID] = (float[]) null;
  }

  public int playEvent(int eventID)
  {
    return this.playEvent(eventID, 1f);
  }

  public int playEvent(int eventID, float volume)
  {
    Player[] player1 = this.m_players[eventID];
    if (player1 != null)
    {
      for (int instance = 0; instance < player1.Length; ++instance)
      {
        Player player2 = player1[instance];
        if (!player2.isPlaying())
        {
          int handle = this.getHandle(eventID, instance);
          this.setVolumeEvent(handle, volume);
          player2.start();
          return handle;
        }
      }
    }
    return -1;
  }

  public int playEventAt(int eventID, float posX, float posY, float posZ)
  {
    return this.playEventAt(eventID, posX, posY, posZ, 1f);
  }

  public int playEventAt(int eventID, float posX, float posY, float posZ, float volume)
  {
    int handle = this.playEvent(eventID, volume);
    if (handle != -1)
      this.setEventPosition(handle, posX, posY, posZ, 0.0f, 0.0f, 0.0f);
    return handle;
  }

  public void pauseEvent(int handle)
  {
    if (handle < 0)
      return;
    Player player = this.m_players[this.getHandleEventId(handle)][this.getHandleInstanceId(handle)];
    if (player == null)
      return;
    player.stop();
    this.setVolumeEvent(handle, 0.0f);
  }

  public void stopEvent(int handle)
  {
    if (handle < 0)
      return;
    Player player = this.m_players[this.getHandleEventId(handle)][this.getHandleInstanceId(handle)];
    if (player == null)
      return;
    player.stop();
    this.setVolumeEvent(handle, 0.0f);
  }

  private int getHandle(int eventID, int instance)
  {
    return eventID | instance << 16;
  }

  private int getHandleEventId(int handle)
  {
    return handle & (int) ushort.MaxValue;
  }

  private int getHandleInstanceId(int handle)
  {
    return handle >> 16 & (int) ushort.MaxValue;
  }

  public void addPlayerListener(int eventId, PlayerListener listener)
  {
    Player[] player = this.m_players[eventId];
    int num = 0;
    while (num < player.Length)
      ++num;
  }

  public void removePlayerListener(int eventId, PlayerListener listener)
  {
    Player[] player = this.m_players[eventId];
    int num = 0;
    while (num < player.Length)
      ++num;
  }

  public int getDurationMicros(int eventID, int instance)
  {
    if (eventID < 0 || this.m_players.Length <= eventID || (instance < 0 || this.m_players[eventID].Length <= instance))
      return 0;
    Player player = this.m_players[eventID][instance];
    return player == null ? 0 : (int) player.getDuration();
  }

  public long getEventTimeMicros(int eventID, int instance)
  {
    if (eventID < 0 || this.m_players.Length <= eventID || (instance < 0 || this.m_players[eventID].Length <= instance))
      return 0;
    Player player = this.m_players[eventID][instance];
    return player == null ? 0L : player.getDuration();
  }

  public void setEventTimeMicros(int eventID, int instance, long time)
  {
    if (0 > eventID && eventID >= this.m_players.Length && (0 > instance && instance >= this.m_players[eventID].Length))
      return;
    Player player = this.m_players[eventID][instance];
  }

  public bool isEventPlaying(int eventID)
  {
    return this.getEventPlayingHandle(eventID) != -1;
  }

  public int getEventPlayingHandle(int eventID)
  {
    Player[] player = this.m_players[eventID];
    if (player != null)
    {
      for (int index = 0; index < player.Length; ++index)
      {
        if (player[index].isPlaying())
          return index;
      }
    }
    return -1;
  }

  private float calcEventVolume(int eventID, int instance)
  {
    float num = this.m_globalVolume * this.m_volumes[eventID][instance];
    int dEventGroup = (int) this.d_eventGroups[eventID];
    int dGroupFlag = (int) this.d_groupFlags[dEventGroup];
    if ((dGroupFlag & 2) != 0)
      num *= this.m_sfxVolume;
    if ((dGroupFlag & 1) != 0)
      num *= this.m_musicVolume;
    return num * this.m_groupVolumes[dEventGroup];
  }

  private void applyVolume(int eventID, int instance)
  {
    this.m_players[eventID][instance].Volume = this.calcEventVolume(eventID, instance);
  }

  public void setVolumeGlobal(float volume)
  {
    this.m_globalVolume = volume;
    for (int eventID = 0; eventID < this.m_players.Length; ++eventID)
    {
      if (this.m_players[eventID] != null)
      {
        for (int instance = 0; instance < this.m_players[eventID].Length; ++instance)
          this.applyVolume(eventID, instance);
      }
    }
  }

  public float getVolumeGlobal()
  {
    return this.m_globalVolume;
  }

  public void setVolumeMusic(float volume)
  {
    this.m_musicVolume = volume;
    for (int eventID = 0; eventID < this.m_players.Length; ++eventID)
    {
      if (((int) this.d_groupFlags[(int) this.d_eventGroups[eventID]] & 1) != 0 && this.m_players[eventID] != null)
      {
        for (int instance = 0; instance < this.m_players[eventID].Length; ++instance)
          this.applyVolume(eventID, instance);
      }
    }
  }

  public float getVolumeMusic()
  {
    return this.m_musicVolume;
  }

  public void setVolumeSFX(float volume)
  {
    this.m_sfxVolume = volume;
    for (int eventID = 0; eventID < this.m_players.Length; ++eventID)
    {
      if (((int) this.d_groupFlags[(int) this.d_eventGroups[eventID]] & 2) != 0 && this.m_players[eventID] != null)
      {
        for (int instance = 0; instance < this.m_players[eventID].Length; ++instance)
          this.applyVolume(eventID, instance);
      }
    }
  }

  public float getVolumeSFX()
  {
    return this.m_sfxVolume;
  }

  public void setVolumeEvent(int handle, float volume)
  {
    if (handle < 0)
      return;
    this.applyVolume(this.getHandleEventId(handle), this.getHandleInstanceId(handle));
  }

  public void setLoopCountEvent(int handle, int loopCount)
  {
    if (handle < 0)
      return;
    this.m_players[this.getHandleEventId(handle)][this.getHandleInstanceId(handle)]?.setLoopCount(loopCount);
  }

  public void setVolumeGroup(int group, float volume)
  {
    this.m_groupVolumes[group] = volume;
    for (int eventID = 0; eventID < this.m_players.Length; ++eventID)
    {
      if ((int) this.d_eventGroups[eventID] == group)
      {
        for (int instance = 0; instance < this.m_players[eventID].Length; ++instance)
          this.applyVolume(eventID, instance);
      }
    }
  }

  public void setListenerPosition(
    float posX,
    float posY,
    float posZ,
    float velX,
    float velY,
    float velZ,
    float atX,
    float atY,
    float atZ,
    float upX,
    float upY,
    float upZ)
  {
    Manager.setListenerPosition(posX, posY, posZ);
    Manager.setListenerVelocity(velX, velY, velZ);
  }

  public void setEventPosition(
    int handle,
    float posX,
    float posY,
    float posZ,
    float velX,
    float velY,
    float velZ)
  {
    Player player = this.m_players[this.getHandleEventId(handle)][this.getHandleInstanceId(handle)];
  }

  public void setEventPitch(int handle, float pitchFactor)
  {
    Player player = this.m_players[this.getHandleEventId(handle)][this.getHandleInstanceId(handle)];
  }

  public void pause()
  {
  }

  public void resume()
  {
  }

  public void update(int timeStep)
  {
  }
}
