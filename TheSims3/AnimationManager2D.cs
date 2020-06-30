// Decompiled with JetBrains decompiler
// Type: AnimationManager2D
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using midp;

public class AnimationManager2D : GlobalConstants
{
  public const float DEPTH_LOWEST = -50f;
  public const float DEPTH_INCREMENT = 0.1f;
  private float[] m_tempFloat4;
  private short[] d_appearanceTextureIds;
  private sbyte[] d_appearanceBlendModes;
  private Appearance[] m_appearances;
  private Node[][] m_instances;
  private short[] m_instanceIndexes;
  private float[][] m_instanceBBs;
  private World m_world;
  private Group m_group;
  private Camera m_camera;
  private PolygonMode m_polygonMode;
  private CompositingMode m_compModeReplace;
  private CompositingMode m_compModeAlpha;
  private CompositingMode m_compModeAlphaAdd;
  private CompositingMode m_compModeModulate;
  private int m_viewportX;
  private int m_viewportY;
  private int m_viewportW;
  private int m_viewportH;
  private float m_worldDepth;
  private int m_worldLayer;
  private float m_globalAlpha;

  public AnimationManager2D()
  {
    this.m_tempFloat4 = new float[4];
    this.d_appearanceTextureIds = (short[]) null;
    this.d_appearanceBlendModes = (sbyte[]) null;
    this.m_appearances = (Appearance[]) null;
    this.m_instances = (Node[][]) null;
    this.m_instanceIndexes = (short[]) null;
    this.m_instanceBBs = (float[][]) null;
    this.m_world = (World) null;
    this.m_group = (Group) null;
    this.m_camera = (Camera) null;
    this.m_polygonMode = (PolygonMode) null;
    this.m_compModeReplace = (CompositingMode) null;
    this.m_compModeAlpha = (CompositingMode) null;
    this.m_compModeAlphaAdd = (CompositingMode) null;
    this.m_compModeModulate = (CompositingMode) null;
    this.m_viewportX = 0;
    this.m_viewportY = 0;
    this.m_viewportW = 533;
    this.m_viewportH = 320;
    this.m_worldDepth = -50f;
    this.m_worldLayer = 0;
    this.m_globalAlpha = 1f;
    this.m_world = new World();
    this.m_group = new Group();
    this.m_world.addChild((Node) this.m_group);
    this.m_camera = new Camera();
    this.m_world.addChild((Node) this.m_camera);
    this.m_world.setActiveCamera(this.m_camera);
    Background background = new Background();
    background.setColorClearEnable(false);
    background.setDepthClearEnable(false);
    this.m_world.setBackground(background);
    this.m_polygonMode = new PolygonMode();
    this.m_polygonMode.setCulling(162);
    this.m_compModeReplace = new CompositingMode();
    this.m_compModeReplace.setBlending(68);
    this.m_compModeReplace.setAlphaThreshold(0.0f);
    this.m_compModeReplace.setAlphaWriteEnable(false);
    this.m_compModeReplace.setDepthWriteEnable(false);
    this.m_compModeReplace.setDepthTestEnable(false);
    this.m_compModeAlpha = new CompositingMode();
    this.m_compModeAlpha.setBlending(64);
    this.m_compModeAlpha.setAlphaThreshold(0.0f);
    this.m_compModeAlpha.setAlphaWriteEnable(false);
    this.m_compModeAlpha.setDepthWriteEnable(false);
    this.m_compModeAlpha.setDepthTestEnable(false);
    this.m_compModeAlphaAdd = new CompositingMode();
    this.m_compModeAlphaAdd.setBlending(65);
    this.m_compModeAlphaAdd.setAlphaThreshold(0.0f);
    this.m_compModeAlphaAdd.setAlphaWriteEnable(false);
    this.m_compModeAlphaAdd.setDepthWriteEnable(false);
    this.m_compModeAlphaAdd.setDepthTestEnable(false);
    this.m_compModeModulate = new CompositingMode();
    this.m_compModeModulate.setBlending(66);
    this.m_compModeModulate.setAlphaThreshold(0.0f);
    this.m_compModeModulate.setAlphaWriteEnable(false);
    this.m_compModeModulate.setDepthWriteEnable(false);
    this.m_compModeModulate.setDepthTestEnable(false);
  }

