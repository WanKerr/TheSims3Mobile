// Decompiled with JetBrains decompiler
// Type: m3g.Group
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System.Collections.Generic;
using System.Linq;

namespace m3g
{
  public class Group : Node
  {
    public new const int M3G_UNIQUE_CLASS_ID = 9;
    private List<Node> m_children;

    public Group()
    {
      this.m_children = (List<Node>) null;
    }

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      Group group = (Group) ret;
      for (int index = 0; index < this.getChildCount(); ++index)
      {
        Node child = (Node) this.getChild(index).duplicate();
        group.addChild(child);
      }
    }

    public override int getReferences(ref Object3D[] references)
    {
      int references1 = base.getReferences(ref references);
      int num1 = references1;
      int num2 = references1 + this.getChildCount();
      if (references != null)
      {
        for (int index = 0; index < this.getChildCount(); ++index)
          references[num1++] = (Object3D) this.getChild(index);
      }
      return num2;
    }

    protected override void findReferences(ref Object3DFinder finder)
    {
      base.findReferences(ref finder);
      int childCount = this.getChildCount();
      while (--childCount >= 0)
        finder.find((Object3D) this.getChild(childCount));
    }

    public override int animateReferences(int time)
    {
      return !this.isRenderingEnabled() ? 0 : this.animateReferencesGroup(time);
    }

    public void addChild(Node child)
    {
      if (this.m_children == null)
        this.m_children = new List<Node>();
      child.setParent((Node) this);
      this.m_children.Add(child);
    }

    public void removeChild(Node child)
    {
      child.setParent((Node) null);
      if (this.m_children == null)
        return;
      this.m_children.Remove(child);
    }

    public int getChildCount()
    {
      return this.m_children == null ? 0 : this.m_children.Count;
    }

    public Node getChild(int index)
    {
      return this.m_children.ElementAt<Node>(index);
    }

    public int animateReferencesGroup(int time)
    {
      int num1 = this.animateReferencesObject3D(time);
      int childCount = this.getChildCount();
      while (--childCount >= 0)
      {
        int num2 = this.getChild(childCount).animate(time);
        if (num2 < num1)
          num1 = num2;
      }
      return num1;
    }

    public override int getM3GUniqueClassID()
    {
      return 9;
    }

    public static Group m3g_cast(Object3D obj)
    {
      switch (obj.getM3GUniqueClassID())
      {
        case 9:
        case 22:
          return (Group) obj;
        default:
          return (Group) null;
      }
    }
  }
}
