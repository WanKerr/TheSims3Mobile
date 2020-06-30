// Decompiled with JetBrains decompiler
// Type: m3g.Graphics3D
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g.renderer;
using m3g.renderer.xna;
using Microsoft.Xna.Framework.Graphics;
using midp;
using System.Collections.Generic;

namespace m3g
{
  public class Graphics3D
  {
    protected Transform m_cameraTransform = new Transform();
    protected Transform m_cameraInverseTransform = new Transform();
    protected Transform m_cameraProjection = new Transform();
    private Dictionary<object, Renderer> m_renderers = new Dictionary<object, Renderer>();
    private Transform m_cameraToWorld = new Transform();
    private List<RenderNode> m_renderNodeList = new List<RenderNode>();
    private Transform nodeTransform = new Transform();
    private int[] cachedRect = new int[4];
    public const int ANTIALIAS = 2;
    public const int DEPTH = 32;
    public const int DITHER = 4;
    public const int GENERATE_MIPMAPS = 128;
    public const int OVERWRITE = 16;
    public const int STENCIL = 64;
    public const int TRUE_COLOR = 8;
    private const int ATG_INSTANCE_CACHE_COUNT = 20;
    protected Camera m_camera;
    protected int m_cameraScope;
    private object m_target;
    private float m_depthRangeNear;
    private float m_depthRangeFar;
    private int m_renderingFlags;
    private int m_viewportX;
    private int m_viewportY;
    private int m_viewportW;
    private int m_viewportH;
    private Renderer m_renderer;
    private Transform[] m_transformList;
    private int m_transformListPosition;
    private int m_reservedCapacity;
    private static Graphics3D staticInstance;
    private Transform[] cachedTransforms;

    private void compileRenderableNodeList(
      ref Node node,
      ref Transform transform,
      int scope,
      int depth)
    {
      if (!node.isRenderingEnabled())
        return;
      Group group = Group.m3g_cast((Object3D) node);
      if (group != null)
      {
        int childCount = group.getChildCount();
        if (transform != null)
        {
          for (int index = 0; index < childCount; ++index)
          {
            Node child = group.getChild(index);
            if (child.isRenderingEnabled())
            {
              this.cachedTransforms[depth].set(transform);
              child.getCompositeTransformCumulative(ref this.cachedTransforms[depth], depth);
              this.compileRenderableNodeList(ref child, ref this.cachedTransforms[depth], scope, depth + 1);
            }
          }
        }
        else
        {
          for (int index = 0; index < childCount; ++index)
          {
            Node child = group.getChild(index);
            if (child.isRenderingEnabled())
            {
              child.getCompositeTransform(ref this.cachedTransforms[depth]);
              this.compileRenderableNodeList(ref child, ref this.cachedTransforms[depth], scope, depth + 1);
            }
          }
        }
      }
      else
      {
        Mesh mesh = Mesh.m3g_cast((Object3D) node);
        if (mesh == null || (scope & mesh.getScope()) == 0)
          return;
        bool skinning = false;
        SkinnedMesh skinnedMesh = SkinnedMesh.m3g_cast((Object3D) mesh);
        if (skinnedMesh != null)
        {
          skinning = skinnedMesh != null;
          if (skinning)
          {
            Node skeleton = (Node) skinnedMesh.getSkeleton();
            skeleton.getCompositeTransform(ref this.cachedTransforms[depth]);
            if (transform != null)
            {
              Transform transform1 = this.m_transformList[this.m_transformListPosition++];
              transform1.set(transform);
              transform1.postMultiply(ref this.cachedTransforms[depth]);
              this.compileRenderableNodeList(ref skeleton, ref transform1, scope, depth + 1);
            }
            else
              this.compileRenderableNodeList(ref skeleton, ref this.nodeTransform, scope, depth + 1);
          }
        }
        Transform transform2 = this.m_transformList[this.m_transformListPosition++];
        if (transform != null)
          transform2.set(transform);
        else
          transform2.setIdentity();
        int submeshCount = mesh.getSubmeshCount();
        for (int index = 0; index != submeshCount; ++index)
        {
          if (mesh.getAppearance(index) != null && mesh.getIndexBuffer(index) != null)
            this.m_renderNodeList.Add(new RenderNode((Node) mesh, index, ref transform2, skinning));
        }
      }
    }

