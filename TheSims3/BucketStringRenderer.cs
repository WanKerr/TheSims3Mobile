// Decompiled with JetBrains decompiler
// Type: BucketStringRenderer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;
using sims3;
using System.Collections.Generic;

public class BucketStringRenderer : StringRenderer
{
  private List<BucketStringRenderer.Slot> m_history = new List<BucketStringRenderer.Slot>();
  private StringRenderer m_stringRenderer;
  private string temp_str;
  private BucketStringRenderer.Bucket[] m_buckets;
  private int m_bucketCount;
  private int m_bucketMaximumWidth;
  private int m_historyCount;
  private int m_fontHeight;

  private BucketStringRenderer.Slot locateStringInHistory(string str)
  {
    for (int index1 = 0; index1 < this.m_history.Count; ++index1)
    {
      if (this.m_history[index1].m_string.Equals(str))
      {
        BucketStringRenderer.Slot slot = this.m_history[index1];
        if (index1 != this.m_history.Count)
        {
          for (int index2 = index1; index2 < this.m_history.Count - index1 - 1; ++index1)
            this.m_history[index2] = this.m_history[index2 + 1];
          this.m_history[this.m_history.Count - 1] = slot;
        }
        return slot;
      }
    }
    return (BucketStringRenderer.Slot) null;
  }

  private BucketStringRenderer.Slot getSlot(int width)
  {
    if (width < this.m_bucketMaximumWidth)
    {
      for (int index = 0; index < this.m_bucketCount; ++index)
      {
        if (this.m_buckets[index].m_width >= width)
          return this.getSlotForBucket(this.m_buckets[index]);
      }
    }
    BucketStringRenderer.Slot slot = new BucketStringRenderer.Slot();
    slot.m_bucket = (BucketStringRenderer.Bucket) null;
    slot.m_used = true;
    int width1 = 1;
    while (width > width1)
      width1 *= 2;
    slot.m_image = Image.createImage(width1, this.m_fontHeight);
    return slot;
  }

  private BucketStringRenderer.Slot getSlotForBucket(
    BucketStringRenderer.Bucket bucket)
  {
    for (int index = 0; index < bucket.m_slots.Count; ++index)
    {
      if (!bucket.m_slots[index].m_used)
      {
        bucket.m_slots[index].m_used = true;
        return bucket.m_slots[index];
      }
    }
    BucketStringRenderer.Slot slot = new BucketStringRenderer.Slot();
    slot.m_bucket = bucket;
    slot.m_used = true;
    slot.m_image = Image.createImage(bucket.m_width, this.m_fontHeight);
    bucket.m_slots.Add(slot);
    return slot;
  }

  private void retireSlot(BucketStringRenderer.Slot slot)
  {
    if (slot.m_bucket == null)
      slot = (BucketStringRenderer.Slot) null;
    else
      slot.m_used = false;
  }

  private void addToHistory(BucketStringRenderer.Slot slot)
  {
    this.m_history.Add(slot);
    if (this.m_history.Count != this.m_historyCount)
      return;
    this.retireSlot(this.m_history[0]);
    this.m_history.RemoveAt(0);
  }

  public BucketStringRenderer(StringRenderer sr, int bufferCount)
  {
    this.m_stringRenderer = sr;
    this.m_historyCount = bufferCount;
    this.m_buckets = (BucketStringRenderer.Bucket[]) null;
    this.m_bucketCount = 0;
    this.m_bucketMaximumWidth = 0;
    this.m_fontHeight = 0;
    this.m_history = new List<BucketStringRenderer.Slot>();
    List<int> intList = new List<int>();
    this.m_bucketMaximumWidth = 0;
    for (int index = 8; index <= 256; index *= 2)
      intList.Add(index);
    this.m_buckets = new BucketStringRenderer.Bucket[intList.Count];
    for (int index = 0; index < intList.Count; ++index)
    {
      this.m_buckets[index] = new BucketStringRenderer.Bucket();
      this.m_buckets[index].m_width = intList[index];
      this.m_bucketMaximumWidth = intList[index];
    }
    this.m_bucketCount = intList.Count;
    int x0 = 0;
    int x1 = 0;
    int y0 = 0;
    int y1 = 0;
    this.m_stringRenderer.getStringTexturePadding(ref x0, ref x1, ref y0, ref y1);
    this.m_fontHeight = this.m_stringRenderer.getHeight() + y0 + y1;
    int num = 1;
    while (this.m_fontHeight > num)
      num *= 2;
    this.m_fontHeight = num;
  }