  public new void Dispose()
  {
    this.m_world = (World) null;
    this.m_group = (Group) null;
    this.m_camera = (Camera) null;
    this.m_polygonMode = (PolygonMode) null;
    this.m_compModeReplace = (CompositingMode) null;
    this.m_compModeAlpha = (CompositingMode) null;
    this.m_compModeAlphaAdd = (CompositingMode) null;
    this.m_compModeModulate = (CompositingMode) null;
    for (int index1 = 0; index1 < this.m_instances.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.m_instances[index1].Length; ++index2)
        this.m_instances[index1][index2] = (Node) null;
    }
  }

  public void loadData()
  {
    ResourceManager resourceManager = AppEngine.getResourceManager();
    DataInputStream dataInputStream = new DataInputStream(ResourceManager.loadBinaryFile(0));
    int length1 = (int) dataInputStream.readShort();
    int[] numArray1 = new int[length1];
    for (int index = 0; index < length1; ++index)
      numArray1[index] = dataInputStream.readInt();
    int length2 = (int) dataInputStream.readShort();
    int[] numArray2 = new int[length2];
    this.d_appearanceTextureIds = new short[length2];
    this.d_appearanceBlendModes = new sbyte[length2];
    for (int index = 0; index < length2; ++index)
    {
      numArray2[index] = dataInputStream.readInt();
      this.d_appearanceTextureIds[index] = GlobalConstants.ANIM2D_SYMBOL_LOOKUPS[(int) dataInputStream.readShort()];
      this.d_appearanceBlendModes[index] = dataInputStream.readByte();
    }
    Node node1 = resourceManager.loadM3GNode(1);
    this.m_appearances = new Appearance[length2];
    for (int index = 0; index < length2; ++index)
    {
      int userID = numArray2[index];
      Appearance appearance = Appearance.m3g_cast(node1.find(userID));
      this.m_appearances[index] = appearance;
      switch (this.d_appearanceBlendModes[index])
      {
        case 0:
          appearance.setCompositingMode(this.m_compModeReplace);
          appearance.setPolygonMode(this.m_polygonMode);
          break;
        case 1:
          appearance.setCompositingMode(this.m_compModeAlpha);
          appearance.setPolygonMode(this.m_polygonMode);
          break;
        case 2:
          appearance.setCompositingMode(this.m_compModeAlphaAdd);
          appearance.setPolygonMode(this.m_polygonMode);
          break;
        case 3:
          appearance.setCompositingMode(this.m_compModeModulate);
          appearance.setPolygonMode(this.m_polygonMode);
          break;
      }
    }
    this.m_instances = new Node[length1][];
    this.m_instanceIndexes = new short[length1];
    this.m_instanceBBs = new float[length1][];
    for (int index = 0; index < length1; ++index)
    {
      int userID = numArray1[index];
      Node node2 = (Node) node1.find(userID);
      ((Group) node2.getParent()).removeChild(node2);
      this.m_instances[index] = new Node[1];
      this.m_instances[index][0] = node2;
      this.m_instanceIndexes[index] = (short) 0;
      this.m_instanceBBs[index] = new float[4];
      this.getBoundingBox(ref this.m_instanceBBs[index], node2);
    }
  }

  private void increaseAnimInstanceCount(int animId, int numInstances)
  {
    if (this.m_instances[animId].Length == numInstances)
      return;
    Node[] nodeArray = new Node[numInstances];
    for (int index = 0; index < this.m_instances[animId].Length; ++index)
      nodeArray[index] = this.m_instances[animId][index];
    Node node = this.m_instances[animId][0];
    for (int length = this.m_instances[animId].Length; length < numInstances; ++length)
    {
      nodeArray[length] = (Node) node.duplicate();
      AnimationManager2D.duplicateAppearances(nodeArray[length]);
    }
    this.m_instances[animId] = nodeArray;
  }

  public void loadTexture(int textureId)
  {
    Texture2D texture = (Texture2D) null;
    for (int index = 0; index < this.m_appearances.Length; ++index)
    {
      if ((int) this.d_appearanceTextureIds[index] == textureId)
      {
        Appearance appearance = this.m_appearances[index];
        if (appearance.getTexture(0) != null)
          break;
        if (texture == null)
        {
          texture = AppEngine.getResourceManager().loadM3GTexture2D(textureId);
          texture.setFiltering(210, 209);
        }
        appearance.setTexture(0, texture);
      }
    }
  }

  public void unloadTexture(int textureId)
  {
    for (int index = 0; index < this.m_appearances.Length; ++index)
    {
      if ((int) this.d_appearanceTextureIds[index] == textureId)
        this.m_appearances[index].setTexture(0, (Texture2D) null);
    }
  }

  public void submitAnim(int animId, float x, float y, float alpha, float scaleX, float scaleY)
  {
    this.submitAnim(animId, x, y, alpha, scaleX, scaleY, 0.0f);
  }

  public void submitAnim(int animId, float x, float y, float alpha, float scaleX)
  {
    this.submitAnim(animId, x, y, alpha, scaleX, 1f, 0.0f);
  }

  public void submitAnim(int animId, float x, float y, float alpha)
  {
    this.submitAnim(animId, x, y, alpha, 1f, 1f, 0.0f);
  }

  public void submitAnim(int animId, float x, float y)
  {
    this.submitAnim(animId, x, y, 1f, 1f, 1f, 0.0f);
  }

  public void submitAnim(
    int animId,
    float x,
    float y,
    float alpha,
    float scaleX,
    float scaleY,
    float angle)
  {
    int instanceIndex = (int) this.m_instanceIndexes[animId];
    int length = this.m_instances[animId].Length;
    if (instanceIndex >= length)
      this.increaseAnimInstanceCount(animId, instanceIndex + 1);
    this.m_instanceIndexes[animId] = (short) (instanceIndex + 1);
    float num1 = (float) this.m_viewportW * 0.5f;
    float num2 = (float) this.m_viewportH * 0.5f;
    Node node = this.m_instances[animId][instanceIndex];
    node.setTranslation(-num1 + x, num2 - y, this.m_worldDepth);
    node.setOrientation(angle, 0.0f, 0.0f, 1f);
    node.setScale(scaleX, scaleY, 1f);
    AnimationManager2D.applyAlphaAndLayer(node, this.m_globalAlpha * alpha, this.m_worldLayer);
    this.m_group.addChild(node);
    this.m_worldDepth += 0.1f;
    ++this.m_worldLayer;
  }

  public void submitAnimStretched(int animId, float x, float y, float w, float h, float alpha)
  {
    this.submitAnimStretched(animId, x, y, w, h, alpha, 0.0f);
  }

  public void submitAnimStretched(int animId, float x, float y, float w, float h)
  {
    this.submitAnimStretched(animId, x, y, w, h, 1f, 0.0f);
  }

  public void submitAnimStretched(
    int animId,
    float x,
    float y,
    float w,
    float h,
    float alpha,
    float angle)
  {
    float x1 = x + w * 0.5f;
    float y1 = y + h * 0.5f;
    float animWidth = this.getAnimWidth(animId);
    float animHeight = this.getAnimHeight(animId);
    float scaleX = w / animWidth;
    float scaleY = h / animHeight;
    this.submitAnim(animId, x1, y1, alpha, scaleX, scaleY, angle);
  }

  public void submitAnimHBar(
    int animLeft,
    int animMid,
    int animRight,
    float x,
    float y,
    float w,
    float alpha)
  {
    this.submitAnimHBar(animLeft, animMid, animRight, x, y, w, alpha, 1f);
  }

  public void submitAnimHBar(
    int animLeft,
    int animMid,
    int animRight,
    float x,
    float y,
    float w)
  {
    this.submitAnimHBar(animLeft, animMid, animRight, x, y, w, 1f, 1f);
  }

  public void submitAnimHBar(
    int animLeft,
    int animMid,
    int animRight,
    float x,
    float y,
    float w,
    float alpha,
    float scaleY)
  {
    float animWidth1 = this.getAnimWidth(animLeft);
    float animWidth2 = this.getAnimWidth(animMid);
    float animWidth3 = this.getAnimWidth(animRight);
    float num1 = w - animWidth1 - animWidth3;
    if (1.0 <= (double) num1)
    {
      float num2 = x - w * 0.5f;
      float x1 = num2 + animWidth1 * 0.5f;
      float x2 = (float) ((double) num2 + (double) animWidth1 + (double) num1 * 0.5);
      float scaleX = num1 / animWidth2;
      float x3 = (float) ((double) num2 + (double) w - (double) animWidth3 * 0.5);
      this.submitAnim(animLeft, x1, y, alpha, 1f, scaleY);
      this.submitAnim(animMid, x2, y, alpha, scaleX, scaleY);
      this.submitAnim(animRight, x3, y, alpha, 1f, scaleY);
    }
    else
    {
      float x1 = x - animWidth1 * 0.5f;
      float x2 = x + animWidth3 * 0.5f;
      this.submitAnim(animLeft, x1, y, alpha, 1f, scaleY);
      this.submitAnim(animRight, x2, y, alpha, 1f, scaleY);
    }
  }

  public void submitAnimHBarXFlipped(
    int animLeft,
    int animMid,
    int animRight,
    float x,
    float y,
    float w,
    float alpha,
    float scaleY)
  {
    float animWidth1 = this.getAnimWidth(animLeft);
    float animWidth2 = this.getAnimWidth(animMid);
    float animWidth3 = this.getAnimWidth(animRight);
    float num1 = w - animWidth1 - animWidth3;
    if (1.0 <= (double) num1)
    {
      float num2 = x - w * 0.5f;
      float x1 = num2 + animWidth1 * 0.5f;
      float x2 = (float) ((double) num2 + (double) animWidth1 + (double) num1 * 0.5);
      float num3 = num1 / animWidth2;
      float x3 = (float) ((double) num2 + (double) w - (double) animWidth3 * 0.5);
      this.submitAnim(animLeft, x1, y, alpha, -1f, scaleY);
      this.submitAnim(animMid, x2, y, alpha, -num3, scaleY);
      this.submitAnim(animRight, x3, y, alpha, -1f, scaleY);
    }
    else
    {
      float x1 = x - animWidth1 * 0.5f;
      float x2 = x + animWidth3 * 0.5f;
      this.submitAnim(animLeft, x1, y, alpha, -1f, scaleY);
      this.submitAnim(animRight, x2, y, alpha, -1f, scaleY);
    }
  }

  public void submitAnimVBar(
    int animTop,
    int animMid,
    int animBottom,
    float x,
    float y,
    float h)
  {
    this.submitAnimVBar(animTop, animMid, animBottom, x, y, h, 1f);
  }

  public void submitAnimVBar(
    int animTop,
    int animMid,
    int animBottom,
    float x,
    float y,
    float h,
    float alpha)
  {
    float animHeight1 = this.getAnimHeight(animTop);
    float animHeight2 = this.getAnimHeight(animMid);
    float animHeight3 = this.getAnimHeight(animBottom);
    float num1 = h - animHeight1 - animHeight3;
    if (1.0 <= (double) num1)
    {
      float num2 = y - h * 0.5f;
      float y1 = (float) ((double) num2 + (double) h - (double) animHeight3 * 0.5);
      float y2 = (float) ((double) num2 + (double) animHeight1 + (double) num1 * 0.5);
      float scaleY = num1 / animHeight2;
      float y3 = num2 + animHeight1 * 0.5f;
      this.submitAnim(animTop, x, y3, alpha);
      this.submitAnim(animMid, x, y2, alpha, 1f, scaleY);
      this.submitAnim(animBottom, x, y1, alpha);
    }
    else
    {
      float y1 = y - animHeight1 * 0.5f;
      float y2 = y + animHeight3 * 0.5f;
      this.submitAnim(animTop, x, y1, alpha);
      this.submitAnim(animBottom, x, y2, alpha);
    }
  }

  public void submitAnimGrid(
    int animTL,
    int animTM,
    int animTR,
    int animML,
    int animMM,
    int animMR,
    int animBL,
    int animBM,
    int animBR,
    float x,
    float y,
    float w,
    float h)
  {
    this.submitAnimGrid(animTL, animTM, animTR, animML, animMM, animMR, animBL, animBM, animBR, x, y, w, h, 1f);
  }

  public void submitAnimGrid(
    int animTL,
    int animTM,
    int animTR,
    int animML,
    int animMM,
    int animMR,
    int animBL,
    int animBM,
    int animBR,
    float x,
    float y,
    float w,
    float h,
    float alpha)
  {
    float animWidth1 = this.getAnimWidth(animTL);
    float animWidth2 = this.getAnimWidth(animTM);
    float animWidth3 = this.getAnimWidth(animTR);
    float animHeight1 = this.getAnimHeight(animTL);
    float animHeight2 = this.getAnimHeight(animML);
    float animHeight3 = this.getAnimHeight(animBL);
    float x1 = x + animWidth1 * 0.5f;
    float num1 = w - animWidth1 - animWidth3;
    float x2 = (float) ((double) x + (double) animWidth1 + (double) num1 * 0.5);
    float scaleX = num1 / animWidth2;
    float x3 = (float) ((double) x + (double) w - (double) animWidth3 * 0.5);
    float y1 = y + animHeight1 * 0.5f;
    float num2 = h - animHeight1 - animHeight3;
    float y2 = (float) ((double) y + (double) animHeight1 + (double) num2 * 0.5);
    float scaleY = num2 / animHeight2;
    float y3 = (float) ((double) y + (double) h - (double) animHeight3 * 0.5);
    this.submitAnim(animTL, x1, y1, alpha);
    this.submitAnim(animTM, x2, y1, alpha, scaleX, 1f);
    this.submitAnim(animTR, x3, y1, alpha);
    this.submitAnim(animML, x1, y2, alpha, 1f, scaleY);
    this.submitAnim(animMM, x2, y2, alpha, scaleX, scaleY);
    this.submitAnim(animMR, x3, y2, alpha, 1f, scaleY);
    this.submitAnim(animBL, x1, y3, alpha);
    this.submitAnim(animBM, x2, y3, alpha, scaleX, 1f);
    this.submitAnim(animBR, x3, y3, alpha);
  }

  public void setViewport(int x, int y, int w, int h)
  {
    this.m_viewportX = x;
    this.m_viewportY = y;
    this.m_viewportW = w;
    this.m_viewportH = h;
  }

  public void flushAnims(Graphics g)
  {
    this.m_camera.setParallel((float) this.m_viewportW, (float) this.m_viewportH / (float) this.m_viewportW, -100f, 100f);
    this.m_camera.setOrientation(90f, 0.0f, 0.0f, 1f);
    int clipX = g.getClipX();
    int clipY = g.getClipY();
    int clipWidth = g.getClipWidth();
    int clipHeight = g.getClipHeight();
    Graphics3D instance = Graphics3D.getInstance();
    instance.bindTarget((object) g, JavaLib.GraphicsDevice);
    instance.setViewport(this.m_viewportX, this.m_viewportY, this.m_viewportW, this.m_viewportH);
    instance.render(this.m_world);
    instance.releaseTarget();
    g.setClip(clipX, clipY, clipWidth, clipHeight);
    while (this.m_group.getChildCount() > 0)
      this.m_group.removeChild(this.m_group.getChild(0));
    AppEngine.fillArray(this.m_instanceIndexes, (short) 0);
    this.m_worldDepth = -50f;
    this.m_worldLayer = 0;
  }

  public float getAnimWidth(int animId)
  {
    return this.m_instanceBBs[animId][2] - this.m_instanceBBs[animId][0];
  }

  public float getAnimHeight(int animId)
  {
    return this.m_instanceBBs[animId][3] - this.m_instanceBBs[animId][1];
  }

  public void resetGlobal()
  {
    this.m_globalAlpha = 1f;
    this.m_group.setTransform((Transform) null);
  }

  public void setGlobalAlpha(float alpha)
  {
    this.m_globalAlpha = alpha;
  }

  public void setGlobalScale(float centerX, float centerY, float scaleX, float scaleY)
  {
    float num1 = (float) this.m_viewportW * 0.5f;
    float num2 = (float) this.m_viewportH * 0.5f;
    Transform transform = new Transform();
    transform.postTranslate(-centerX + num1, -centerY + num2, 0.0f);
    transform.postScale(scaleX, scaleY, 1f);
    transform.postTranslate(centerX - num1, centerY - num2, 0.0f);
    this.m_group.setTransform(transform);
  }

  public static void applyAlphaAndLayer(Node node, float alpha, int layer)
  {
    if (node == null)
      return;
    Group group = Group.m3g_cast((Object3D) node);
    if (group != null)
    {
      int childCount = group.getChildCount();
      for (int index = 0; index < childCount; ++index)
        AnimationManager2D.applyAlphaAndLayer(group.getChild(index), alpha, layer);
    }
    Mesh mesh = Mesh.m3g_cast((Object3D) node);
    if (mesh == null)
      return;
    mesh.setAlphaFactor(alpha);
    mesh.getAppearance(0).setLayer(layer);
  }

  public static void duplicateAppearances(Node node)
  {
    if (node == null)
      return;
    Group group = Group.m3g_cast((Object3D) node);
    if (group != null)
    {
      int childCount = group.getChildCount();
      for (int index = 0; index < childCount; ++index)
        AnimationManager2D.duplicateAppearances(group.getChild(index));
    }
    Mesh mesh = Mesh.m3g_cast((Object3D) node);
    if (mesh == null)
      return;
    int submeshCount = mesh.getSubmeshCount();
    for (int index = 0; index < submeshCount; ++index)
    {
      Appearance appearance = mesh.getAppearance(index);
      mesh.setAppearance(index, (Appearance) appearance.duplicate());
    }
  }

  public void getBoundingBox(ref float[] result, Node node)
  {
    this.getBoundingBox(ref result, node, true);
  }

  public void getBoundingBox(ref float[] result, Node node, bool topLevel)
  {
    if (topLevel)
    {
      result[0] = 0.0f;
      result[1] = 0.0f;
      result[2] = 0.0f;
      result[3] = 0.0f;
    }
    if (node == null)
      return;
    Group group = Group.m3g_cast((Object3D) node);
    if (group != null)
    {
      int childCount = group.getChildCount();
      for (int index = 0; index < childCount; ++index)
        this.getBoundingBox(ref result, group.getChild(index), false);
    }
    Mesh mesh = Mesh.m3g_cast((Object3D) node);
    if (mesh == null)
      return;
    VertexBuffer vertexBuffer = mesh.getVertexBuffer();
    int vertexCount = vertexBuffer.getVertexCount();
    float[] scaleBias = new float[4];
    VertexArray positions = vertexBuffer.getPositions(ref scaleBias);
    int componentCount = positions.getComponentCount();
    float num1 = 0.0f;
    float num2 = 0.0f;
    float num3 = 0.0f;
    float num4 = 0.0f;
    float[] values = new float[vertexCount * componentCount];
    positions.get(0, vertexCount, ref values);
    float num5 = scaleBias[0];
    float num6 = scaleBias[1];
    float num7 = scaleBias[2];
    for (int index = 0; index < vertexCount; ++index)
    {
      float b1 = num5 * values[index * componentCount] + num6;
      float b2 = num5 * values[index * componentCount + 1] + num7;
      if (index == 0)
      {
        num1 = num2 = b1;
        num3 = num4 = b2;
      }
      else
      {
        num1 = JMath.min(num1, b1);
        num3 = JMath.min(num3, b2);
        num2 = JMath.max(num2, b1);
        num4 = JMath.max(num4, b2);
      }
    }
    result[0] = JMath.min(result[0], num1);
    result[1] = JMath.min(result[1], num3);
    result[2] = JMath.max(result[2], num2);
    result[3] = JMath.max(result[3], num4);
  }
}
