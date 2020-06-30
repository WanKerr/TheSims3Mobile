// Decompiled with JetBrains decompiler
// Type: midp.JavaLib
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using SevenZip;
using SevenZip.Compression.LZMA;
using System;
using System.Collections.Generic;
using System.IO;

namespace midp
{
  public class JavaLib
  {
    private Queue<int> keysPressed = new Queue<int>();
    private Queue<int> keysReleased = new Queue<int>();
    private const int K_UP = 2;
    private const int K_DOWN = 4;
    private const int K_LEFT = 8;
    private const int K_RIGHT = 16;
    private const int K_FIRE = 32;
    private const int K_CLR = 64;
    private const int K_0 = 128;
    private const int K_1 = 256;
    private const int K_2 = 512;
    private const int K_3 = 1024;
    private const int K_4 = 2048;
    private const int K_5 = 4096;
    private const int K_6 = 8192;
    private const int K_7 = 16384;
    private const int K_8 = 32768;
    private const int K_9 = 65536;
    private const int K_SOFT1 = 131072;
    private const int K_SOFT2 = 262144;
    private const int K_STAR = 524288;
    private const int K_POUND = 1048576;
    private int key;
    private MouseState currentMouseState;
    private MouseState previousMouseState;
    public static ContentManager contentManager;

    public static MIDlet MIDlet { get; protected set; }

    public static Game Game { get; protected set; }

    public static IServiceProvider ServiceProvider { get; set; }

    public static GraphicsDevice GraphicsDevice { get; protected set; }

    internal JavaLib(Game game, GraphicsDevice device)
    {
      JavaLib.Game = game;
      JavaLib.GraphicsDevice = device;
      JavaLib.Game.IsMouseVisible = true;
    }

    internal void LoadMIDlet(MIDlet midlet)
    {
      JavaLib.MIDlet = midlet;
      midlet.Load(JavaLib.GraphicsDevice);
      midlet.startApp();
    }

    public static InputStream getResourceAsStream(string filename, bool compressed)
    {
      try
      {
        Stream stream = TitleContainer.OpenStream("Content/" + filename);
        if (compressed)
        {
          MemoryStream memoryStream = new MemoryStream();
          byte[] numArray = new byte[5];
          if (stream.Read(numArray, 0, numArray.Length) != 5)
            throw new Exception("input .lzma is too short");
          Decoder decoder = new Decoder();
          decoder.SetDecoderProperties(numArray);
          long outSize = 0;
          for (int index = 0; index < 8; ++index)
          {
            int num = stream.ReadByte();
            if (num < 0)
              throw new Exception("Can't Read 1");
            outSize |= (long) (byte) num << 8 * index;
          }
          long inSize = stream.Length - stream.Position;
          decoder.Code(stream, (Stream) memoryStream, inSize, outSize, (ICodeProgress) null);
          memoryStream.Position = 0L;
          stream.Close();
          stream = (Stream) memoryStream;
        }
        try
        {
          return (InputStream) new MemoryInputStream(stream);
        }
        finally
        {
          stream.Close();
        }
      }
      catch (Exception ex)
      {
        return (InputStream) null;
      }
    }

    internal void Update(GameTime gameTime)
    {
      this.HandleKeys();
      TouchCollection state = TouchPanel.GetState();
      if (state.Count > 1)
      {
        if (JavaLib.MIDlet == null || JavaLib.MIDlet.Display == null || JavaLib.MIDlet.Display.current == null)
          return;
        if (state[0].State == TouchLocationState.Pressed && state[1].State == TouchLocationState.Released || state[1].State == TouchLocationState.Pressed && state[0].State == TouchLocationState.Released)
        {
          JavaLib.MIDlet.Display.current.OnPointerPressed((int) state[0].Position.Y, (int) state[0].Position.X, 0, 0);
          JavaLib.MIDlet.Display.current.OnPointerReleased((int) state[0].Position.Y, (int) state[0].Position.X, 0, 0);
        }
        else if (state[0].State == TouchLocationState.Pressed || state[1].State == TouchLocationState.Pressed)
        {
          JavaLib.MIDlet.Display.current.OnPointerPressed((int) state[0].Position.Y, (int) state[0].Position.X, 0, 0);
          JavaLib.MIDlet.Display.current.OnPointerPressed((int) state[1].Position.Y, (int) state[1].Position.X, 1, 0);
        }
        else if (state[0].State == TouchLocationState.Released || state[1].State == TouchLocationState.Released)
        {
          JavaLib.MIDlet.Display.current.OnPointerReleased((int) state[0].Position.Y, (int) state[0].Position.X, 0, 0);
          JavaLib.MIDlet.Display.current.OnPointerReleased((int) state[1].Position.Y, (int) state[1].Position.X, 1, 0);
        }
        else
        {
          if (state[0].State != TouchLocationState.Moved && state[1].State != TouchLocationState.Moved)
            return;
          JavaLib.MIDlet.Display.current.OnPointerDragged((int) state[0].Position.Y, (int) state[0].Position.X, 0, 0);
          JavaLib.MIDlet.Display.current.OnPointerDragged((int) state[1].Position.Y, (int) state[1].Position.X, 1, 0);
        }
      }
      else
        this.HandleMouse();
    }

    private void HandleKeys()
    {
    }

    private void HandleMouse()
    {
      this.previousMouseState = this.currentMouseState;
      this.currentMouseState = Mouse.GetState();
      if (JavaLib.MIDlet == null || JavaLib.MIDlet.Display == null || JavaLib.MIDlet.Display.current == null)
        return;
      if (this.previousMouseState.LeftButton == ButtonState.Released && this.currentMouseState.LeftButton == ButtonState.Pressed)
        JavaLib.MIDlet.Display.current.OnPointerPressed(320 - this.currentMouseState.Y, this.currentMouseState.X, 0, 0);
      else if (this.previousMouseState.LeftButton == ButtonState.Pressed && this.currentMouseState.LeftButton == ButtonState.Released)
      {
        JavaLib.MIDlet.Display.current.OnPointerReleased(320 - this.currentMouseState.Y, this.currentMouseState.X, 0, 0);
      }
      else
      {
        if (this.previousMouseState.LeftButton != ButtonState.Pressed || this.currentMouseState.LeftButton != ButtonState.Pressed || this.previousMouseState.X == this.currentMouseState.X && this.previousMouseState.Y == this.currentMouseState.Y)
          return;
        JavaLib.MIDlet.Display.current.OnPointerDragged(320 - this.currentMouseState.Y, this.currentMouseState.X, 0, 0);
      }
    }

    private void ReleaseKey(int keyCode)
    {
      this.key &= ~keyCode;
    }

    public static Image createImage(string name)
    {
      try
      {
        return new Image(JavaLib.contentManager.Load<Texture2D>(name))
        {
          Name = name
        };
      }
      catch (Exception ex)
      {
        return new Image(32, 32);
      }
    }
  }
}
