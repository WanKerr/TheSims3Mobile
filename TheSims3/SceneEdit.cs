// Decompiled with JetBrains decompiler
// Type: SceneEdit
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using house;
using midp;

public class SceneEdit : SceneGame
{
  private readonly string[] LOOKUP_FACINGS = new string[4];
  public const int EDITSTATE_NONE = 0;
  public const int EDITSTATE_SELECT_HOUSE = 1;
  public const int EDITSTATE_MAIN = 2;
  public const int EDITSTATE_PAN = 3;
  public const int EDITSTATE_ATTRIBUTES = 4;
  public const int EDITSTATE_PREVIEW = 5;
  private const int COLOR_WINDOW = 16776960;
  private const int COLOR_ROOM = 16711680;
  private const int COLOR_HOUSE_OBJECT = 16711935;
  private const int COLOR_DOOR = 65280;
  private const int COLOR_ANCHOR_MARKER = 5592405;
  private const int COLOR_TILE_CENTER_MARKER = 5592405;
  private const int ANCHOR_MARKER_SIZE = 4;
  private const int TILE_CENTER_MARKER_SIZE = 2;
  private const int COLOR_SELECTION = 16777215;
  private const int BUTTON_ID_NONE = -1;
  private const int BUTTON_ID_HOUSE_SELECT_OK = 0;
  private const int NUM_BUTTONS_HOUSE_SELECT = 1;
  private const int BUTTON_ID_MAIN_EDIT_ROOM = 0;
  private const int BUTTON_ID_MAIN_EDIT_DOOR = 1;
  private const int BUTTON_ID_MAIN_EDIT_WINDOW = 2;
  private const int BUTTON_ID_MAIN_EDIT_OBJECT = 3;
  private const int BUTTON_ID_MAIN_EDIT_TRASH = 4;
  private const int BUTTON_ID_MAIN_EDIT_PREVIEW = 5;
  private const int BUTTON_ID_MAIN_EDIT_RECALC_PREVIEW = 6;
  private const int NUM_BUTTONS_MAIN_EDIT = 7;
  private const int BUTTON_ID_ATTR_EDIT_COL1_PREV = 0;
  private const int BUTTON_ID_ATTR_EDIT_COL1_NEXT = 1;
  private const int BUTTON_ID_ATTR_EDIT_COL2_PREV = 2;
  private const int BUTTON_ID_ATTR_EDIT_COL2_NEXT = 3;
  private const int BUTTON_ID_ATTR_EDIT_FACING_X_POS = 4;
  private const int BUTTON_ID_ATTR_EDIT_FACING_X_NEG = 5;
  private const int BUTTON_ID_ATTR_EDIT_FACING_Z_POS = 6;
  private const int BUTTON_ID_ATTR_EDIT_FACING_Z_NEG = 7;
  private const int BUTTON_ID_ATTR_EDIT_LEFT_LIST = 8;
  private const int BUTTON_ID_ATTR_EDIT_RIGHT_LIST = 9;
  private const int NUM_BUTTONS_ATTR_EDIT = 10;
  private const int EDIT_BUTTON_WIDTH = 80;
  private const int EDIT_BUTTON_HEIGHT = 43;
  private const int BUTTON_PADDING = 2;
  private const int LIST_PADDING = 40;
  private const int LIST_ITEM_HEIGHT = 20;
  private const int LIST_ITEM_PADDING = 4;
  private const int COLOR_ATTRIBUTE_LIST = 11184810;
  private const int FACING_BUTTON_HEIGHT = 40;
  private int m_editState;
  private int m_editStateTime;
  private House m_currentHouse;
  private int m_prevAddedObjectType;
  private EditorButton[] m_houseSelectButtons;
  private int m_selectedHouseIndex;
  private EditorButton[] m_mainEditButtons;
  private EditorButton[] m_attrEditButtons;
  private int m_currentFacingSelectionButtonId;
  private int m_numListRows;
  private string[] m_lookupsFirstList;
  private int m_lookupSizeFirstList;
  private int m_numPagesFirstList;
  private int m_currPageFirstList;
  private int m_currSelectionFirstList;
  private string[] m_lookupsSecondList;
  private int m_lookupSizeSecondList;
  private int m_numPagesSecondList;
  private int m_currPageSecondList;
  private int m_currSelectionSecondList;
  private int m_tileSize;
  private int m_topLeftTileX;
  private int m_topLeftTileY;
  private int m_startDragTopLeftTileX;
  private int m_startDragTopLeftTileY;
  private int m_activeTileX;
  private int m_activeTileY;
  private int m_prevActiveTileX;
  private int m_prevActiveTileY;
  private int m_startDragScreenX;
  private int m_startDragScreenY;
  private PlaceableObject m_selectedObject;

  public SceneEdit(AppEngine ae)
    : base(ae)
  {
    this.m_editState = 0;
    this.m_editStateTime = 0;
    this.m_tileSize = 40;
    this.m_topLeftTileX = 0;
    this.m_topLeftTileY = 0;
    this.m_startDragTopLeftTileX = 0;
    this.m_startDragTopLeftTileY = 0;
    this.m_activeTileX = 0;
    this.m_activeTileY = 0;
    this.m_prevActiveTileX = 0;
    this.m_prevActiveTileY = 0;
    this.m_startDragScreenX = 0;
    this.m_startDragScreenY = 0;
    this.m_selectedObject = (PlaceableObject) null;
    this.m_currentHouse = (House) null;
    this.m_prevAddedObjectType = -1;
    this.m_mainEditButtons = new EditorButton[7];
    this.m_attrEditButtons = new EditorButton[10];
    this.m_houseSelectButtons = new EditorButton[1];
    this.m_selectedHouseIndex = -1;
    this.m_lookupsFirstList = (string[]) null;
    this.m_lookupSizeFirstList = 0;
    this.m_numPagesFirstList = 0;
    this.m_currPageFirstList = 0;
    this.m_currSelectionFirstList = -1;
    this.m_lookupsSecondList = (string[]) null;
    this.m_lookupSizeSecondList = 0;
    this.m_numPagesSecondList = 0;
    this.m_currPageSecondList = 0;
    this.m_currSelectionSecondList = -1;
    this.m_numListRows = 0;
    this.m_currentFacingSelectionButtonId = -1;
  }

