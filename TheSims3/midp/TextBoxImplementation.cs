// Decompiled with JetBrains decompiler
// Type: midp.TextBoxImplementation
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace midp
{
  public class TextBoxImplementation
  {
    private readonly TextBox m_textBox;

    public TextBoxImplementation(TextBox textBox)
    {
      this.m_textBox = textBox;
    }

    public virtual void Dispose()
    {
    }

    public TextBox getTextBox()
    {
      return this.m_textBox;
    }
  }
}
