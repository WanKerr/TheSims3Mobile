// Decompiled with JetBrains decompiler
// Type: ScrollText
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using midp;

public class ScrollText
{
  private const int RIGHT_PADDING = 5;
  private int fontID;
  private string[] text;
  private string[] scores;
  private int x;
  private int y;
  private int width;
  private int height;
  private int align_flag;
  private int y_offset;
  private int prev_y;
  private int acceleration;
  private TextManager tm;

  public ScrollText(
    int fontID,
    string[] text,
    string[] scores,
    int x,
    int y,
    int width,
    int height,
    int align_flag)
  {
    this.fontID = fontID;
    this.text = text;
    this.scores = scores;
    this.x = x;
    this.y = y;
    this.width = width;
    this.height = height;
    this.align_flag = align_flag;
    this.y_offset = 0;
    this.tm = AppEngine.getCanvas().getTextManager();
  }

  public void handleInput(int _event, int[] args)
  {
    int num = this.prev_y - args[2];
    if (_event == 1)
    {
      this.y_offset += num;
      this.acceleration = num;
    }
    else
    {
      this.acceleration -= this.acceleration > 0 ? 1 : -1;
      if (System.Math.Abs(this.acceleration) <= 2)
        this.acceleration = 0;
      this.y_offset += this.acceleration;
    }
    this.y_offset = System.Math.Max(0, this.y_offset);
    this.y_offset = System.Math.Min(this.y_offset, this.scrollableTextHeight());
    this.prev_y = args[2];
  }

  private int scrollableTextHeight()
  {
    int num = this.text.Length * this.tm.getLineHeight(this.fontID) - this.height;
    return num <= 0 ? 0 : num;
  }

  public float getCursorProgression()
  {
    return (float) this.y_offset / (float) this.scrollableTextHeight();
  }

  public void draw(Graphics g)
  {
    Rectangle clip = g.getClip();
    g.setClip(320 - this.y - this.height, this.x, this.height, this.width);
    g.Begin();
    for (int index = 0; index < System.Math.Min(this.text.Length, this.scores.Length); ++index)
    {
      this.tm.drawString(g, this.text[index], this.fontID, this.x, this.y + this.tm.getLineHeight(this.fontID) * index - this.y_offset, 9);
      this.tm.drawString(g, this.scores[index], this.fontID, this.x + this.width - 5, this.y + this.tm.getLineHeight(this.fontID) * index - this.y_offset, 33);
    }
    g.End();
    g.setClip(clip);
  }
}