  public new void Dispose()
  {
    if (this.m_currentHouse != null)
    {
      this.writeCurrentHouseToFile();
      this.m_currentHouse.Dispose();
      this.m_currentHouse = (House) null;
    }
    base.Dispose();
  }

  public override int getSceneID()
  {
    return 4;
  }

  public override void start(int initialState)
  {
    AppEngine engine = this.m_engine;
    ModelManager.getInstance().setLoadStatus(2);
    this.initUI();
    this.m_editState = 0;
    this.m_editStateTime = 0;
    this.loadMap(0);
    this.initEditMode();
    this.editStateTransition(1);
    this.createButtons();
    engine.stopFade();
    this.m_currentHouse = this.getHouse(0);
    this.m_prevAddedObjectType = -1;
    this.initHUDZoomBar();
  }

  public override void pause()
  {
  }

  public override void resume()
  {
  }

  public override void end()
  {
    this.writeCurrentHouseToFile();
    foreach (MapObject @object in this.getObjects())
      this.removeObject(@object);
    if (this.m_simWorld != null)
      this.m_simWorld.unload();
    int mask = 2032;
    if (this.m_engine.getNextSceneId() == 2)
      mask &= -17;
    this.m_engine.unloadAllImages(mask, -1);
  }

  public override void render(Graphics g)
  {
    this.startUI();
    string str = " ";
    switch (this.m_editState)
    {
      case 1:
        this.renderHouseSelect(g);
        break;
      case 2:
        this.renderGrid(g);
        this.renderCurrentHouse(g);
        this.renderEditButtons(g);
        this.renderSelectionInfo(g);
        break;
      case 3:
        str = "view mode";
        this.renderGrid(g);
        this.renderCurrentHouse(g);
        break;
      case 4:
        this.renderGrid(g);
        this.renderCurrentHouse(g);
        this.renderAttributeEditWindow(g);
        break;
      case 5:
        this.m_simWorld.renderWorld(g);
        break;
    }
    this.m_engine.getTextManager().drawString(g, str, 5, 3, 320, 12);
    this.endUI();
    this.renderTapper(g);
  }

  private void renderGrid(Graphics g)
  {
    int viewportWidth = this.m_simWorld.getViewportWidth();
    int viewportHeight = this.m_simWorld.getViewportHeight();
    g.setColor(3355443);
    g.fillRect(0, 0, viewportWidth, viewportHeight);
    int num1 = 1 + viewportWidth / this.m_tileSize;
    int num2 = 1 + viewportHeight / this.m_tileSize;
    int topLeftTileX = this.m_topLeftTileX;
    for (int index1 = 0; index1 < num1; ++index1)
    {
      int topLeftTileY = this.m_topLeftTileY;
      for (int index2 = 0; index2 < num2; ++index2)
      {
        int screenX = 0;
        int screenY = 0;
        this.coordTileToScreen(topLeftTileX, topLeftTileY, ref screenX, ref screenY);
        if (topLeftTileX == 0 && topLeftTileY == 0)
        {
          g.setColor(2236962);
          g.fillRect(screenX - (this.m_tileSize >> 1), screenY - (this.m_tileSize >> 1), this.m_tileSize, this.m_tileSize);
        }
        else
        {
          g.setColor(4473924);
          g.drawRect((float) (screenX - (this.m_tileSize >> 1)), (float) (screenY - (this.m_tileSize >> 1)), (float) this.m_tileSize, (float) this.m_tileSize);
        }
        ++topLeftTileY;
      }
      ++topLeftTileX;
    }
  }

  private void renderHouseSelect(Graphics g)
  {
    int viewportWidth = this.m_simWorld.getViewportWidth();
    int viewportHeight = this.m_simWorld.getViewportHeight();
    g.setColor(3355443);
    g.fillRect(0, 0, viewportWidth, viewportHeight);
    int houseCount = this.m_simWorld.getHouseCount();
    int y = 0;
    for (int index = 0; index < houseCount; ++index)
    {
      int x = index == this.m_selectedHouseIndex ? 35 : 5;
      this.m_engine.getTextManager().drawString(g, GlobalConstants.LOOKUP_HOUSE[index], 5, x, y, 9);
      y += 20;
    }
    this.m_houseSelectButtons[0].render(g);
  }

  private void renderEditButtons(Graphics g)
  {
    int length = this.m_mainEditButtons.Length;
    for (int index = 0; index < length; ++index)
      this.m_mainEditButtons[index].render(g);
  }

