// Decompiled with JetBrains decompiler
// Type: m3g.Node
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using System.Collections.Generic;
using System.Linq;

namespace m3g
{
  public class Node : Transformable
  {
    private static List<Node> s_nodeList = new List<Node>();
    private static object s_nodeListLock = new object();
    public const int NONE = 144;
    public const int ORIGIN = 145;
    public const int X_AXIS = 146;
    public const int Y_AXIS = 147;
    public const int Z_AXIS = 148;
    private Node m_parent;
    private bool m_renderingEnabled;
    private int m_alphaFactor;
    private int m_scope;

    internal static void requireNodeNotNull(Node node)
    {
    }

    internal static bool getPathToParent(Node from, Node target, ref List<Node> path)
    {
      Node.requireNodeNotNull(from);
      Node.requireNodeNotNull(target);
      Node node;
      Node parent;
      for (node = from; node != target; node = parent)
      {
        path.Add(node);
        parent = node.getParent();
        if (parent == null)
          break;
      }
      return node == target;
    }

    protected Node()
    {
      this.m_parent = (Node) null;
      this.m_renderingEnabled = true;
      this.m_alphaFactor = 65536;
      this.m_scope = -1;
    }

    protected override void duplicateTo(ref Object3D ret)
    {
      base.duplicateTo(ref ret);
      ((Node) ret).setAlphaFactorx(this.getAlphaFactorx());
    }

    protected override void updateAnimationProperty(int property, float[] value)
    {
      base.updateAnimationProperty(property, value);
      switch (property)
      {
        case 256:
          this.setAlphaFactor(value[0]);
          break;
        case 276:
          this.setRenderingEnable((double) value[0] > 0.5);
          break;
      }
    }

    protected override void updateAnimationProperty(int property, int[] value)
    {
      base.updateAnimationProperty(property, value);
      switch (property)
      {
        case 256:
          this.setAlphaFactorx(value[0]);
          break;
        case 276:
          this.setRenderingEnable(value[0] > (int) short.MaxValue);
          break;
      }
    }

    public void align(Node node)
    {
    }

    public Node getAlignmentReference(int axis)
    {
      return (Node) null;
    }

    public int getAlignmentTarget(int axis)
    {
      return 0;
    }

    public Node getParent()
    {
      return this.m_parent;
    }

    public void setParent(Node parent)
    {
      this.m_parent = parent;
    }

    public float getAlphaFactor()
    {
      return (float) this.m_alphaFactor / 65536f;
    }

    public int getAlphaFactorx()
    {
      return this.m_alphaFactor;
    }

    public RenderPass getPreRenderPass(int index)
    {
      return (RenderPass) null;
    }

    public int getPreRenderPassCount()
    {
      return 0;
    }

    public int getScope()
    {
      return this.m_scope;
    }

    public bool getTransformTo(Node target, ref Transform transform)
    {
      Node.requireNodeNotNull(target);
      lock (Node.s_nodeListLock)
      {
        List<Node> nodeList = Node.s_nodeList;
        bool pathToParent = Node.getPathToParent(this, target, ref nodeList);
        if (!pathToParent)
        {
          nodeList.Clear();
          if (!Node.getPathToParent(target, this, ref nodeList))
          {
            nodeList.Clear();
            return false;
          }
        }
        transform.setIdentity();
        for (int index = nodeList.Count - 1; index >= 0; --index)
          nodeList.ElementAt<Node>(index).getCompositeTransformCumulative(ref transform);
        if (!pathToParent)
          transform.invert();
        nodeList.Clear();
        return true;
      }
    }

    public bool isPickingEnabled()
    {
      return false;
    }

    public bool isRenderingEnabled()
    {
      return this.m_renderingEnabled;
    }

    public void preRender()
    {
    }

    public void setAlignment(Node zRef, int zTarget, Node yRef, int yTarget)
    {
    }

    public void setAlphaFactor(float alpha)
    {
      this.setAlphaFactorx((int) ((double) alpha * 65536.0 + 0.5));
    }

    public void setAlphaFactorx(int alpha)
    {
      this.m_alphaFactor = alpha;
    }

    public void setPickingEnable(bool enable)
    {
    }

    public void setPreRenderPass(int index, RenderPass pass)
    {
    }

    public void setRenderingEnable(bool enable)
    {
      this.m_renderingEnabled = enable;
    }

    public void setScope(int scope)
    {
      this.m_scope = scope;
    }

    public static Node m3g_cast(Object3D obj)
    {
      switch (obj.getM3GUniqueClassID())
      {
        case 5:
        case 9:
        case 12:
        case 14:
        case 16:
        case 18:
        case 22:
          return (Node) obj;
        default:
          return (Node) null;
      }
    }
  }
}
