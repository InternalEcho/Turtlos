using UnityEngine;
using UnityEditor;

public class YuME_editorSceneUI : EditorWindow 
{
    //static bool _isolateTiles = false;

	// ----------------------------------------------------------------------------------------------------
	// ----- Editor Tool Bar
	// ----------------------------------------------------------------------------------------------------

	public static void drawToolUI(SceneView sceneView)
	{
        Handles.BeginGUI();

        // ----------------------------------------------------------------------------------------------------
        // ----- Draw Vertical Tool Bar
        // ----------------------------------------------------------------------------------------------------

        GUI.skin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Scene);

        for (int i = 0; i < YuME_mapEditor.editorData.primaryIconData.Count; i++)
		{
			drawToolIcons(i);
		}

        for (int i = 0; i < YuME_mapEditor.editorData.secondaryIconData.Count; i++)
        {
            drawSecondaryToolIcons(i, sceneView.position);
        }

		if (YuME_mapEditor.selectedTiles.Count > 0)
        {
            for (int i = 0; i < YuME_mapEditor.editorData.selectIconData.Count; i++)
            {
                drawSelectToolIcons(i, sceneView.position);
            }
        }

        // ----------------------------------------------------------------------------------------------------
        // ----- Draw Layer Bar
        // ----------------------------------------------------------------------------------------------------

        drawLayerToolIcons(sceneView.position);