  private void renderAttributeEditWindow(Graphics g)
  {
    int length = this.m_attrEditButtons.Length;
    for (int index = 0; index < length; ++index)
    {
      this.m_attrEditButtons[index].render(g);
      if (this.m_attrEditButtons[index].getId() == this.m_currentFacingSelectionButtonId)
      {
        int x = this.m_attrEditButtons[index].getX();
        int y = this.m_attrEditButtons[index].getY();
        g.setColor((int) byte.MaxValue, 0, 0);
        g.fillRect(x, y, 15, 15);
      }
    }
    int x1 = this.m_attrEditButtons[8].getX();
    int num1 = this.m_attrEditButtons[8].getX() + this.m_attrEditButtons[8].getWidth();
    int y1 = this.m_attrEditButtons[8].getY();
    int y2 = y1 + 10;
    int num2 = this.m_currPageFirstList * this.m_numListRows;
    if (this.m_lookupsFirstList != null)
    {
      for (int index = 0; index < this.m_numListRows && index + num2 < this.m_lookupSizeFirstList; ++index)
      {
        int num3 = this.m_currSelectionFirstList == index + num2 ? 44 : 4;
        int valueLookupIndex = this.getAttributeValueLookupIndex(index + num2, 0);
        this.m_engine.getTextManager().drawString(g, this.m_lookupsFirstList[valueLookupIndex], 5, x1 + num3, y2, 10);
        y2 += 20;
      }
    }
    int y3 = y1 + 10;
    int num4 = this.m_currPageSecondList * this.m_numListRows;
    if (this.m_lookupsSecondList == null)
      return;
    for (int index = 0; index < this.m_numListRows && index + num4 < this.m_lookupSizeSecondList; ++index)
    {
      int num3 = this.m_currSelectionSecondList == index + num4 ? 44 : 4;
      this.m_engine.getTextManager().drawString(g, this.m_lookupsSecondList[this.getAttributeValueLookupIndex(index + num4, 1)], 5, num1 + num3, y3, 10);
      y3 += 20;
    }
  }

  private void renderSelectionInfo(Graphics g)
  {
    StringBuffer strBuffer = new StringBuffer();
    strBuffer.append("selection: ");
    if (this.m_selectedObject == null)
      strBuffer.append("none");
    else if (house.Room.house_cast(this.m_selectedObject) != null)
    {
      house.Room room = house.Room.house_cast(this.m_selectedObject);
      strBuffer.append("room (floor=").append(GlobalConstants.LOOKUP_FLOOR[room.getFloor()]).append(", wall=").append(GlobalConstants.LOOKUP_WALL[room.getWall()]).append(")");
    }
    else if (Door.house_cast(this.m_selectedObject) != null)
    {
      Door door = Door.house_cast(this.m_selectedObject);
      strBuffer.append("door (type=").append(GlobalConstants.LOOKUP_OBJECT[door.getType()]).append(")");
    }
    else if (HouseObject.house_cast(this.m_selectedObject) != null)
    {
      HouseObject houseObject = HouseObject.house_cast(this.m_selectedObject);
      strBuffer.append("object (type=").append(GlobalConstants.LOOKUP_OBJECT[houseObject.getType()]).append(")");
    }
    else if (Window.house_cast(this.m_selectedObject) != null)
    {
      Window window = Window.house_cast(this.m_selectedObject);
      strBuffer.append("window (type=").append(GlobalConstants.LOOKUP_OBJECT[window.getType()]).append(")");
    }
    this.m_engine.getTextManager().drawString(g, strBuffer, 5, 5, 5, 9);
  }

  private void renderCurrentHouse(Graphics g)
  {
    if (this.m_currentHouse == null)
      return;
    Vector rooms = this.m_currentHouse.getRooms();
    int num1 = rooms.size();
    Vector windows = this.m_currentHouse.getWindows();
    int num2 = windows.size();
    Vector houseObjects = this.m_currentHouse.getHouseObjects();
    int num3 = houseObjects.size();
    Vector doors = this.m_currentHouse.getDoors();
    int num4 = doors.size();
    for (int index = 0; index < num1; ++index)
    {
      house.Room room = (house.Room) rooms.elementAt(index);
      this.renderPlaceableObject(g, 16711680, room.getX(), room.getY(), room.getWidth(), room.getHeight(), true, room == this.m_selectedObject, -1);
    }
    for (int index = 0; index < num2; ++index)
    {
      Window window = (Window) windows.elementAt(index);
      this.renderPlaceableObject(g, 16776960, window.getX(), window.getY(), window.getWidth(), window.getHeight(), false, window == this.m_selectedObject, -1);
    }
    for (int index = 0; index < num3; ++index)
    {
      HouseObject houseObject = (HouseObject) houseObjects.elementAt(index);
      this.renderPlaceableObject(g, 16711935, houseObject.getX(), houseObject.getY(), houseObject.getWidth(), houseObject.getHeight(), false, houseObject == this.m_selectedObject, houseObject.getFacing());
    }
    for (int index = 0; index < num4; ++index)
    {
      Door door = (Door) doors.elementAt(index);
      this.renderPlaceableObject(g, 65280, door.getX(), door.getY(), door.getWidth(), door.getHeight(), false, door == this.m_selectedObject, -1);
    }
  }

