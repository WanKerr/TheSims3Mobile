// Decompiled with JetBrains decompiler
// Type: WebView
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using System;

public class WebView : Displayable
{
  private string m_url = "";
  private object m_impl;
  private Display m_display;
  private Displayable m_oldDisplayable;

  public string getURL()
  {
    return this.m_url;
  }

  internal override void OnPaint(Graphics g)
  {
    throw new NotImplementedException();
  }

  internal override void OnKeyPressed(int key)
  {
    throw new NotImplementedException();
  }

  internal override void OnKeyRepeated(int key)
  {
    throw new NotImplementedException();
  }

  internal override void OnKeyReleased(int key)
  {
    throw new NotImplementedException();
  }

  internal override void OnPointerPressed(int x, int y, int pointerNum, int tapCount)
  {
    throw new NotImplementedException();
  }

  internal override void OnPointerReleased(int x, int y, int pointerNum, int tapCount)
  {
    throw new NotImplementedException();
  }

  internal override void OnPointerDragged(int x, int y, int pointerNum, int tapCount)
  {
    throw new NotImplementedException();
  }

  internal static void launchBrowser(string url)
  {
    throw new NotImplementedException();
  }
}
