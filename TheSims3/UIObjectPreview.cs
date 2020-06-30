// Decompiled with JetBrains decompiler
// Type: UIObjectPreview
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using midp;

public class UIObjectPreview : UIElement
{
  private World m_world;
  private Camera m_camera;
  private Model m_model;
  private int m_modelId;
  private bool m_isPlumbBob;
  private bool m_isSim;

  public UIObjectPreview()
  {
    this.m_world = (World) null;
    this.m_camera = (Camera) null;
    this.m_model = (Model) null;
    this.m_modelId = -1;
    this.m_isPlumbBob = false;
    this.m_isSim = false;
    this.m_world = new World();
    Background background = new Background();
    background.setColorClearEnable(false);
    background.setDepthClearEnable(true);
    this.m_world.setBackground(background);
    this.m_camera = new Camera();
    this.m_world.addChild((Node) this.m_camera);
    this.m_world.setActiveCamera(this.m_camera);
    this.m_model = new Model();
    this.m_world.addChild(this.m_model.getNode());
  }

  public new void Dispose()
  {
    base.Dispose();
  }

  public void unload()
  {
    if (this.m_model != null)
      this.m_model.unload();
    this.m_modelId = -1;
  }

  public void loadObject(int objectType)
  {
    this.m_isPlumbBob = false;
    this.m_isSim = false;
    if (this.m_modelId == objectType)
      return;
    this.m_modelId = objectType;
    this.m_model.assembleObject(AppEngine.getCanvas().getSimWorld().getObjectModelId(objectType));
    int[] result = new int[6];
    ModelManager.getBoundingBox(result, this.m_model.getNode(), (Node) null);
    for (int index = 0; index < result.Length; ++index)
      result[index] = result[index] >> 16;
    float b = (float) JMath.sqrt((result[3] << 1) * (result[3] << 1) + (result[5] << 1) * (result[5] << 1));
    float num1 = JMath.max((float) result[4], b);
    float num2 = (float) (result[4] + (result[3] << 1) + (result[5] << 1)) / 3f;
    float tx = 0.0f;
    float ty = (float) (result[4] >> 1);
    float tz1 = 0.0f;
    float num3 = (float) (-0.0199999995529652 * ((double) num1 - (double) num2) + 3.0);
    float tz2 = num1 * num3;
    float num4 = 20f;
    float degrees = 45f;
    Transform transform = new Transform();
    transform.setIdentity();
    transform.postTranslate(tx, ty, tz1);
    transform.postRotate(degrees, 0.0f, 1f, 0.0f);
    transform.postRotate(-num4, 1f, 0.0f, 0.0f);
    transform.postTranslate(0.0f, 0.0f, tz2);
    transform.postRotate(90f, 0.0f, 0.0f, 1f);
    this.m_camera.setTransform(transform);
  }

  public void setupDefaultCamera()
  {
    float tz1 = 200f;
    float num = 20f;
    float degrees = 45f;
    float tx = 0.0f;
    float ty = 32f;
    float tz2 = 0.0f;
    Transform transform = new Transform();
    transform.setIdentity();
    transform.postTranslate(tx, ty, tz2);
    transform.postRotate(degrees, 0.0f, 1f, 0.0f);
    transform.postRotate(-num, 1f, 0.0f, 0.0f);
    transform.postTranslate(0.0f, 0.0f, tz1);
    transform.postRotate(90f, 0.0f, 0.0f, 1f);
    this.m_camera.setTransform(transform);
  }

  public void loadPlumbBobObject(bool hideGlow)
  {
    this.m_isPlumbBob = true;
    this.m_isSim = false;
    this.m_model.assembleObject(169);
    this.m_model.getLocator(705).setRenderingEnable(!hideGlow);
    Transform transform = new Transform();
    transform.setIdentity();
    transform.postTranslate(0.0f, 0.0f, 0.0f);
    transform.postRotate(0.0f, 0.0f, 1f, 0.0f);
    transform.postRotate(-0.0f, 1f, 0.0f, 0.0f);
    transform.postTranslate(0.0f, 0.0f, 80f);
    transform.postRotate(90f, 0.0f, 0.0f, 1f);
    this.m_camera.setTransform(transform);
  }

  public void loadSim(int simId)
  {
    this.m_isPlumbBob = false;
    this.m_isSim = true;
    if (this.m_modelId == simId)
      return;
    this.m_modelId = simId;
    this.m_model.assembleSimForGame(simId);
    this.m_model.getAnimPlayer3D().setAnimTime(90480);
    float tz1 = 90f;
    float num = 20f;
    float degrees = 10f;
    float tx = 0.0f;
    float ty = 32f;
    float tz2 = 0.0f;
    Transform transform = new Transform();
    transform.setIdentity();
    transform.postTranslate(tx, ty, tz2);
    transform.postRotate(degrees, 0.0f, 1f, 0.0f);
    transform.postRotate(-num, 1f, 0.0f, 0.0f);
    transform.postTranslate(0.0f, 0.0f, tz1);
    transform.postRotate(90f, 0.0f, 0.0f, 1f);
    this.m_camera.setTransform(transform);
  }

  public void render(Graphics g, int x, int y, int w, int h)
  {
    this.m_camera.setPerspective(38f, (float) h / (float) w, 32f, 2600f);
    Graphics3D graphics3D = AppEngine.getCanvas().getGraphics3D();
    graphics3D.bindTarget((object) g, JavaLib.GraphicsDevice);
    int viewportX = graphics3D.getViewportX();
    int viewportY = graphics3D.getViewportY();
    int viewportWidth = graphics3D.getViewportWidth();
    int viewportHeight = graphics3D.getViewportHeight();
    graphics3D.setViewport(x, y, w, h);
    graphics3D.renderForceAppearanceLoad(this.m_world);
    graphics3D.setViewport(viewportX, viewportY, viewportWidth, viewportHeight);
    graphics3D.releaseTarget();
  }

  public void renderSim(Graphics g, int x, int y, int w, int h, float alpha)
  {
  }

  public override void processInput(int _event, int[] args)
  {
  }

  public override void update(int timeStep)
  {
    if (!this.m_isPlumbBob)
      return;
    this.m_model.updatePlumbBob(timeStep, false, 0, 0, 0, 0.0f, 0.0f, 0.0f);
  }

  public Model getModel()
  {
    return this.m_model;
  }
}
