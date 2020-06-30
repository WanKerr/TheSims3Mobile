// Decompiled with JetBrains decompiler
// Type: midp.TextBox
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System;

namespace midp
{
  public class TextBox : Displayable
  {
    public const int TEXTBOX_DEFAULT = 0;
    public const int TEXTBOX_PASSWORD = 1;
    public const int TEXTBOX_EMAIL = 2;
    public const int TEXTBOX_ALLOW_EMPTY = 4;
    private string m_title;
    private string m_text;
    private int m_maxSize;
    private int m_constraints;
    private int m_flags;
    private TextBoxImplementation m_implementation;
    private Displayable m_returnTo;

    private static TextBoxImplementation getImplementation(TextBox txt)
    {
      return txt.m_implementation;
    }

    public TextBox(string title, string text, int maxSize, int constraints)
      : this(title, text, maxSize, constraints, 0)
    {
    }

    public TextBox(string title, string text, int maxSize, int constraints, int flags)
    {
      this.m_title = (string) null;
      this.m_text = (string) null;
      this.m_maxSize = 0;
      this.m_constraints = 0;
      this.m_flags = flags;
      this.m_implementation = new TextBoxImplementation((TextBox) null);
      this.m_returnTo = (Displayable) null;
      this.setTitle(title);
      this.setString(text);
      this.setMaxSize(maxSize);
      this.setFlags(flags);
      this.setConstraints(constraints);
      this.m_implementation = TextBox.getImplementation(this);
    }

    public void Dispose()
    {
      this.m_implementation.Dispose();
      this.setTitle((string) null);
      this.setString((string) null);
    }

    public int getConstraints()
    {
      return this.m_constraints;
    }

    public int getFlags()
    {
      return this.m_flags;
    }

    public int getMaxSize()
    {
      return this.m_maxSize;
    }

    public string getString()
    {
      return this.m_text;
    }

    public string getTitle()
    {
      return this.m_title;
    }

    public void setConstraints(int constraints)
    {
      this.m_constraints = constraints;
    }

    public void setFlags(int flags)
    {
      this.m_flags = flags;
    }

    public void setMaxSize(int maxSize)
    {
      this.m_maxSize = maxSize;
    }

    public void setString(string text)
    {
      this.m_text = text;
    }

    public void setTitle(string title)
    {
      this.m_title = title;
    }

    public void show(Display display)
    {
      this.m_returnTo = display.getCurrent();
      display.setCurrent((Displayable) this);
    }

    public void returnToGame()
    {
      this.getDisplay().setCurrent(this.m_returnTo);
    }

    public override void showNotify()
    {
    }

    public override void hideNotify()
    {
    }

    public void updateKeyboard()
    {
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
  }
}
