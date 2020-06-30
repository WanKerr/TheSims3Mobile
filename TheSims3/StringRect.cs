// Decompiled with JetBrains decompiler
// Type: StringRect
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

public class StringRect
{
  private string m_str = "";
  private int m_width;

  public StringRect()
  {
    this.m_width = 0;
    this.m_str = (string) null;
  }

  public StringRect(ref StringRect rhs)
  {
    this.m_width = rhs.m_width;
    this.m_str = rhs.m_str;
  }

  public StringRect CopyFrom(ref StringRect rhs)
  {
    if (rhs != this)
    {
      this.m_width = rhs.m_width;
      this.m_str = rhs.m_str;
    }
    return this;
  }

  public void set(string str, int width)
  {
    this.m_width = width;
    this.m_str = str;
  }

  public bool equals(string str)
  {
    return this.m_str != null && this.m_str.Equals(str);
  }

  public int getWidth()
  {
    return this.m_width;
  }

  public bool isEmpty()
  {
    return this.m_str == null;
  }

  public void clear()
  {
    this.m_str = (string) null;
  }
}
