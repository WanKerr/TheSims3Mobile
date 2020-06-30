// Decompiled with JetBrains decompiler
// Type: StringRecord
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class StringRecord
{
  private string m_str = "";
  private Image m_image = new Image();

  public StringRecord()
  {
    this.m_str = (string) null;
    this.m_image = (Image) null;
  }

  public StringRecord(ref StringRecord rhs)
  {
    this.m_str = rhs.m_str;
    this.m_image = rhs.m_image;
  }

  public StringRecord CopyFrom(ref StringRecord rhs)
  {
    if (rhs != this)
    {
      this.m_str = rhs.m_str;
      this.m_image = rhs.m_image;
    }
    return this;
  }

  public void set(string str, Image image)
  {
    this.m_str = str;
    this.m_image = image;
  }

  public bool equals(string str)
  {
    return this.m_str != null && this.m_str.Equals(str);
  }

  public Image getImage()
  {
    return this.m_image;
  }

  public bool isEmpty()
  {
    return this.m_str == null;
  }

  public void clear()
  {
    this.m_str = (string) null;
    this.m_image = (Image) null;
  }
}