    protected Graphics3D()
    {
      this.m_camera = (Camera) null;
      this.m_cameraScope = -1;
      this.m_cameraTransform = new Transform();
      this.m_cameraInverseTransform = new Transform();
      this.m_cameraProjection = new Transform();
      this.m_target = (object) null;
      this.m_depthRangeNear = 0.0f;
      this.m_depthRangeFar = 1f;
      this.m_renderingFlags = 0;
      this.m_viewportX = 0;
      this.m_viewportY = 0;
      this.m_viewportW = 0;
      this.m_viewportH = 0;
      this.m_renderers = new Dictionary<object, Renderer>();
      this.m_cameraToWorld = new Transform();
      this.m_renderNodeList = new List<RenderNode>();
      this.m_transformList = new Transform[500];
      for (int index = 0; index < this.m_transformList.Length; ++index)
        this.m_transformList[index] = new Transform();
      this.m_transformListPosition = 0;
      this.m_reservedCapacity = 256;
      this.cachedTransforms = new Transform[20];
      for (int index = 0; index < 20; ++index)
        this.cachedTransforms[index] = new Transform();
    }

    public void bindTarget(object target, GraphicsDevice device)
    {
      this.bindTarget(target, 32, device);
    }

    public void render(Node node, Transform transform)
    {
      this.m_renderNodeList.Clear();
      this.m_transformListPosition = 0;
      this.compileRenderableNodeList(ref node, ref transform, this.m_cameraScope, 0);
      this.m_renderNodeList.Sort();
      int cameraScope = this.m_cameraScope;
      int count = this.m_renderNodeList.Count;
      for (int index = 0; index < count; ++index)
      {
        RenderNode renderNode1 = this.m_renderNodeList[index];
        Mesh renderNode2 = (Mesh) renderNode1.renderNode;
        if (renderNode2 != null && (renderNode2.getScope() & cameraScope) != 0)
        {
          AppearanceBase appearance = renderNode1.m_appearance;
          if (appearance != null)
          {
            VertexBuffer vertexBuffer = renderNode1.m_vertexBuffer;
            IndexBuffer indexBuffer = renderNode1.m_indexBuffer;
            float alphaFactor = renderNode2.getAlphaFactor();
            this.m_renderer.pushModelTransform(renderNode1.compositeTransform);
            if ((object) renderNode2.GetType() == (object) typeof (SkinnedMesh) || renderNode2.GetType().IsSubclassOf(typeof (SkinnedMesh)))
            {
              SkinnedMesh skinnedMesh = (SkinnedMesh) renderNode2;
              this.m_renderer.render(vertexBuffer, skinnedMesh.getSkinIndices(), skinnedMesh.getSkinWeights(), skinnedMesh.getBoneTransforms(), indexBuffer, appearance, alphaFactor);
            }
            else
              this.m_renderer.render(vertexBuffer, indexBuffer, appearance, alphaFactor);
            this.m_renderer.popModelTransform();
          }
        }
      }
      if (this.m_renderNodeList.Count > this.m_reservedCapacity)
      {
        this.m_reservedCapacity = this.m_renderNodeList.Count;
        this.m_renderNodeList.Capacity = this.m_reservedCapacity;
      }
      this.m_renderNodeList.Clear();
      this.m_renderer.restoreToClamp();
    }

    public void render(
      VertexBuffer vertices,
      IndexBuffer primitives,
      AppearanceBase appearance,
      Transform transform)
    {
      this.render(vertices, primitives, appearance, transform, -1, 1f);
    }

    public virtual void render(
      VertexBuffer vertices,
      IndexBuffer primitives,
      AppearanceBase appearance,
      Transform transform,
      int scope,
      float alphaFactor)
    {
      if (!(this.m_cameraScope != 0 & scope != 0))
        return;
      this.m_renderer.pushModelTransform(transform);
      this.m_renderer.render(vertices, primitives, appearance, alphaFactor);
      this.m_renderer.popModelTransform();
    }

    public virtual void setViewport(int x, int y, int width, int height)
    {
      this.m_viewportX = x;
      this.m_viewportY = y;
      this.m_viewportW = width;
      this.m_viewportH = height;
      this.cachedRect[0] = x;
      this.cachedRect[1] = y;
      this.cachedRect[2] = width;
      this.cachedRect[3] = height;
      Display.getDisplay(JavaLib.MIDlet).getCurrent().transformRect(ref this.cachedRect);
      this.m_renderer.setViewport(this.cachedRect[0], this.cachedRect[1], this.cachedRect[2], this.cachedRect[3]);
    }

    public virtual void setCamera(Camera camera, ref Transform transform)
    {
      this.m_camera = camera;
      if (transform != null)
      {
        this.m_cameraTransform.set(transform);
        this.m_cameraInverseTransform.set(transform);
        this.m_cameraInverseTransform.invert();
      }
      else
      {
        this.m_cameraTransform.setIdentity();
        this.m_cameraInverseTransform.setIdentity();
      }
      if (camera != null)
      {
        camera.getProjection(this.m_cameraProjection);
        this.m_cameraScope = camera.getScope();
      }
      else
      {
        this.m_cameraProjection.setIdentity();
        this.m_cameraScope = -1;
      }
      this.m_renderer.setProjectionAndViewTransform(this.m_cameraProjection, this.m_cameraInverseTransform);
    }

