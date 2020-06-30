// Decompiled with JetBrains decompiler
// Type: midp.Manager
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace midp
{
  public sealed class Manager
  {
    public static Player createPlayer(string filename)
    {
      string withoutExtension = Path.GetFileNameWithoutExtension(filename);
      string extension = Path.GetExtension(filename);
      ContentManager contentManager = new ContentManager(JavaLib.ServiceProvider, "Content");
      return extension == ".mp3" || extension == ".wma" ? new Player(contentManager.Load<Song>(withoutExtension)) : new Player(contentManager.Load<SoundEffect>(withoutExtension));
    }

    public static bool isOtherAudioPlaying()
    {
      return MediaPicker.isPlaying();
    }

    internal static void setListenerPosition(float p, float p_2, float p_3)
    {
      midp.JSystem.println("TODO: implement setListenerPosition");
    }

    internal static void setListenerOrientation(
      float p,
      float p_2,
      float p_3,
      int p_4,
      int p_5,
      int p_6)
    {
      midp.JSystem.println("TODO: implement setListenerOrientation");
    }

    internal static void setListenerVelocity(float velX, float velY, float velZ)
    {
      midp.JSystem.println("TODO: implement setListenerVelocity");
    }
  }
}
