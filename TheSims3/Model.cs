// Decompiled with JetBrains decompiler
// Type: Model
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;

public class Model : GlobalConstants
{
  public static readonly int[] CACHED_USERIDS = new int[12]
  {
    702,
    703,
    705,
    704,
    1100,
    1101,
    1107,
    1108,
    2001,
    2002,
    2003,
    2004
  };
  public static readonly int[] ROOT_USERIDS = new int[4]
  {
    1100,
    1101,
    1107,
    1108
  };
  private static Transform s_tempTransform = new Transform();
  private Texture2D m_hemisphereMap = new Texture2D();
  private Transform tempTransform = new Transform();
  private int[] cachedPos = new int[4];
  private const int TYPE_NULL = 0;
  private const int TYPE_OBJECT = 1;
  private const int TYPE_SIM = 2;
  private const int TYPE_SIM_CAS = 3;
  private const int TYPE_SIM_CAS_REFLECTED = 4;
  private int m_type;
  private int m_modelId;
  private Group m_group;
  private AnimPlayer3D m_animPlayer3D;
  private int m_supportNodeModelId;
  private Node m_supportNode;
  private AnimPlayer3D m_supportAnimPlayer3D;
  private int m_animTimer;
  private Node[] m_cachedLocators;
  private Node[] m_hotspotLocators;
  private Node[] m_benchtopLocators;
  private Node m_root;

  public Model()
  {
    this.m_type = 0;
    this.m_modelId = -1;
    this.m_group = (Group) null;
    this.m_animPlayer3D = (AnimPlayer3D) null;
    this.m_supportNodeModelId = -1;
    this.m_supportNode = (Node) null;
    this.m_supportAnimPlayer3D = (AnimPlayer3D) null;
    this.m_animTimer = 0;
    this.m_hemisphereMap = (Texture2D) null;
    this.m_cachedLocators = (Node[]) null;
    this.m_hotspotLocators = (Node[]) null;
    this.m_benchtopLocators = (Node[]) null;
    this.m_root = (Node) null;
    this.m_group = new Group();
    AnimationManager3D animationManager3D = AppEngine.getCanvas().getAnimationManager3D();
    this.m_animPlayer3D = new AnimPlayer3D(animationManager3D);
    this.m_supportAnimPlayer3D = new AnimPlayer3D(animationManager3D);
  }

  public new void Dispose()
  {
    this.unload();
    if (this.m_animPlayer3D != null)
    {
      this.m_animPlayer3D.Dispose();
      this.m_animPlayer3D = (AnimPlayer3D) null;
    }
    if (this.m_supportAnimPlayer3D != null)
    {
      this.m_supportAnimPlayer3D.Dispose();
      this.m_supportAnimPlayer3D = (AnimPlayer3D) null;
    }
    base.Dispose();
  }

  public void unload()
  {
    this.m_animPlayer3D.setNode((Node) null);
    this.m_supportAnimPlayer3D.setNode((Node) null);
    this.m_supportNode = (Node) null;
    this.m_supportNodeModelId = -1;
    while (this.m_group.getChildCount() != 0)
      this.m_group.removeChild(this.m_group.getChild(0));
    this.m_root = (Node) null;
    if (this.m_type == 2 && this.m_modelId != -1)
      ModelManager.getInstance().unloadSimTextures(this.m_modelId);
    this.m_modelId = -1;
    this.m_cachedLocators = new Node[0];
    this.m_hotspotLocators = new Node[0];
    this.m_benchtopLocators = new Node[0];
    this.m_type = 0;
  }

  public int getModelId()
  {
    return this.m_modelId;
  }

  public Node getNode()
  {
    return (Node) this.m_group;
  }

  public AnimPlayer3D getAnimPlayer3D()
  {
    return this.m_animPlayer3D;
  }

  public void setSupportNode(int supportNodeId)
  {
    if (this.m_supportNodeModelId == supportNodeId)
      return;
    if (this.m_supportNode != null)
    {
      ModelManager.orphanNode(this.m_supportNode);
      this.m_supportNode = (Node) null;
      this.m_supportAnimPlayer3D.setNode((Node) null);
    }
    this.m_supportNodeModelId = supportNodeId;
    if (supportNodeId == -1)
      return;
    this.m_supportNode = ModelManager.getInstance().getModel(supportNodeId);
    this.m_group.addChild(this.m_supportNode);
    this.m_supportAnimPlayer3D.setNode(this.m_supportNode);
  }

