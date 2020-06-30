// Decompiled with JetBrains decompiler
// Type: nio.Buffer
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace nio
{
  public abstract class Buffer
  {
    private const int NO_MARK = -1;
    private readonly int m_capacity;
    private int m_limit;
    private int m_position;
    private int m_mark;

    protected Buffer(int cap)
    {
      this.m_capacity = cap;
      this.m_limit = 0;
      this.m_position = 0;
      this.m_mark = -1;
    }

    protected void requireValidIndex(int index)
    {
    }

    protected void requireValidPosition(int newPosition)
    {
    }

    protected void requireValidLimit(int newLimit)
    {
    }

    public void Dispose()
    {
    }

    public int capacity()
    {
      return this.m_capacity;
    }

    public Buffer clear()
    {
      this.position(0);
      this.limit(this.capacity());
      this.clearMark();
      return this;
    }

    public Buffer flip()
    {
      this.limit(this.position());
      this.position(0);
      this.clearMark();
      return this;
    }

    public bool hasRemaining()
    {
      return this.remaining() > 0;
    }

    public abstract bool isReadOnly();

    public int limit()
    {
      return this.m_limit;
    }

    public Buffer limit(int newLimit)
    {
      this.requireValidLimit(newLimit);
      this.m_limit = newLimit;
      return this;
    }

    public Buffer mark()
    {
      this.m_mark = this.position();
      return this;
    }

    public int position()
    {
      return this.m_position;
    }

    public Buffer position(int newPosition)
    {
      this.requireValidPosition(newPosition);
      this.m_position = newPosition;
      return this;
    }

    public int remaining()
    {
      return this.limit() - this.position();
    }

    public Buffer reset()
    {
      this.position(this.m_mark);
      return this;
    }

    public Buffer rewind()
    {
      this.position(0);
      this.clearMark();
      return this;
    }

    private void clearMark()
    {
      this.m_mark = -1;
    }
  }
}