        Handles.EndGUI();
	}

    static void drawToolIcons(int index)
	{
		bool isActive = false;

        if (YuME_mapEditor.selectedTool == (YuME_mapEditor.toolIcons)index)
        {
            isActive = true;
        }

        GUIContent buttonContent;
        buttonContent = new GUIContent(YuME_mapEditor.editorData.primaryIconData[index], YuME_mapEditor.editorData.primaryIconTooltip[index]);

        bool overrideSelection = false;

        if(YuME_mapEditor.eraseToolOverride && index == (int)YuME_mapEditor.toolIcons.eraseTool)
        {
            overrideSelection = true;
        }

        if (YuME_mapEditor.pickToolOverride && index == (int)YuME_mapEditor.toolIcons.pickTool)
        {
            overrideSelection = true;
        }

        if (overrideSelection)
        {
            GUI.Toggle(new Rect(10, index * YuME_mapEditor.editorData.iconWidth + 10, YuME_mapEditor.editorData.iconWidth, YuME_mapEditor.editorData.iconWidth), overrideSelection, buttonContent, GUI.skin.button);

        }
        else
        {
            bool isToggleDown = GUI.Toggle(new Rect(10, index * YuME_mapEditor.editorData.iconWidth + 10, YuME_mapEditor.editorData.iconWidth, YuME_mapEditor.editorData.iconWidth), isActive, buttonContent, GUI.skin.button);

            if (isToggleDown == true && isActive == false)
            {
                YuME_mapEditor.selectedTool = (YuME_mapEditor.toolIcons)index;
            }
        }
    }

    static void drawSecondaryToolIcons(int index, Rect position)
    {
        bool isActive = false;
        int toolOffeset = YuME_mapEditor.editorData.primaryIconData.Count;

        if (YuME_mapEditor.selectedTool == (YuME_mapEditor.toolIcons)index + toolOffeset)
        {
            isActive = true;
        }

        GUIContent buttonContent;
        buttonContent = new GUIContent(YuME_mapEditor.editorData.secondaryIconData[index], YuME_mapEditor.editorData.secondaryIconTooltip[index]);

        bool isToggleDown = GUI.Toggle(new Rect((index * -1) * YuME_mapEditor.editorData.iconWidth + position.width - YuME_mapEditor.editorData.iconWidth - 10,
            position.height - 25 - YuME_mapEditor.editorData.iconWidth,
            YuME_mapEditor.editorData.iconWidth, 
            YuME_mapEditor.editorData.iconWidth), isActive, buttonContent, GUI.skin.button);

        if (isToggleDown == true && isActive == false)
        {
            YuME_mapEditor.selectedTool = (YuME_mapEditor.toolIcons)index + toolOffeset;
        }

        if (index + toolOffeset == (int)YuME_mapEditor.toolIcons.isolateTool)
        {
            isActive = YuME_mapEditor.isolateTiles;

            GUI.Toggle(new Rect((index * -1) * YuME_mapEditor.editorData.iconWidth + position.width - YuME_mapEditor.editorData.iconWidth - 10, 
                position.height - 25 - YuME_mapEditor.editorData.iconWidth, 
                YuME_mapEditor.editorData.iconWidth, 
                YuME_mapEditor.editorData.iconWidth), isActive, buttonContent, GUI.skin.button);
        }

        if (index + toolOffeset == (int)YuME_mapEditor.toolIcons.showGizmos)
        {
            isActive = YuME_mapEditor.showGizmos;

            GUI.Toggle(new Rect((index * -1) * YuME_mapEditor.editorData.iconWidth + position.width - YuME_mapEditor.editorData.iconWidth - 10,
                position.height - 25 - YuME_mapEditor.editorData.iconWidth,
                YuME_mapEditor.editorData.iconWidth,
                YuME_mapEditor.editorData.iconWidth), isActive, buttonContent, GUI.skin.button);
        }
    }

    static void drawSelectToolIcons(int index, Rect position)
    {
        bool isActive = false;
        int toolOffeset = YuME_mapEditor.editorData.primaryIconData.Count + YuME_mapEditor.editorData.secondaryIconData.Count;
        float screenOffset = YuME_mapEditor.editorData.iconWidth * YuME_mapEditor.editorData.primaryIconData.Count;

        if (YuME_mapEditor.selectedTool == (YuME_mapEditor.toolIcons)index + toolOffeset)
        {
            isActive = true;
        }

        GUIContent buttonContent;
        buttonContent = new GUIContent(YuME_mapEditor.editorData.selectIconData[index], YuME_mapEditor.editorData.selectionIconTooltip[index]);

        bool isToggleDown = GUI.Toggle(new Rect(10, index * YuME_mapEditor.editorData.iconWidth + screenOffset + 16f, YuME_mapEditor.editorData.iconWidth, YuME_mapEditor.editorData.iconWidth), isActive, buttonContent, GUI.skin.button);
        //bool isToggleDown = GUI.Toggle(new Rect(10, index * YuME_mapEditor.editorData.iconWidth + 192, YuME_mapEditor.editorData.iconWidth, YuME_mapEditor.editorData.iconWidth), isActive, buttonContent, GUI.skin.button);

        if (isToggleDown == true && isActive == false)
        {
            YuME_mapEditor.selectedTool = (YuME_mapEditor.toolIcons)index + toolOffeset;
        }
    }

    static void drawLayerToolIcons(Rect position)
    {
        bool isActive = false;

        isActive = YuME_mapEditor.isolateLayer;

        GUIContent buttonContent;
        buttonContent = new GUIContent(YuME_mapEditor.editorData.layerIconData[0], YuME_mapEditor.editorData.layerIconTooltip[0]);

        bool isToggleDown = GUI.Toggle(new Rect(10, position.height - 25 - YuME_mapEditor.editorData.iconWidth, YuME_mapEditor.editorData.iconWidth, YuME_mapEditor.editorData.iconWidth), isActive, buttonContent, GUI.skin.button);

        if (isToggleDown == true && isActive == false)
        {
            YuME_mapEditor.selectedTool = YuME_mapEditor.toolIcons.isolateLayerTool;
        }
        else if (isToggleDown == false && isActive == true)
        {
            YuME_mapEditor.selectedTool = YuME_mapEditor.toolIcons.isolateLayerTool;
        }

        GUILayout.BeginArea(new Rect(10 + YuME_mapEditor.editorData.iconWidth + 2, position.height - 25 - (YuME_mapEditor.editorData.iconWidth / 2), YuME_mapEditor.editorData.iconWidth * 2, YuME_mapEditor.editorData.iconWidth / 2), EditorStyles.textArea);
        {
            GUILayout.Label(YuME_mapEditor.editorData.layerNames[YuME_mapEditor.currentLayer-1], EditorStyles.label, GUILayout.Width(YuME_mapEditor.editorData.iconWidth * 2));
        }
        GUILayout.EndArea();

        isActive = false;

        if (YuME_mapEditor.selectedTool == YuME_mapEditor.toolIcons.layerUp)
        {
            isActive = true;
        }
        
        buttonContent = new GUIContent(YuME_mapEditor.editorData.layerIconData[1], YuME_mapEditor.editorData.layerIconTooltip[1]);

        isToggleDown = GUI.Toggle(new Rect(10 + YuME_mapEditor.editorData.iconWidth + 2, position.height - 25 - YuME_mapEditor.editorData.iconWidth, YuME_mapEditor.editorData.iconWidth, YuME_mapEditor.editorData.iconWidth / 2), isActive, buttonContent, GUI.skin.button);

        if (isToggleDown == true && isActive == false)
        {
            YuME_mapEditor.selectedTool = YuME_mapEditor.toolIcons.layerUp;
        }

        isActive = false;

        if (YuME_mapEditor.selectedTool == YuME_mapEditor.toolIcons.layerDown)
        {
            isActive = true;
        }

        buttonContent = new GUIContent(YuME_mapEditor.editorData.layerIconData[2], YuME_mapEditor.editorData.layerIconTooltip[2]);

        isToggleDown = GUI.Toggle(new Rect(10 + (YuME_mapEditor.editorData.iconWidth * 2) + 2, position.height - 25 - YuME_mapEditor.editorData.iconWidth, YuME_mapEditor.editorData.iconWidth, YuME_mapEditor.editorData.iconWidth / 2), isActive, buttonContent, GUI.skin.button);

        if (isToggleDown == true && isActive == false)
        {
            YuME_mapEditor.selectedTool = YuME_mapEditor.toolIcons.layerDown;
        }
    }
}