  public void Dispose()
  {
    for (int index = 0; index < this.m_history.Count; ++index)
      this.retireSlot(this.m_history[index]);
    for (int index1 = 0; index1 < this.m_bucketCount; ++index1)
    {
      for (int index2 = 0; index2 < this.m_buckets[index1].m_slots.Count; ++index2)
        this.m_buckets[index1].m_slots[index2] = (BucketStringRenderer.Slot) null;
    }
    this.m_buckets = (BucketStringRenderer.Bucket[]) null;
  }

  public override void drawString(Graphics g, string str, int x, int y, int anchor)
  {
    this.bufferedDrawString(g, str, x, y, anchor);
  }

  public override void drawString(Graphics g, StringBuffer str, int x, int y, int anchor)
  {
    this.drawString(g, str.toString(), x, y, anchor);
  }

  public override void drawSubstring(
    Graphics g,
    string str,
    int offset,
    int len,
    int x,
    int y,
    int anchor)
  {
    this.temp_str = str.Substring(offset, len);
    this.bufferedDrawString(g, this.temp_str, x, y, anchor);
  }

  public override int charsWidth(ushort[] ch, int offset, int length)
  {
    return this.m_stringRenderer.charsWidth(ch, offset, length);
  }

  public override int charWidth(ushort chr)
  {
    return this.m_stringRenderer.charWidth(chr);
  }

  public override int getBaselinePosition()
  {
    return this.m_stringRenderer.getBaselinePosition();
  }

  public override int getHeight()
  {
    return this.m_stringRenderer.getHeight();
  }

  public override int stringWidth(string str)
  {
    return this.m_stringRenderer.stringWidth(str);
  }

  public override int substringWidth(string str, int offset, int length)
  {
    return this.m_stringRenderer.substringWidth(str, offset, length);
  }

  private void bufferedDrawString(Graphics g, string str, int x, int y, int anchor)
  {
    this.temp_str = str;
    int num = this.m_stringRenderer.stringWidth(str);
    int height = this.m_stringRenderer.getHeight();
    int x0 = 0;
    int x1 = 0;
    int y0 = 0;
    int y1 = 0;
    this.m_stringRenderer.getStringTexturePadding(ref x0, ref x1, ref y0, ref y1);
    if (num <= 0 || height <= 0)
      return;
    int x2 = x - x0;
    int y2 = y - y0;
    if ((anchor & 16) != 0)
      x2 -= num / 2;
    else if ((anchor & 32) != 0)
      x2 -= num;
    if ((anchor & 2) != 0)
      y2 -= height / 2;
    else if ((anchor & 4) != 0)
      y2 -= height;
    this.m_stringRenderer.drawString(g, str, x2, y2, 9);
  }

  private class Slot
  {
    public Image m_image = new Image();
    public string m_string = "";
    public bool m_used;
    public BucketStringRenderer.Bucket m_bucket;

    public Slot()
    {
      this.m_image = (Image) null;
      this.m_string = (string) null;
      this.m_used = false;
      this.m_bucket = (BucketStringRenderer.Bucket) null;
    }
  }

  private class Bucket
  {
    public List<BucketStringRenderer.Slot> m_slots = new List<BucketStringRenderer.Slot>();
    public int m_width;

    public Bucket()
    {
      this.m_width = 0;
      this.m_slots = new List<BucketStringRenderer.Slot>();
    }
  }
}
