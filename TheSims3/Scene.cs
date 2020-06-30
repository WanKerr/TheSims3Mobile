// Decompiled with JetBrains decompiler
// Type: Scene
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using midp;
using System;
using System.Threading;

public abstract class Scene : Runnable
{
    private Vector m_uiElements = new Vector();
    private int[] m_loadingChevIdx = new int[2];
    private int[] m_loadingChevTime = new int[2];
    private TimeSpan timeSpan0 = new TimeSpan(0L);
    private TimeSpan timeSpanGSC = new TimeSpan(50L);
    public const int SCENE_NONE = 0;
    public const int SCENE_MENU = 1;
    public const int SCENE_GAME = 2;
    public const int SCENE_MOREGAMES = 3;
    public const int SCENE_EDIT = 4;
    public const int KEY_0 = 1;
    public const int KEY_1 = 2;
    public const int KEY_2 = 4;
    public const int KEY_3 = 8;
    public const int KEY_4 = 16;
    public const int KEY_5 = 32;
    public const int KEY_6 = 64;
    public const int KEY_7 = 128;
    public const int KEY_8 = 256;
    public const int KEY_9 = 512;
    public const int KEY_POUND = 1024;
    public const int KEY_STAR = 2048;
    public const int KEY_DPAD_FIRE = 4096;
    public const int KEY_DPAD_UP = 8192;
    public const int KEY_DPAD_DOWN = 16384;
    public const int KEY_DPAD_LEFT = 32768;
    public const int KEY_DPAD_RIGHT = 65536;
    public const int KEY_SOFTL = 131072;
    public const int KEY_SOFTR = 262144;
    public const int KEY_CLR = 524288;
    public const int KEY_FIRE = 4128;
    public const int KEY_UP = 8196;
    public const int KEY_DOWN = 16640;
    public const int KEY_LEFT = 32784;
    public const int KEY_RIGHT = 65600;
    public const int KEY_ARROW = 123220;
    public const int KEY_ANY_UP = 8206;
    public const int KEY_ANY_DOWN = 17280;
    public const int KEY_ANY_LEFT = 32914;
    public const int KEY_ANY_RIGHT = 66120;
    public const int KEY_NUMBER = 1023;
    public const int KEY_TEXT_NUMBER = 1023;
    public const int COMMAND_NONE = 0;
    public const int COMMAND_PAUSE = 1;
    public const int COMMAND_BACK = 2;
    public const int COMMAND_OKAY = 4;
    public const int COMMAND_SELECT = 8;
    public const int COMMAND_CANCEL = 16;
    public const int COMMAND_YES = 32;
    public const int COMMAND_NO = 64;
    public const int COMMAND_CLOSE = 128;
    public const int COMMAND_WORK = 256;
    public const int COMMAND_TOWN = 512;
    public const int COMMAND_HOME = 1024;
    public const int COMMAND_DELETEGAME = 2048;
    public const int COMMAND_CAS_APPEARANCE_BACK = 4096;
    public const int COMMAND_CAS_APPEARANCE_NEXT = 8192;
    public const int COMMAND_WISH = 16384;
    public const int COMMAND_BUILD_CHANGE = 32768;
    public const int COMMAND_BUILD_EDIT = 65536;
    public const int COMMAND_BUILD_BUY = 131072;
    public const int COMMAND_BUILD_UPGRADE = 262144;
    public const int COMMAND_OKAY_ALT = 524288;
    public const int COMMAND_INFO_BACK = 1048576;
    public const int COMMAND_STARTGAME = 2097152;
    public const int COMMAND_EAMTXSTORE = 4194304;
    public const int COMMAND_EXPORT = 8388608;
    public const int COMMAND_EXPORT_SKIPTUTORIAL = 16777216;
    public const int COMMAND_EXPORT_TUTORIAL = 33554432;
    public const int COMMAND_EXPORT_NEXT = 67108864;
    public const int COMMAND_EXPORT_BACK = 134217728;
    public const int COMMAND_IMPORT = 268435456;
    public const int MAX_COMMANDS = 29;
    public const int COMMAND_STRINGID = -2147483648;
    public const int PS_NONE = 0;
    public const int PS_SINGLEPRESSED = 1;
    public const int PS_SINGLETAP = 2;
    public const int PS_SINGLEDRAGGING = 3;
    public const int PS_DOUBLEPRESSED = 4;
    public const int PS_DOUBLETAP = 5;
    public const int PS_DOUBLEDRAGGING = 6;
    public const int TEXT_Y_PADDING = 1;
    public const int UIPARAM_X = 0;
    public const int UIPARAM_Y = 1;
    public const int UIPARAM_WIDTH = 2;
    public const int UIPARAM_HEIGHT = 3;
    public const int UIPARAM_PARAM1 = 4;
    public const int UIPARAM_SIZE = 6;
    public const int SHAREDMENU_NONE = -1;
    public const int SHAREDMENU_OPTIONS = 0;
    public const int SHAREDMENU_INGAME_OPTIONS = 1;
    public const int SHAREDMENU_RESET_CONFIRM = 2;
    public const int SHAREDMENU_HELP = 3;
    public const int SHAREDMENU_HELP_SCREEN = 4;
    public const int SHAREDMENU_ABOUT = 5;
    public const int SHAREDMENU_ABOUT_SPYWAREPROMPT = 6;
    public const int SHAREDMENU_ABOUT_SPYWAREDISABLED = 7;
    public const int SHAREDMENU_INITLANG = 8;
    public const int SHAREDMENU_LANGUAGE = 9;
    public const int SHAREDMENU_CONFIRM_URL = 10;
    public const int MENUFLAG_GENERIC = 0;
    public const int MENUFLAG_BORDER = 1;
    public const int MENUFLAG_CONTEXTLEFT = 2;
    public const int MENUFLAG_CONTEXTRIGHT = 4;
    public const int MENUFLAG_HALF_LEFT = 8;
    public const int MENUFLAG_JUSTITEMS = 16;
    public const int MENUFLAG_MAIN_MENU = 32;
    public const int FIRST_LOADING_MESSAGE = 1489;
    public const int LAST_LOADING_MESSAGE = 1525;
    public const int LOADING_CHEV_MAX_TIME = 1500;
    public const int LOADING_CHEV_SPLIT_TIME = 400;
    public const float TAPPER_REALSIZE = 8388608f;
    public const int TAPPER_STARTSIZE = 2097152;
    public const int TAPPER_ENDSIZE = 8388608;
    public const float LOADING_BAR_FILL_SPEED = 20f;
    public const float LOADING_BAR_FILL_SPEED_CAS = 40f;
    protected AppEngine m_engine;
    protected SimData m_simData;
    protected SimWorld m_simWorld;
    public int[] m_tempInt4;
    private UIElement m_inputUIElement;
    private UIButton[] m_uiButtons;
    private UIList[] m_uiLists;
    private int m_pointerState;
    private int m_pointerStatePrev;
    private int m_pointerStateTimer;
    private int m_pointerFirst;
    private int m_pointerSecond;
    private int m_pointerFirstStartX;
    private int m_pointerFirstStartY;
    private int m_pointerFirstCurX;
    private int m_pointerFirstCurY;
    private int m_pointerSecondStartX;
    private int m_pointerSecondStartY;
    private int m_pointerSecondCurX;
    private int m_pointerSecondCurY;
    private int m_uiTextScreenMaxLines;
    private int m_uiWrappedLineHeight;
    private int m_uiMessageBoxWidth;
    private int m_uiMessageBoxWrapWidth;
    private int m_uiInfoBoxWrapWidth;
    private int m_uiTextHeight;
    private int[] m_uiParams;
    private int[] m_uiStrings;
    private int m_sharedMenuState;
    private int[] m_optionsMenu;
    private int[] m_inGameOptionsMenu;
    private int[] m_helpMenu;
    private int[] m_aboutMenu;
    private int[] m_sharedMenu;
    private int m_sharedMenuBackState;
    private UIOptionMenu m_optionMenu;
    protected UIMessageBox m_messageBox;
    private int m_sharedMenuURL;
    private WebView m_webViewRef;
    private int m_tapperX;
    private int m_tapperY;
    private int m_tapperZ;
    private int m_tapperSize;
    private bool m_tapperWorldSpace;
    protected XNAMenu m_achievementsMenu;
    protected XNAMenu m_leaderboardsMenu;
    protected XNAMenu m_achievementDetailMenu;
    protected XNAMenuRes m_xnaMenuRes;
    protected XNAConnect m_xnaConnect;
    private int m_loadingString;
    private int m_loadingStringPosXF;
    private int m_loadingStringWidth;
    private float m_loadingPercentGoal;
    private float m_loadingPercent;
    private System.Threading.Thread threadGSC;