  private void renderPlaceableObject(
    Graphics g,
    int color,
    int xTile,
    int yTile,
    int widthConst,
    int heightConst,
    bool isRoom,
    bool selected,
    int facing)
  {
    int screenX = 0;
    int screenY = 0;
    this.coordTileToScreen(xTile, yTile, ref screenX, ref screenY);
    bool flag = facing == 1 || facing == 3;
    int num1 = flag ? heightConst : widthConst;
    int num2 = flag ? widthConst : heightConst;
    g.setColor(color);
    if (!isRoom)
    {
      g.drawRect((float) (screenX - num1 * this.m_tileSize + 1 + (this.m_tileSize >> 1)), (float) (screenY - num2 * this.m_tileSize + 1 + (this.m_tileSize >> 1)), (float) (num1 * this.m_tileSize - 2), (float) (num2 * this.m_tileSize - 2));
      if (facing != -1)
      {
        int num3 = this.m_tileSize >> 1;
        g.setColor((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 60);
        if (facing == 0)
        {
          g.drawLine((float) screenX, (float) (screenY + num3), (float) (screenX + num3), (float) screenY);
          g.drawLine((float) screenX, (float) (screenY - num3), (float) (screenX + num3), (float) screenY);
        }
        else if (facing == 2)
        {
          g.drawLine((float) screenX, (float) (screenY + num3), (float) (screenX - num3), (float) screenY);
          g.drawLine((float) screenX, (float) (screenY - num3), (float) (screenX - num3), (float) screenY);
        }
        else if (facing == 1)
        {
          g.drawLine((float) (screenX - num3), (float) screenY, (float) screenX, (float) (screenY + num3));
          g.drawLine((float) (screenX + num3), (float) screenY, (float) screenX, (float) (screenY + num3));
        }
        else if (facing == 3)
        {
          g.drawLine((float) (screenX - num3), (float) screenY, (float) screenX, (float) (screenY - num3));
          g.drawLine((float) (screenX + num3), (float) screenY, (float) screenX, (float) (screenY - num3));
        }
      }
    }
    else
      g.drawRect((float) (screenX + 1 - (this.m_tileSize >> 1)), (float) (screenY + 1 - (this.m_tileSize >> 1)), (float) (num1 * this.m_tileSize - 2), (float) (num2 * this.m_tileSize - 2));
    g.setColor(selected ? 10044416 : 5592405);
    int num4 = selected ? 8 : 4;
    g.drawRect((float) (screenX - (num4 >> 1)), (float) (screenY - (num4 >> 1)), (float) num4, (float) num4);
  }

  private bool isDoubleTapHorizontal(int[] doubleTapArgs)
  {
    return JMath.abs(doubleTapArgs[1] - doubleTapArgs[3]) >= JMath.abs(doubleTapArgs[2] - doubleTapArgs[4]);
  }

  public override void update(int timeStep)
  {
    base.update(timeStep);
    this.m_editStateTime += timeStep;
    switch (this.m_editState)
    {
      case 3:
        this.updateCamera(timeStep);
        break;
      case 5:
        this.updateCamera(timeStep);
        break;
    }
  }

  private void processAttributeListSelection(int listIndex, int itemIdx)
  {
    if (listIndex == 0)
    {
      if (itemIdx + this.m_currPageFirstList * this.m_numListRows >= this.m_lookupSizeFirstList)
        JSystem.println("non existing item selected from list 1, doing nothing");
      else
        this.m_currSelectionFirstList = this.m_currPageFirstList * this.m_numListRows + itemIdx;
    }
    else if (itemIdx + this.m_currPageSecondList * this.m_numListRows >= this.m_lookupSizeSecondList)
      JSystem.println("non existing item selected from list 2, doing nothing");
    else
      this.m_currSelectionSecondList = this.m_currPageSecondList * this.m_numListRows + itemIdx;
  }

  private void initStateEditAttributes()
  {
    this.m_lookupsFirstList = (string[]) null;
    this.m_numPagesFirstList = 0;
    this.m_currPageFirstList = 0;
    this.m_lookupSizeFirstList = 0;
    this.m_lookupsSecondList = (string[]) null;
    this.m_numPagesSecondList = 0;
    this.m_currPageSecondList = 0;
    this.m_lookupSizeFirstList = 0;
    this.m_currSelectionFirstList = 0;
    this.m_currSelectionSecondList = 0;
    this.m_currentFacingSelectionButtonId = -1;
    this.m_attrEditButtons[4].hide();
    this.m_attrEditButtons[5].hide();
    this.m_attrEditButtons[6].hide();
    this.m_attrEditButtons[7].hide();
    this.m_attrEditButtons[0].hide();
    this.m_attrEditButtons[2].hide();
    this.m_attrEditButtons[1].hide();
    this.m_attrEditButtons[3].hide();
    if (house.Room.house_cast(this.m_selectedObject) != null)
    {
      house.Room room = house.Room.house_cast(this.m_selectedObject);
      this.m_lookupsFirstList = GlobalConstants.LOOKUP_FLOOR;
      this.m_lookupSizeFirstList = this.m_simWorld.getFloorCount();
      this.m_currSelectionFirstList = room.getFloor();
      this.m_lookupsSecondList = GlobalConstants.LOOKUP_WALL;
      this.m_lookupSizeSecondList = this.m_simWorld.getWallCount();
      this.m_currSelectionSecondList = room.getWall();
    }
    else if (Door.house_cast(this.m_selectedObject) != null)
    {
      Door door = Door.house_cast(this.m_selectedObject);
      this.m_lookupsFirstList = GlobalConstants.LOOKUP_OBJECT;
      this.m_lookupSizeFirstList = this.m_simWorld.getDoorTypeNthCount();
      this.m_currSelectionFirstList = this.m_simWorld.getObjectOfTypeIndexFromObjectArrayIndex(15, door.getType() == -1 ? 70 : door.getType());
      JSystem.println("door count = " + (object) this.m_lookupSizeFirstList);
    }
    else if (HouseObject.house_cast(this.m_selectedObject) != null)
    {
      HouseObject houseObject = HouseObject.house_cast(this.m_selectedObject);
      this.m_attrEditButtons[4].show();
      this.m_attrEditButtons[5].show();
      this.m_attrEditButtons[6].show();
      this.m_attrEditButtons[7].show();
      switch (houseObject.getFacing())
      {
        case 0:
          this.m_currentFacingSelectionButtonId = 4;
          break;
        case 1:
          this.m_currentFacingSelectionButtonId = 6;
          break;
        case 2:
          this.m_currentFacingSelectionButtonId = 5;
          break;
        case 3:
          this.m_currentFacingSelectionButtonId = 7;
          break;
      }
      this.m_lookupsFirstList = GlobalConstants.LOOKUP_OBJECT;
      this.m_lookupSizeFirstList = this.m_simWorld.getBuildableNthCount();
      JSystem.println("object count = " + (object) this.m_lookupSizeFirstList);
      this.m_currSelectionFirstList = this.m_simWorld.getBuildableObjectIndexFromObjectArrayIndex(houseObject.getType());
    }
    else if (Window.house_cast(this.m_selectedObject) != null)
    {
      Window window = Window.house_cast(this.m_selectedObject);
      this.m_lookupsFirstList = GlobalConstants.LOOKUP_OBJECT;
      this.m_lookupSizeFirstList = this.m_simWorld.getWindowTypeNthCount();
      JSystem.println("window count = " + (object) this.m_lookupSizeFirstList);
      this.m_currSelectionFirstList = this.m_simWorld.getObjectOfTypeIndexFromObjectArrayIndex(32, window.getType());
    }
    if (this.m_lookupsFirstList != null)
    {
      this.m_numPagesFirstList = 1 + (this.m_lookupSizeFirstList - 1) / this.m_numListRows;
      if (this.m_numPagesFirstList > 1)
        this.m_attrEditButtons[1].show();
    }
    if (this.m_lookupsSecondList == null)
      return;
    this.m_numPagesSecondList = 1 + (this.m_lookupSizeSecondList - 1) / this.m_numListRows;
    if (this.m_numPagesSecondList <= 1)
      return;
    this.m_attrEditButtons[3].show();
  }

  public void editStateTransition(int newState)
  {
    int editState = this.m_editState;
    this.m_editState = newState;
    this.m_editStateTime = 0;
    switch (newState)
    {
      case 2:
        if (editState == 1)
        {
          this.m_currentHouse = this.getHouse(this.m_selectedHouseIndex);
          break;
        }
        if (editState != 4)
          break;
        this.setSelectedObjectAttributes();
        break;
      case 4:
        this.initStateEditAttributes();
        break;
    }
  }

  private void createButtons()
  {
    int viewportWidth = this.m_simWorld.getViewportWidth();
    int viewportHeight = this.m_simWorld.getViewportHeight();
    int y1 = 2;
    this.m_houseSelectButtons[0].init(300, 100, 80, 43, "continue", 0);
    for (int buttonId = 0; buttonId < 7; ++buttonId)
    {
      int x = viewportWidth - 2 - 80;
      string label = (string) null;
      switch (buttonId)
      {
        case 0:
          label = "room";
          break;
        case 1:
          label = "door";
          break;
        case 2:
          label = "window";
          break;
        case 3:
          label = "object";
          break;
        case 4:
          label = "delete selection";
          break;
        case 5:
          label = "preview";
          break;
        case 6:
          label = "recalc and preview";
          break;
      }
      this.m_mainEditButtons[buttonId].init(x, y1, 80, 43, label, buttonId);
      y1 += 45;
    }
    int num1 = viewportWidth >> 2;
    int num2 = viewportHeight - 80;
    for (int buttonId = 0; buttonId < 10; ++buttonId)
    {
      int x = 0;
      int y2 = 0;
      int width = 0;
      int height = 0;
      string label = (string) null;
      switch (buttonId)
      {
        case 0:
          x = 0;
          y2 = 40 + num2;
          width = num1;
          height = 40;
          label = "prev page";
          break;
        case 1:
          x = num1;
          y2 = 40 + num2;
          width = num1;
          height = 40;
          label = "next p";
          break;
        case 2:
          x = 2 * num1;
          y2 = 40 + num2;
          width = num1;
          height = 40;
          label = "prev page";
          break;
        case 3:
          x = 3 * num1;
          y2 = 40 + num2;
          width = num1;
          height = 40;
          label = "next p";
          break;
        case 4:
          y2 = 0;
          width = num1;
          height = 40;
          x = 0;
          label = "x pos (right)";
          break;
        case 5:
          y2 = 0;
          width = num1;
          height = 40;
          x = num1;
          label = "x neg (left)";
          break;
        case 6:
          y2 = 0;
          width = num1;
          height = 40;
          x = 2 * num1;
          label = "z pos (down)";
          break;
        case 7:
          y2 = 0;
          width = num1;
          height = 40;
          x = 3 * num1;
          label = "z neg (up)";
          break;
        case 8:
          x = 0;
          y2 = 40;
          width = viewportWidth >> 1;
          height = num2;
          label = " ";
          break;
        case 9:
          x = viewportWidth >> 1;
          y2 = 40;
          width = viewportWidth >> 1;
          height = num2;
          label = " ";
          this.m_numListRows = height / 20;
          break;
      }
      this.m_attrEditButtons[buttonId].init(x, y2, width, height, label, buttonId);
    }
  }

  private int getListItemIndex(int xScreen, int yScreen)
  {
    int y = this.m_attrEditButtons[8].getY();
    return (yScreen - y) / 20;
  }

  private int getAttributeValueLookupIndex(int uiListItemIndex, int listIndex)
  {
    int num = -1;
    if (house.Room.house_cast(this.m_selectedObject) != null)
      num = uiListItemIndex;
    else if (Door.house_cast(this.m_selectedObject) != null)
      num = this.m_simWorld.getDoorTypeNthObject(uiListItemIndex);
    else if (HouseObject.house_cast(this.m_selectedObject) != null)
      num = this.m_simWorld.getBuildableNthObject(uiListItemIndex);
    else if (Window.house_cast(this.m_selectedObject) != null)
      num = this.m_simWorld.getWindowTypeNthObject(uiListItemIndex);
    return num;
  }

  private void changeAttributePage(int columnIdx, int delta)
  {
    this.m_attrEditButtons[0].show();
    this.m_attrEditButtons[1].show();
    this.m_attrEditButtons[2].show();
    this.m_attrEditButtons[3].show();
    switch (columnIdx)
    {
      case 0:
        this.m_currPageFirstList = delta <= 0 ? JMath.max(this.m_currPageFirstList - 1, 0) : JMath.min(this.m_currPageFirstList + 1, this.m_numPagesFirstList - 1);
        JSystem.println("first list page changed to " + (object) this.m_currPageFirstList);
        break;
      case 1:
        this.m_currPageSecondList = delta <= 0 ? JMath.max(this.m_currPageSecondList - 1, 0) : JMath.min(this.m_currPageSecondList + 1, this.m_numPagesSecondList - 1);
        JSystem.println("second list page changed to " + (object) this.m_currPageSecondList);
        break;
    }
    if (this.m_currPageFirstList == 0 || this.m_numPagesFirstList == 0)
      this.m_attrEditButtons[0].hide();
    if (this.m_currPageFirstList == this.m_numPagesFirstList - 1 || this.m_numPagesFirstList == 0)
      this.m_attrEditButtons[1].hide();
    if (this.m_currPageSecondList == 0 || this.m_numPagesSecondList == 0)
      this.m_attrEditButtons[2].hide();
    if (this.m_currPageSecondList != this.m_numPagesSecondList - 1 && this.m_numPagesSecondList != 0)
      return;
    this.m_attrEditButtons[3].hide();
  }

  private void setSelectedObjectAttributes()
  {
    if (house.Room.house_cast(this.m_selectedObject) != null)
    {
      house.Room room = house.Room.house_cast(this.m_selectedObject);
      JSystem.println("setting room attributes");
      room.setFloor(this.m_currSelectionFirstList);
      room.setWall(this.m_currSelectionSecondList);
    }
    else if (Door.house_cast(this.m_selectedObject) != null)
      Door.house_cast(this.m_selectedObject).setType(this.getAttributeValueLookupIndex(this.m_currSelectionFirstList, 0));
    else if (HouseObject.house_cast(this.m_selectedObject) != null)
    {
      HouseObject houseObject = HouseObject.house_cast(this.m_selectedObject);
      if (this.m_currentFacingSelectionButtonId == 4)
        houseObject.setFacing(0);
      else if (this.m_currentFacingSelectionButtonId == 5)
        houseObject.setFacing(2);
      else if (this.m_currentFacingSelectionButtonId == 6)
        houseObject.setFacing(1);
      else if (this.m_currentFacingSelectionButtonId == 7)
        houseObject.setFacing(3);
      int valueLookupIndex = this.getAttributeValueLookupIndex(this.m_currSelectionFirstList, 0);
      this.m_prevAddedObjectType = valueLookupIndex;
      houseObject.setType(valueLookupIndex);
    }
    else
    {
      if (Window.house_cast(this.m_selectedObject) == null)
        return;
      Window.house_cast(this.m_selectedObject).setType(this.getAttributeValueLookupIndex(this.m_currSelectionFirstList, 0));
    }
  }

  private int getMainEditButtonId(int screenX, int screenY)
  {
    int length = this.m_mainEditButtons.Length;
    for (int index = 0; index < length; ++index)
    {
      if (this.m_mainEditButtons[index].isPointWithin(screenX, screenY))
        return this.m_mainEditButtons[index].getId();
    }
    return -1;
  }

  private int getAttrEditButtonId(int screenX, int screenY)
  {
    int length = this.m_attrEditButtons.Length;
    for (int index = 0; index < length; ++index)
    {
      if (this.m_attrEditButtons[index].isPointWithin(screenX, screenY))
        return this.m_attrEditButtons[index].getId();
    }
    return -1;
  }

  private void coordScreenToTile(int screenX, int screenY, ref int tileX, ref int tileY)
  {
    tileX = this.m_topLeftTileX + screenX / this.m_tileSize;
    tileY = this.m_topLeftTileY + screenY / this.m_tileSize;
  }

  private void coordTileToScreen(int tileX, int tileY, ref int screenX, ref int screenY)
  {
    screenX = (this.m_tileSize >> 1) + (tileX - this.m_topLeftTileX) * this.m_tileSize;
    screenY = (this.m_tileSize >> 1) + (tileY - this.m_topLeftTileY) * this.m_tileSize;
  }

  private PlaceableObject getObjectAt(int xTile, int yTile)
  {
    return (PlaceableObject) this.m_currentHouse.getHouseObjectAt(this.m_activeTileX, this.m_activeTileY) ?? (PlaceableObject) this.m_currentHouse.getWindowAt(this.m_activeTileX, this.m_activeTileY) ?? (PlaceableObject) this.m_currentHouse.getDoorAt(this.m_activeTileX, this.m_activeTileY) ?? (PlaceableObject) this.m_currentHouse.getRoomAt(this.m_activeTileX, this.m_activeTileY);
  }

  private void writeCurrentHouseToFile()
  {
    JSystem.println("Saving house " + this.m_currentHouse.getName() + ".xml");
    StringBuffer stringBuffer = new StringBuffer();
    stringBuffer.append(this.m_currentHouse.getName()).append(".xml");
    DataOutputStream @out = new DataOutputStream(OutputStream.getResourceAsStream(stringBuffer.toString()));
    this.m_currentHouse.writexml(@out);
    @out.close();
  }

  private House getHouse(int houseId)
  {
    string str = GlobalConstants.LOOKUP_HOUSE[houseId];
    StringBuffer stringBuffer = new StringBuffer();
    stringBuffer.append(str).append(".xml");
    InputStream resourceAsStream = JavaLib.getResourceAsStream(stringBuffer.toString(), false);
    return resourceAsStream != null ? House.fromXMLStream(new DataInputStream(resourceAsStream), str, houseId) : this.m_simWorld.getHouse(houseId);
  }

  private new bool isMapMode()
  {
    return false;
  }

  private new bool isZoomMapMode()
  {
    return false;
  }

  private void loadMap(int houseId)
  {
    this.m_engine.resetRMSGameData();
    MapObject[] objects = this.getObjects();
    int length = objects.Length;
    for (int index = 0; index < length; ++index)
      objects[index].destroy();
    this.m_simWorld.unload();
    this.pointerReset();
    this.m_engine.clearPointerEvents();
    this.m_engine.clearCommandKeys();
    this.m_engine.clearKeysPressedDown();
    this.m_simWorld.setViewport(0, 0, 533, 320);
    this.m_engine.setNextHouseId(houseId);
    this.initHouseMap();
    this.m_simWorld.setCameraPosY(32f);
    this.m_simWorld.setCameraYaw(45f);
    this.m_simWorld.setCameraPitch(45f);
    this.m_simWorld.setCameraDolly(this.isMapMode() ? 1000f : 300f);
    this.m_simWorld.updateCameraPos(0);
    this.stateTransitionCamera(0);
    this.clearCameraFollow();
    this.setCameraLookAt((MapObject) this.getPlayerSim());
    this.snapCameraPosition();
    this.setCameraLookAt((MapObject) null);
    this.setCursorSelectFlags(0);
  }

  public override void processInput(int _event, int[] args)
  {
    base.processInput(_event, args);
    if (this.m_engine.isFading())
      return;
    switch (this.m_editState)
    {
      case 1:
        this.processInputHouseSelect(_event, args);
        break;
      case 2:
        this.processInputMainEdit(_event, args);
        break;
      case 3:
        this.processInputPan(_event, args);
        break;
      case 4:
        this.processInputAttrEdit(_event, args);
        break;
      case 5:
        this.processInputPreview(_event, args);
        break;
    }
  }

  private void processInputHouseSelect(int _event, int[] args)
  {
    this.processInputCameraNavigation(_event, args);
    if (_event != 3)
      return;
    int x = args[1];
    int y = args[2];
    if (this.m_houseSelectButtons[0].isPointWithin(x, y) && this.m_selectedHouseIndex != -1)
    {
      this.editStateTransition(2);
    }
    else
    {
      int houseCount = this.m_simWorld.getHouseCount();
      int num = y / 20;
      if (num >= houseCount)
        return;
      this.m_selectedHouseIndex = num;
    }
  }

  private void processInputPreview(int _event, int[] args)
  {
    this.processInputCameraNavigation(_event, args);
    if (_event != 7)
      return;
    this.editStateTransition(2);
  }

  private void processInputAttrEdit(int _event, int[] args)
  {
    switch (_event)
    {
      case 3:
        int num1 = args[1];
        int num2 = args[2];
        int attrEditButtonId = this.getAttrEditButtonId(num1, num2);
        switch (attrEditButtonId)
        {
          case 0:
            this.changeAttributePage(0, -1);
            JSystem.println("col 1 prev pressed");
            break;
          case 1:
            this.changeAttributePage(0, 1);
            JSystem.println("col 1 next pressed");
            break;
          case 2:
            this.changeAttributePage(1, -1);
            JSystem.println("col 2 prev pressed");
            break;
          case 3:
            this.changeAttributePage(1, 1);
            JSystem.println("col 2 next pressed");
            break;
          case 4:
            JSystem.println("x p facing button pressed");
            this.m_currentFacingSelectionButtonId = attrEditButtonId;
            break;
          case 5:
            JSystem.println("x n facing button pressed");
            this.m_currentFacingSelectionButtonId = attrEditButtonId;
            break;
          case 6:
            JSystem.println("z p facing button pressed");
            this.m_currentFacingSelectionButtonId = attrEditButtonId;
            break;
          case 7:
            JSystem.println("z n facing button pressed");
            this.m_currentFacingSelectionButtonId = attrEditButtonId;
            break;
          case 8:
            int listItemIndex1 = this.getListItemIndex(num1, num2);
            this.processAttributeListSelection(0, listItemIndex1);
            JSystem.println("list 1 tapped, " + (object) listItemIndex1 + " selected");
            break;
          case 9:
            int listItemIndex2 = this.getListItemIndex(num1, num2);
            this.processAttributeListSelection(1, listItemIndex2);
            JSystem.println("list 2 tapped, " + (object) listItemIndex2 + " selected");
            break;
        }
        break;
      case 7:
        this.editStateTransition(2);
        break;
    }
    this.setSelectedObjectAttributes();
  }

  private void processInputMainEdit(int _event, int[] args)
  {
    switch (_event)
    {
      case 0:
        this.coordScreenToTile(args[1], args[2], ref this.m_activeTileX, ref this.m_activeTileY);
        break;
      case 3:
        JSystem.println("  single tap");
        int screenX1 = args[1];
        int screenY1 = args[2];
        this.coordScreenToTile(screenX1, screenY1, ref this.m_activeTileX, ref this.m_activeTileY);
        int mainEditButtonId1 = this.getMainEditButtonId(screenX1, screenY1);
        if (mainEditButtonId1 == 5)
        {
          this.writeCurrentHouseToFile();
          this.editStateTransition(5);
        }
        if (mainEditButtonId1 == 6)
        {
          this.writeCurrentHouseToFile();
          this.m_simWorld.editHouse(this.m_currentHouse.getId(), this.m_currentHouse);
          this.loadMap(this.m_currentHouse.getId());
          this.editStateTransition(5);
          break;
        }
        if (mainEditButtonId1 == 4 && this.m_selectedObject != null)
        {
          JSystem.println("object dropped on the trash button...");
          if (house.Room.house_cast(this.m_selectedObject) != null)
            this.m_currentHouse.deleteRoom((house.Room) this.m_selectedObject);
          else if (Window.house_cast(this.m_selectedObject) != null)
            this.m_currentHouse.deleteWindow((Window) this.m_selectedObject);
          else if (HouseObject.house_cast(this.m_selectedObject) != null)
            this.m_currentHouse.deleteHouseObject((HouseObject) this.m_selectedObject);
          else if (Door.house_cast(this.m_selectedObject) != null)
            this.m_currentHouse.deleteDoor((Door) this.m_selectedObject);
          this.m_selectedObject = (PlaceableObject) null;
          break;
        }
        this.m_selectedObject = this.getObjectAt(this.m_activeTileX, this.m_activeTileY);
        break;
      case 4:
        int screenX2 = args[1];
        int screenY2 = args[2];
        this.m_startDragScreenX = screenX2;
        this.m_startDragScreenY = screenY2;
        this.m_prevActiveTileX = this.m_activeTileX;
        this.m_prevActiveTileY = this.m_activeTileY;
        this.coordScreenToTile(screenX2, screenY2, ref this.m_activeTileX, ref this.m_activeTileY);
        int mainEditButtonId2 = this.getMainEditButtonId(screenX2, screenY2);
        JSystem.println("Drag started in button w id " + (object) mainEditButtonId2);
        if (mainEditButtonId2 != -1 && mainEditButtonId2 != 4 && this.m_currentHouse != null)
        {
          switch (mainEditButtonId2)
          {
            case 0:
              house.Room room1 = new house.Room(this.m_activeTileX, this.m_activeTileY, 2, 2, 0, 0);
              this.m_currentHouse.addRoom(room1);
              this.m_selectedObject = (PlaceableObject) room1;
              break;
            case 1:
              Door door1 = new Door(this.m_activeTileX, this.m_activeTileY, 1, 70);
              this.m_currentHouse.addDoor(door1);
              this.m_selectedObject = (PlaceableObject) door1;
              break;
            case 2:
              Window window1 = new Window(this.m_activeTileX, this.m_activeTileY, 1, 138);
              this.m_currentHouse.addWindow(window1);
              this.m_selectedObject = (PlaceableObject) window1;
              break;
            case 3:
              HouseObject @object = new HouseObject(this.m_activeTileX, this.m_activeTileY, this.m_prevAddedObjectType < 0 ? 82 : this.m_prevAddedObjectType, 1);
              this.m_currentHouse.addHouseObject(@object);
              this.m_selectedObject = (PlaceableObject) @object;
              break;
          }
        }
        if (this.m_selectedObject == null)
          break;
        this.m_selectedObject.setPosition(this.m_selectedObject.getX() + this.m_activeTileX - this.m_prevActiveTileX, this.m_selectedObject.getY() + this.m_activeTileY - this.m_prevActiveTileY);
        break;
      case 5:
        int screenX3 = args[1];
        int screenY3 = args[2];
        this.m_prevActiveTileX = this.m_activeTileX;
        this.m_prevActiveTileY = this.m_activeTileY;
        this.coordScreenToTile(screenX3, screenY3, ref this.m_activeTileX, ref this.m_activeTileY);
        if (this.m_selectedObject == null)
          break;
        this.m_selectedObject.setPosition(this.m_selectedObject.getX() + (this.m_activeTileX - this.m_prevActiveTileX), this.m_selectedObject.getY() + (this.m_activeTileY - this.m_prevActiveTileY));
        break;
      case 6:
        JSystem.println("  single drag end");
        break;
      case 7:
        JSystem.println("  double tap");
        if (this.isDoubleTapHorizontal(args))
        {
          if (this.m_selectedObject == null)
            break;
          this.editStateTransition(4);
          break;
        }
        this.editStateTransition(3);
        break;
      case 9:
        int num1 = args[1];
        int num2 = args[2];
        int num3 = args[3];
        int num4 = args[4];
        int viewportHeight = this.m_simWorld.getViewportHeight();
        bool flag1 = num1 < 40 && num2 > viewportHeight - 40;
        bool flag2 = num1 < 40 && num4 > viewportHeight - 40;
        if ((!flag1 || flag2) && (flag1 || !flag2) || this.m_selectedObject == null)
          break;
        int screenX4 = flag1 ? num3 : num1;
        int screenY4 = flag2 ? num2 : num4;
        this.m_prevActiveTileX = this.m_activeTileX;
        this.m_prevActiveTileY = this.m_activeTileY;
        this.coordScreenToTile(screenX4, screenY4, ref this.m_activeTileX, ref this.m_activeTileY);
        house.Room room2 = house.Room.house_cast(this.m_selectedObject);
        Door door2 = Door.house_cast(this.m_selectedObject);
        Window window2 = Window.house_cast(this.m_selectedObject);
        int num5 = this.m_activeTileX - this.m_prevActiveTileX;
        int num6 = this.m_activeTileY - this.m_prevActiveTileY;
        if (room2 != null)
        {
          room2.setSize(JMath.max(1, room2.getWidth() + num5), JMath.max(1, room2.getHeight() + num6));
          break;
        }
        if (door2 != null)
        {
          door2.setSize(door2.getWidth() + num5, door2.getHeight());
          break;
        }
        window2?.setSize(JMath.min(2, window2.getWidth() + num5), window2.getHeight());
        break;
    }
  }

  private void processInputPan(int _event, int[] args)
  {
    switch (_event)
    {
      case 4:
        int num1 = args[1];
        int num2 = args[2];
        this.m_startDragScreenX = num1;
        this.m_startDragScreenY = num2;
        this.m_startDragTopLeftTileX = this.m_topLeftTileX;
        this.m_startDragTopLeftTileY = this.m_topLeftTileY;
        break;
      case 5:
        int num3 = args[1];
        int num4 = args[2];
        int num5 = (num3 - this.m_startDragScreenX) / this.m_tileSize;
        int num6 = (num4 - this.m_startDragScreenY) / this.m_tileSize;
        this.m_topLeftTileX = this.m_startDragTopLeftTileX - num5;
        this.m_topLeftTileY = this.m_startDragTopLeftTileY - num6;
        break;
      case 7:
        JSystem.println("  double tap");
        this.editStateTransition(2);
        break;
      case 9:
        int num7 = args[5];
        int num8 = args[6];
        int num9 = args[7];
        int num10 = args[8];
        this.m_tileSize = (int) (5.0 + 45.0 * (double) JMath.min(1f, JMath.max(0.0f, JMath.max(150f, JMath.min(400f, MathExt.mag2((float) (num9 - num7), (float) (num10 - num8)))) / 400f)));
        break;
    }
  }
}
