// Decompiled with JetBrains decompiler
// Type: midp.Hashtable
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System.Collections.Generic;

namespace midp
{
  public class Hashtable
  {
    private Dictionary<object, object> dictionary;

    public Hashtable()
      : this(0)
    {
    }

    public Hashtable(int initialCapacity)
    {
      this.dictionary = new Dictionary<object, object>(initialCapacity);
    }

    public virtual void clear()
    {
      this.dictionary.Clear();
    }

    public virtual bool contains(object value)
    {
      return this.dictionary.ContainsValue(value);
    }

    public virtual bool containsKey(object key)
    {
      return this.dictionary.ContainsKey(key);
    }

    public virtual object get(object key)
    {
      return this.dictionary[key];
    }

    public virtual bool isEmpty()
    {
      return this.dictionary.Count == 0;
    }

    public virtual object put(object key, object value)
    {
      if (this.dictionary.ContainsKey(key))
      {
        object obj = this.dictionary[key];
        this.dictionary[key] = value;
        return obj;
      }
      this.dictionary.Add(key, value);
      return (object) null;
    }

    public virtual object remove(object key)
    {
      if (!this.dictionary.ContainsKey(key))
        return (object) null;
      object obj = this.dictionary[key];
      this.dictionary.Remove(key);
      return obj;
    }

    public virtual int size()
    {
      return this.dictionary.Count;
    }
  }
}
