// Decompiled with JetBrains decompiler
// Type: EditorButton
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class EditorButton
{
  private int m_id;
  private int m_x;
  private int m_y;
  private int m_width;
  private int m_height;
  private bool m_initialised;
  private bool m_visible;
  private string m_label;

  public EditorButton()
  {
    this.m_initialised = false;
    this.m_x = 0;
    this.m_y = 0;
    this.m_id = 0;
    this.m_width = 0;
    this.m_height = 0;
    this.m_label = "";
    this.m_visible = true;
  }

  public void init(int x, int y, int width, int height, string label, int buttonId)
  {
    this.m_x = x;
    this.m_y = y;
    this.m_id = buttonId;
    this.m_width = width;
    this.m_height = height;
    this.m_label = label;
    this.m_initialised = true;
  }

  public bool isPointWithin(int x, int y)
  {
    return x >= this.m_x && x <= this.m_x + this.m_width && (y >= this.m_y && y <= this.m_y + this.m_height) && this.m_visible;
  }

  public int getId()
  {
    return this.m_id;
  }

  public int getHeight()
  {
    return this.m_height;
  }

  public int getWidth()
  {
    return this.m_width;
  }

  public int getX()
  {
    return this.m_x;
  }

  public int getY()
  {
    return this.m_y;
  }

  public void hide()
  {
    this.m_visible = false;
  }

  public void show()
  {
    this.m_visible = true;
  }

  public void render(Graphics g)
  {
    if (!this.m_visible)
      return;
    g.setColor(0, 0, 0, 150);
    g.fillRect(this.m_x, this.m_y, this.m_width, this.m_height);
    g.setColor(90, 90, 90, 150);
    g.drawRect((float) this.m_x, (float) this.m_y, (float) this.m_width, (float) this.m_height);
    AppEngine.getCanvas().getTextManager().drawString(g, this.m_label, 5, this.m_x + (this.m_width >> 1), this.m_y + (this.m_height >> 1), 18);
  }
}