  public AnimPlayer3D getSupportAnimPlayer3D()
  {
    return this.m_supportAnimPlayer3D;
  }

  public void setAlpha(int alphaF)
  {
    ModelManager.applyAlphaFactor((Node) this.m_group, alphaF);
  }

  public void assembleObject(int modelId)
  {
    this.unload();
    ModelManager instance = ModelManager.getInstance();
    Node model = instance.getModel(modelId, false);
    this.m_hemisphereMap = instance.addHemisphereMap(model);
    ModelManager.applyCommit(model);
    this.m_group.addChild(model);
    this.m_animPlayer3D.setNode(model);
    this.cacheLocators();
    int[] numArray = new int[4]{ 1100, 1102, 1103, 1107 };
    foreach (int userId in numArray)
      this.getLocator(userId)?.setRenderingEnable(false);
    this.m_type = 1;
    this.m_modelId = modelId;
  }

  public void assembleMacromap(Node node)
  {
    this.unload();
    ((Group) node.getParent())?.removeChild(node);
    this.m_group.addChild(node);
    this.m_animPlayer3D.setNode(node);
    node.setTransform((Transform) null);
    node.setTranslation(0.0f, 0.0f, 0.0f);
    node.setOrientation(0.0f, 1f, 0.0f, 0.0f);
    this.cacheLocators();
    this.m_type = 1;
  }

  public void assembleSimForGame(int simId)
  {
    AppEngine.timerBegin();
    this.assembleSim(simId, false);
    ModelManager.applyCommit((Node) this.m_group);
    this.m_type = 2;
    AppEngine.timerEnd(nameof (assembleSimForGame));
  }

  public void assembleSimForGameNaked(int simId)
  {
    AppEngine.timerBegin();
    this.assembleSim(simId, false, true);
    ModelManager.applyCommit((Node) this.m_group);
    this.m_type = 2;
    AppEngine.timerEnd("assembleSimForGame");
  }

  public void assembleSimForCAS(Model reflection)
  {
    AppEngine.timerBegin();
    ModelManager instance = ModelManager.getInstance();
    reflection.unload();
    this.assembleSim(0, true);
    Node node = (Node) this.m_group.getChild(0).duplicate();
    reflection.m_group.addChild(node);
    reflection.m_animPlayer3D.setNode(node);
    instance.overrideSimAppearance(node, 0, 10, 0);
    instance.overrideSimAppearance(node, 2, 12, 0);
    instance.overrideSimAppearance(node, 3, 13, 0);
    instance.overrideSimAppearance(node, 4, 14, 0);
    instance.overrideSimAppearance(node, 5, 15, 0);
    instance.overrideSimAppearance(node, 6, 16, 0);
    instance.overrideSimAppearance(node, 7, 17, 0);
    instance.overrideSimAppearance(node, 8, 18, 0);
    instance.overrideAppearance(node, 25, 26);
    ModelManager.applyCommit((Node) reflection.m_group);
    reflection.m_type = 4;
    ModelManager.applyCommit((Node) this.m_group);
    this.m_type = 3;
    AppEngine.timerEnd(nameof (assembleSimForCAS));
  }

  private void assembleSim(int simId, bool forCAS)
  {
    this.assembleSim(simId, forCAS, false);
  }

  private void assembleSim(int simId, bool forCAS, bool naked)
  {
    this.unload();
    AppEngine.timerBegin();
    ModelManager instance = ModelManager.getInstance();
    Node simModel = instance.getSimModel(simId, forCAS, naked);
    this.m_group.addChild(simModel);
    this.m_animPlayer3D.setNode(simModel);
    instance.loadSimTextures(simId, forCAS, naked);
    this.m_modelId = simId;
    this.cacheLocators();
    this.m_type = 2;
    AppEngine.timerEnd(nameof (assembleSim));
  }

  public void assembleMacromapSim(int simId)
  {
    this.unload();
    ModelManager instance = ModelManager.getInstance();
    int modelId = simId == 0 ? 27 : 26;
    Node model1 = instance.getModel(modelId);
    this.m_group.addChild(model1);
    model1.setUserID(1109);
    string simCarModel = AppEngine.getCanvas().getSimData().getSimCarModel(simId);
    Node model2 = instance.getModel(simCarModel);
    this.m_group.addChild(model2);
    model2.setRenderingEnable(false);
    model2.setUserID(1110);
    this.m_animPlayer3D.setNode((Node) this.m_group);
    this.cacheLocators();
  }

