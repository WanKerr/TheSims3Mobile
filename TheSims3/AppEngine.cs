// Decompiled with JetBrains decompiler
// Type: AppEngine
// Assembly: sims3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7B131356-9960-4428-AE45-C717550C1909
// Assembly location: E:\wamwo\Downloads\The Sims 3 1.0.0.0\sims3.dll

using m3g;
using midp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class AppEngine : Canvas
{
    public static AppEngine AppEngine_instance = (AppEngine)null;
    private static ResourceManager m_resourceManager = new ResourceManager();
    private AnimationManagerData m_animManData = new AnimationManagerData();
    private AnimationManager2D m_animationManager2D = new AnimationManager2D();
    private AnimationManager3D m_animationManager3D = new AnimationManager3D();
    private SoundManager m_soundManager = new SoundManager();
    private JRandom m_randomInstance = new JRandom();
    private TextManager m_textManager = new TextManager();
    private PostEffects m_postEffects = new PostEffects();
    public const int MAIN_TIMER = 16;
    public const int KEYCODE_LSOFTKEY = -6;
    public const int KEYCODE_RSOFTKEY = -7;
    public const int KEYCODE_BACKKEY = -8;
    public const int KEYCODE_VOLUME_UP = -9;
    public const int KEYCODE_VOLUME_DOWN = -10;
    public const string RMS_SETTINGS = "sim3set";
    public const string RMS_DATA = "sim3dat";
    private const int MAX_POINTER_QUEUE = 50;
    private const int KEY_BUFFER_LENGTH = 8;
    public const int VIBRATION_SHORT = 250;
    public const int VIBRATION_MEDIUM = 400;
    public const int VIBRATION_LONG = 600;
    public const int LOAD_EVENTS = 1046528;
    public const int UNLOAD_SCENEGAME = 2032;
    public const int UNLOAD_SCENEMENU = 8;
    public const int SETTINGS_VERSION_LEGACY = 130;
    public const int SETTINGS_VERSION_LEGACY_DLC = 138;
    public const int SETTINGS_VERSION = 139;
    public const int OPTIONSTATE_NONE = -1;
    public const int OPTIONSTATE_OFF = 0;
    public const int OPTIONSTATE_ON = 1;
    public const int OPTIONSTATE_SELECTED = 2;
    public const int OPTIONSTATE_UNSELECTED = 3;
    private bool m_saveFileError;
    public AppEngine.AppEngineThread m_gameThread;
    private Timer m_gameTimer;
    public volatile bool m_paintScheduled;
    public volatile bool m_updateScheduled;
    private MonkeyApp m_midlet;
    public volatile bool m_gameRunning;
    private Scene m_currentScene;
    public volatile bool m_paused;
    private SceneMenu m_sceneMenu;
    private SceneGame m_sceneGame;
    private Graphics3D m_graphics3D;
    private BGMusic m_bgMusic;
    private MediaPicker m_mediaPicker;
    private int m_pointerQueueBuffer;
    private int[] m_pointerQueueIndexes;
    private int[][] m_pointerQueueEvents;
    private int[][] m_pointerQueueXs;
    private int[][] m_pointerQueueYs;
    private int[][] m_pointerQueuePointerNums;
    private int[][] m_pointerQueueTapCounts;
    private int[] m_pointerArgs;
    private int m_pointerKeyPressed;
    private int m_keysPressedDown;
    private int m_commandPressedDown;
    private int[] m_keyBuffer;
    private int m_keyBufferIndex;
    private int[] m_keyArgs;
    private int m_rightCommandID;
    private int m_leftCommandID;
    private bool m_fading;
    private int m_fadeColor;
    private int m_fadeDir;
    private int m_fadeStep;
    private bool m_fadeColorReached;
    private int m_curScene;
    private int m_nextScene;
    private int m_nextSceneState;
    private int[] d_images;
    private int[] d_anim2DTextures;
    private int m_loadImageIndex;
    private bool m_rmsGSVibrationEnabled;
    private bool m_rmsGSTutorialsEnabled;
    private bool m_rmsGDTutorialPlayed;
    private bool m_rmsGSAutonomityEnabled;
    private bool m_rmsGSSavePrompts;
    private int m_gameSlotIndex;
    private bool[] m_rmsGSActiveGame;
    private int m_rmsGDTutorialFlags;
    private int m_rmsGDTutorialFlagsExt;
    private bool m_rmsGSBonusUnlocked;
    private bool m_rmsGSShownStorePrompt;
    private long m_rmsGlobalDreamsDiscovered1;
    private long m_rmsGlobalDreamsDiscovered2;
    private long m_rmsGlobalDreamsComplete1;
    private long m_rmsGlobalDreamsComplete2;
    private long m_rmsGDDreamsDiscovered1;
    private long m_rmsGDDreamsDiscovered2;
    private long m_rmsGDDreamsComplete1;
    private long m_rmsGDDreamsComplete2;
    private string[] m_rmsSimNameStrings;
    private SimData m_simData;
    private SimWorld m_simWorld;
    private int m_nextHouseId;
    private int m_nextZoomMapId;
    private short[][] d_uiPanels;
    private int m_encounterPlayerXF;
    private int m_encounterPlayerZF;
    private int m_encounterNPCXF;
    private int m_encounterNPCZF;
    private int m_encounterNPCId;

    public AppEngine(MonkeyApp m)
    {
        this.m_midlet = m;
        this.m_gameRunning = false;
        this.m_currentScene = (Scene)null;
        this.m_sceneMenu = (SceneMenu)null;
        this.m_sceneGame = (SceneGame)null;
        this.m_paused = true;
        this.m_graphics3D = (Graphics3D)null;
        AppEngine.m_resourceManager = new ResourceManager();
        this.m_animManData = new AnimationManagerData();
        this.m_animationManager2D = new AnimationManager2D();
        this.m_animationManager3D = new AnimationManager3D();
        this.m_soundManager = new SoundManager();
        this.m_randomInstance = new JRandom();
        this.m_textManager = new TextManager();
        this.m_mediaPicker = (MediaPicker)null;
        this.m_gameThread = (AppEngine.AppEngineThread)null;
        this.m_paintScheduled = false;
        this.m_updateScheduled = false;
        this.m_pointerQueueBuffer = 0;
        this.m_pointerQueueIndexes = new int[2];
        this.m_pointerQueueEvents = new int[2][];
        for (int index = 0; index < 2; ++index)
            this.m_pointerQueueEvents[index] = new int[50];
        this.m_pointerQueueXs = new int[2][];
        for (int index = 0; index < 2; ++index)
            this.m_pointerQueueXs[index] = new int[50];
        this.m_pointerQueueYs = new int[2][];
        for (int index = 0; index < 2; ++index)
            this.m_pointerQueueYs[index] = new int[50];
        this.m_pointerQueuePointerNums = new int[2][];
        for (int index = 0; index < 2; ++index)
            this.m_pointerQueuePointerNums[index] = new int[50];
        this.m_pointerQueueTapCounts = new int[2][];
        for (int index = 0; index < 2; ++index)
            this.m_pointerQueueTapCounts[index] = new int[50];
        this.m_pointerArgs = new int[3];
        this.m_pointerKeyPressed = -1;
        this.m_keysPressedDown = 0;
        this.m_commandPressedDown = 0;
        this.m_keyBuffer = new int[8];
        this.m_keyBufferIndex = 0;
        this.m_keyArgs = new int[3];
        this.m_rightCommandID = 0;
        this.m_leftCommandID = 0;
        this.m_postEffects = new PostEffects();
        this.m_fading = false;
        this.m_fadeColor = 0;
        this.m_fadeDir = 0;
        this.m_fadeStep = 0;
        this.m_fadeColorReached = false;
        this.m_curScene = 0;
        this.m_nextScene = 0;
        this.m_nextSceneState = 0;
        this.m_loadImageIndex = 0;
        this.m_rmsGSVibrationEnabled = false;
        this.m_rmsGSTutorialsEnabled = false;
        this.m_rmsGDTutorialPlayed = false;
        this.m_rmsGSAutonomityEnabled = false;
        this.m_rmsGSSavePrompts = false;
        this.m_gameSlotIndex = 0;
        this.m_rmsSimNameStrings = new string[7];
        this.m_rmsGSActiveGame = new bool[7];
        this.m_rmsGDTutorialFlags = 0;
        this.m_rmsGDTutorialFlagsExt = 0;
        this.m_rmsGSBonusUnlocked = false;
        this.m_rmsGSShownStorePrompt = false;
        this.m_rmsGlobalDreamsDiscovered1 = 0L;
        this.m_rmsGlobalDreamsDiscovered2 = 0L;
        this.m_rmsGlobalDreamsComplete1 = 0L;
        this.m_rmsGlobalDreamsComplete2 = 0L;
        this.m_rmsGDDreamsDiscovered1 = 0L;
        this.m_rmsGDDreamsDiscovered2 = 0L;
        this.m_rmsGDDreamsComplete1 = 0L;
        this.m_rmsGDDreamsComplete2 = 0L;
        this.m_simData = (SimData)null;
        this.m_simWorld = (SimWorld)null;
        this.m_nextHouseId = 0;
        this.m_nextZoomMapId = 0;
        this.d_uiPanels = (short[][])null;
        this.m_encounterPlayerXF = 0;
        this.m_encounterPlayerZF = 0;
        this.m_encounterNPCXF = 0;
        this.m_encounterNPCZF = 0;
        this.m_encounterNPCId = 0;
        this.m_saveFileError = false;
        this.d_images = (int[])null;
        this.d_anim2DTextures = (int[])null;
        AppEngine.timerBegin();
        for (int index = 0; index < 7; ++index)
            this.m_rmsSimNameStrings[index] = (string)null;
        AnimationManager.constructAnimationManager(ref this.m_animManData);
        AnimationManager.loadSubimageFile(ref this.m_animManData, ref AppEngine.m_resourceManager);
        AnimationManager.loadAnimFile(ref this.m_animManData, ref AppEngine.m_resourceManager);
        AnimationManager.loadColorsFile(ref this.m_animManData, ref AppEngine.m_resourceManager);
        this.m_graphics3D = Graphics3D.getInstance();
        this.getAnimationManager3D().loadAnimFile(ref AppEngine.m_resourceManager);
        this.debugMem("loaded 3d data");
        this.getAnimationManager2D().loadData();
        this.debugMem("loaded 2d data");
        this.loadSounds();
        this.loadGameData();
        this.debugMem("loaded gamedata");
        this.loadRMSAppSettings();
        this.m_textManager.init();
        this.debugMem("init text manager");
        this.m_mediaPicker = new MediaPicker();
        this.debugMem("init media picker");
        AppEngine.timerEnd("AppEngine()");
    }

    public void addPointerEvent(int _event, int x, int y, int pointerNum, int tapCount)
    {
        int num = x;
        x = y;
        y = 320 - num;
        int pointerQueueBuffer = this.m_pointerQueueBuffer;
        int pointerQueueIndex = this.m_pointerQueueIndexes[pointerQueueBuffer];
        if (pointerQueueIndex < 50)
        {
            ++this.m_pointerQueueIndexes[pointerQueueBuffer];
            this.m_pointerQueueEvents[pointerQueueBuffer][pointerQueueIndex] = _event;
            this.m_pointerQueueXs[pointerQueueBuffer][pointerQueueIndex] = x;
            this.m_pointerQueueYs[pointerQueueBuffer][pointerQueueIndex] = y;
            this.m_pointerQueuePointerNums[pointerQueueBuffer][pointerQueueIndex] = pointerNum;
            this.m_pointerQueueTapCounts[pointerQueueBuffer][pointerQueueIndex] = tapCount;
        }
        else
            midp.JSystem.println("ARGH!!! - hit the end of the pointer event queue");
        this.processPointerKey(_event, x, y, pointerNum, tapCount);
    }

    public void processPointerKey(int _event, int x, int y, int pointerNum, int tapCount)
    {
        if (pointerNum != 0)
            return;
        int key = -1;
        if (y > this.getHeight() - 30)
        {
            key = x >= this.getWidth() / 5 ? (x >= this.getWidth() * 2 / 5 ? (x >= this.getWidth() * 3 / 5 ? (x >= this.getWidth() * 4 / 5 ? -7 : 35) : 48) : 42) : -6;
        }
        else
        {
            switch (x * 3 / this.getWidth() + y * 3 / (this.getHeight() - 30) * 3)
            {
                case 0:
                    key = 49;
                    break;
                case 1:
                    key = 50;
                    break;
                case 2:
                    key = 51;
                    break;
                case 3:
                    key = 52;
                    break;
                case 4:
                    key = 53;
                    break;
                case 5:
                    key = 54;
                    break;
                case 6:
                    key = 55;
                    break;
                case 7:
                    key = 56;
                    break;
                case 8:
                    key = 57;
                    break;
            }
        }
        switch (_event)
        {
            case 0:
            case 1:
                if (this.m_pointerKeyPressed != -1 && this.m_pointerKeyPressed != key)
                    this.keyReleased(this.m_pointerKeyPressed);
                if (key == -1 || this.m_pointerKeyPressed == key)
                    break;
                this.m_pointerKeyPressed = key;
                this.keyPressed(key);
                break;
            case 2:
                if (this.m_pointerKeyPressed == -1)
                    break;
                this.keyReleased(this.m_pointerKeyPressed);
                this.m_pointerKeyPressed = -1;
                break;
        }
    }

    public void debug(string s)
    {
    }

    public void debugMem(string tag)
    {
        Debug.WriteLine($"{tag} {GC.GetTotalMemory(false)} bytes");
    }

    private static long timestamp;

    public static void timerBegin()
    {
        timestamp = Stopwatch.GetTimestamp();
    }

    public static void timerEnd(string tag)
    {
        Debug.WriteLine($"{tag} {TimeSpan.FromSeconds((Stopwatch.GetTimestamp() - timestamp) / (float)Stopwatch.Frequency).TotalMilliseconds}ms");
    }

    public void loadSounds()
    {
        SoundManager soundManager = this.getSoundManager();
        soundManager.loadData();
        this.m_bgMusic = new BGMusic(soundManager);
        AppEngine.timerBegin();
        soundManager.loadEvent(20);
        soundManager.loadEvent(18);
        soundManager.loadEvent(21);
        soundManager.loadEvent(22);
        soundManager.loadEvent(19);
        AppEngine.timerEnd("AppEngine::loadSounds");
    }

    public void unloadSounds()
    {
    }

    public void loadImagesBegin()
    {
        this.m_loadImageIndex = 0;
    }

    public bool loadImagesNext(int mask)
    {
        int num1 = 2;
        int num2 = this.d_images.Length >> 1;
        int num3 = this.d_images.Length + this.d_anim2DTextures.Length >> 1;
        ResourceManager resourceManager = AppEngine.getResourceManager();
        AnimationManager2D animationManager2D = this.getAnimationManager2D();
        for (int index = 0; this.m_loadImageIndex < num3 && index < num1; ++this.m_loadImageIndex)
        {
            if (this.m_loadImageIndex < num2)
            {
                if ((this.d_images[(this.m_loadImageIndex << 1) + 1] & mask) != 0)
                {
                    int num4 = 1;
                    while (!AnimationManager.loadImage(ref resourceManager, this.d_images[this.m_loadImageIndex << 1]) && num4 < 2)
                    {
                        ++num4;
                        AppEngine.doGC();
                    }
                    ++this.m_loadImageIndex;
                }
            }
            else
            {
                int num4 = this.m_loadImageIndex - num2;
                if ((this.d_anim2DTextures[(num4 << 1) + 1] & mask) != 0)
                    animationManager2D.loadTexture(this.d_anim2DTextures[num4 << 1]);
            }
        }
        return this.m_loadImageIndex >= num3;
    }

    public void loadAllImages(int mask)
    {
        this.loadImagesBegin();
        do
            ;
        while (!this.loadImagesNext(mask));
    }

    public void unloadAllImages(int mask, int fromBank)
    {
        for (int index = 0; index << 1 < this.d_images.Length; ++index)
        {
            if ((this.d_images[(index << 1) + 1] & mask) != 0)
            {
                int dImage = this.d_images[index << 1];
                if (fromBank == -1)
                {
                    for (int bank = 0; bank < 1; ++bank)
                        AnimationManager.unloadImage(dImage, bank);
                }
                else
                    AnimationManager.unloadImage(dImage, fromBank);
            }
        }
        AnimationManager2D animationManager2D = this.getAnimationManager2D();
        for (int index = 0; index < this.d_anim2DTextures.Length; index += 2)
        {
            if ((this.d_anim2DTextures[index + 1] & mask) != 0)
                animationManager2D.unloadTexture(this.d_anim2DTextures[index]);
        }
        AppEngine.doGC();
    }

    public static int indexOf(int value, int[] anArray, int startIndex)
    {
        return Array.IndexOf<int>(anArray, value, startIndex);
    }

    public static int indexOf(int value, int[] anArray)
    {
        return AppEngine.indexOf(value, anArray, 0);
    }

    public static int indexOf(sbyte value, sbyte[] anArray, sbyte startIndex)
    {
        return Array.IndexOf<sbyte>(anArray, value, (int)startIndex);
    }

    public static int indexOf(short value, short[] anArray)
    {
        return AppEngine.indexOf(value, anArray, 0);
    }

    public static int indexOf(short value, short[] anArray, int startIndex)
    {
        return Array.IndexOf<short>(anArray, value, startIndex);
    }

    public static int indexOf(sbyte value, sbyte[] anArray)
    {
        return AppEngine.indexOf(value, anArray, 0);
    }

    public static int indexOf(sbyte value, sbyte[] anArray, int startIndex)
    {
        return Array.IndexOf<sbyte>(anArray, value, startIndex);
    }

    public static int indexOf<T>(T value, T[] anArray)
    {
        return AppEngine.indexOf<T>(value, anArray, 0);
    }

    public static int indexOf<T>(T value, T[] anArray, int startIndex)
    {
        return Array.IndexOf<T>(anArray, value, startIndex);
    }

    public static int indexOf(Appearance value, Appearance[] anArray, int startIndex)
    {
        return Array.IndexOf<Appearance>(anArray, value, startIndex);
    }

    public static int indexOf(Appearance value, Appearance[] anArray)
    {
        return AppEngine.indexOf(value, anArray, 0);
    }

    public static int indexOfFlags(int flags, sbyte[] anArray)
    {
        return AppEngine.indexOfFlags(flags, anArray, 0);
    }

    public static int indexOfFlags(int flags, sbyte[] anArray, int startIndex)
    {
        for (int index = startIndex; index < anArray.Length; ++index)
        {
            if (((int)anArray[index] & flags) != 0)
                return index;
        }
        return -1;
    }

    public static int indexOfFlags(int flags, short[] anArray)
    {
        return AppEngine.indexOfFlags(flags, anArray, 0);
    }

    public static int indexOfFlags(int flags, short[] anArray, int startIndex)
    {
        for (int index = startIndex; index < anArray.Length; ++index)
        {
            if (((int)anArray[index] & flags) != 0)
                return index;
        }
        return -1;
    }

    public static int indexOfNthElement(int index, sbyte[] anArray, int skipElement)
    {
        int num = 0;
        for (int index1 = 0; index1 < anArray.Length; ++index1)
        {
            if ((int)anArray[index1] != skipElement && num++ == index)
                return index1;
        }
        return -1;
    }

    public static int indexOfNthElement(int index, short[] anArray, int skipElement)
    {
        int num = 0;
        for (int index1 = 0; index1 < anArray.Length; ++index1)
        {
            if ((int)anArray[index1] != skipElement && num++ == index)
                return index1;
        }
        return -1;
    }

    public static int indexOfNthInclusiveElement(int index, sbyte[] anArray, int element)
    {
        int num = 0;
        for (int index1 = 0; index1 < anArray.Length; ++index1)
        {
            if ((int)anArray[index1] == element && num++ == index)
                return index1;
        }
        return -1;
    }

    public static int indexOfNthInclusiveElement(int index, short[] anArray, int element)
    {
        int num = 0;
        for (int index1 = 0; index1 < anArray.Length; ++index1)
        {
            if ((int)anArray[index1] == element && num++ == index)
                return index1;
        }
        return -1;
    }

    public static int indexOfNthElementFlags(int index, short[] anArray, int interestFlags)
    {
        int num = 0;
        for (int index1 = 0; index1 < anArray.Length; ++index1)
        {
            if (((int)anArray[index1] & interestFlags) != 0 && num++ == index)
                return index1;
        }
        return -1;
    }

    public static int indexOfNthElementFlags(int index, int[] anArray, int interestFlags)
    {
        int num = 0;
        for (int index1 = 0; index1 < anArray.Length; ++index1)
        {
            if ((anArray[index1] & interestFlags) != 0 && num++ == index)
                return index1;
        }
        return -1;
    }

    public int indexOfLastElementLessThan(int index, short[] anArray, bool wraparound)
    {
        for (int index1 = anArray.Length - 1; index1 >= 0; --index1)
        {
            if (index >= (int)anArray[index1])
                return index1;
        }
        return wraparound ? anArray.Length - 1 : 0;
    }

    public int indexOfNthElementNotFlags(int index, int[] anArray, int interestFlags)
    {
        int num = 0;
        for (int index1 = 0; index1 < anArray.Length; ++index1)
        {
            if ((anArray[index1] & interestFlags) == 0 && num++ == index)
                return index1;
        }
        return -1;
    }

    public int randomIndexOfElement(int value, sbyte[] anArray)
    {
        int num = AppEngine.countOf(value, anArray);
        return num > 0 ? AppEngine.indexOfNthInclusiveElement(AppEngine.getCanvas().rand(0, num - 1), anArray, value) : -1;
    }

    public static int countOf(int value, int[] anArray)
    {
        int num = 0;
        for (int index = 0; index < anArray.Length; ++index)
        {
            if (anArray[index] == value)
                ++num;
        }
        return num;
    }

    public static int countOf(int value, short[] anArray)
    {
        int num = 0;
        for (int index = 0; index < anArray.Length; ++index)
        {
            if ((int)anArray[index] == value)
                ++num;
        }
        return num;
    }

    public static int countOf(int value, sbyte[] anArray)
    {
        int num = 0;
        for (int index = 0; index < anArray.Length; ++index)
        {
            if ((int)anArray[index] == value)
                ++num;
        }
        return num;
    }

    public static int countOfFlags(int flags, int[] anArray)
    {
        return AppEngine.countOfFlags(flags, anArray, 0);
    }

    public static int countOfFlags(int flags, int[] anArray, int startIndex)
    {
        int num = 0;
        for (int index = startIndex; index < anArray.Length; ++index)
        {
            if ((anArray[index] & flags) != 0)
                ++num;
        }
        return num;
    }

    public static int countOfFlags(int flags, short[] anArray)
    {
        return AppEngine.countOfFlags(flags, anArray, 0);
    }

    public static int countOfFlags(int flags, short[] anArray, int startIndex)
    {
        int num = 0;
        for (int index = startIndex; index < anArray.Length; ++index)
        {
            if (((int)anArray[index] & flags) != 0)
                ++num;
        }
        return num;
    }

    public static int countOfFlags(int flags, sbyte[] anArray)
    {
        return AppEngine.countOfFlags(flags, anArray, 0);
    }

    public static int countOfFlags(int flags, sbyte[] anArray, int startIndex)
    {
        int num = 0;
        for (int index = startIndex; index < anArray.Length; ++index)
        {
            if (((int)anArray[index] & flags) != 0)
                ++num;
        }
        return num;
    }

    public void replace(int oldValue, int newValue, short[] anArray)
    {
        for (int index = 0; index < anArray.Length; ++index)
        {
            if ((int)anArray[index] == oldValue)
                anArray[index] = (short)newValue;
        }
    }

    public void replace(int oldValue, int newValue, int[] anArray)
    {
        for (int index = 0; index < anArray.Length; ++index)
        {
            if (anArray[index] == oldValue)
                anArray[index] = newValue;
        }
    }

    public static int appendUnique(MapObject newValue, MapObject[] anArray)
    {
        return AppEngine.appendUnique(newValue, anArray, (MapObject)null);
    }

    public static int appendUnique(MapObject newValue, MapObject[] anArray, MapObject nullValue)
    {
        int index1 = -1;
        for (int index2 = 0; index2 < anArray.Length; ++index2)
        {
            MapObject an = anArray[index2];
            if (index1 == -1 && an == nullValue)
                index1 = index2;
            else if (an == newValue)
                return -2;
        }
        if (index1 != -1)
            anArray[index1] = newValue;
        return index1;
    }

    public static void menuClear(int[] menu, int title)
    {
        AppEngine.menuClear(menu, title, -1);
    }

    public static void menuClear(int[] menu, int title, int visibleItems)
    {
        menu[1] = title;
        menu[2] = 0;
        menu[3] = 0;
        menu[4] = visibleItems;
        menu[0] = 0;
    }

    public static int[] menuCreate(int numItems)
    {
        return new int[5 + numItems];
    }

    public static void menuAppendItem(int[] menu, int item)
    {
        int num = menu[0];
        menu[5 + num] = item;
        menu[0] = num + 1;
    }

    public static bool menuContains(int[] menu, int item)
    {
        int num = menu[0] + 5;
        for (int index = 5; index < num; ++index)
        {
            if (item == menu[index])
                return true;
        }
        return false;
    }

    public static void menuCopy(int[] destMenu, int[] srcMenu)
    {
        midp.JSystem.arraycopy((Array)srcMenu, 0, (Array)destMenu, 0, 5 + srcMenu[0]);
    }

    public static int menuGetSelectedItem(int[] menu)
    {
        return menu[5 + menu[2]];
    }

    public static void menuVisible(int[] menu)
    {
        int num1 = menu[4];
        if (num1 <= 0)
            return;
        int num2 = menu[2];
        int num3 = menu[3];
        if (num2 < num3)
            num3 = num2;
        else if (num2 >= num3 + num1)
            num3 = midp.JMath.max(0, num2 - num1 + 1);
        menu[3] = num3;
    }

    public bool menuCursorUpDown(int[] menu, int keyCode)
    {
        int num1 = menu[0];
        int num2 = menu[2];
        if ((keyCode & 8196) != 0)
        {
            this.clearKeyBit(8196);
            menu[2] = (num2 + num1 - 1) % num1;
        }
        if ((keyCode & 16640) != 0)
        {
            this.clearKeyBit(16640);
            menu[2] = (num2 + 1) % num1;
        }
        if (menu[2] == num2)
            return false;
        AppEngine.menuVisible(menu);
        if (this.getSceneGame() != null)
            this.getSoundManager().playEvent(18);
        return true;
    }

    public bool menuCursorLeftRight(int[] menu, int keyCode)
    {
        int num1 = menu[0];
        int num2 = menu[2];
        if ((keyCode & 32784) != 0)
        {
            this.clearKeyBit(32784);
            menu[2] = (num2 + num1 - 1) % num1;
        }
        if ((keyCode & 65600) != 0)
        {
            this.clearKeyBit(65600);
            menu[2] = (num2 + 1) % num1;
        }
        if (menu[2] == num2)
            return false;
        AppEngine.menuVisible(menu);
        if (this.getSceneGame() != null)
            this.getSoundManager().playEvent(19);
        return true;
    }

    public void menuVisibleSet(int[] menu, int visibleItems)
    {
        menu[4] = midp.JMath.min(visibleItems, menu[0]);
    }

    public bool menuShowBackArrow(int[] menu)
    {
        return menu[3] != 0;
    }

    public bool menuShowNextArrow(int[] menu)
    {
        return menu[3] + menu[4] != menu[0];
    }

    public void menuSelectById(int[] menu, int id)
    {
        for (int index = 5; index < menu.Length; ++index)
        {
            if (menu[index] == id)
            {
                menu[2] = index - 5;
                break;
            }
        }
    }

    public int calcRMSChecksum(sbyte[] byteArray, int startIndex, int length)
    {
        int num1 = 0;
        int num2 = length - startIndex;
        for (int index = startIndex; index < num2; ++index)
        {
            int num3 = (int)byteArray[index];
            num1 += num3 + 3571;
        }
        return num1;
    }

    public sbyte[] loadRMS(string filename)
    {
        midp.JSystem.println("loadRMS : " + filename);
        FileInputStream fileInputStream = new FileInputStream(filename);
        if (fileInputStream != null && fileInputStream.loadSuccessful())
        {
            int length = fileInputStream.size();
            sbyte[] numArray1 = new sbyte[length];
            DataInputStream dataInputStream1 = new DataInputStream((InputStream)fileInputStream);
            dataInputStream1.readFully(numArray1);
            dataInputStream1.close();
            fileInputStream.close();
            if (numArray1.Length > 8)
            {
                DataInputStream dataInputStream2 = new DataInputStream((InputStream)new ByteArrayInputStream(numArray1));
                if (dataInputStream2.readInt() != 139)
                    return numArray1;
                int num1 = length - 8;
                dataInputStream2.skipBytes(num1);
                int num2 = dataInputStream2.readInt();
                int num3 = this.calcRMSChecksum(numArray1, 4, num1);
                midp.JSystem.println("  checkSum: calc=" + (object)num3 + " file=dataCheckSum");
                if (num3 == num2)
                {
                    sbyte[] numArray2 = new sbyte[numArray1.Length - 4];
                    midp.JSystem.arraycopy((Array)numArray1, 0, (Array)numArray2, 0, numArray2.Length);
                    return numArray2;
                }
            }
        }
        return new sbyte[0];
    }

    public void saveRMS(string filename, sbyte[] byteData)
    {
        midp.JSystem.println("Saving RMS : " + filename);
        FileOutputStream fileOutputStream = new FileOutputStream(filename);
        if (fileOutputStream == null || !fileOutputStream.loadSuccessful())
            return;
        fileOutputStream.clear();
        DataOutputStream dataOutputStream = new DataOutputStream((OutputStream)fileOutputStream);
        dataOutputStream.write(byteData);
        int v = this.calcRMSChecksum(byteData, 4, byteData.Length - 4);
        midp.JSystem.println("checkSum: " + (object)v);
        dataOutputStream.writeInt(v);
        dataOutputStream.close();
        fileOutputStream.close();
    }

    public void resetRMSAppSettings()
    {
        midp.JSystem.println(nameof(resetRMSAppSettings));
        this.m_rmsGSVibrationEnabled = true;
        this.m_rmsGSTutorialsEnabled = true;
        this.m_rmsGDTutorialPlayed = false;
        this.m_rmsGSAutonomityEnabled = true;
        this.m_rmsGSSavePrompts = true;
        SpywareManager.getInstance().setEnabled(true);
        this.m_rmsGSBonusUnlocked = false;
        this.m_rmsGSShownStorePrompt = false;
        this.m_rmsGlobalDreamsDiscovered1 = 0L;
        this.m_rmsGlobalDreamsDiscovered2 = 0L;
        this.m_rmsGlobalDreamsComplete1 = 0L;
        this.m_rmsGlobalDreamsComplete2 = 0L;
        this.resetSimSaveData();
    }

    public void loadRMSAppSettings()
    {
        midp.JSystem.println(nameof(loadRMSAppSettings));
        bool flag = false;
        sbyte[] buf = this.loadRMS("sim3set");
        if (buf.Length != 0)
        {
            DataInputStream dataInputStream = new DataInputStream((InputStream)new ByteArrayInputStream(buf));
            int num1 = dataInputStream.readInt();
            dataInputStream.readInt();
            switch (num1)
            {
                case 130:
                    this.getSoundManager().setVolumeGlobal(dataInputStream.readFloat());
                    this.getSoundManager().setVolumeSFX(dataInputStream.readFloat());
                    this.getBgMusic().setEnabled(dataInputStream.readBoolean());
                    this.m_rmsGSVibrationEnabled = dataInputStream.readBoolean();
                    this.m_rmsGSTutorialsEnabled = dataInputStream.readBoolean();
                    this.m_rmsGSAutonomityEnabled = dataInputStream.readBoolean();
                    this.m_rmsGSSavePrompts = dataInputStream.readBoolean();
                    SpywareManager.getInstance().setEnabled(true);
                    this.m_rmsGSBonusUnlocked = dataInputStream.readBoolean();
                    this.m_rmsGSShownStorePrompt = false;
                    this.m_rmsGlobalDreamsDiscovered1 = dataInputStream.readLong();
                    this.m_rmsGlobalDreamsDiscovered2 = dataInputStream.readLong();
                    this.m_rmsGlobalDreamsComplete1 = dataInputStream.readLong();
                    this.m_rmsGlobalDreamsComplete2 = dataInputStream.readLong();
                    for (int index = 0; index < 7; ++index)
                    {
                        if (index >= 3)
                        {
                            this.setSimName((string)null, index);
                            this.m_rmsGSActiveGame[index] = false;
                        }
                        else
                        {
                            string name = dataInputStream.readUTF();
                            if (name.Length > 0)
                                this.setSimName(name, index);
                            else
                                this.setSimName((string)null, index);
                            this.m_rmsGSActiveGame[index] = dataInputStream.readBoolean();
                        }
                    }
                    break;
                case 138:
                case 139:
                    this.getSoundManager().setVolumeGlobal(dataInputStream.readFloat());
                    this.getSoundManager().setVolumeSFX(dataInputStream.readFloat());
                    this.getBgMusic().setEnabled(dataInputStream.readBoolean());
                    this.m_rmsGSVibrationEnabled = dataInputStream.readBoolean();
                    this.m_rmsGSTutorialsEnabled = dataInputStream.readBoolean();
                    this.m_rmsGSAutonomityEnabled = dataInputStream.readBoolean();
                    this.m_rmsGSSavePrompts = dataInputStream.readBoolean();
                    SpywareManager.getInstance().setEnabled(dataInputStream.readBoolean());
                    this.m_rmsGSBonusUnlocked = dataInputStream.readBoolean();
                    this.m_rmsGSShownStorePrompt = dataInputStream.readBoolean();
                    this.m_rmsGlobalDreamsDiscovered1 = dataInputStream.readLong();
                    this.m_rmsGlobalDreamsDiscovered2 = dataInputStream.readLong();
                    this.m_rmsGlobalDreamsComplete1 = dataInputStream.readLong();
                    this.m_rmsGlobalDreamsComplete2 = dataInputStream.readLong();
                    for (int index = 0; index != 7; ++index)
                    {
                        string name = dataInputStream.readUTF();
                        if (name.Length > 0)
                            this.setSimName(name, index);
                        else
                            this.setSimName((string)null, index);
                        this.m_rmsGSActiveGame[index] = dataInputStream.readBoolean();
                    }
                    if (num1 == 139)
                    {
                        int num2 = dataInputStream.readInt();
                        if (num1 != num2)
                        {
                            flag = true;
                            break;
                        }
                        break;
                    }
                    break;
                default:
                    midp.JSystem.println("Different game settings version " + (object)num1);
                    midp.JSystem.println("Resetting game settings " + (object)139);
                    flag = true;
                    break;
            }
            if (dataInputStream.available() > 0)
                flag = true;
            dataInputStream.close();
        }
        else
            flag = true;
        if (!flag)
            return;
        this.resetRMSAppSettings();
        this.saveRMSAppSettings();
    }

    public bool saveRMSAppSettings()
    {
        midp.JSystem.println(nameof(saveRMSAppSettings));
        ByteArrayOutputStream arrayOutputStream = new ByteArrayOutputStream();
        DataOutputStream dataOutputStream = new DataOutputStream((OutputStream)arrayOutputStream);
        dataOutputStream.writeInt(139);
        dataOutputStream.writeInt(7);
        dataOutputStream.writeFloat(this.getSoundManager().getVolumeGlobal());
        dataOutputStream.writeFloat(this.getSoundManager().getVolumeSFX());
        dataOutputStream.writeBoolean(this.getBgMusic().getEnabled());
        dataOutputStream.writeBoolean(this.m_rmsGSVibrationEnabled);
        dataOutputStream.writeBoolean(this.m_rmsGSTutorialsEnabled);
        dataOutputStream.writeBoolean(this.m_rmsGSAutonomityEnabled);
        dataOutputStream.writeBoolean(this.m_rmsGSSavePrompts);
        dataOutputStream.writeBoolean(SpywareManager.getInstance().isEnabled());
        dataOutputStream.writeBoolean(this.m_rmsGSBonusUnlocked);
        dataOutputStream.writeBoolean(this.m_rmsGSShownStorePrompt);
        dataOutputStream.writeLong(this.m_rmsGlobalDreamsDiscovered1);
        dataOutputStream.writeLong(this.m_rmsGlobalDreamsDiscovered2);
        dataOutputStream.writeLong(this.m_rmsGlobalDreamsComplete1);
        dataOutputStream.writeLong(this.m_rmsGlobalDreamsComplete2);
        for (int index = 0; index != 7; ++index)
        {
            string simName = this.getSimName(index);
            dataOutputStream.writeUTF(simName == null ? " " : simName);
            dataOutputStream.writeBoolean(this.m_rmsGSActiveGame[index]);
        }
        dataOutputStream.writeInt(139);
        sbyte[] byteArray = arrayOutputStream.toByteArray();
        this.m_saveFileError |= !dataOutputStream.close();
        this.saveRMS("sim3set", byteArray);
        return !this.m_saveFileError;
    }

    public void validateRMSSaveGames()
    {
        for (int index = 0; index < 7; ++index)
        {
            if (this.getRMSActiveGame(index))
                this.setRMSGameSlotIndex(index);
        }
    }

    public void resetRMSGameData()
    {
        midp.JSystem.println(nameof(resetRMSGameData));
        this.m_rmsGDTutorialFlags = 0;
        this.m_rmsGDTutorialFlagsExt = 0;
        this.resetGDGoals();
        this.m_rmsGDTutorialPlayed = false;
        this.m_simData.resetRMSGameData();
        this.m_simWorld.resetRMSGameData();
    }

    public bool loadRMSGameData()
    {
        midp.JSystem.println(nameof(loadRMSGameData));
        StringBuffer stringBuffer = new StringBuffer();
        stringBuffer.append("sim3dat");
        stringBuffer.append(this.m_gameSlotIndex);
        string filename = stringBuffer.toString();
        bool flag = false;
        sbyte[] buf = this.loadRMS(filename);
        if (buf.Length != 0)
        {
            DataInputStream @in = new DataInputStream((InputStream)new ByteArrayInputStream(buf));
            int version = @in.readInt();
            switch (version)
            {
                case 130:
                    midp.JSystem.println("loading legacy save game");
                    this.m_rmsGDTutorialFlags = @in.readInt();
                    this.m_rmsGDTutorialFlagsExt = 0;
                    this.m_rmsGDTutorialPlayed = @in.readBoolean();
                    this.m_simData.loadRMSGameDataLegacy(@in);
                    this.m_simWorld.loadRMSGameDataLegacy(@in);
                    break;
                case 138:
                case 139:
                    midp.JSystem.println("loading current save game");
                    this.m_rmsGDTutorialFlags = @in.readInt();
                    this.m_rmsGDTutorialFlagsExt = @in.readInt();
                    this.m_rmsGDTutorialPlayed = @in.readBoolean();
                    this.m_simData.loadRMSGameData(@in, version);
                    this.m_simWorld.loadRMSGameData(@in);
                    if (version == 139)
                    {
                        int num = @in.readInt();
                        if (version != num)
                        {
                            flag = true;
                            break;
                        }
                        break;
                    }
                    break;
                default:
                    midp.JSystem.println("Different game data version " + (object)version);
                    midp.JSystem.println("Resetting game data " + (object)139);
                    flag = true;
                    break;
            }
            this.m_nextHouseId = 0;
        }
        else
            flag = true;
        if (!flag)
            return true;
        midp.JSystem.println("game data recordstore not found");
        this.resetRMSGameData();
        this.saveRMSGameData();
        return false;
    }

    public bool saveRMSGameData()
    {
        midp.JSystem.println(nameof(saveRMSGameData));
        this.m_rmsGlobalDreamsDiscovered1 |= this.m_rmsGDDreamsDiscovered1;
        this.m_rmsGlobalDreamsDiscovered2 |= this.m_rmsGDDreamsDiscovered2;
        this.m_rmsGlobalDreamsComplete1 |= this.m_rmsGDDreamsComplete1;
        this.m_rmsGlobalDreamsComplete2 |= this.m_rmsGDDreamsComplete2;
        this.saveRMSAppSettings();
        ByteArrayOutputStream arrayOutputStream = new ByteArrayOutputStream();
        DataOutputStream @out = new DataOutputStream((OutputStream)arrayOutputStream);
        @out.writeInt(139);
        @out.writeInt(this.m_rmsGDTutorialFlags);
        @out.writeInt(this.m_rmsGDTutorialFlagsExt);
        @out.writeBoolean(this.m_rmsGDTutorialPlayed);
        this.m_simData.saveRMSGameData(@out);
        this.m_simWorld.saveRMSGameData(@out);
        @out.writeInt(139);
        sbyte[] byteArray = arrayOutputStream.toByteArray();
        @out.close();
        StringBuffer stringBuffer = new StringBuffer();
        stringBuffer.append("sim3dat");
        stringBuffer.append(this.m_gameSlotIndex);
        this.saveRMS(stringBuffer.toString(), byteArray);
        return !this.m_saveFileError;
    }

    public int getRMSOptionState(int @string)
    {
        switch (@string)
        {
            case 67:
                return (double)this.getSoundManager().getVolumeSFX() != 1.0 ? 0 : 1;
            case 68:
                return !this.getBgMusic().getEnabled() ? 0 : 1;
            case 69:
                return !this.m_rmsGSVibrationEnabled ? 0 : 1;
            case 70:
                return !this.m_rmsGSTutorialsEnabled ? 0 : 1;
            case 71:
                return !this.m_rmsGSAutonomityEnabled ? 0 : 1;
            case 72:
                return !this.m_rmsGSSavePrompts ? 0 : 1;
            case 88:
                return !SpywareManager.getInstance().isEnabled() ? 0 : 1;
            default:
                return -1;
        }
    }

    public void setRMSOptionState(int @string, int state)
    {
        if (state == 1 || state == 0)
            SpywareManager.getInstance().trackOptionToggle(@string, state == 1);
        if (@string == 67)
            this.getSoundManager().setVolumeSFX(state == 1 ? 1f : 0.0f);
        if (@string == 68)
            this.getBgMusic().setEnabled(state == 1);
        if (@string == 69)
        {
            this.m_rmsGSVibrationEnabled = state == 1;
            if (state == 1)
                this.vibrate();
        }
        if (@string == 70)
            this.m_rmsGSTutorialsEnabled = state == 1;
        if (@string == 71)
            this.m_rmsGSAutonomityEnabled = state == 1;
        if (@string == 72)
            this.m_rmsGSSavePrompts = state == 1;
        if (@string == 88)
            SpywareManager.getInstance().setEnabled(state == 1);
        this.saveRMSAppSettings();
    }

    public int getRMSGameSlotIndex()
    {
        return this.m_gameSlotIndex;
    }

    public void setRMSGameSlotIndex(int index)
    {
        this.m_gameSlotIndex = index;
        if (!this.getRMSActiveGame() || this.loadRMSGameData())
            return;
        this.resetSimSaveData(this.m_gameSlotIndex);
        this.saveRMSAppSettings();
    }

    public bool getRMSActiveGame()
    {
        return this.m_rmsGSActiveGame[this.m_gameSlotIndex];
    }

    public bool getRMSActiveGame(int index)
    {
        return this.m_rmsGSActiveGame[index];
    }

    public int getRMSNumActiveGames()
    {
        int num = 0;
        for (int index = 0; index < 7; ++index)
        {
            if (this.getRMSActiveGame(index))
                ++num;
        }
        return num;
    }

    public void resetSimSaveData()
    {
        midp.JSystem.println(nameof(resetSimSaveData));
        for (int gameSlot = 0; gameSlot < 7; ++gameSlot)
            this.resetSimSaveData(gameSlot);
    }

    public void resetSimSaveData(int gameSlot)
    {
        midp.JSystem.println("resetSimSaveData: " + (object)gameSlot);
        this.setSimName((string)null, gameSlot);
        this.m_rmsGSActiveGame[gameSlot] = false;
    }

    public void clearSimName()
    {
        this.m_rmsSimNameStrings[this.m_gameSlotIndex] = (string)null;
    }

    public string getSimName()
    {
        return this.getSimName(this.m_gameSlotIndex);
    }

    public void setSimName(string name)
    {
        this.setSimName(name, this.m_gameSlotIndex);
    }

    public string getSimName(int index)
    {
        return this.m_rmsSimNameStrings[index];
    }

    public void setSimName(string name, int index)
    {
        this.m_rmsSimNameStrings[index] = name;
    }

    public void newGame()
    {
        midp.JSystem.println(nameof(newGame));
        this.m_rmsGSActiveGame[this.m_gameSlotIndex] = true;
        this.m_rmsGDTutorialFlags = 0;
        this.m_rmsGDTutorialFlagsExt = 0;
        this.saveRMSAppSettings();
        this.m_simData.newGame();
        this.saveRMSGameData();
        SpywareManager.getInstance().trackNewGame(this.m_gameSlotIndex, this.getSimName());
    }

    public void beginGame()
    {
        midp.JSystem.println(nameof(beginGame));
        this.loadRMSGameData();
        this.m_nextHouseId = 0;
        SpywareManager.getInstance().trackStartGame();
    }

    public bool getRMSHasSeenTutorial(int tutorialId)
    {
        return tutorialId <= 31 ? (1 << tutorialId & this.m_rmsGDTutorialFlags) != 0 : (1 << tutorialId - 32 & this.m_rmsGDTutorialFlagsExt) != 0;
    }

    public void setRMSHasSeenTutorial(int tutorialId)
    {
        if (tutorialId <= 31)
            this.m_rmsGDTutorialFlags |= 1 << tutorialId;
        else
            this.m_rmsGDTutorialFlagsExt |= 1 << tutorialId - 32;
    }

    public bool isBonusUnlocked()
    {
        return this.m_rmsGSBonusUnlocked;
    }

    public void unlockBonus()
    {
        this.m_rmsGSBonusUnlocked = true;
        this.saveRMSAppSettings();
    }

    public void resetGlobalGoals()
    {
        this.m_rmsGSBonusUnlocked = false;
        this.m_rmsGlobalDreamsDiscovered1 = 0L;
        this.m_rmsGlobalDreamsDiscovered2 = 0L;
        this.m_rmsGlobalDreamsComplete1 = 0L;
        this.m_rmsGlobalDreamsComplete2 = 0L;
    }

    public void resetGDGoals()
    {
        this.m_rmsGDDreamsDiscovered1 = 0L;
        this.m_rmsGDDreamsDiscovered2 = 0L;
        this.m_rmsGDDreamsComplete1 = 0L;
        this.m_rmsGDDreamsComplete2 = 0L;
    }

    public bool isDreamDiscovered(int dream)
    {
        return dream < 64 ? ((this.m_rmsGlobalDreamsDiscovered1 | this.m_rmsGDDreamsDiscovered1) & 1L << dream) != 0L : ((this.m_rmsGlobalDreamsDiscovered2 | this.m_rmsGDDreamsDiscovered2) & 1L << dream - 64) != 0L;
    }

    public void setGoalDiscovered(int dream)
    {
        if (dream < 64)
            this.m_rmsGDDreamsDiscovered1 |= 1L << dream;
        else
            this.m_rmsGDDreamsDiscovered2 |= 1L << dream - 64;
    }

    public int getNumGoalsDiscovered()
    {
        long num1 = this.m_rmsGlobalDreamsDiscovered1 | this.m_rmsGDDreamsDiscovered1;
        long num2 = this.m_rmsGlobalDreamsDiscovered2 | this.m_rmsGDDreamsDiscovered2;
        int num3 = 0;
        for (int index = 0; index != 64; ++index)
            num3 = num3 + ((int)(num1 >> index) & 1) + ((int)(num2 >> index) & 1);
        return num3;
    }

    public bool isGoalCompleted(int dream)
    {
        return dream < 64 ? ((this.m_rmsGlobalDreamsComplete1 | this.m_rmsGDDreamsComplete1) & 1L << dream) != 0L : ((this.m_rmsGlobalDreamsComplete2 | this.m_rmsGDDreamsComplete2) & 1L << dream - 64) != 0L;
    }

    public void setGoalCompleted(int dream)
    {
        if (dream < 64)
            this.m_rmsGDDreamsComplete1 |= 1L << dream;
        else
            this.m_rmsGDDreamsComplete2 |= 1L << dream - 64;
    }

    public int getNumGoalsComplete()
    {
        long num1 = this.m_rmsGlobalDreamsComplete1 | this.m_rmsGDDreamsComplete1;
        long num2 = this.m_rmsGlobalDreamsComplete2 | this.m_rmsGDDreamsComplete2;
        int num3 = 0;
        for (int index = 0; index != 64; ++index)
            num3 = num3 + ((int)(num1 >> index) & 1) + ((int)(num2 >> index) & 1);
        return num3;
    }

    public void setRMSShownStorePrompt()
    {
        this.m_rmsGSShownStorePrompt = true;
        this.saveRMSAppSettings();
    }

    public bool getRMSShownStorePrompt()
    {
        return this.m_rmsGSShownStorePrompt;
    }

    public void loadGameData()
    {
        this.loadUIPanels();
        this.m_simWorld = new SimWorld(this);
        this.m_simData = new SimData(this);
        this.m_nextHouseId = 0;
        this.m_nextZoomMapId = -1;
        this.m_encounterNPCId = -1;
    }

    public void setNextHouseId(int houseId)
    {
        this.m_nextHouseId = houseId;
        this.m_nextZoomMapId = -1;
    }

    public int getNextHouseId()
    {
        return this.m_nextHouseId;
    }

    public void setNextZoomMapId(int map)
    {
        this.m_nextZoomMapId = map;
    }

    public int getNextZoomMapId()
    {
        return this.m_nextZoomMapId;
    }

    public void setupEncounter(MapObjectSim npc)
    {
        MapObjectSim playerSim = this.getSceneGame().getPlayerSim();
        this.m_encounterPlayerXF = playerSim.getPosX();
        this.m_encounterPlayerZF = playerSim.getPosZ();
        if (npc != null)
        {
            this.m_encounterNPCXF = npc.getPosX();
            this.m_encounterNPCZF = npc.getPosZ();
            this.m_encounterNPCId = npc.getId();
        }
        else
            this.m_encounterNPCId = -1;
        this.m_nextHouseId = -1;
    }

    public int getEncounterPlayerX()
    {
        return this.m_encounterPlayerXF;
    }

    public int getEncounterPlayerZ()
    {
        return this.m_encounterPlayerZF;
    }

    public int getEncounterNPCX()
    {
        return this.m_encounterNPCXF;
    }

    public int getEncounterNPCZ()
    {
        return this.m_encounterNPCZF;
    }

    public int getEncounterNPCId()
    {
        return this.m_encounterNPCId;
    }

    public short lookupSimsUI(DataInputStream dis)
    {
        return GlobalConstants.SIMSUI_SYMBOL_LOOKUPS[(int)dis.readShort()];
    }

    public void loadUIPanels()
    {
        AppEngine.getResourceManager();
        try
        {
            InputStream input = ResourceManager.loadBinaryFile(181);
            if (input == null)
                return;
            DataInputStream dis = new DataInputStream(input);
            int length = (int)dis.readByte();
            midp.JSystem.println("numPanels: " + (object)length);
            short[][] numArray1 = new short[length][];
            for (int index1 = 0; index1 < length; ++index1)
            {
                int num = (int)dis.readByte();
                midp.JSystem.println("numElements: " + (object)num);
                short[] numArray2 = new short[num << 1];
                int index2 = 0;
                for (int index3 = 0; index3 < num; ++index3)
                {
                    numArray2[index2] = (short)dis.readByte();
                    numArray2[index2 + 1] = this.lookupSimsUI(dis);
                    index2 += 2;
                }
                numArray1[index1] = numArray2;
            }
            int num1 = (int)dis.readByte();
            midp.JSystem.println("numImages: " + (object)num1);
            int[] numArray3 = new int[num1 << 1];
            int index4 = 0;
            for (int index1 = 0; index1 < num1; ++index1)
            {
                numArray3[index4] = (int)this.lookupSimsUI(dis);
                numArray3[index4 + 1] = dis.readInt();
                index4 += 2;
            }
            this.d_images = numArray3;
            int num2 = (int)dis.readByte();
            midp.JSystem.println("num Anim 2D Textures: " + (object)num2);
            int[] numArray4 = new int[num2 << 1];
            int index5 = 0;
            for (int index1 = 0; index1 < num2; ++index1)
            {
                numArray4[index5] = (int)this.lookupSimsUI(dis);
                numArray4[index5 + 1] = dis.readInt();
                index5 += 2;
            }
            this.d_anim2DTextures = numArray4;
            dis.close();
            this.d_uiPanels = numArray1;
        }
        catch (IOException ex)
        {
            midp.JSystem.println(ex.Message);
        }
    }

    public short[] getUIPanel(int id)
    {
        return this.d_uiPanels[id];
    }

    public void Dispose()
    {
        this.stopThread();
        this.m_currentScene = (Scene)null;
        this.m_sceneMenu = (SceneMenu)null;
        this.m_sceneGame = (SceneGame)null;
        this.m_midlet = (MonkeyApp)null;
        this.m_graphics3D = (Graphics3D)null;
        this.getBgMusic().beQuiet();
        this.m_bgMusic = (BGMusic)null;
        this.m_mediaPicker = (MediaPicker)null;
    }

    public bool getSaveFileError()
    {
        return this.m_saveFileError;
    }

    public Graphics3D getGraphics3D()
    {
        return this.m_graphics3D;
    }

    public AnimationManagerData getAnimManData()
    {
        return this.m_animManData;
    }

    public static ResourceManager getResourceManager()
    {
        return AppEngine.m_resourceManager;
    }

    public AnimationManager2D getAnimationManager2D()
    {
        return this.m_animationManager2D;
    }

    public AnimationManager3D getAnimationManager3D()
    {
        return this.m_animationManager3D;
    }

    public SoundManager getSoundManager()
    {
        return this.m_soundManager;
    }

    public BGMusic getBgMusic()
    {
        return this.m_bgMusic;
    }

    public TextManager getTextManager()
    {
        return this.m_textManager;
    }

    public MediaPicker getMediaPicker()
    {
        return this.m_mediaPicker;
    }

    public int getHalfWidth()
    {
        return this.getWidth() >> 1;
    }

    public int getHalfHeight()
    {
        return this.getHeight() >> 1;
    }

    public static void createAppEngine(MonkeyApp m)
    {
        AppEngine.AppEngine_instance = new AppEngine(m);
    }

    public static AppEngine getCanvas()
    {
        return AppEngine.AppEngine_instance;
    }

    public static MonkeyApp getMIDlet()
    {
        return AppEngine.getCanvas().m_midlet;
    }

    public void start()
    {
        AppEngine.timerBegin();
        DLCManager.getInstance().initPacks();
        this.loadAllImages(3);
        this.debugMem("loaded AppEngine images");
        this.validateRMSSaveGames();
        this.changeScene(1, -1);
        this.m_paused = false;
        AppEngine.timerEnd("AppEngine::start()");
    }

    public void end()
    {
        this.m_gameRunning = false;
        while (this.m_updateScheduled || this.m_paintScheduled)
            JThread.yield();
        if (this.m_currentScene != null)
            this.m_currentScene.end();
        this.requestGC(true);
        this.unloadSounds();
    }

    public override void showNotify()
    {
        if (!this.m_paused)
            return;
        this.pauseGame();
        this.resumeGame();
        this.startThread();
    }

    public override void hideNotify()
    {
    }

    public void startThread()
    {
        this.m_gameRunning = true;
        if (this.m_gameThread != null)
            return;
        this.m_gameThread = new AppEngine.AppEngineThread(this);
        this.m_gameThread.getSystemThread().IsBackground = false;
        midp.JSystem.println("main thread starting...");
        this.m_gameThread.start();
    }

    public void stopThread()
    {
        if (this.m_gameThread == null)
            return;
        this.m_gameThread.setDone();
        this.m_gameThread.join();
        this.m_gameThread = (AppEngine.AppEngineThread)null;
    }

    public void runLoop(int frameTime)
    {
        int bitsToClear = this.updateKeyBuffer();
        this.getSoundManager().update(frameTime);
        this.getBgMusic().update(frameTime);
        this.update(frameTime);
        this.clearKeyBit(bitsToClear);
    }

    private int updateKeyBuffer()
    {
        int[] keyBuffer = this.m_keyBuffer;
        for (int index = this.m_keyBufferIndex - 1; index >= 0; --index)
        {
            if (keyBuffer[index] < 0)
            {
                this.m_keysPressedDown &= ~-keyBuffer[index];
                if (-keyBuffer[index] == 131072 || -keyBuffer[index] == 262144 || -keyBuffer[index] == 524288)
                    this.m_commandPressedDown = 0;
            }
        }
        for (int index = this.m_keyBufferIndex - 1; index >= 0; --index)
        {
            if (keyBuffer[index] > 0)
            {
                this.m_keysPressedDown |= keyBuffer[index];
                if (keyBuffer[index] == 524288)
                    this.m_commandPressedDown |= 2;
                else if (keyBuffer[index] == 262144)
                    this.m_commandPressedDown |= this.m_rightCommandID;
                else if (keyBuffer[index] == 131072)
                    this.m_commandPressedDown |= this.m_leftCommandID;
            }
        }
        int num = 0;
        for (int index1 = 1; index1 <= 18; ++index1)
        {
            for (int index2 = 0; index2 < this.m_keyBufferIndex; ++index2)
            {
                if (keyBuffer[index2] < 0)
                    num |= -keyBuffer[index2];
                else if (num == 1 << index1 && keyBuffer[index2] > 0)
                    num &= ~keyBuffer[index2];
                keyBuffer[index2] = 0;
            }
        }
        this.m_keyBufferIndex = 0;
        return num;
    }

    public void endGame()
    {
        this.m_gameRunning = false;
    }

    public void pauseGame()
    {
        this.getBgMusic().suspend();
        this.getSoundManager().pause();
        this.clearCommandKeys();
        this.clearKeysPressedDown();
        if (this.m_currentScene != null)
            this.m_currentScene.pause();
        this.m_paused = true;
        while (this.m_paintScheduled)
            JThread.yield();
    }

    public void resumeGame()
    {
        this.getSoundManager().resume();
        this.getBgMusic().resume();
        if (this.m_currentScene != null)
            this.m_currentScene.resume();
        this.clearCommandKeys();
        this.clearKeysPressedDown();
        this.m_keyBufferIndex = 0;
        this.m_paused = false;
    }

    public bool isPaused()
    {
        return this.m_paused;
    }

    public void update(int intervalConst)
    {
        int timeStep = intervalConst;
        if (timeStep > 135)
            timeStep = 135;
        if (this.m_nextScene != -1)
        {
            this.performChangeScene(this.m_nextScene, this.m_nextSceneState);
            this.m_nextScene = -1;
            this.m_nextSceneState = -1;
        }
        if (this.m_currentScene == null)
            return;
        if (this.m_fading)
        {
            this.m_fadeColor += this.m_fadeDir * this.m_fadeStep * (timeStep >> 3);
            if (this.m_fadeDir > 0 && this.m_fadeColor >= 16777215)
            {
                this.m_fadeColor = 16777215;
                this.m_fading = false;
            }
            else if (this.m_fadeDir < 0 && this.m_fadeColor <= 0)
            {
                this.m_fadeColor = 0;
                this.m_fading = false;
            }
        }
        if (this.m_currentScene == null)
            return;
        this.processPointerEvents();
        this.m_keyArgs[1] = this.m_keysPressedDown;
        this.m_keyArgs[0] = this.m_commandPressedDown;
        this.m_keyArgs[2] = -1;
        this.m_currentScene.processInput(11, this.m_keyArgs);
        this.m_currentScene.update(timeStep);
    }

    protected override void paint(Graphics g)
    {
        Graphics g1 = g;
        if (this.m_currentScene != null && this.m_gameRunning)
            this.m_currentScene.render(g1);
        if (this.m_fadeColor < 16777215)
            this.renderFade(g1);
        if (this.fadeColorReached() || (this.m_fadeDir <= 0 || this.m_fadeColor < 16777215) && (this.m_fadeDir >= 0 || this.m_fadeColor > 0))
            return;
        this.m_fadeColorReached = true;
    }

    public static void ASSERT(bool condition, string tag)
    {
    }

    public override void pointerPressed(int x, int y, int pointerNum, int tapCount)
    {
        this.addPointerEvent(0, x, y, pointerNum, tapCount);
    }

    public override void pointerDragged(int x, int y, int pointerNum, int tapCount)
    {
        this.addPointerEvent(1, x, y, pointerNum, tapCount);
    }

    public override void pointerReleased(int x, int y, int pointerNum, int tapCount)
    {
        this.addPointerEvent(2, x, y, pointerNum, tapCount);
    }

    public void clearPointerEvents()
    {
        this.m_pointerQueueIndexes[0] = 0;
        this.m_pointerQueueIndexes[1] = 0;
    }

    private void renderPointerKeys(Graphics g)
    {
    }

    private void processPointerEvents()
    {
        if (this.m_currentScene == null)
            return;
        int pointerQueueBuffer = this.m_pointerQueueBuffer;
        this.m_pointerQueueBuffer = 1 - pointerQueueBuffer;
        for (int index = 0; index < this.m_pointerQueueIndexes[pointerQueueBuffer]; ++index)
        {
            int _event = this.m_pointerQueueEvents[pointerQueueBuffer][index];
            int num1 = this.m_pointerQueueXs[pointerQueueBuffer][index];
            int num2 = this.m_pointerQueueYs[pointerQueueBuffer][index];
            this.m_pointerArgs[0] = this.m_pointerQueuePointerNums[pointerQueueBuffer][index];
            this.m_pointerArgs[1] = num1;
            this.m_pointerArgs[2] = num2;
            this.m_currentScene.processInput(_event, this.m_pointerArgs);
        }
        this.m_pointerQueueIndexes[pointerQueueBuffer] = 0;
    }

    private int translateKeyCode(int keyCode)
    {
        switch (keyCode)
        {
            case -8:
                return 524288;
            case -7:
                return 262144;
            case -6:
                return 131072;
            case 1:
                return 8192;
            case 2:
                return 32768;
            case 5:
                return 65536;
            case 6:
                return 16384;
            case 8:
                return 4096;
            case 35:
                return 1024;
            case 42:
                return 2048;
            case 48:
                return 1;
            case 49:
                return 2;
            case 50:
                return 4;
            case 51:
                return 8;
            case 52:
                return 16;
            case 53:
                return 32;
            case 54:
                return 64;
            case 55:
                return 128;
            case 56:
                return 256;
            case 57:
                return 512;
            default:
                switch (this.getGameAction(keyCode))
                {
                    case 1:
                        return 8192;
                    case 2:
                        return 32768;
                    case 5:
                        return 65536;
                    case 6:
                        return 16384;
                    case 8:
                        return 4096;
                    default:
                        return 0;
                }
        }
    }

    internal override void keyPressed(int keyCode)
    {
        int num = this.translateKeyCode(keyCode);
        if (num == 0 || this.m_keyBufferIndex >= this.m_keyBuffer.Length)
            return;
        this.m_keyBuffer[this.m_keyBufferIndex++] = num;
    }

    internal override void keyReleased(int keyCode)
    {
        int num = this.translateKeyCode(keyCode);
        if (num == 0 || this.m_keyBufferIndex >= this.m_keyBuffer.Length)
            return;
        this.m_keyBuffer[this.m_keyBufferIndex++] = -num;
    }

    public void clearKeyBit(int bitsToClear)
    {
        this.m_keysPressedDown &= ~bitsToClear;
    }

    public void clearKeysPressedDown()
    {
        this.m_keysPressedDown = 0;
    }

    public void clearCommandKeys()
    {
        this.m_commandPressedDown = 0;
        this.clearKeyBit(524288);
    }

    public void setSoftKeys(int cancelIDConst, int selectIDConst)
    {
        int num1 = cancelIDConst;
        int num2 = selectIDConst;
        if (num2 != this.m_rightCommandID)
            this.m_rightCommandID = num2;
        if (num1 == this.m_leftCommandID)
            return;
        this.m_leftCommandID = num1;
    }

    public int getRightCommandID()
    {
        return this.m_rightCommandID;
    }

    public int getLeftCommandID()
    {
        return this.m_leftCommandID;
    }

    public void startFadeOut()
    {
        this.m_fadeColor = 16777215;
        this.m_fadeDir = -1;
        this.m_fading = true;
        this.m_fadeColorReached = false;
    }

    public void startFadeOutDim()
    {
        this.m_fadeColor = 11184810;
        this.m_fadeDir = -1;
        this.m_fading = true;
        this.m_fadeColorReached = false;
    }

    public void startFadeIn()
    {
        this.m_fadeColor = 0;
        this.m_fadeDir = 1;
        this.m_fading = true;
        this.m_fadeColorReached = false;
    }

    public void stopFade()
    {
        this.m_fadeColor = 16777215;
        this.m_fadeDir = -1;
        this.m_fading = false;
    }

    public bool fadeColorReached()
    {
        return this.m_fadeColorReached;
    }

    public bool isFading()
    {
        return this.m_fading && !this.fadeColorReached();
    }

    public bool isFadingOut()
    {
        return this.isFading() && this.m_fadeDir == -1;
    }

    public bool isFadingIn()
    {
        return this.isFading() && this.m_fadeDir == 1;
    }

    public int getFadeDir()
    {
        return this.m_fadeDir;
    }

    public void setFadeStep(int step)
    {
        this.m_fadeStep = step;
    }

    public void renderFade(Graphics g)
    {
        this.m_postEffects.setViewport(0, 0, this.getWidth(), this.getHeight());
        this.m_postEffects.setBlendMode(66);
        this.m_postEffects.setColor((int)((long)this.m_fadeColor | 4278190080L));
        this.m_postEffects.apply(g);
    }

    public void renderFade(Graphics g, int blendMode, int color, int x, int y, int w, int h)
    {
        this.m_postEffects.setBlendMode(blendMode);
        this.m_postEffects.setViewport(x, y, w, h);
        this.m_postEffects.setColor((int)((long)color | 4278190080L));
        this.m_postEffects.apply(g);
    }

    public void renderBackgroundDim(Graphics g)
    {
        this.renderBackgroundDim(g, false);
    }

    public void renderBackgroundDim(Graphics g, bool fullscreen)
    {
        this.m_postEffects.setViewport(0, 0, this.getWidth(), this.getHeight());
        this.m_postEffects.setBlendMode(64);
        this.m_postEffects.setColor(1358954495);
        this.m_postEffects.apply(g);
    }

    public static void doGC()
    {
    }

    public void requestGC(bool immediate)
    {
    }

    public int getNextSceneId()
    {
        return this.m_nextScene;
    }

    public Scene getScene()
    {
        return this.m_currentScene;
    }

    public SceneGame getSceneGame()
    {
        return this.m_curScene != 2 ? (SceneGame)null : (SceneGame)this.m_currentScene;
    }

    public SceneMenu getSceneMenu()
    {
        return this.m_curScene != 1 ? (SceneMenu)null : (SceneMenu)this.m_currentScene;
    }

    public SceneMenu getSceneMenuCached()
    {
        return this.m_sceneMenu;
    }

    public SceneGame getSceneGameCached()
    {
        return this.m_sceneGame;
    }

    public void changeScene(int sceneID)
    {
        this.changeScene(sceneID, -1);
    }

    public void changeScene(int sceneID, int state)
    {
        this.m_nextScene = sceneID;
        this.m_nextSceneState = state;
    }

    private void performChangeScene(int sceneID, int state)
    {
        AppEngine.timerBegin();
        if (this.m_currentScene != null)
        {
            this.m_currentScene.end();
            this.m_currentScene = (Scene)null;
            this.requestGC(true);
        }
        this.stopFade();
        this.m_curScene = sceneID;
        switch (sceneID)
        {
            case 1:
                this.m_currentScene = this.m_sceneMenu == null ? (Scene)new SceneMenu(this) : (Scene)this.m_sceneMenu;
                break;
            case 2:
                this.m_currentScene = this.m_sceneGame == null ? (Scene)new SceneGame(this) : (Scene)this.m_sceneGame;
                break;
        }
        this.m_currentScene.start(state);
        this.clearKeysPressedDown();
        this.clearCommandKeys();
        this.repaint();
        AppEngine.timerEnd("performSceneChange");
    }

    public int rand(int randLow, int randHigh)
    {
        int num1 = this.m_randomInstance.nextInt() & int.MaxValue;
        int num2 = randHigh - randLow + 1;
        return randLow + num1 % num2;
    }

    public int randPercent()
    {
        return this.rand(0, 99);
    }

    public float randFloat()
    {
        return this.m_randomInstance.nextFloat();
    }

    public void vibrate()
    {
        this.vibrate(400);
    }

    public void vibrate(int duration)
    {
    }

    public bool isVibrationEnabled()
    {
        return this.m_rmsGSVibrationEnabled;
    }

    public void setVibrationEnabled(bool enabled)
    {
        this.m_rmsGSVibrationEnabled = enabled;
    }

    public static void fillArray(short[][] anArray, short value)
    {
        for (int index = 0; index < anArray.Length; ++index)
            AppEngine.fillArray(anArray[index], value);
    }

    public static void fillArray(short[] anArray, short value)
    {
        for (int index = 0; index < anArray.Length; ++index)
            anArray[index] = value;
    }

    public static void fillArray(int[][] anArray, int value)
    {
        for (int index = 0; index < anArray.Length; ++index)
            AppEngine.fillArray(anArray[index], value);
    }

    public static void fillArray(int[] anArray, int value)
    {
        for (int index = 0; index < anArray.Length; ++index)
            anArray[index] = value;
    }

    public static void fillArray(object[] anArray, object value)
    {
        for (int index = 0; index < anArray.Length; ++index)
            anArray[index] = value;
    }

    public static void removeObjectFromStack<T>(ref Stack<T> stack, T obj)
    {
        if (!stack.Contains(obj))
            return;
        Stack<T> objStack = new Stack<T>();
        while (stack.Count > 0)
        {
            object obj1 = (object)stack.Pop();
            if (!obj1.Equals((object)obj))
                objStack.Push((T)obj1);
            else
                break;
        }
        while (objStack.Count > 0)
            stack.Push(objStack.Pop());
    }

    public static void fillArray(byte[][] anArray, byte value)
    {
        for (int index = 0; index < anArray.Length; ++index)
            AppEngine.fillArray(anArray[index], value);
    }

    public static void fillArray(byte[] anArray, byte value)
    {
        for (int index = 0; index < anArray.Length; ++index)
            anArray[index] = value;
    }

    public static void fillArray(sbyte[][] anArray, sbyte value)
    {
        for (int index = 0; index < anArray.Length; ++index)
            AppEngine.fillArray(anArray[index], value);
    }

    public static void fillArray(sbyte[] anArray, sbyte value)
    {
        for (int index = 0; index < anArray.Length; ++index)
            anArray[index] = value;
    }

    public bool getAutonomityEnabled()
    {
        return this.m_rmsGSAutonomityEnabled;
    }

    public bool getTutorialsEnabled()
    {
        return this.m_rmsGSTutorialsEnabled;
    }

    public bool hasTutorialBeenPlayed()
    {
        return this.m_rmsGDTutorialPlayed;
    }

    public void setTutorialBeenPlayed()
    {
        this.m_rmsGDTutorialPlayed = true;
    }

    public bool getSavePromptsEnabled()
    {
        return this.m_rmsGSSavePrompts;
    }

    public SimData getSimData()
    {
        return this.m_simData;
    }

    public SimWorld getSimWorld()
    {
        return this.m_simWorld;
    }

    public class AppEngineThread : JThread
    {
        public long timeStartFrame;
        private AppEngine engine;
        private volatile bool done;

        public AppEngineThread(AppEngine e)
        {
            this.timeStartFrame = midp.JSystem.currentTimeMillis();
            this.engine = e;
            this.done = false;
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        public void setDone()
        {
            this.done = true;
        }

        public override void run()
        {
            midp.JSystem.println("main thread started");
        }
    }

    private class AppEngineTimerTask : TimerTask
    {
        private long timeStartFrame;
        private AppEngine engine;

        public AppEngineTimerTask(AppEngine e)
        {
            this.timeStartFrame = midp.JSystem.currentTimeMillis();
            this.engine = e;
        }

        public override void run()
        {
            if (!this.engine.m_gameRunning)
            {
                this.cancel();
                this.engine.m_midlet.destroyApp(true);
            }
            else
            {
                if (this.engine.m_paused || this.engine.m_paintScheduled)
                    return;
                long num = midp.JSystem.currentTimeMillis();
                this.engine.runLoop(midp.JMath.max(1, (int)(num - this.timeStartFrame)));
                this.timeStartFrame = num;
                this.engine.m_paintScheduled = true;
                this.engine.repaint();
                this.engine.serviceRepaints();
            }
        }
    }
}