    public UIElement getActiveUIElement()
    {
        return this.m_inputUIElement;
    }

    public int getPointerState()
    {
        return this.m_pointerState;
    }

    private int getPointerStateTimer()
    {
        return this.m_pointerStateTimer;
    }

    public bool isLoadbarFull()
    {
        return (double)this.m_loadingPercent >= 100.0;
    }

    public Scene(AppEngine ae)
    {
        this.m_engine = ae;
        this.m_simData = ae.getSimData();
        this.m_simWorld = ae.getSimWorld();
        this.m_uiTextScreenMaxLines = 0;
        this.m_uiWrappedLineHeight = 0;
        this.m_uiMessageBoxWidth = 0;
        this.m_uiMessageBoxWrapWidth = 0;
        this.m_uiInfoBoxWrapWidth = 0;
        this.m_uiTextHeight = 0;
        this.m_sharedMenuState = 0;
        this.m_optionsMenu = (int[])null;
        this.m_inGameOptionsMenu = (int[])null;
        this.m_helpMenu = (int[])null;
        this.m_aboutMenu = (int[])null;
        this.m_sharedMenu = (int[])null;
        this.m_sharedMenuBackState = 0;
        this.m_sharedMenuURL = -1;
        this.m_tempInt4 = new int[4];
        this.m_uiElements = new Vector();
        this.m_uiButtons = new UIButton[29];
        this.m_uiLists = new UIList[14];
        this.m_pointerState = 0;
        this.m_pointerStatePrev = 0;
        this.m_pointerStateTimer = 0;
        this.m_pointerFirst = -1;
        this.m_pointerSecond = -1;
        this.m_pointerFirstStartX = 0;
        this.m_pointerFirstStartY = 0;
        this.m_pointerFirstCurX = 0;
        this.m_pointerFirstCurY = 0;
        this.m_pointerSecondStartX = 0;
        this.m_pointerSecondStartY = 0;
        this.m_pointerSecondCurX = 0;
        this.m_pointerSecondCurY = 0;
        this.m_uiParams = new int[6];
        this.m_uiStrings = new int[11];
        this.m_tapperX = 0;
        this.m_tapperY = 0;
        this.m_tapperZ = 0;
        this.m_tapperSize = 0;
        this.m_tapperWorldSpace = false;
        this.m_loadingString = -1;
        this.m_loadingStringPosXF = 0;
        this.m_loadingStringWidth = 0;
        this.m_loadingPercentGoal = 0.0f;
        this.m_loadingPercent = 0.0f;
        for (int index = 0; index < 29; ++index)
        {
            this.m_uiButtons[index] = new UIButton(1 << index);
            this.m_uiElements.addElement((object)this.m_uiButtons[index]);
        }
        for (int listId = 0; listId < 14; ++listId)
        {
            this.m_uiLists[listId] = new UIList(listId);
            this.m_uiElements.addElement((object)this.m_uiLists[listId]);
        }
        this.m_optionMenu = new UIOptionMenu();
        this.addUIElement((UIElement)this.m_optionMenu);
        this.m_messageBox = new UIMessageBox();
        this.addUIElement((UIElement)this.m_messageBox);
        this.m_loadingChevIdx[0] = 1;
        this.m_loadingChevTime[0] = 0;
        this.m_loadingChevIdx[1] = 0;
        this.m_loadingChevTime[1] = 750;
    }

    protected void initXNAMenus()
    {
        this.m_xnaMenuRes = new XNAMenuRes();
        this.m_xnaMenuRes.load();
        this.m_xnaConnect = new XNAConnect();
        this.m_achievementsMenu = (XNAMenu)new AchievementsMenu(this.m_engine, this.m_xnaMenuRes, this, this.m_xnaConnect);
        this.m_achievementDetailMenu = (XNAMenu)new AchievementDetailMenu(this.m_engine, this.m_xnaMenuRes, (AchievementsMenu)this.m_achievementsMenu, this, this.m_xnaConnect);
        this.m_leaderboardsMenu = (XNAMenu)new LeaderboardsMenu(this.m_engine, this.m_xnaMenuRes, this, this.m_xnaConnect);
    }

    public virtual void processInput(int _event, int[] args)
    {
        this.processInputEvents(_event, args);
    }

    public void processInputEvents(int _event, int[] args)
    {
        if (this.m_inputUIElement != null)
        {
            this.m_inputUIElement.processInput(_event, args);
        }
        else
        {
            int num = this.m_uiElements.size();
            for (int index = 0; index < num && this.m_inputUIElement == null; ++index)
            {
                UIElement uiElement = (UIElement)this.m_uiElements.elementAt(index);
                if (uiElement.getFlag(1))
                    uiElement.processInput(_event, args);
            }
        }
        if (_event != 0 && _event != 1 && _event != 2)
            return;
        this.processPointerEvents(_event, args);
    }

