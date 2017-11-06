using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;

public class YuME_mapEditor : EditorWindow
{
    // ----------------------------------------------------------------------------------------------------
    // ----- Editor Helpers and Settings
    // ----------------------------------------------------------------------------------------------------

    public static YuME_editorData editorData;
    public static GameObject editorGameObject;
    public static GameObject tileMapParent;
    public static GameObject[] mapLayers = new GameObject[8];
    public static List<YuME_tilesetData> availableTileSets = new List<YuME_tilesetData>();
    public static List<string> availableTileSetsPath = new List<string>();
    public static List<GameObject> selectedTiles = new List<GameObject>();

    public static string[] tileSetNames;
    public static GameObject[] currentTileSetObjects;
    static GameObject[] currentCustomBrushes;
    static Vector2 _scrollPosition;
    static brushOptions brushPallete = brushOptions.tilesetBrush;
    public static GameObject gridSceneObject;

    static Color _gridColorNormal = Color.black;
    static Color _gridColorBorder = Color.black;
    static Color _gridColorFill = Color.black;

	static Vector3 _brushSize = Vector3.one;

    static bool setupScene = false;
    static bool unFreeze = false;

    public static bool eraseToolOverride = false;
    public static bool pickToolOverride = false;

    public static int currentBrushIndex = 0; // note - custom brushes should not effect this. It's used for cycling through the standard tiles.

    public static brushTypes currentBrushType = brushTypes.standardBrush;

    public static bool showWireBrush = true;
    public static bool showGizmos = false;

    public enum toolIcons
    {
        defaultTools,
        brushTool,
        pickTool,
        eraseTool,
        selectTool,
        showGizmos,
        isolateTool,
        gridUpTool,
        gridDownTool,
        rotateTool,
        flipVerticalTool,
        flipHorizontalTool,
        copyTool,
        moveTool,
		customBrushTool,
        trashTool,
        isolateLayerTool,
        layerUp,
        layerDown,
        none
    }

    public enum brushOptions
    {
        tilesetBrush,
        customBrush
    }

    public enum brushTypes
    {
        standardBrush,
        customBrush,
        copyBrush
    }

    public static bool controlHeld = false;
    public static bool shiftHeld = false;
    public static bool altHeld = false;

    public static List<GameObject> isolatedGridObjects = new List<GameObject>();
    public static bool isolateTiles = false;
    public static List<GameObject> isolatedLayerObjects = new List<GameObject>();
    public static bool isolateLayer = false;

    // ----------------------------------------------------------------------------------------------------
    // ----- Editor Tools Variables
    // ----------------------------------------------------------------------------------------------------

    public static toolIcons selectedTool = toolIcons.brushTool;
    public static toolIcons previousSelectedTool;
    static float _tileRotation = 0f;
    static bool allowTileRedraw = true;
    static string currentScene;
    static int _currentTileSetIndex;
    static int _currentLayer = 1;
	static bool openConfig = false;

    // ----------------------------------------------------------------------------------------------------
    // ----- Scene Tools Variables
    // ----------------------------------------------------------------------------------------------------

    bool _toolEnabled;
    static public Vector3 tilePosition = Vector3.zero;
    static public bool validTilePosition = false;
    static Vector3 oldTilePosition = Vector3.zero;

    // ----------------------------------------------------------------------------------------------------
    // ----- Brush and Current Tile Variables
    // ----------------------------------------------------------------------------------------------------

    public static GameObject brushTile;
    public static GameObject currentTile;
    public static List<GameObject> tileChildObjects = new List<GameObject>();

    static int controlId;

    // ----------------------------------------------------------------------------------------------------

    [MenuItem("Window/Yuponic/YuME: Map Editor")]
    static void Initialize()
    {
        YuME_mapEditor tileMapEditorWindow = EditorWindow.GetWindow<YuME_mapEditor>(false, "Map Editor");
        tileMapEditorWindow.titleContent.text = "Map Editor";
    }