  public void switchRoot(int userId)
  {
    this.m_root = (Node) null;
    for (int index = 0; index < Model.ROOT_USERIDS.Length; ++index)
      this.findLocator(Model.ROOT_USERIDS[index])?.setRenderingEnable(false);
    this.m_root = this.findLocator(userId);
    if (this.m_root != null)
      this.m_root.setRenderingEnable(true);
    this.m_hotspotLocators = this.cacheNodeList(1050, 1059);
  }

  private Node findLocator(int userId)
  {
    Object3D object3D = (this.m_root ?? (Node) this.m_group).find(userId);
    return object3D != null ? Node.m3g_cast(object3D) : (Node) null;
  }

  public Node getLocator(int userId)
  {
    int length = this.m_cachedLocators.Length;
    for (int index = 0; index < length; ++index)
    {
      if (Model.CACHED_USERIDS[index] == userId)
        return this.m_cachedLocators[index];
    }
    return this.findLocator(userId);
  }

  public void getLocatorPos(int[] result, int userId)
  {
    this.getLocatorPos(result, userId, true);
  }

  public void getLocatorPos(int[] result, int userId, bool worldRelative)
  {
    Object3D object3D = this.m_group.find(userId);
    if (object3D != null)
    {
      Node node = Node.m3g_cast(object3D);
      if (node != null)
      {
        this.getLocatorPos(result, node, worldRelative);
        return;
      }
    }
    result[0] = 0;
    result[1] = 0;
    result[2] = 0;
  }

  private Node[] cacheNodeList(int startUserID, int endUserId)
  {
    int length = 0;
    for (int userId = startUserID; userId <= endUserId; ++userId)
    {
      if (this.getLocator(userId) != null)
        ++length;
    }
    Node[] nodeArray = new Node[length];
    int index = 0;
    for (int userId = startUserID; userId <= endUserId; ++userId)
    {
      Node locator = this.getLocator(userId);
      if (locator != null)
      {
        nodeArray[index] = locator;
        ++index;
      }
    }
    return nodeArray;
  }

  private void cacheLocators()
  {
    int length = Model.CACHED_USERIDS.Length;
    this.m_cachedLocators = new Node[length];
    for (int index = 0; index < length; ++index)
    {
      int userId = Model.CACHED_USERIDS[index];
      this.m_cachedLocators[index] = this.findLocator(userId);
    }
    this.m_hotspotLocators = this.cacheNodeList(1050, 1059);
    this.m_benchtopLocators = this.cacheNodeList(1060, 1069);
  }

  public int getHotspotCount()
  {
    return this.m_hotspotLocators.Length;
  }

  public void getHotspot(int[] result, int index)
  {
    this.getHotspot(result, index, true);
  }

  public void getHotspot(int[] result, int index, bool worldRelative)
  {
    if (index < this.getHotspotCount())
      this.getLocatorPos(result, this.m_hotspotLocators[index], worldRelative);
    else
      this.getLocatorPos(result, (Node) this.m_group);
  }

  public int getBenchtopCount()
  {
    return this.m_benchtopLocators.Length;
  }

  public void getBenchtop(int[] result, int index)
  {
    this.getLocatorPos(result, this.m_benchtopLocators[index]);
  }

  public void setTint(int tint)
  {
    ModelManager.applyTintColor((Node) this.m_group, tint);
  }

  public void updatePlumbBob(
    int timeStep,
    bool primaryInstance,
    int gemPosX,
    int gemPosY,
    int gemPosZ,
    float facing,
    float yaw)
  {
    this.updatePlumbBob(timeStep, primaryInstance, gemPosX, gemPosY, gemPosZ, facing, yaw, 0.0f);
  }

  public void updatePlumbBob(
    int timeStep,
    bool primaryInstance,
    int gemPosX,
    int gemPosY,
    int gemPosZ,
    float facing)
  {
    this.updatePlumbBob(timeStep, primaryInstance, gemPosX, gemPosY, gemPosZ, facing, 0.0f, 0.0f);
  }