    public void processPointerEvents(int _event, int[] args)
    {
        int num1 = args[0];
        int num2 = args[1];
        int num3 = args[2];
        switch (this.m_pointerState)
        {
            case 0:
                if (_event != 0)
                    break;
                this.m_pointerFirst = num1;
                this.m_pointerFirstStartX = num2;
                this.m_pointerFirstStartY = num3;
                this.m_pointerFirstCurX = num2;
                this.m_pointerFirstCurY = num3;
                this.pointerStateTransition(1);
                break;
            case 1:
                switch (_event)
                {
                    case 0:
                        if (num1 == this.m_pointerFirst)
                        {
                            this.m_pointerFirst = -1;
                            this.m_pointerSecond = -1;
                            this.pointerStateTransition(0);
                            return;
                        }
                        this.m_pointerSecond = num1;
                        this.m_pointerSecondStartX = num2;
                        this.m_pointerSecondStartY = num3;
                        this.m_pointerSecondCurX = num2;
                        this.m_pointerSecondCurY = num3;
                        this.pointerStateTransition(4);
                        return;
                    case 1:
                        if (num1 != this.m_pointerFirst)
                            return;
                        this.m_pointerFirstCurX = num2;
                        this.m_pointerFirstCurY = num3;
                        int num4 = this.m_pointerFirstStartX - this.m_pointerFirstCurX;
                        int num5 = this.m_pointerFirstStartY - this.m_pointerFirstCurY;
                        if (MathExt.Fsqrt(num4 * num4 + num5 * num5 << 16) >> 16 <= 10)
                            return;
                        this.m_pointerFirstStartX = this.m_pointerFirstCurX;
                        this.m_pointerFirstStartY = this.m_pointerFirstCurY;
                        this.pointerStateTransition(3);
                        return;
                    case 2:
                        if (num1 != this.m_pointerFirst)
                            return;
                        if (this.m_pointerStatePrev == 4 && this.m_pointerStateTimer < 500)
                        {
                            this.pointerStateTransition(5);
                            return;
                        }
                        this.pointerStateTransition(2);
                        return;
                    default:
                        return;
                }
            case 3:
                switch (_event)
                {
                    case 0:
                        if (num1 == this.m_pointerFirst)
                        {
                            this.m_pointerFirst = -1;
                            this.m_pointerSecond = -1;
                            this.pointerStateTransition(0);
                            return;
                        }
                        this.m_pointerSecond = num1;
                        this.m_pointerSecondStartX = num2;
                        this.m_pointerSecondStartY = num3;
                        this.m_pointerSecondCurX = num2;
                        this.m_pointerSecondCurY = num3;
                        this.pointerStateTransition(6);
                        return;
                    case 1:
                        if (num1 != this.m_pointerFirst)
                            return;
                        this.m_pointerFirstCurX = num2;
                        this.m_pointerFirstCurY = num3;
                        return;
                    case 2:
                        if (num1 != this.m_pointerFirst)
                            return;
                        this.pointerStateTransition(0);
                        return;
                    default:
                        return;
                }
            case 4:
                switch (_event)
                {
                    case 0:
                        return;
                    case 1:
                        if (num1 == this.m_pointerFirst)
                        {
                            this.m_pointerFirstCurX = num2;
                            this.m_pointerFirstCurY = num3;
                            int num6 = this.m_pointerFirstStartX - this.m_pointerFirstCurX;
                            int num7 = this.m_pointerFirstStartY - this.m_pointerFirstCurY;
                            if (MathExt.Fsqrt(num6 * num6 + num7 * num7 << 16) >> 16 <= 10)
                                return;
                            this.m_pointerFirstStartX = this.m_pointerFirstCurX;
                            this.m_pointerFirstStartY = this.m_pointerFirstCurY;
                            this.m_pointerSecondStartX = this.m_pointerSecondCurX;
                            this.m_pointerSecondStartY = this.m_pointerSecondCurY;
                            this.pointerStateTransition(6);
                            return;
                        }
                        if (num1 != this.m_pointerSecond)
                            return;
                        this.m_pointerSecondCurX = num2;
                        this.m_pointerSecondCurY = num3;
                        int num8 = this.m_pointerSecondStartX - this.m_pointerSecondCurX;
                        int num9 = this.m_pointerSecondStartY - this.m_pointerSecondCurY;
                        if (MathExt.Fsqrt(num8 * num8 + num9 * num9 << 16) >> 16 <= 10)
                            return;
                        this.m_pointerFirstStartX = this.m_pointerFirstCurX;
                        this.m_pointerFirstStartY = this.m_pointerFirstCurY;
                        this.m_pointerSecondStartX = this.m_pointerSecondCurX;
                        this.m_pointerSecondStartY = this.m_pointerSecondCurY;
                        this.pointerStateTransition(6);
                        return;
                    case 2:
                        if (num1 == this.m_pointerFirst)
                        {
                            this.m_pointerFirst = this.m_pointerSecond;
                            int pointerFirstStartX = this.m_pointerFirstStartX;
                            this.m_pointerFirstStartX = this.m_pointerSecondStartX;
                            this.m_pointerSecondStartX = pointerFirstStartX;
                            int pointerFirstStartY = this.m_pointerFirstStartY;
                            this.m_pointerFirstStartY = this.m_pointerSecondStartY;
                            this.m_pointerSecondStartY = pointerFirstStartY;
                            int pointerFirstCurX = this.m_pointerFirstCurX;
                            this.m_pointerFirstCurX = this.m_pointerSecondCurX;
                            this.m_pointerSecondCurX = pointerFirstCurX;
                            int pointerFirstCurY = this.m_pointerFirstCurY;
                            this.m_pointerFirstCurY = this.m_pointerSecondCurY;
                            this.m_pointerSecondCurY = pointerFirstCurY;
                            this.m_pointerSecond = -1;
                            this.pointerStateTransition(1);
                            return;
                        }
                        if (num1 != this.m_pointerSecond)
                            return;
                        this.m_pointerSecond = -1;
                        this.pointerStateTransition(1);
                        return;
                    default:
                        return;
                }
            case 6:
                switch (_event)
                {
                    case 0:
                        return;
                    case 1:
                        if (num1 == this.m_pointerFirst)
                        {
                            this.m_pointerFirstCurX = num2;
                            this.m_pointerFirstCurY = num3;
                            return;
                        }
                        if (num1 != this.m_pointerSecond)
                            return;
                        this.m_pointerSecondCurX = num2;
                        this.m_pointerSecondCurY = num3;
                        return;
                    case 2:
                        if (num1 == this.m_pointerFirst)
                        {
                            this.m_pointerFirst = this.m_pointerSecond;
                            this.m_pointerFirstStartX = this.m_pointerSecondStartX;
                            this.m_pointerFirstStartY = this.m_pointerSecondStartY;
                            this.m_pointerFirstCurX = this.m_pointerSecondCurX;
                            this.m_pointerFirstCurY = this.m_pointerSecondCurY;
                            this.m_pointerSecond = -1;
                            this.pointerStateTransition(3);
                            return;
                        }
                        if (num1 != this.m_pointerSecond)
                            return;
                        this.m_pointerSecond = -1;
                        this.pointerStateTransition(3);
                        return;
                    default:
                        return;
                }
        }
    }

