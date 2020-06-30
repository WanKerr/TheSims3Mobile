// Decompiled with JetBrains decompiler
// Type: midp.Vector
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System.Collections;
using System.Collections.Generic;

namespace midp
{
  public class Vector : IEnumerable
  {
    private List<object> list;

    public Vector()
      : this(0)
    {
    }

    public Vector(int initialCapacity)
    {
      this.list = new List<object>(initialCapacity);
    }

    public void copyInto(object[] anArray)
    {
      this.list.CopyTo(anArray);
    }

    public void trimToSize()
    {
      this.list.TrimExcess();
    }

    public void setSize(int newSize)
    {
      this.list.Capacity = newSize;
    }

    public void ensureCapacity(int minCapacity)
    {
      if (this.list.Capacity >= minCapacity)
        return;
      this.list.Capacity = minCapacity;
    }

    public int capacity()
    {
      return this.list.Capacity;
    }

    public int size()
    {
      return this.list.Count;
    }

    public bool isEmpty()
    {
      return this.list.Count == 0;
    }

    public bool contains(object elem)
    {
      return this.list.Contains(elem);
    }

    public int indexOf(object elem)
    {
      return this.list.IndexOf(elem);
    }

    public int indexOf(object elem, int index)
    {
      return this.list.IndexOf(elem, index);
    }

    public int lastIndexOf(object elem)
    {
      return this.list.LastIndexOf(elem);
    }

    public int lastIndexOf(object elem, int index)
    {
      return this.list.LastIndexOf(elem, index);
    }

    public object elementAt(int index)
    {
      return this.list[index];
    }

    public object firstElement()
    {
      return this.list[0];
    }

    public object lastElement()
    {
      return this.list[this.list.Count - 1];
    }

    public void setElementAt(object elem, int index)
    {
      this.list[index] = elem;
    }

    public void removeElementAt(int index)
    {
      this.list.RemoveAt(index);
    }

    public void insertElementAt(object elem, int index)
    {
      this.list.Insert(index, elem);
    }

    public void addElement(object obj)
    {
      this.list.Add(obj);
    }

    public bool removeElement(object obj)
    {
      return this.list.Remove(obj);
    }

    public void removeAllElements()
    {
      this.list.Clear();
    }

    public string toString()
    {
      return this.list.ToString();
    }

    public IEnumerator GetEnumerator()
    {
      return (IEnumerator) this.list.GetEnumerator();
    }
  }
}