  public void updatePlumbBob(
    int timeStep,
    bool primaryInstance,
    int gemPosX,
    int gemPosY,
    int gemPosZ)
  {
    this.updatePlumbBob(timeStep, primaryInstance, gemPosX, gemPosY, gemPosZ, 0.0f, 0.0f, 0.0f);
  }

  public void updatePlumbBob(int timeStep, bool primaryInstance, int gemPosX, int gemPosY)
  {
    this.updatePlumbBob(timeStep, primaryInstance, gemPosX, gemPosY, 0, 0.0f, 0.0f, 0.0f);
  }

  public void updatePlumbBob(int timeStep, bool primaryInstance, int gemPosX)
  {
    this.updatePlumbBob(timeStep, primaryInstance, gemPosX, 0, 0, 0.0f, 0.0f, 0.0f);
  }

  public void updatePlumbBob(int timeStep, bool primaryInstance)
  {
    this.updatePlumbBob(timeStep, primaryInstance, 0, 0, 0, 0.0f, 0.0f, 0.0f);
  }

  public void updatePlumbBob(int timeStep)
  {
    this.updatePlumbBob(timeStep, false, 0, 0, 0, 0.0f, 0.0f, 0.0f);
  }

  public void updatePlumbBob(
    int timeStep,
    bool primaryInstance,
    int gemPosX,
    int gemPosY,
    int gemPosZ,
    float facing,
    float yaw,
    float pitch)
  {
    this.m_animTimer += timeStep;
    if (this.m_animTimer > 10000)
      this.m_animTimer -= 10000;
    this.getLocator(703).setTranslationx(gemPosX, gemPosY, gemPosZ);
    Node locator = this.getLocator(705);
    Model.s_tempTransform.setIdentity();
    Model.s_tempTransform.postRotate(yaw - facing, 0.0f, 1f, 0.0f);
    Model.s_tempTransform.postRotate(-pitch, 1f, 0.0f, 0.0f);
    locator.setTransform(Model.s_tempTransform);
    Mesh mesh = Mesh.m3g_cast((Object3D) this.getLocator(704));
    float degrees = (float) ((double) yaw - (double) facing + (double) this.m_animTimer * 360.0 / 10000.0);
    mesh.setOrientation(degrees, 0.0f, 1f, 0.0f);
    if (!primaryInstance)
      return;
    mesh.getAppearance(0).getTexture(0).setTranslation((float) ((double) this.m_animTimer * 2.0 / 10000.0), 0.0f, 0.0f);
  }

  public void disableFurnitureShadows()
  {
    this.getLocator(2001)?.setRenderingEnable(false);
    this.getLocator(2002)?.setRenderingEnable(false);
    this.getLocator(2003)?.setRenderingEnable(false);
    this.getLocator(2004)?.setRenderingEnable(false);
  }

  public void setNodeRenderingEnable(int nodeId, bool enable)
  {
    this.getLocator(nodeId)?.setRenderingEnable(enable);
  }

  public void updateHemisphereMap()
  {
    if (this.m_hemisphereMap == null)
      return;
    Transform cameraTransform = AppEngine.getCanvas().getSimWorld().getCameraTransform();
    this.tempTransform.setIdentity();
    this.m_group.getTransformTo(this.m_group.getParent(), ref this.tempTransform);
    this.tempTransform.postScale(0.5f, 0.5f, 0.5f);
    this.tempTransform.postMultiply(ref cameraTransform);
    ModelManager.transformHemisphereMap(this.m_hemisphereMap, this.tempTransform);
  }

  public void getLocatorPos(int[] result, Node node)
  {
    this.getLocatorPos(result, node, true);
  }

  public void getLocatorPos(int[] result, Node node, bool worldRelative)
  {
    Node target = (Node) this.m_group;
    if (worldRelative && this.m_group.getParent() != null)
      target = this.m_group.getParent();
    this.tempTransform.setIdentity();
    node.getTransformTo(target, ref this.tempTransform);
    this.cachedPos[0] = 0;
    this.cachedPos[1] = 0;
    this.cachedPos[2] = 0;
    this.cachedPos[3] = 65536;
    this.tempTransform.transformx(ref this.cachedPos);
    result[0] = this.cachedPos[0];
    result[1] = this.cachedPos[1];
    result[2] = this.cachedPos[2];
  }
}
