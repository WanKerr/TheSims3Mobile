// Decompiled with JetBrains decompiler
// Type: PostEffects
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using midp;

public class PostEffects
{
  public const int ALPHA = 64;
  public const int MODULATE = 66;
  public const int ALPHA_ADD = 65;
  private int m_viewportX;
  private int m_viewportY;
  private int m_viewportW;
  private int m_viewportH;
  private World m_postEffectsWorld;
  private CompositingMode m_postEffectsCompositingMode;
  private VertexBuffer m_vertexBuffer;

  public PostEffects()
  {
    this.m_viewportX = 0;
    this.m_viewportY = 0;
    this.m_viewportW = 0;
    this.m_viewportH = 0;
    this.m_postEffectsWorld = (World) null;
    this.m_postEffectsCompositingMode = (CompositingMode) null;
    this.m_vertexBuffer = (VertexBuffer) null;
    float[] bias = (float[]) null;
    Appearance appearance = new Appearance();
    this.m_postEffectsCompositingMode = new CompositingMode();
    this.m_postEffectsCompositingMode.setAlphaThreshold(0.0f);
    this.m_postEffectsCompositingMode.setDepthTestEnable(false);
    this.m_postEffectsCompositingMode.setDepthWriteEnable(false);
    appearance.setCompositingMode(this.m_postEffectsCompositingMode);
    VertexArray arr = new VertexArray(4, 3, 2);
    short[] src = new short[12]
    {
      (short) -1,
      (short) -1,
      (short) 0,
      (short) 1,
      (short) -1,
      (short) 0,
      (short) -1,
      (short) 1,
      (short) 0,
      (short) 1,
      (short) 1,
      (short) 0
    };
    arr.set(0, 4, src);
    this.m_vertexBuffer = new VertexBuffer();
    this.m_vertexBuffer.setPositions(arr, 1f, bias);
    Mesh mesh = new Mesh(this.m_vertexBuffer, (IndexBuffer) new TriangleStripArray(0, new int[1]
    {
      4
    }), appearance);
    this.m_postEffectsWorld = new World();
    Camera camera = new Camera();
    camera.setParallel(1f, 1f, -1f, 1f);
    this.m_postEffectsWorld.addChild((Node) camera);
    this.m_postEffectsWorld.setActiveCamera(camera);
    Background background = new Background();
    background.setColorClearEnable(false);
    background.setDepthClearEnable(false);
    this.m_postEffectsWorld.setBackground(background);
    this.m_postEffectsWorld.addChild((Node) mesh);
  }

  public virtual void Dispose()
  {
    if (this.m_postEffectsWorld == null)
      return;
    this.m_postEffectsWorld = (World) null;
  }

  public void setColor(int color)
  {
    this.m_vertexBuffer.setDefaultColor(color);
  }

  public void setBlendMode(int blendMode)
  {
    this.m_postEffectsCompositingMode.setBlending(blendMode);
  }

  public void setViewport(int x, int y, int w, int h)
  {
    this.m_viewportX = x;
    this.m_viewportY = y;
    this.m_viewportW = w;
    this.m_viewportH = h;
  }

  public void apply(Graphics g)
  {
    Graphics3D instance = Graphics3D.getInstance();
    instance.bindTarget((object) g, JavaLib.GraphicsDevice);
    instance.setViewport(this.m_viewportX, this.m_viewportY, this.m_viewportW, this.m_viewportH);
    instance.render(this.m_postEffectsWorld);
    instance.releaseTarget();
  }
}
