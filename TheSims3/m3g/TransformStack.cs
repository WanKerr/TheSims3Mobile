// Decompiled with JetBrains decompiler
// Type: m3g.TransformStack
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

namespace m3g
{
  internal class TransformStack
  {
    private int m_capacity;
    private int m_position;
    private Transform[] m_array;

    public TransformStack()
    {
      this.m_capacity = 0;
      this.m_position = 0;
      this.m_array = (Transform[]) null;
    }

    public TransformStack(int capacity)
    {
      this.m_capacity = 0;
      this.m_position = 0;
      this.m_array = (Transform[]) null;
      this.setCapacity(capacity);
    }

    public void setCapacity(int capacity)
    {
      this.m_capacity = capacity;
      this.m_array = new Transform[this.m_capacity];
    }

    public Transform top()
    {
      return this.m_array[this.m_position];
    }

    public void push()
    {
      this.m_array[this.m_position + 1].set(this.top());
      ++this.m_position;
    }

    public void pop()
    {
      --this.m_position;
    }

    public void load(Transform transform)
    {
      this.m_array[this.m_position].set(transform);
    }

    public void loadIdentity()
    {
      this.top().setIdentity();
    }

    public void translate(float x, float y, float z)
    {
      this.top().postTranslate(x, y, z);
    }

    public void scale(float x, float y, float z)
    {
      this.top().postScale(x, y, z);
    }

    public void loadAndClear(Transform transform)
    {
      this.m_position = 0;
      this.m_array[this.m_position].set(transform);
    }
  }
}