    void OnEnable()
    {
        editorData = ScriptableObject.CreateInstance<YuME_editorData>();
        AssetPreview.SetPreviewTextureCacheSize(1000);
        YuTools_Utils.disableTileGizmo(showGizmos);
        YuTools_Utils.addLayer("YuME_TileMap");

        YuME_brushFunctions.cleanSceneOfBrushObjects();

        string[] guids;

        // ----------------------------------------------------------------------------------------------------
        // ----- Load Editor Settings
        // ----------------------------------------------------------------------------------------------------

        guids = AssetDatabase.FindAssets("YuME_editorSetupData");
        editorData = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guids[0]), typeof(YuME_editorData)) as YuME_editorData;

        importTileSets(false);
        loadPreviewTiles();
        loadCustomBrushes();
                
        _toolEnabled = toolEnabled;

        gridSceneObject = GameObject.Find("YuME_MapEditorObject");

        updateGridColors();

        gridHeight = 0;

        YuME_brushFunctions.createBrushTile();

        YuTools_Utils.showUnityGrid(true);
        SceneView.RepaintAll();

        // ----------------------------------------------------------------------------------------------------
        // ----- Setup Scene Delegates
        // ----------------------------------------------------------------------------------------------------

        currentScene = EditorSceneManager.GetActiveScene().name;

        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        SceneView.onSceneGUIDelegate += OnSceneGUI;

        EditorApplication.hierarchyWindowChanged -= OnSceneChanged;
        EditorApplication.hierarchyWindowChanged += OnSceneChanged;
    }

	static void OnSceneChanged()
	{
		if (currentScene != EditorSceneManager.GetActiveScene().name)
		{
			toolEnabled = false;
			YuME_sceneGizmoFunctions.displayGizmoGrid();
            YuTools_Utils.showUnityGrid(true);
			currentScene = EditorSceneManager.GetActiveScene().name;
		}
	}

    void OnDestroy()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        EditorApplication.hierarchyWindowChanged -= OnSceneChanged;
    }

    void OnSelectionChange()
    {
        selectedTiles.Clear();

        foreach (GameObject selection in Selection.gameObjects)
        {
            if (selection.GetComponent<YuME_tileGizmo>() != null)
            {
                selectedTiles.Add(selection);
            }
        }
    }

    void Update()
    {
        Repaint();
    }

    // ----------------------------------------------------------------------------------------------------
    // ----- Draw Editor Tool GUI
    // ----------------------------------------------------------------------------------------------------

    void OnGUI()
    {
        if (GameObject.Find("YuME_MapEditorObject") == null)
        {
            setupGUI();
        }
        else
        {
            if (!checkForForzenMap())
            {
                mainGUI();
            }
            else
            {
                unFreezeMap();
            }
        }
    }

    bool checkForForzenMap()
    {
        if (findTileMapParent())
        {
            foreach (Transform chid in tileMapParent.transform)
            {
                if (chid.gameObject.name == "frozenMap")
                {
                    toolEnabled = false;
                    YuTools_Utils.showUnityGrid(true);
                    return true;
                }
            }
        }

        return false;
    }


    void unFreezeMap()
    {
        toolEnabled = false;
        EditorGUILayout.Space();

        GUILayout.Label(editorData.mapEditorHeader);

        EditorGUILayout.BeginVertical("box");

        unFreeze = GUILayout.Toggle(unFreeze, "Unfreeze Map", "Button", GUILayout.Height(30));

        if (unFreeze)
        {
            if (findTileMapParent())
            {
                foreach (Transform child in tileMapParent.transform)
                {
                    if (child.name.Contains("layer"))
                    {
                        child.gameObject.SetActive(true);
                    }
                    else if (child.gameObject.name == "frozenMap")
                    {
                        DestroyImmediate(child.gameObject);
                    }
                }
            }
            toolEnabled = true;
        }

        YuME_sceneGizmoFunctions.displayGizmoGrid();
        unFreeze = false;
        EditorGUILayout.EndVertical();
    }

    void setupGUI()
    {
        toolEnabled = false;

        EditorGUILayout.Space();

        GUILayout.Label(editorData.mapEditorHeader);

        EditorGUILayout.BeginVertical("box");

        if (GUILayout.Button("Get the full version of YuME", GUILayout.Height(30)))
        {
            Application.OpenURL("http://u3d.as/DrF");
        }

        setupScene = GUILayout.Toggle(setupScene, "Add YuME Map Editor Objects", "Button", GUILayout.Height(30));

        if (setupScene)
        {
            string[] guids;

            // ----------------------------------------------------------------------------------------------------
            // ----- Load Editor Settings
            // ----------------------------------------------------------------------------------------------------

            guids = AssetDatabase.FindAssets("YuME_MapEditorObject");
            GameObject tileParentPrefab = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guids[0]), typeof(GameObject)) as GameObject;

            tileMapParent = PrefabUtility.InstantiatePrefab(tileParentPrefab as GameObject) as GameObject;

            tileMapParent.layer = LayerMask.NameToLayer("YuME_TileMap");

            GameObject mainMap = new GameObject("YuME_MapData");
            mainMap.transform.position = Vector3.zero;

            for (int i = 1; i < 9; i++)
            {
                GameObject layer = new GameObject("layer" + i);
                layer.transform.position = Vector3.zero;
                layer.transform.parent = mainMap.transform;
            }

            EditorSceneManager.MarkAllScenesDirty();
        }

        setupScene = false;

        EditorGUILayout.EndVertical();
    }

    void mainGUI()
    {
        if (Event.current != null)
        {
            // ----------------------------------------------------------------------------------------------------
            // ----- Check Keyboard and Mouse Shortcuts
            // ----------------------------------------------------------------------------------------------------

            YuME_keyboardShortcuts.checkKeyboardShortcuts(Event.current);
            YuME_mouseShorcuts.checkMouseShortcuts(Event.current);

            SceneView.RepaintAll();
        }

        EditorGUILayout.Space();

        GUILayout.Label(editorData.mapEditorHeader);

        EditorGUILayout.BeginVertical("box");

        if (GUILayout.Button("Get the full version of YuME", GUILayout.Height(30)))
        {
            Application.OpenURL("http://u3d.as/DrF");
        }

        EditorGUILayout.BeginHorizontal();

        toolEnabled = GUILayout.Toggle(toolEnabled, "Enable YuME", "Button", GUILayout.Height(30));

        if (_toolEnabled != toolEnabled)
        {
            if (!toolEnabled)
            {
                YuTools_Utils.showUnityGrid(true);
                YuME_tileFunctions.restoreIsolatedGridTiles();
                YuME_tileFunctions.restoreIsolatedLayerTiles();
            }
            else
            {
                setTileBrush(0);
                YuTools_Utils.showUnityGrid(false);
            }

            SceneView.RepaintAll();
        }

        _toolEnabled = toolEnabled;

        openConfig = GUILayout.Toggle(openConfig, editorData.configButton, "Button", GUILayout.Width(30), GUILayout.Height(30));

        if (openConfig == true)
        {
            YuME_editorConfig editorConfig = EditorWindow.GetWindow<YuME_editorConfig>(true, "Editor Config");
            editorConfig.titleContent.text = "Editor Config";
        }

        openConfig = false;

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box");
        gridDimensions = EditorGUILayout.Vector2Field("Grid Dimensions", gridDimensions);
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Grid Height: " + gridHeight.ToString());
        GUILayout.Label("Brush Size: (" + brushSize.x.ToString() + "," + brushSize.y.ToString() + "," + brushSize.z.ToString() + ")");
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Pick The Tile Set To Use", EditorStyles.boldLabel);
        currentTileSetIndex = EditorGUILayout.Popup("Choose Tileset", currentTileSetIndex, tileSetNames);

        if (currentTileSetIndex != _currentTileSetIndex)
        {
            loadPreviewTiles();
        }

        if (GUILayout.Button("Reload Available Tilesets", GUILayout.Height(30)))
        {
            importTileSets(true);
            loadCustomBrushes();
            loadPreviewTiles(); // this is in the wrong place - it needs to be triggered when the user picks a new tileset
        }

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box");

        string[] buttonLabels = new string[] { "Tileset Brushes", "Custom Brushes" };

        brushPallete = (brushOptions)GUILayout.SelectionGrid(
            (int)brushPallete,
            buttonLabels,
            2,
            EditorStyles.toolbarButton
            );

        EditorGUILayout.EndVertical();

        drawTilePreviews();

        EditorGUILayout.BeginVertical("box");

        EditorGUILayout.LabelField("Tile Previw Columns", EditorStyles.boldLabel);
        tilePreviewColumnWidth = EditorGUILayout.IntSlider(tilePreviewColumnWidth, 1, 10);

        EditorGUILayout.EndVertical();
        
        updateGridColors();
        YuME_sceneGizmoFunctions.displayGizmoGrid();

        _currentTileSetIndex = currentTileSetIndex;

    }

    // ----------------------------------------------------------------------------------------------------
    // ----- Draw Scene Tools
    // ----------------------------------------------------------------------------------------------------

    static void OnSceneGUI(SceneView sceneView)
    {
        if (toolEnabled)
        {
            // ----------------------------------------------------------------------------------------------------
            // ----- Draw Scene Editor Tools
            // ----------------------------------------------------------------------------------------------------

            if (selectedTool > 0 && toolEnabled)
            {
                controlId = GUIUtility.GetControlID(FocusType.Passive);
                updateSceneMousePosition();
                checkTilePositionIsValid(sceneView.position);
                YuME_sceneGizmoFunctions.drawBrushGizmo();
            }

            // ----------------------------------------------------------------------------------------------------
            // ----- Draw Editor Tool Bar
            // ----------------------------------------------------------------------------------------------------

            YuME_editorSceneUI.drawToolUI(sceneView);

            // ----------------------------------------------------------------------------------------------------
            // ----- Check Keyboard and Mouse Shortcuts
            // ----------------------------------------------------------------------------------------------------

            YuME_keyboardShortcuts.checkKeyboardShortcuts(Event.current);
            YuME_mouseShorcuts.checkMouseShortcuts(Event.current);

            foreach (GameObject selected in selectedTiles)
            {
                if (selected != null)
                {
                    YuME_sceneGizmoFunctions.drawSceneGizmoCube(selected.transform.position, Vector3.one, Color.green);
                }
            }

            // ----------------------------------------------------------------------------------------------------
            // ----- Momenteray handling of the editor tool bar
            // ----------------------------------------------------------------------------------------------------

            switch (selectedTool)
            {
                case toolIcons.defaultTools:
                    YuME_brushFunctions.destroyBrushTile();
                    break;
                case toolIcons.brushTool:
                    YuME_brushFunctions.createBrushTile();
                    selectedTiles.Clear();
                    break;
                case toolIcons.pickTool:
                    YuME_brushFunctions.destroyBrushTile();
                    selectedTiles.Clear();
                    break;
                case toolIcons.eraseTool:
                    YuME_brushFunctions.destroyBrushTile();
                    selectedTiles.Clear();
                    break;
                case toolIcons.selectTool:
                    YuME_brushFunctions.destroyBrushTile();
                    break;
                case toolIcons.copyTool:
                    YuME_customBrushFunctions.createCopyBrush(false);
                    selectedTool = toolIcons.brushTool;
                    break;
                case toolIcons.moveTool:
                    YuME_customBrushFunctions.createCopyBrush(true);
                    selectedTool = toolIcons.brushTool;
                    break;
                case toolIcons.trashTool:
                    YuME_tileFunctions.trashTiles();
                    selectedTool = previousSelectedTool;
                    break;
                case toolIcons.customBrushTool:
                    YuME_customBrushFunctions.createCustomBrush();
                    selectedTool = previousSelectedTool;
                    break;
                case toolIcons.showGizmos:
                    showGizmos = !showGizmos;
                    YuTools_Utils.disableTileGizmo(showGizmos);
                    selectedTool = previousSelectedTool;
                    break;
                case toolIcons.gridUpTool:
					if(Event.current.alt)
					{
	                    gridHeight+=0.25f;
					}
					else
					{
						gridHeight++;
					}
					selectedTool = previousSelectedTool;
                    break;
                case toolIcons.gridDownTool:
					if(Event.current.alt)
					{
						gridHeight-=0.25f;
					}
					else
					{
						gridHeight--;
					}
                    selectedTool = previousSelectedTool;
                    break;
                case toolIcons.rotateTool:
                    tileRotation+=90f;
                    selectedTool = previousSelectedTool;
                    break;
                case toolIcons.flipHorizontalTool:
                    YuME_tileFunctions.flipHorizontal();
                    selectedTool = previousSelectedTool;
                    break;
                case toolIcons.flipVerticalTool:
                    YuME_tileFunctions.flipVertical();
                    selectedTool = previousSelectedTool;
                    break;
                case toolIcons.isolateTool:
                    YuME_tileFunctions.isolateTilesToggle();
                    selectedTool = previousSelectedTool;
                    break;
                case toolIcons.isolateLayerTool:
                    YuME_tileFunctions.isolateLayerToggle();
                    selectedTool = previousSelectedTool;
                    break;
                case toolIcons.layerUp:
                    currentLayer++;
                    selectedTool = previousSelectedTool;
                    break;
                case toolIcons.layerDown:
                    currentLayer--;
                    selectedTool = previousSelectedTool;
                    break;
            }

            // ----------------------------------------------------------------------------------------------------
            // ----- Check Scene View Inputs for Drawing, Picking etc.
            // ----------------------------------------------------------------------------------------------------

            if (selectedTool > toolIcons.defaultTools)
            {
                if ((Event.current.type == EventType.mouseDrag || Event.current.type == EventType.mouseDown) &&
                    Event.current.button == 0 &&
                    Event.current.alt == false &&
                    Event.current.shift == false &&
                    Event.current.control == false &&
                    allowTileRedraw)
                {
                    switch (selectedTool)
                    {
                        case toolIcons.brushTool:
                            switch (currentBrushType)
                            {
                                case brushTypes.standardBrush:
                                    addTiles();
                                    break;
                                case brushTypes.customBrush:
                                    YuME_customBrushFunctions.pasteCustomBrush(tilePosition);
                                    break;
                                case brushTypes.copyBrush:
                                    YuME_customBrushFunctions.pasteCopyBrush(tilePosition);
                                    break;
                            }
                            break;
                        case toolIcons.pickTool:
                            YuME_tileFunctions.pickTile(tilePosition);
                            break;
                        case toolIcons.eraseTool:
                            eraseTiles();
                            break;
                        case toolIcons.selectTool:
                            YuME_tileFunctions.selectTile(tilePosition);
                            break;
                    }

                    allowTileRedraw = false;
                }
                else if ((Event.current.type == EventType.mouseDrag || Event.current.type == EventType.mouseDown) &&
                    Event.current.button == 0 &&
                    Event.current.alt == false &&
                    Event.current.shift == true &&
                    Event.current.control == false &&
                    allowTileRedraw)
                {
                    switch (selectedTool)
                    {
                        case toolIcons.brushTool:
                            eraseTiles();
                            break;
                    }

                    allowTileRedraw = false;
                }
                else if ((Event.current.type == EventType.mouseDrag || Event.current.type == EventType.mouseDown) &&
                    Event.current.button == 0 &&
                    Event.current.alt == false &&
                    Event.current.shift == false &&
                    Event.current.control == true &&
                    allowTileRedraw)
                {
                    switch (selectedTool)
                    {
                        case toolIcons.brushTool:
                            YuME_tileFunctions.pickTile(tilePosition);
                            break;
                        case toolIcons.selectTool:
                            YuME_tileFunctions.deSelectTile(tilePosition);
                            break;
                    }

                    allowTileRedraw = false;
                }

                HandleUtility.AddDefaultControl(controlId);
            }

            if(showGizmos)
            {
                if(selectedTiles.Count > 0)
                {
                    foreach(GameObject tile in selectedTiles)
                    {
                        YuME_sceneGizmoFunctions.handleInfo data;
                        data.tileName = tile.name;
                        data.layer = tile.transform.parent.name;
                        data.grid = tile.transform.position.y;
                        YuME_sceneGizmoFunctions.drawTileInfo(tile.transform.position, data);
                    }
                }
            }

            // ----------------------------------------------------------------------------------------------------
            // ----- Scene Housekeeping
            // ----------------------------------------------------------------------------------------------------

            YuME_brushFunctions.updateBrushPosition();
            repaintSceneView();
            previousSelectedTool = selectedTool;
        }
    }

    public static void addTiles()
    {
        if (standardBrushSize)
        {
            YuME_tileFunctions.eraseTile(tilePosition);
            YuME_tileFunctions.addTile(tilePosition);
        }
        else
        {
            Vector3 newTilePos = tilePosition;

            for (int y = 0; y < (int)brushSize.y; y++)
            {
                newTilePos.y = tilePosition.y + y;
                newTilePos.z = tilePosition.z - ((brushSize.z - 1) / 2);

                for (int z = 0; z < (int)brushSize.z; z++)
                {
                    newTilePos.x = tilePosition.x - ((brushSize.x - 1) / 2);
                    for (int x = 0; x < (int)brushSize.x; x++)
                    {
                        YuME_tileFunctions.eraseTile(newTilePos);
                        YuME_tileFunctions.addTile(newTilePos);
                        newTilePos.x++;
                    }
                    newTilePos.z++;
                }
            }
        }
    }

    public static void eraseTiles()
    {
        if (standardBrushSize)
        {
            YuME_tileFunctions.eraseTile(tilePosition);
        }
        else
        {
            Vector3 newTilePos = tilePosition;

            for (int y = 0; y < (int)brushSize.y; y++)
            {
                newTilePos.y = tilePosition.y + y;
                newTilePos.z = tilePosition.z - ((brushSize.z - 1) / 2);

                for (int z = 0; z < (int)brushSize.z; z++)
                {
                    newTilePos.x = tilePosition.x - ((brushSize.x - 1) / 2);
                    for (int x = 0; x < (int)brushSize.x; x++)
                    {
                        YuME_tileFunctions.eraseTile(newTilePos);
                        newTilePos.x++;
                    }
                    newTilePos.z++;
                }
            }
        }
    }

    static void repaintSceneView()
    {
        if (tilePosition != oldTilePosition)
        {
            SceneView.RepaintAll();
            allowTileRedraw = true;
            oldTilePosition = tilePosition;
        }
    }

    // ----------------------------------------------------------------------------------------------------
    // ----- Tileset functions for preview in the editor window
    // ----------------------------------------------------------------------------------------------------

    public static void importTileSets(bool fullRescan)
    {
        // find all assest of type YuME_tileSetData
        string[] guids = AssetDatabase.FindAssets("t:YuME_tileSetData");

        if (guids.Length > 0)
        {
            availableTileSets = new List<YuME_tilesetData>();

            foreach (string guid in guids)
            {
                YuME_tilesetData tempData = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(YuME_tilesetData)) as YuME_tilesetData;

                if (fullRescan)
                {
                    EditorUtility.DisplayProgressBar("Reloading Tile Set: " + tempData.name, "Note: Reimport can take some time to complete", 0f);
                    string path = YuTools_Utils.getAssetPath(tempData);
                    string[] containedPrefabs = YuTools_Utils.getDirectoryContents(YuTools_Utils.getAssetPath(tempData), "*.prefab");

                    if (containedPrefabs != null)
                    {
                        foreach (string prefab in containedPrefabs)
                        {
                            AssetDatabase.ImportAsset(path + prefab);
                        }
                    }
                    if (tempData != null)
                    {
                        path = YuTools_Utils.getAssetPath(tempData) + "CustomBrushes/";
                        containedPrefabs = YuTools_Utils.getDirectoryContents(YuTools_Utils.getAssetPath(tempData) + "CustomBrushes/", "*.prefab");

                        if (containedPrefabs != null)
                        {
                            foreach (string prefab in containedPrefabs)
                            {
                                AssetDatabase.ImportAsset(path + prefab);
                            }
                        }
                    }
                }

                availableTileSets.Add(tempData);
            }

            if (fullRescan)
            {
                EditorUtility.ClearProgressBar();
            }

            tileSetNames = new string[availableTileSets.Count];

            for (int i = 0; i < availableTileSets.Count; i++)
            {
                tileSetNames[i] = availableTileSets[i].tileSetName;
            }

			loadPreviewTiles();

        }
        else
        {
            Debug.Log("No tile sets have been created");
        }
    }

    static void loadPreviewTiles()
    {
        try
        {
            string path = YuTools_Utils.getAssetPath(availableTileSets[currentTileSetIndex]);

            currentTileSetObjects = YuTools_Utils.loadDirectoryContents(path, "*.prefab");
            currentTile = currentTileSetObjects[0];
        }
        catch
        {
            Debug.Log("Tile Sets seem to be missing. Please reload the tile sets");
        }
    }

    public static void loadCustomBrushes()
    {
        try
        {
            string path = YuTools_Utils.getAssetPath(availableTileSets[currentTileSetIndex]) + "CustomBrushes";

            if (path != null)
            {
                currentCustomBrushes = YuTools_Utils.loadDirectoryContents(path, "*_YuME.prefab");

                if (currentCustomBrushes == null)
                {
                    createCustomBrushFolder(path);
                }
            }
        }
        catch
        {
            Debug.Log("Custom Brush Folder missing");
        }
    }

    static void drawTilePreviews()
    {
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

        int horizontalCounter = 0;

        EditorGUILayout.BeginHorizontal();

        if (brushPallete == brushOptions.tilesetBrush)
        {
            if (currentTileSetObjects != null)
            {
                for (int i = 0; i < currentTileSetObjects.Length; i++)
                {
                    if(currentTileSetObjects[i] != null)
                    {
                        EditorGUILayout.BeginVertical();

                        drawTileButtons(i);
                        EditorGUILayout.BeginHorizontal("Box");
                        EditorGUILayout.LabelField(currentTileSetObjects[i].name, GUILayout.MaxWidth(132));
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.EndVertical();

                        horizontalCounter++;

                        if (horizontalCounter == tilePreviewColumnWidth)
                        {
                            horizontalCounter = 0;
                            EditorGUILayout.EndHorizontal();
                            EditorGUILayout.BeginHorizontal();
                        }
                    }
                }
            }
        }
        else if (brushPallete == brushOptions.customBrush)
        {
            if (currentCustomBrushes != null)
            {
                for (int i = 0; i < currentCustomBrushes.Length; i++)
                {
                    drawCustomBrushButtons(i);
                    horizontalCounter++;
                    if (horizontalCounter == tilePreviewColumnWidth)
                    {
                        horizontalCounter = 0;
                        EditorGUILayout.EndHorizontal();
                        EditorGUILayout.BeginHorizontal();
                    }
                }
            }
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();
    }

    static void drawTileButtons(int index)
    {
        if(currentTileSetObjects[index] != null)
        {
            //By passing a Prefab or GameObject into AssetPreview.GetAssetPreview you get a texture that shows this object
            Texture2D previewImage = AssetPreview.GetAssetPreview(currentTileSetObjects[index]);
            GUIContent buttonContent = new GUIContent(previewImage);

            bool isActive = false;

            if (currentTile.name == currentTileSetObjects[index].name)
            {
                isActive = true;
            }

            bool isToggleDown = GUILayout.Toggle(isActive, buttonContent, GUI.skin.button);

            //If this button is clicked but it wasn't clicked before (ie. if the user has just pressed the button)
            if (isToggleDown == true && isActive == false)
            {
                setTileBrush(index);
            }
        }
    }

    public static void setTileBrush(int index)
    {
        currentBrushIndex = index;
        currentBrushType = brushTypes.standardBrush;
        currentTile = currentTileSetObjects[index];
        tileRotation = 0f;
        YuME_brushFunctions.updateBrushTile();
        selectedTool = toolIcons.brushTool;
    }

    static void drawCustomBrushButtons(int index)
    {
        Texture2D previewImage = AssetPreview.GetAssetPreview(currentCustomBrushes[index]);
        GUIContent buttonContent = new GUIContent(previewImage);

        bool isActive = false;

        if (currentTile.name == currentCustomBrushes[index].name)
        {
            isActive = true;
        }

        EditorGUILayout.BeginVertical();

        bool isToggleDown = GUILayout.Toggle(isActive, buttonContent, GUI.skin.button);

        if (isToggleDown == true && isActive == false)
        {
            currentTile = currentCustomBrushes[index];
            currentBrushType = brushTypes.customBrush;
            tileRotation = 0f;
            YuME_brushFunctions.updateBrushTile();
            selectedTool = toolIcons.brushTool;
        }

        if (GUILayout.Button("Delete Brush"))
        {
            if (EditorUtility.DisplayDialog("Delete Custom Brush?", "Are you sure you want to delete the custom brush prefab from the project", "Delete", "No"))
            {
                string destinationPath = availableTileSets[currentTileSetIndex].customBrushDestinationFolder + "/" + currentCustomBrushes[index].name + ".prefab";
                AssetDatabase.DeleteAsset(destinationPath);
                loadCustomBrushes();
            }
        }

        EditorGUILayout.EndVertical();
    }

    // ----------------------------------------------------------------------------------------------------
    // ----- Make sure the editor aways has the essential scene objects
    // ----------------------------------------------------------------------------------------------------
    
    public static bool findEditorGameObject()
    {
        editorGameObject = GameObject.Find("YuME_MapEditorObject");

        if (editorGameObject != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool findTileMapParent()
    {
        tileMapParent = GameObject.Find("YuME_MapData");

        if (tileMapParent != null)
        {
            int i = 0;
            foreach (Transform child in tileMapParent.transform)
            {
                if (child.name.Contains("layer"))
                {
                    mapLayers[i] = child.gameObject;
                    i++;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    void updateGridColors()
    {
        if (gridSceneObject == null)
        {
            gridSceneObject = GameObject.Find("YuME_MapEditorObject");
        }
        else
        {
            if (_gridColorBorder != editorData.gridColorBorder || _gridColorFill != editorData.gridColorFill || _gridColorNormal != editorData.gridColorNormal)
            {
                gridSceneObject.GetComponent<YuME_GizmoGrid>().gridColorNormal = editorData.gridColorNormal;
                gridSceneObject.GetComponent<YuME_GizmoGrid>().gridColorFill = editorData.gridColorFill;
                gridSceneObject.GetComponent<YuME_GizmoGrid>().gridColorBorder = editorData.gridColorBorder;

                _gridColorBorder = editorData.gridColorBorder;
                _gridColorFill = editorData.gridColorFill;
                _gridColorNormal = editorData.gridColorNormal;

                SceneView.RepaintAll();
            }

        }
    }

    // ----------------------------------------------------------------------------------------------------
    // ----- Check Mouse Positions
    // ----------------------------------------------------------------------------------------------------

    static void checkTilePositionIsValid(Rect sceneViewRect)
    {
        //Make sure the cube handle is only drawn when the mouse is within a position that we want
        //In this case we simply hide the cube cursor when the mouse is hovering over custom GUI elements in the lower
        //are of the sceneView which we will create in E07
        bool isInValidArea = Event.current.mousePosition.y < sceneViewRect.height - 35;

        if (isInValidArea != validTilePosition)
        {
            validTilePosition = isInValidArea;
            SceneView.RepaintAll();
        }
    }

    static void updateSceneMousePosition()
    {
        if (Event.current == null)
        {
            return;
        }

        Vector2 mousePosition = new Vector2(Event.current.mousePosition.x, Event.current.mousePosition.y);

        Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("YuME_TileMap")) == true)
        {
            hit.point += new Vector3(0.5f, -0.5f, 0.5f); // Offset to get the correct mouse poition in scene
            Vector3 offset = hit.normal;

            tilePosition.x = Mathf.Floor(hit.point.x - hit.normal.x * 0.001f + offset.x);
			tilePosition.y = gridHeight;
            tilePosition.z = Mathf.Floor(hit.point.z - hit.normal.z * 0.001f + offset.z);
        }
    }

    // ----------------------------------------------------------------------------------------------------
    // ----- Custom Brush File System Functions
    // ----------------------------------------------------------------------------------------------------

    public static void createCustomBrushFolder(string path)
    {
        Debug.Log("Directory" + path + " is missing. Creating now."); // No folder can be found so lets create on
        string newPath = path.Replace("/CustomBrushes", "");
        AssetDatabase.CreateFolder(newPath, "CustomBrushes");
    }

    // ----------------------------------------------------------------------------------------------------
    // ----- Tool Settings
    // ----------------------------------------------------------------------------------------------------

    public static int toolSelect
    {
        get
        {
            return EditorPrefs.GetInt("selectedTool", 0);
        }
        set
        {
            EditorPrefs.SetInt("selectedTool", value);
        }
    }

    public static bool toolEnabled
    {
        get
        {
            return EditorPrefs.GetBool("toolEnabled", true);
        }
        set
        {
            EditorPrefs.SetBool("toolEnabled", value);
        }
    }

    public static int currentTileSetIndex
    {
        get
        {
            return EditorPrefs.GetInt("currentTileSetIndex", 0);
        }
        set
        {
            EditorPrefs.SetInt("currentTileSetIndex", value);
        }
    }

    public static int tilePreviewColumnWidth
    {
        get
        {
            return EditorPrefs.GetInt("tilePreviewColumnWidth", 2);
        }
        set
        {
            EditorPrefs.SetInt("tilePreviewColumnWidth", value);
        }
    }

    public static float gridHeight
    {
        get
        {
            GameObject tempGrid = GameObject.Find("YuME_MapEditorObject");

            if (tempGrid != null)
            {
                return GameObject.Find("YuME_MapEditorObject").GetComponent<YuME_GizmoGrid>().gridHeight;
            }
            else
            {
                return 0;
            }
        }
        set
        {
            GameObject tempGrid = GameObject.Find("YuME_MapEditorObject");

            if (tempGrid != null)
            {
                tempGrid.GetComponent<YuME_GizmoGrid>().gridHeight = value;
                tempGrid.GetComponent<YuME_GizmoGrid>().moveGrid();
            }
        }
    }

    public static float gridOffset
    {
        get
        {
            return editorData.gridOffset;
        }
        set
        {
            GameObject gridTemp = GameObject.Find("YuME_MapEditorObject");
            editorData.gridOffset = value;
            gridTemp.GetComponent<YuME_GizmoGrid>().gridOffset = value;
        }
    }

    public static Vector2 gridDimensions
    {
        get
        {
            GameObject gridTemp = GameObject.Find("YuME_MapEditorObject");
            if (gridTemp != null)
            {
                Vector2 tempV2;
                tempV2.x = gridTemp.GetComponent<YuME_GizmoGrid>().gridWidth;
                tempV2.y = gridTemp.GetComponent<YuME_GizmoGrid>().gridDepth;
                return tempV2;
            }
            else
            {
                return Vector2.zero;
            }
        }
        set
        {
            GameObject gridTemp = GameObject.Find("YuME_MapEditorObject");
            if (gridTemp != null)
            {
                gridTemp.GetComponent<YuME_GizmoGrid>().gridWidth = (int)value.x;
                gridTemp.GetComponent<YuME_GizmoGrid>().gridDepth = (int)value.y;
                Vector3 tempGridSize;
                tempGridSize.x = (int)value.x;
                tempGridSize.y = 0.1f;
                tempGridSize.z = (int)value.y;
                gridTemp.GetComponent<BoxCollider>().size = tempGridSize;
            }
        }
    }

    public static bool standardBrushSize
    {
        get
        {
            if (brushSize.x == 1f && brushSize.y == 1f && brushSize.z == 1f)
                return true;
            else
                return false;
        }

    }

	public static Vector3 brushSize
	{
		get
		{
			return _brushSize;
		}
		set
		{
			_brushSize = value;

            if (_brushSize.x < 1f) _brushSize.x = 1f;
            if (_brushSize.y < 1f) _brushSize.y = 1f;
            if (_brushSize.z < 1f) _brushSize.z = 1f;
        }
    }

    public static int currentLayer
    {
        get
        {
            return _currentLayer;
        }
        set
        {
            _currentLayer = value;

            if (_currentLayer > 8)
            {
                _currentLayer = 8;
            }
            else if (_currentLayer < 1)
            {
                _currentLayer = 1;
            }
        }
    }

    public static float tileRotation
    {
        get
        {
            return _tileRotation;
        }
        set
        {
            _tileRotation = value;

            if (_tileRotation >= 360)
            {
                _tileRotation = 0f;
            }
            else if (_tileRotation < 0f)
            {
                _tileRotation = 270f;
            }

        }
    }
}