    public virtual void clear(Background background)
    {
      if (this.getViewportWidth() == 0 || this.getViewportHeight() == 0)
        return;
      this.m_renderer.clear(background);
    }

    public virtual Camera getCamera(ref Transform transform)
    {
      if (transform != null)
        transform.set(this.m_cameraTransform);
      return this.m_camera;
    }

    public virtual void releaseTarget()
    {
      this.m_target = (object) null;
    }

    public void bindTarget(object target, bool depthBuffer, int flags, GraphicsDevice device)
    {
      this.bindTarget(target, flags | (depthBuffer ? 32 : 0), device);
    }

    public virtual void bindTarget(object target, int flags, GraphicsDevice device)
    {
      if (target == null)
        return;
      this.m_target = target;
      this.m_renderingFlags = flags;
      if (this.m_renderer != null)
        return;
      this.m_renderer = (Renderer) new RendererXNA(device);
    }

    public object getTarget()
    {
      return this.m_target;
    }

    public int getViewportHeight()
    {
      return this.m_viewportH;
    }

    public int getViewportWidth()
    {
      return this.m_viewportW;
    }

    public int getViewportX()
    {
      return this.m_viewportX;
    }

    public int getViewportY()
    {
      return this.m_viewportY;
    }

    public void render(World world)
    {
      if (world == null)
        return;
      Camera activeCamera = world.getActiveCamera();
      if (activeCamera == null || !activeCamera.getTransformTo((Node) world, ref this.m_cameraToWorld))
        return;
      this.setCamera(activeCamera, ref this.m_cameraToWorld);
      this.clear(world.getBackground());
      this.render((Node) world, (Transform) null);
    }

    public void renderForceAppearanceLoad(World world)
    {
      if (world == null)
        return;
      Camera activeCamera = world.getActiveCamera();
      if (activeCamera == null || !activeCamera.getTransformTo((Node) world, ref this.m_cameraToWorld))
        return;
      this.setCamera(activeCamera, ref this.m_cameraToWorld);
      this.clear(world.getBackground());
      this.renderForceAppearanceLoad((Node) world, (Transform) null);
    }

    public void renderForceAppearanceLoad(Node node, Transform transform)
    {
      this.m_renderNodeList.Clear();
      this.m_transformListPosition = 0;
      this.compileRenderableNodeList(ref node, ref transform, this.m_cameraScope, 0);
      this.m_renderNodeList.Sort();
      int cameraScope = this.m_cameraScope;
      int count = this.m_renderNodeList.Count;
      long num = 0;
      for (int index = 0; index < count; ++index)
      {
        RenderNode renderNode1 = this.m_renderNodeList[index];
        Mesh renderNode2 = (Mesh) renderNode1.renderNode;
        if (renderNode2 != null && (renderNode2.getScope() & cameraScope) != 0)
        {
          AppearanceBase appearance = renderNode1.m_appearance;
          if (appearance != null)
          {
            VertexBuffer vertexBuffer = renderNode1.m_vertexBuffer;
            IndexBuffer indexBuffer = renderNode1.m_indexBuffer;
            float alphaFactor = renderNode2.getAlphaFactor();
            this.m_renderer.pushModelTransform(renderNode1.compositeTransform);
            this.m_renderer.processApperance((Appearance) appearance);
            if ((object) renderNode2.GetType() == (object) typeof (SkinnedMesh) || renderNode2.GetType().IsSubclassOf(typeof (SkinnedMesh)))
            {
              SkinnedMesh skinnedMesh = (SkinnedMesh) renderNode2;
              this.m_renderer.render(vertexBuffer, skinnedMesh.getSkinIndices(), skinnedMesh.getSkinWeights(), skinnedMesh.getBoneTransforms(), indexBuffer, appearance, alphaFactor);
              num += (long) indexBuffer.getPrimitiveCount();
            }
            else
            {
              this.m_renderer.render(vertexBuffer, indexBuffer, appearance, alphaFactor);
              num += (long) indexBuffer.getPrimitiveCount();
            }
            this.m_renderer.popModelTransform();
          }
        }
      }
      if (this.m_renderNodeList.Count > this.m_reservedCapacity)
      {
        this.m_reservedCapacity = this.m_renderNodeList.Count;
        this.m_renderNodeList.Capacity = this.m_reservedCapacity;
      }
      this.m_renderNodeList.Clear();
      this.m_renderer.restoreToClamp();
    }

    public static Graphics3D getInstance()
    {
      if (Graphics3D.staticInstance == null)
        Graphics3D.staticInstance = new Graphics3D();
      return Graphics3D.staticInstance;
    }
  }
}