    public void processInputSharedMenu(int _event, int[] args)
    {
        AppEngine engine = this.m_engine;
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Scene.checkCommand(_event, args, 6))
        {
            this.stateTransitionSharedMenu(this.m_sharedMenuBackState);
        }
        else
        {
            switch (this.m_sharedMenuState)
            {
                case 0:
                case 1:
                case 3:
                case 5:
                    if (!Scene.checkCommand(_event, args, int.MinValue))
                        break;
                    this.processSharedMenuItem(args[2]);
                    break;
                case 2:
                    if (Scene.checkCommand(_event, args, 32))
                    {
                        SpywareManager.getInstance().trackResetData();
                        engine.resetSimSaveData();
                        engine.resetGlobalGoals();
                        engine.saveRMSAppSettings();
                        engine.resetRMSGameData();
                        engine.saveRMSGameData();
                        this.stateTransitionSharedMenu(this.m_sharedMenuBackState);
                        break;
                    }
                    if (!Scene.checkCommand(_event, args, 64))
                        break;
                    this.stateTransitionSharedMenu(this.m_sharedMenuBackState);
                    break;
                case 6:
                    if (Scene.checkCommand(_event, args, 32))
                    {
                        this.m_engine.setRMSOptionState(88, 0);
                        this.stateTransitionSharedMenu(7);
                        break;
                    }
                    if (!Scene.checkCommand(_event, args, 64))
                        break;
                    this.stateTransitionSharedMenu(5);
                    break;
                case 10:
                    if (Scene.checkCommand(_event, args, 32))
                    {
                        WebView.launchBrowser(engine.getTextManager().getString(this.m_sharedMenuURL));
                        break;
                    }
                    if (!Scene.checkCommand(_event, args, 64))
                        break;
                    this.stateTransitionSharedMenu(this.m_sharedMenuBackState);
                    break;
            }
        }
    }

    public static bool checkCommand(int _event, int[] args, int checkCommandMask)
    {
        return _event == 11 && (args[0] & checkCommandMask) != 0;
    }

    public override void Dispose()
    {
        this.m_uiElements.removeAllElements();
    }

    public virtual void update(int timeStep)
    {
        this.updateInputEvents(timeStep);
        this.updateTapper(timeStep);
        if (this.m_simData != null)
            this.m_simData.totalAppRunTime = this.m_simData.totalAppRunTime.Add(new TimeSpan(0, 0, 0, 0, timeStep));
        if (this.threadGSC != null || XNAConnect.getGamer() == null)
            return;
        this.threadGSC = new System.Threading.Thread(new ThreadStart(this.updateGSC));
        this.threadGSC.Start();
    }

    private void updateGSC()
    {
    }

    public void startUI()
    {
        int num = this.m_uiElements.size();
        for (int index = 0; index < num; ++index)
            ((UIElement)this.m_uiElements.elementAt(index)).clear();
    }

    public void endUI()
    {
        if (this.m_inputUIElement == null || this.m_inputUIElement.getFlag(1))
            return;
        this.m_inputUIElement.onLostInput();
        this.m_inputUIElement = (UIElement)null;
    }

    public UIButton getUIButton(int commandId)
    {
        return this.m_uiButtons[this.commandToIndex(commandId)];
    }

    public UIList getUIList(int listId)
    {
        return this.m_uiLists[listId];
    }

    public int getUIListItemAt(int listId, int xScreen, int yScreen)
    {
        return this.m_uiLists[listId].getItemAt(xScreen, yScreen);
    }

    public void activateUIElement(UIElement element)
    {
        if (this.m_inputUIElement != null)
            return;
        this.m_inputUIElement = element;
    }

    public void deactivateUIElement(UIElement element)
    {
        if (this.m_inputUIElement != element)
            return;
        this.m_inputUIElement = (UIElement)null;
    }

    public void addUIElement(UIElement element)
    {
        this.m_uiElements.addElement((object)element);
    }

    public void removeUIElement(UIElement element)
    {
        this.m_uiElements.removeElement((object)element);
    }

    public void pointerReset()
    {
        this.m_pointerState = 0;
        this.m_pointerStatePrev = 0;
        this.m_pointerStateTimer = 0;
        this.m_pointerFirst = -1;
        this.m_pointerSecond = -1;
        this.m_engine.clearPointerEvents();
    }

    public void pointerStateTransition(int newState)
    {
        this.m_pointerStatePrev = this.m_pointerState;
        this.m_pointerState = newState;
        this.m_pointerStateTimer = 0;
        switch (this.m_pointerStatePrev)
        {
            case 3:
                int[] args1 = new int[10];
                args1[1] = this.m_pointerFirstCurX;
                args1[2] = this.m_pointerFirstCurY;
                this.processInput(6, args1);
                break;
            case 6:
                int[] args2 = new int[10];
                args2[1] = this.m_pointerFirstCurX;
                args2[2] = this.m_pointerFirstCurY;
                args2[1] = this.m_pointerSecondCurX;
                args2[2] = this.m_pointerSecondCurY;
                this.processInput(10, args2);
                break;
        }
        switch (newState)
        {
            case 2:
                int[] args3 = new int[10];
                args3[1] = this.m_pointerFirstCurX;
                args3[2] = this.m_pointerFirstCurY;
                this.processInput(3, args3);
                this.pointerStateTransition(0);
                this.m_engine.clearPointerEvents();
                break;
            case 3:
                int[] args4 = new int[10];
                args4[1] = this.m_pointerFirstCurX;
                args4[2] = this.m_pointerFirstCurY;
                this.processInput(4, args4);
                break;
            case 5:
                int[] args5 = new int[10];
                args5[1] = this.m_pointerFirstCurX;
                args5[2] = this.m_pointerFirstCurY;
                args5[3] = this.m_pointerSecondCurX;
                args5[4] = this.m_pointerSecondCurY;
                this.processInput(7, args5);
                this.pointerStateTransition(0);
                this.m_engine.clearPointerEvents();
                break;
            case 6:
                int[] args6 = new int[10];
                args6[1] = this.m_pointerFirstCurX;
                args6[2] = this.m_pointerFirstCurY;
                args6[3] = this.m_pointerSecondCurX;
                args6[4] = this.m_pointerSecondCurY;
                this.processInput(8, args6);
                break;
        }
    }

    public void updateInputEvents(int timeStep)
    {
        this.m_pointerStateTimer = midp.JMath.min(this.m_pointerStateTimer + timeStep, 3600000);
        switch (this.m_pointerState)
        {
            case 1:
                if (this.m_pointerStateTimer > 500)
                {
                    this.pointerStateTransition(3);
                    break;
                }
                break;
            case 3:
                this.processInput(5, new int[10]
                {
          0,
          this.m_pointerFirstStartX,
          this.m_pointerFirstStartY,
          0,
          0,
          this.m_pointerFirstCurX,
          this.m_pointerFirstCurY,
          0,
          0,
          timeStep
                });
                this.m_pointerFirstStartX = this.m_pointerFirstCurX;
                this.m_pointerFirstStartY = this.m_pointerFirstCurY;
                break;
            case 4:
                if (this.m_pointerStateTimer > 500)
                {
                    this.m_pointerFirstStartX = this.m_pointerFirstCurX;
                    this.m_pointerFirstStartY = this.m_pointerFirstCurY;
                    this.m_pointerSecondStartX = this.m_pointerSecondCurX;
                    this.m_pointerSecondStartY = this.m_pointerSecondCurY;
                    this.pointerStateTransition(6);
                    break;
                }
                break;
            case 6:
                int[] args = new int[10];
                args[1] = this.m_pointerFirstStartX;
                args[2] = this.m_pointerFirstStartY;
                args[5] = this.m_pointerFirstCurX;
                args[6] = this.m_pointerFirstCurY;
                args[3] = this.m_pointerSecondStartX;
                args[4] = this.m_pointerSecondStartY;
                args[7] = this.m_pointerSecondCurX;
                args[8] = this.m_pointerSecondCurY;
                args[9] = timeStep;
                this.processInput(9, args);
                this.m_pointerFirstStartX = this.m_pointerFirstCurX;
                this.m_pointerFirstStartY = this.m_pointerFirstCurY;
                this.m_pointerSecondStartX = this.m_pointerSecondCurX;
                this.m_pointerSecondStartY = this.m_pointerSecondCurY;
                break;
        }
        int num = this.m_uiElements.size();
        for (int index = 0; index < num; ++index)
        {
            UIElement uiElement = (UIElement)this.m_uiElements.elementAt(index);
            if (uiElement.getFlag(1))
                uiElement.update(timeStep);
        }
    }

    public void processCommand(int commandId)
    {
        int[] args = new int[3] { 0, 0, 0 };
        args[0] = commandId;
        args[2] = -1;
        this.processInput(11, args);
    }

    public void processStringId(int stringId)
    {
        int[] args = new int[3] { 0, 0, 0 };
        args[0] = int.MinValue;
        args[2] = stringId;
        this.processInput(11, args);
    }

    public void drawUIFullScreen(Graphics g, int uiPanelId)
    {
        AppEngine engine = this.m_engine;
        this.drawUI(g, uiPanelId, 0, 0, engine.getWidth(), engine.getHeight() - 15);
    }

    public void drawUIFullScreen(Graphics g, int uiPanelId, int topOffset)
    {
        AppEngine engine = this.m_engine;
        this.drawUI(g, uiPanelId, 0, topOffset, engine.getWidth(), engine.getHeight() - 15 - topOffset);
    }

    public int getUIPanelHeight(int uiPanelId, int width, int maxHeight)
    {
        short[] uiPanel = this.m_engine.getUIPanel(uiPanelId);
        if (this.getUIPanelStretchWeight(uiPanel) != 0)
            return maxHeight;
        int[] uiParams = this.m_uiParams;
        uiParams[0] = 0;
        uiParams[1] = 0;
        uiParams[2] = width;
        uiParams[3] = 0;
        this.drawSubUI((Graphics)null, uiPanel, uiParams);
        return uiParams[3];
    }

    public void drawUIPanel(Graphics g, int uiPanelId, int x, int y, int width, int height)
    {
        this.drawUI(g, uiPanelId, x, y, width, height);
    }

    public void initUI()
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        this.initSharedMenus();
        this.m_uiWrappedLineHeight = textManager.getLineHeight(3);
        this.m_uiMessageBoxWidth = engine.getWidth() * 7 / 10;
        this.m_uiMessageBoxWrapWidth = this.m_uiMessageBoxWidth * 4 / 5;
        this.m_uiInfoBoxWrapWidth = engine.getWidth() * 4 / 5;
        this.m_uiTextHeight = textManager.getLineHeight(3) + 2;
    }

    public void setUIPlaceholderString(int index, int value)
    {
        this.m_uiStrings[index] = value;
    }

    public void drawUI(Graphics g, int uiPanelId, int x, int y, int w, int h)
    {
        this.drawUI(g, this.getUIPanel(uiPanelId), x, y, w, h);
    }

    public void drawUI(Graphics g, short[] elements, int x, int y, int w, int h)
    {
        int[] uiParams = this.m_uiParams;
        uiParams[0] = x;
        uiParams[1] = y;
        uiParams[2] = w;
        uiParams[3] = 0;
        this.drawSubUI((Graphics)null, elements, uiParams);
        uiParams[0] = x;
        uiParams[2] = w;
        int num = uiParams[3];
        if (this.getUIPanelStretchWeight(elements) != 0)
        {
            uiParams[1] = y;
            uiParams[3] = h - num;
        }
        else
        {
            uiParams[1] = y + (h - num >> 1);
            uiParams[3] = num;
        }
        this.drawSubUI(g, elements, uiParams);
    }

    public void drawSubUI(Graphics g, short[] elements, int[] @params)
    {
        int num1 = @params[0];
        int num2 = @params[1];
        int num3 = @params[2];
        int num4 = @params[3];
        int num5 = 0;
        int num6 = 0;
        for (int index = 0; index < elements.Length; index += 2)
        {
            int element1 = (int)elements[index];
            int element2 = (int)elements[index + 1];
            @params[4] = element2;
            this.drawUIElement((Graphics)null, element1, @params);
            int num7 = @params[3];
            num6 += this.getUIElementStretchWeight(element1, element2);
            num5 += num7;
        }
        if (g != null)
        {
            int num7 = num4;
            if (num6 > 0)
                num7 += num5;
            @params[0] = num1;
            @params[1] = num2;
            @params[2] = num3;
            int num8 = 0;
            for (int index = 0; index < elements.Length; index += 2)
            {
                int element1 = (int)elements[index];
                int element2 = (int)elements[index + 1];
                @params[4] = element2;
                int elementStretchWeight = this.getUIElementStretchWeight(element1, element2);
                if (elementStretchWeight != 0)
                {
                    AppEngine.ASSERT(num6 > 0, "unexpected stretchable found");
                    int num9 = num4 * elementStretchWeight / num6;
                    @params[3] = num9;
                    this.drawUIElement(g, element1, @params);
                }
                else
                {
                    @params[3] = num7 - num8;
                    this.drawUIElement(g, element1, @params);
                }
                num8 += @params[3];
            }
        }
        if (g == null)
            @params[3] = num5;
        else
            @params[3] = num4 + num5;
    }

    public int getUIElementStretchWeight(int element, int param)
    {
        int num = 0;
        switch (element)
        {
            case 13:
                return param;
            case 18:
                num = 1;
                break;
            case 19:
                num = this.getUIPanelStretchWeight(this.getUIPanel(param));
                break;
        }
        return num;
    }

    public int getUIPanelStretchWeight(short[] subElements)
    {
        int num = 0;
        for (int index = 0; index < subElements.Length; index += 2)
        {
            int subElement1 = (int)subElements[index];
            int subElement2 = (int)subElements[index + 1];
            num += this.getUIElementStretchWeight(subElement1, subElement2);
        }
        return num;
    }

    public void drawUIElement(Graphics g, int element, int[] @params)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        int x1 = @params[0];
        int y1 = @params[1];
        int w = @params[2];
        int h1 = @params[3];
        int num1 = @params[4];
        int h2 = 0;
        switch (element)
        {
            case 0:
                if (g != null)
                {
                    g.Begin();
                    g.setColor(0);
                    g.drawRect((float)x1, (float)y1, (float)w, (float)h1);
                    g.End();
                    break;
                }
                break;
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                if (g != null)
                {
                    string uiString = this.getUIString(num1);
                    if (uiString != null)
                    {
                        int x2 = x1;
                        int y2 = y1 + 1;
                        int anchor = 9;
                        if (element == 2 || element == 5)
                        {
                            x2 += w;
                            anchor = 33;
                        }
                        else if (element == 3 || element == 6)
                        {
                            x2 += w >> 1;
                            anchor = 17;
                        }
                        int font = element == 4 || element == 5 || element == 6 ? 3 : 3;
                        g.Begin();
                        textManager.drawString(g, uiString, font, x2, y2, anchor);
                        g.End();
                        break;
                    }
                    break;
                }
                break;
            case 7:
                h2 = this.m_uiTextHeight;
                y1 += h2;
                break;
            case 8:
            case 9:
                h2 = midp.JMath.max(num1, textManager.getNumWrappedLines()) * this.m_uiWrappedLineHeight;
                if (g != null)
                {
                    if (element == 9)
                        h2 = h1;
                    g.Begin();
                    textManager.drawWrappedString(g, 3, x1 + (w >> 1), y1 + (h2 >> 1), 18);
                    g.End();
                }
                y1 += h2;
                break;
            case 10:
            case 11:
            case 12:
                h2 = 12;
                if (g != null)
                {
                    AnimationManager2D animationManager2D = engine.getAnimationManager2D();
                    float scaleX = (float)w / animationManager2D.getAnimWidth((int)sbyte.MaxValue);
                    float scaleY = element == 12 ? -1f : 1f;
                    int animId = element == 10 ? 126 : (int)sbyte.MaxValue;
                    animationManager2D.submitAnim(animId, (float)(x1 + (w >> 1)), (float)(y1 + (h2 >> 1)), 1f, scaleX, scaleY);
                    animationManager2D.flushAnims(g);
                }
                y1 += 12;
                break;
            case 13:
                if (g != null)
                {
                    h2 = h1;
                    y1 += h2;
                    break;
                }
                break;
            case 14:
                int num2 = num1;
                x1 += num2;
                w -= num2 << 1;
                y1 += num2;
                h2 = num2 << 1;
                break;
            case 15:
                int num3 = num1;
                x1 += num3;
                w -= num3 << 1;
                break;
            case 16:
                int num4 = num1;
                y1 += num4;
                h2 = num4 << 1;
                break;
            case 17:
                h2 = num1;
                y1 += h2;
                break;
            case 18:
                if (g != null)
                {
                    this.drawUIList(g, x1, y1, w, h1, num1);
                    h2 = h1;
                    y1 += h2;
                    break;
                }
                break;
            case 19:
                short[] uiPanel = this.getUIPanel(num1);
                this.drawSubUI(g, uiPanel, @params);
                h2 = @params[3];
                y1 += h2;
                break;
            case 20:
                h2 = ((SceneGame)this).drawUICurrentDream(g, x1, y1, w, h2);
                y1 += h2;
                break;
            case 21:
                h2 = ((SceneGame)this).drawUIGetItem(g, x1, y1, w, h2);
                y1 += h2;
                break;
            default:
                AppEngine.ASSERT(false, "invalid ui element");
                break;
        }
        @params[0] = x1;
        @params[1] = y1;
        @params[2] = w;
        @params[3] = h2;
    }

    public string getUIString(int stringId)
    {
        TextManager textManager = this.m_engine.getTextManager();
        if (stringId >= -12)
            return textManager.getString(stringId);
        AppEngine.ASSERT(stringId >= -23, "invalid string id");
        stringId = this.getUIPlaceholderStringId(stringId);
        return stringId != 8 ? textManager.getString(stringId) : (string)null;
    }

    public int getUIPlaceholderStringId(int stringId)
    {
        return this.m_uiStrings[-13 - stringId];
    }

    public short[] getUIPanel(int panelId)
    {
        return this.m_engine.getUIPanel(panelId);
    }

    public void drawUIList(Graphics g, int x, int y, int w, int h, int id)
    {
        if (g == null)
            return;
        this.getUIList(id).setup(x, y, w, h);
        this.getUIList(id).render(g);
    }

    public void initSharedMenus()
    {
        int[] numArray = new int[5 + 5];
        AppEngine.menuClear(numArray, 49);
        AppEngine.menuAppendItem(numArray, 67);
        AppEngine.menuAppendItem(numArray, 68);
        AppEngine.menuAppendItem(numArray, 70);
        AppEngine.menuAppendItem(numArray, 71);
        this.m_inGameOptionsMenu = new int[numArray[0] + 5];
        AppEngine.menuCopy(this.m_inGameOptionsMenu, numArray);
        AppEngine.menuAppendItem(numArray, 74);
        this.m_optionsMenu = numArray;
        int[] menu1 = new int[12];
        AppEngine.menuClear(menu1, 50);
        AppEngine.menuAppendItem(menu1, 51);
        AppEngine.menuAppendItem(menu1, 91);
        AppEngine.menuAppendItem(menu1, 98);
        AppEngine.menuAppendItem(menu1, 100);
        AppEngine.menuAppendItem(menu1, 102);
        AppEngine.menuAppendItem(menu1, 111);
        this.m_helpMenu = menu1;
        int[] menu2 = new int[10];
        this.m_aboutMenu = menu2;
        AppEngine.menuClear(menu2, 51);
        AppEngine.menuAppendItem(menu2, 51);
        AppEngine.menuAppendItem(menu2, 82);
        AppEngine.menuAppendItem(menu2, 84);
        AppEngine.menuAppendItem(menu2, 86);
        this.m_sharedMenuState = -1;
    }

    public int getSharedMenuState()
    {
        return this.m_sharedMenuState;
    }

    public void stateTransitionSharedMenu(int state)
    {
        int[] items = (int[])null;
        int num = -1;
        switch (state)
        {
            case 0:
                items = this.m_optionsMenu;
                this.m_optionMenu.setItems(ref items);
                break;
            case 1:
                items = this.m_inGameOptionsMenu;
                this.m_optionMenu.setItems(ref items);
                break;
            case 2:
                num = 0;
                this.prepareConfirmBox(75, 74);
                break;
            case 3:
                items = this.m_helpMenu;
                this.m_optionMenu.setItems(ref items);
                break;
            case 4:
                num = 3;
                if (this.m_sharedMenuState == 5)
                {
                    num = 5;
                    break;
                }
                break;
            case 5:
                num = 3;
                items = this.m_aboutMenu;
                if (this.m_sharedMenuState != 6 && this.m_sharedMenuState != 7)
                {
                    this.m_optionMenu.setItems(ref items);
                    break;
                }
                break;
            case 6:
                num = 5;
                this.prepareConfirmBox(89, 88);
                break;
            case 7:
                num = 5;
                this.prepareMessageBox(90, 88);
                break;
            case 10:
                num = 5;
                this.prepareConfirmBox(81, 80);
                break;
        }
        if (this.m_sharedMenuState == -1 && items != null)
            items[2] = 0;
        this.m_sharedMenu = items;
        this.m_sharedMenuBackState = num;
        this.m_sharedMenuState = state;
        this.pointerReset();
        this.m_engine.clearKeysPressedDown();
        this.m_engine.clearCommandKeys();
    }

    public void renderSharedMenu(Graphics g)
    {
        switch (this.m_sharedMenuState)
        {
            case -1:
                AppEngine.ASSERT(false, "no shared menu");
                break;
            case 0:
            case 1:
            case 3:
            case 5:
                this.m_optionMenu.render(g);
                break;
            case 2:
            case 4:
            case 6:
            case 7:
            case 10:
                this.drawGenericMessageBox(g);
                break;
        }
    }

    public void updateSharedMenu(int timeStep)
    {
    }

    public void processSharedMenuItem(int item)
    {
        switch (item)
        {
            case 51:
                this.prepareTextBox(79, 51);
                this.stateTransitionSharedMenu(4);
                break;
            case 74:
                this.stateTransitionSharedMenu(2);
                break;
            case 82:
                this.m_sharedMenuURL = 83;
                this.stateTransitionSharedMenu(10);
                break;
            case 84:
                this.m_sharedMenuURL = 85;
                this.stateTransitionSharedMenu(10);
                break;
            case 86:
                this.m_sharedMenuURL = 87;
                this.stateTransitionSharedMenu(10);
                break;
            case 88:
                if (this.m_engine.getRMSOptionState(88) == 0)
                {
                    this.m_engine.setRMSOptionState(88, 1);
                    break;
                }
                this.stateTransitionSharedMenu(6);
                break;
            case 91:
                this.prepareTextBox(1723, 91);
                this.stateTransitionSharedMenu(4);
                break;
            case 98:
                this.prepareTextBox(99, 98);
                this.stateTransitionSharedMenu(4);
                break;
            case 100:
                this.prepareTextBox(101, 100);
                this.stateTransitionSharedMenu(4);
                break;
            case 102:
                this.prepareTextBox(103, 102);
                this.stateTransitionSharedMenu(4);
                break;
            case 111:
                this.prepareTextBox(112, 111);
                this.stateTransitionSharedMenu(4);
                break;
        }
    }

    public void initGoalsScreen()
    {
        this.prepareCustomOptionBox(8, 48);
        this.getUIList(3).initList();
    }

    public void renderGoalsScreen(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        int taskCount = this.m_simData.getTaskCount();
        StringBuffer str1 = textManager.clearStringBuffer();
        textManager.appendStringIdToBuffer(809);
        textManager.appendIntToBuffer(engine.getNumGoalsComplete());
        textManager.appendStringIdToBuffer(11);
        textManager.appendIntToBuffer(taskCount);
        textManager.dynamicString(-9, str1);
        this.setUIPlaceholderString(1, -9);
        StringBuffer str2 = textManager.clearStringBuffer();
        textManager.appendStringIdToBuffer(808);
        textManager.appendIntToBuffer(engine.getNumGoalsDiscovered());
        textManager.appendStringIdToBuffer(11);
        textManager.appendIntToBuffer(taskCount);
        textManager.dynamicString(-8, str2);
        this.setUIPlaceholderString(2, -8);
        this.drawCustomMessageBox(g, 1);
    }

    public void initAchievementsScreen()
    {
        this.prepareCustomOptionBox(8, 1814);
        this.getUIList(3).initList();
    }

    public void renderAchievements(Graphics g)
    {
        this.drawCustomMessageBox(g, 1);
    }

    public void initLeaderboardsScreen()
    {
        this.prepareCustomOptionBox(8, 1815);
        this.getUIList(3).initList();
    }

    public void renderLeaderboards(Graphics g)
    {
        this.drawCustomMessageBox(g, 1);
    }

    public void prepareCustomMessageBox(int stringId, int titleStringId)
    {
        this.m_messageBox.setMessageCustom(stringId, titleStringId, 4, -1, -1, 1);
    }

    public void prepareCustomConfirmBox(int stringId, int titleStringId)
    {
        this.m_messageBox.setMessageCustom(stringId, titleStringId, -1, 64, 32, 2);
    }

    public void prepareCustomOptionBox(int stringId, int titleStringId)
    {
        this.m_messageBox.setMessageCustom(stringId, titleStringId, 2, -1, -1, 3);
    }

    public void prepareMessageBox(int stringId, int titleStringId)
    {
        this.m_messageBox.setMessage(stringId, titleStringId, 4);
    }

    public void prepareConfirmBox(int stringId, int titleStringId)
    {
        this.m_messageBox.setMessage(stringId, titleStringId, 64, 32);
    }

    public void prepareTextBox(int bodyStringId, int titleStringId)
    {
        this.m_messageBox.setMessageScrollable(bodyStringId, titleStringId, 4);
    }

    public void drawGenericMessageBox(Graphics g)
    {
        this.m_messageBox.render(g);
    }

    public void drawCustomMessageBox(Graphics g, int panelId)
    {
        this.m_messageBox.renderCustom(g, panelId);
    }

    public void drawGenericMenu(Graphics g, int[] menu, int flags)
    {
        string[] strings = (string[])null;
        this.drawGenericMenu(g, menu, flags, strings);
    }

    public void drawGenericMenu(Graphics g, int[] menu, int flags, string[] strings)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        SimWorld simWorld = this.m_simWorld;
        int b = menu[0];
        int num1 = menu[3];
        int num2 = menu[2];
        int a = menu[4];
        int num3 = a != -1 ? midp.JMath.min(a, b) : b;
        int width = engine.getWidth();
        int height = engine.getHeight();
        int num4 = (flags & 1) != 0 ? 4 : 0;
        bool flag1 = (flags & 6) != 0;
        int w = !flag1 ? ((flags & 8) == 0 ? width * 4 / 5 : width >> 1) : width >> 1;
        int num5 = (flags & 16) == 0 ? 14 : 0;
        int h = num5 + 7 + 13 * num3 + 1 + (num4 << 1);
        int x1 = (flags & 2) == 0 ? ((flags & 4) == 0 ? ((flags & 8) == 0 ? width - w >> 1 : 3) : simWorld.getViewportX() + simWorld.getViewportWidth() - w - 3) : simWorld.getViewportX() + 3;
        int y1 = !flag1 ? height - 15 - h >> 1 : (simWorld.getViewportY() + simWorld.getViewportHeight() - h >> 1) - ((flags & 2) != 0 ? 13 : 0);
        if (num4 != 0)
        {
            int index1 = 78;
            int index2 = 62;
            if ((flags & 32) != 0)
            {
                index1 = 78;
                index2 = 77;
            }
            AnimationManager.setColor(g, index1);
            g.drawRect((float)x1, (float)y1, (float)w, (float)h);
            AnimationManager.setColor(g, index2);
            x1 += num4;
            y1 += num4;
            w -= num4 << 1;
            h -= num4 << 1;
        }
        bool flag2 = num3 != b;
        int x2 = x1 + 3;
        int num6 = w - 6 + (flag2 ? -9 : 1);
        int x3 = x2 + (num6 >> 1);
        AnimationManager.setColor(g, 77);
        g.fillRect(x1, y1, w, h);
        AnimationManager.setColor(g, 78);
        g.drawRect((float)x1, (float)y1, (float)w, (float)h);
        if ((flags & 16) == 0)
        {
            g.fillRect(x1, y1 + num5, w, 1);
            textManager.drawString(g, menu[1], 3, x3, y1 + 3, 17);
        }
        int y2 = y1 + num5 + 7;
        for (int index1 = 0; index1 < num3; ++index1)
        {
            int index2 = num1 + index1;
            int font = 3;
            int strId = -1;
            if (strings == null)
                strId = menu[5 + index2];
            if (num2 == index2 && strId != 430 && strId != 431)
            {
                font = 3;
                int y3 = y2 - 2;
                if ((flags & 32) != 0)
                {
                    AnimationManager.setColor(g, 1);
                    g.fillRect(x2, y3, num6, 13);
                }
                else if (flag1)
                {
                    AnimationManager.setColor(g, 78);
                    g.fillRect(x2, y3, num6, 13);
                }
                else
                    this.drawMenuSelector(g, x2, y3, num6, 13);
            }
            if (strId != -1)
            {
                textManager.drawString(g, strId, font, x3, y2, 17);
            }
            else
            {
                string str = strings[index2];
                textManager.drawString(g, str, font, x3, y2, 17);
            }
            y2 += 13;
        }
    }

    public void drawMenuSelector(Graphics g, int x, int y, int width, int height)
    {
        AnimationManager.setColor(g, 63);
        g.fillRect(x, y, width, 1);
        AnimationManager.setColor(g, 64);
        g.fillRect(x, y + 1, width, height - 3);
        AnimationManager.setColor(g, 65);
        g.fillRect(x, y + height - 2, width, 1);
    }

    public int interpolateValue(int displayLevel, int realLevel, int timeStep, int shiftDown)
    {
        if (displayLevel != realLevel)
        {
            int n = realLevel - displayLevel;
            int num = n * timeStep >> shiftDown;
            if (num == 0)
                num = MathExt.sign(n);
            else if (n > 0 && displayLevel + num > realLevel || n < 0 && displayLevel + num < realLevel)
                num = n;
            displayLevel += num;
        }
        return displayLevel;
    }

    public void triggerTapper(int x, int y)
    {
        this.m_tapperX = x;
        this.m_tapperY = y;
        this.m_tapperZ = 0;
        this.m_tapperSize = 2097152;
        this.m_tapperWorldSpace = false;
    }

    public void triggerTapperInWorldSpace(int x, int y, int z)
    {
        this.m_tapperX = x;
        this.m_tapperY = y;
        this.m_tapperZ = z;
        this.m_tapperSize = 2097152;
        this.m_tapperWorldSpace = true;
    }

    public void triggerTapperOnCommand(int commandId)
    {
        UIButton uiButton = this.getUIButton(commandId);
        this.triggerTapper(uiButton.getPosX(), uiButton.getPosY());
    }

    public void updateTapper(int timeStep)
    {
        if (this.m_tapperSize == 0)
            return;
        this.m_tapperSize += timeStep * 16384;
        if (this.m_tapperSize < 8388608)
            return;
        this.m_tapperSize = 0;
    }

    public void renderTapper(Graphics g)
    {
        AnimationManager2D animationManager2D = this.m_engine.getAnimationManager2D();
        if (this.m_tapperSize <= 0)
            return;
        float alpha = (float)(1.0 - (double)(this.m_tapperSize - 2097152) / 6291456.0);
        float num = (float)this.m_tapperSize / 8388608f;
        int tapperX;
        int tapperY;
        if (this.m_tapperWorldSpace)
        {
            this.m_simWorld.coordWorldToScreen(this.m_tempInt4, this.m_tapperX, this.m_tapperY, this.m_tapperZ);
            tapperX = this.m_tempInt4[0];
            tapperY = this.m_tempInt4[1];
        }
        else
        {
            tapperX = this.m_tapperX;
            tapperY = this.m_tapperY;
        }
        animationManager2D.submitAnim(42, (float)tapperX, (float)tapperY, alpha, num, num);
        animationManager2D.flushAnims(g);
    }

    public void updateLoadingCAS(int timeStep, int loadingPercent)
    {
        if (this.m_loadingString == -1)
        {
            this.m_loadingString = this.m_engine.rand(1489, 1525);
            this.m_loadingStringPosXF = this.m_engine.getWidth() - 60 << 16;
            this.m_loadingStringWidth = this.m_engine.getTextManager().getStringWidth(this.m_loadingString, 3);
        }
        else
        {
            this.m_loadingStringPosXF -= timeStep * 6553;
            if (this.m_loadingStringPosXF - 3932160 < -(this.m_loadingStringWidth << 16))
                this.m_loadingString = -1;
        }
        for (int index = 0; index < 2; ++index)
        {
            this.m_loadingChevTime[index] += timeStep;
            if (this.m_loadingChevTime[index] >= 1500)
            {
                this.m_loadingChevIdx[index] = (this.m_loadingChevIdx[index] + 2) % 8;
                this.m_loadingChevTime[index] -= 1500;
            }
        }
        this.m_loadingPercentGoal = (float)loadingPercent;
        if ((double)this.m_loadingPercent < (double)this.m_loadingPercentGoal)
        {
            this.m_loadingPercent += (float)(40.0 * ((double)timeStep / 1000.0));
            if ((double)this.m_loadingPercent <= (double)this.m_loadingPercentGoal)
                return;
            this.m_loadingPercent = this.m_loadingPercentGoal;
        }
        else
        {
            if ((double)this.m_loadingPercentGoal >= (double)this.m_loadingPercent)
                return;
            this.m_loadingPercent = this.m_loadingPercentGoal;
        }
    }

    public void updateLoading(int timeStep, int loadingPercent)
    {
        if (this.m_loadingString == -1)
        {
            this.m_loadingString = this.m_engine.rand(1489, 1525);
            this.m_loadingStringPosXF = this.m_engine.getWidth() - 60 << 16;
            this.m_loadingStringWidth = this.m_engine.getTextManager().getStringWidth(this.m_loadingString, 3);
        }
        else
        {
            this.m_loadingStringPosXF -= timeStep * 6553;
            if (this.m_loadingStringPosXF - 3932160 < -(this.m_loadingStringWidth << 16))
                this.m_loadingString = -1;
        }
        for (int index = 0; index < 2; ++index)
        {
            this.m_loadingChevTime[index] += timeStep;
            if (this.m_loadingChevTime[index] >= 1500)
            {
                this.m_loadingChevIdx[index] = (this.m_loadingChevIdx[index] + 2) % 8;
                this.m_loadingChevTime[index] -= 1500;
            }
        }
        this.m_loadingPercentGoal = (float)loadingPercent;
        if ((double)this.m_loadingPercent < (double)this.m_loadingPercentGoal)
        {
            this.m_loadingPercent += (float)(20.0 * ((double)timeStep / 1000.0));
            if ((double)this.m_loadingPercent <= (double)this.m_loadingPercentGoal)
                return;
            this.m_loadingPercent = this.m_loadingPercentGoal;
        }
        else
        {
            if ((double)this.m_loadingPercentGoal >= (double)this.m_loadingPercent)
                return;
            this.m_loadingPercent = this.m_loadingPercentGoal;
        }
    }

    public int getTheTheTheTheAnim()
    {
        switch (this.m_engine.getTextManager().getString(9)[0])
        {
            case 'A':
                return 528;
            case 'B':
                return 529;
            case 'C':
                return 525;
            case 'D':
                return 526;
            default:
                return -1;
        }
    }

    public void renderLoading(Graphics g)
    {
        AppEngine engine = this.m_engine;
        TextManager textManager = engine.getTextManager();
        AnimationManager2D animationManager2D = this.m_engine.getAnimationManager2D();
        int width = engine.getWidth();
        int height = engine.getHeight();
        g.setColor(16711680);
        lock (g.spriteBatch)
        {
            g.Begin();
            g.fillRect(0, 0, width, height);
            g.End();
        }
        animationManager2D.submitAnimStretched(428, 0.0f, 0.0f, (float)width, (float)height);
        int halfWidth = this.m_engine.getHalfWidth();
        int num1 = this.m_engine.getHalfHeight() - 35;
        float num2 = 22.5f;
        for (int index = 0; index < 8; ++index)
        {
            int num3 = (int)((double)halfWidth + 88.0 * (double)midp.JMath.Cos(num2 * ((float)System.Math.PI / 180f)));
            int num4 = (int)((double)num1 + 88.0 * (double)midp.JMath.Sin(num2 * ((float)System.Math.PI / 180f)));
            animationManager2D.submitAnim(429, (float)num3, (float)num4, 1f, -1f, 1f, (float)(-(double)num2 - 90.0));
            num2 += 45f;
        }
        for (int index = 0; index < 2; ++index)
        {
            float num3 = (float)(24.0 + 45.0 * (double)this.m_loadingChevIdx[index]);
            int num4 = this.m_loadingChevTime[index];
            float alpha = num4 > 400 ? (float)(1.0 - (double)(num4 - 400) / 1100.0) : (float)num4 / 400f;
            int num5 = (int)((double)halfWidth + 86.0 * (double)midp.JMath.Cos(num3 * ((float)System.Math.PI / 180f)));
            int num6 = (int)((double)num1 + 86.0 * (double)midp.JMath.Sin(num3 * ((float)System.Math.PI / 180f)));
            animationManager2D.submitAnim(430, (float)num5, (float)num6, alpha, -2f, 2f, (float)(-(double)num3 - 90.0));
        }
        animationManager2D.submitAnim(426, (float)(halfWidth - 3), (float)num1);
        if (textManager.getCurrentLocale().Equals("ja"))
        {
            int num3 = halfWidth - 3 + 56;
            int num4 = num1 - 15;
            animationManager2D.submitAnim(427, (float)num3, (float)num4);
        }
        int num7 = halfWidth - 3 - 86;
        int num8 = num1 + 1;
        int theTheTheTheAnim = this.getTheTheTheTheAnim();
        animationManager2D.submitAnim(theTheTheTheAnim, (float)num7, (float)num8, 1f, 1f, 1f);
        int num9 = textManager.getStringWidth(19, 4) + 160;
        int num10 = textManager.getLineHeight(4) + 20;
        int x = width >> 1;
        int y1 = height - 68;
        animationManager2D.submitAnimStretched(438, (float)(x - (num9 >> 1)), (float)(y1 - (num10 >> 1)), (float)num9, (float)num10);
        int num11 = width >> 1;
        int num12 = y1 + num10 - 8;
        animationManager2D.submitAnimHBar(434, 435, 436, (float)num11, (float)num12, 250f);
        float num13 = this.m_loadingPercent / 100f;
        int h = (int)(250.0 * (double)num13);
        int num14 = num11 - 125 + (h >> 1);
        int num15 = num12 - 3;
        int num16 = num14 + (h >> 1) - 10;
        int num17 = num15;
        int num18 = width >> 1;
        int y2 = (int)((double)num12 + (double)animationManager2D.getAnimHeight(435) + 3.0);
        int num19 = num10;
        animationManager2D.submitAnimStretched(438, (float)(num18 - 175), (float)(y2 - (num19 >> 1)), 350f, (float)num19);
        animationManager2D.flushAnims(g);
        animationManager2D.submitAnimHBar(431, 432, 433, (float)num11, (float)num15, 250f);
        g.setClip(0, num11 - 125, height, h);
        animationManager2D.flushAnims(g);
        g.setClip(0, 0, height, width);
        int num20 = num11 - 125;
        float alpha1;
        if ((double)num13 < 0.5)
        {
            alpha1 = (float)midp.JMath.min(num16 - num20, 20) / 20f;
        }
        else
        {
            int num3 = (int)((double)num16 + (double)animationManager2D.getAnimWidth(439) * 0.5);
            alpha1 = (float)midp.JMath.min(num20 + 250 - num3, 20) / 20f;
        }
        animationManager2D.submitAnim(439, (float)num16, (float)num17, alpha1);
        animationManager2D.flushAnims(g);
        lock (g.spriteBatch)
        {
            g.Begin();
            textManager.drawString(g, 19, 4, x, y1, 18);
            if (this.m_loadingString != -1)
            {
                g.setClip(0, 47, height, width - 94);
                textManager.drawString(g, this.m_loadingString, 4, this.m_loadingStringPosXF >> 16, y2, 10);
                g.setClip(0, 0, height, width);
            }
            g.End();
        }
        int num21 = (width - 94 >> 1) + 4;
        int num22 = width >> 1;
        int num23 = height - 27;
        animationManager2D.submitAnimStretched(437, (float)num22, (float)num23, (float)num21, 27f);
        animationManager2D.submitAnimStretched(437, (float)num22, (float)num23, (float)-num21, 27f);
        animationManager2D.flushAnims(g);
    }

    public int commandToIndex(int commandKey)
    {
        for (int index = 0; index < 29; ++index)
        {
            if (1 << index == commandKey)
                return index;
        }
        return -1;
    }

    public bool checkKeys(int keyCode, int commandKey, int checkKeyMask, int checkCommandMask)
    {
        if ((commandKey & checkCommandMask) == 0 && (keyCode & checkKeyMask) == 0)
            return false;
        this.m_engine.clearCommandKeys();
        this.m_engine.clearKeyBit(checkKeyMask);
        return true;
    }

    public int playSound(int eventId)
    {
        SoundManager soundManager = this.m_engine.getSoundManager();
        if (soundManager.isEventPlaying(eventId))
            soundManager.stopEvent(eventId);
        return soundManager.playEvent(eventId);
    }

    public void stopSound(int handle)
    {
        this.m_engine.getSoundManager().stopEvent(handle);
    }

    public abstract int getSceneID();

    public abstract void start(int initialState);

    public abstract void pause();

    public abstract void resume();

    public abstract void end();

    public abstract void render(Graphics g);

    public void awardAchievment(int achievmentID)
    {
        if (this.m_simData.LiveAchievementAwarded[achievmentID])
            return;
        AchievementCollection achievements = XNAConnect.getAchievements();
        if (achievements == null)
            return;
        Achievement achievement = achievements[achievmentID];
        if (!achievement.IsEarned)
            this.m_xnaConnect.awardAchievement(achievement.Key);
        this.m_simData.LiveAchievementAwarded[achievmentID] = true;
    }

    public void writeLeaderboard(int leaderboardID, int score, TimeSpan time)
    {
        if (Scene.IsScoreLeaderboard(leaderboardID))
            this.m_xnaConnect.writeToLeaderboard(leaderboardID, score, time, true, LeaderboardKey.BestScoreLifeTime);
        else
            this.m_xnaConnect.writeToLeaderboard(leaderboardID, score, time, true, LeaderboardKey.BestTimeLifeTime);
    }

    public static bool IsScoreLeaderboard(int leaderboardID)
    {
        switch (leaderboardID)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                return true;
            default:
                return false;
        }
    }
}
