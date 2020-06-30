// Decompiled with JetBrains decompiler
// Type: MonkeyApp
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using midp;
using System;

public class MonkeyApp : MIDlet
{
  private volatile bool m_gameHasStarted;
  public AppEngine m_engine;
  private Display m_display;
  private volatile bool m_gettingInput;
  private volatile bool m_beingDestroyed;

  public MonkeyApp()
  {
    this.m_gameHasStarted = false;
    this.m_engine = (AppEngine) null;
    this.m_display = (Display) null;
    this.m_gettingInput = false;
    this.m_beingDestroyed = false;
    this.m_gameHasStarted = false;
    AppEngine.createAppEngine(this);
    this.m_engine = AppEngine.getCanvas();
  }

  public void Dispose()
  {
    if (this.m_engine != null)
    {
      this.m_engine.end();
      this.m_engine = (AppEngine) null;
    }
    if (this.m_display == null)
      return;
    this.m_display.setCurrent((Displayable) null);
    this.m_display = (Display) null;
  }

  public string getInputString(string title, int maxSize)
  {
    this.m_gettingInput = true;
    TextBox textBox = new TextBox(title, (string) null, maxSize, 0);
    Displayable current = this.m_display.getCurrent();
    textBox.show(this.m_display);
    JavaLibGame.GraphicsDeviceManager.SupportedOrientations = DisplayOrientation.LandscapeLeft;
    JavaLibGame.GraphicsDeviceManager.ApplyChanges();
    string defaultText = "";
    if (XNAConnect.getGamer() != null)
      defaultText = XNAConnect.getGamer().DisplayName;
    //IAsyncResult result = Guide.BeginShowKeyboardInput(PlayerIndex.One, this.m_engine.getTextManager().getString(1823), this.m_engine.getTextManager().getString(1824), defaultText, (AsyncCallback) null, (object) null);
    //while (!result.IsCompleted)
      //JThread.sleep(500);
    string text = /* Guide.EndShowKeyboardInput(result) */ string.IsNullOrWhiteSpace(defaultText) ? "Cunt" : defaultText;
    JavaLibGame.GraphicsDeviceManager.SupportedOrientations = DisplayOrientation.Portrait;
    JavaLibGame.GraphicsDeviceManager.ApplyChanges();
    textBox.setString(text);
    if (!this.m_beingDestroyed)
      this.m_display.setCurrent(current);
    else
      this.m_display.setCurrent((Displayable) null);
    string str = textBox.getString();
    this.m_gettingInput = false;
    return str;
  }

  protected internal override void destroyApp(bool unconditional)
  {
    this.m_beingDestroyed = true;
    while (this.m_gettingInput)
      JThread.yield();
    if (this.m_engine != null)
    {
      this.m_engine.end();
      this.m_engine = (AppEngine) null;
    }
    if (this.m_display != null)
    {
      this.m_display.setCurrent((Displayable) null);
      this.m_display = (Display) null;
    }
    this.notifyDestroyed();
  }

  protected internal override void pauseApp()
  {
    this.m_engine.pauseGame();
  }

  protected internal override void startApp()
  {
    AppEngine engine = this.m_engine;
    this.m_display = Display.getDisplay((MIDlet) this);
    if (!this.m_gameHasStarted)
    {
      engine.start();
      this.m_gameHasStarted = true;
      engine.startThread();
    }
    if (engine.isPaused())
    {
      engine.resumeGame();
      engine.startThread();
    }
    if (this.m_display.getCurrent() != null)
      return;
    this.m_display.setCurrent((Displayable) engine);
  }
}
