// Decompiled with JetBrains decompiler
// Type: XNAUnlockFullVersion
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using midp;

public class XNAUnlockFullVersion
{
  private const int HEADER_X = 260;
  private const int HEADER_Y = 55;
  private const int TEXT_X = 20;
  private const int TEXT_Y = 190;
  private const int TEXT_W = 260;
  private const int TEXT_H = 110;
  private const int BTN_STORE_X = 340;
  private const int BTN_STORE_Y = 180;
  private const int BTN_STORE_W = 170;
  private const int BTN_STORE_H = 70;
  private const int BTN_BACK_X = 340;
  private const int BTN_BACK_Y = 250;
  private const int BTN_BACK_W = 170;
  private const int BTN_BACK_H = 60;
  private AppEngine ae;
  private TextManager tm;
  private Image bg;

  public XNAButton btnStore { get; private set; }

  public XNAButton btnMenu { get; private set; }

  public XNAUnlockFullVersion(AppEngine ae)
  {
    this.ae = ae;
  }

  public void Initialize()
  {
    this.bg = JavaLib.createImage("XNAMenu//trialover_sims3");
    this.tm = this.ae.getTextManager();
    this.btnStore = new XNAButton(340, 180, 170, 70, XNAButton.Type.UNLOCKFULL_STORE);
    this.btnMenu = new XNAButton(340, 250, 170, 60, XNAButton.Type.UNLOCKFULL_BACK);
  }

  public void Update(int timeStep)
  {
    this.btnStore.update(timeStep);
    this.btnMenu.update(timeStep);
  }

  public void Render(Graphics g)
  {
    g.Begin();
    g.drawImage(this.bg, 0.0f, 0.0f, 9);
    int font = 6;
    this.tm.drawString(g, 1820, font, 260, 55, 18);
    this.tm.wrapString(1821, font, 260);
    this.tm.drawWrappedString(g, font, 150, 245, 18);
    this.btnStore.render(g);
    this.btnMenu.render(g);
    g.End();
  }
}
