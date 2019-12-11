using UnityEngine;
using UnityEditor;

public class YuME_sceneGizmoFunctions : EditorWindow 
{
	public static void drawBrushGizmo()
	{
		if (YuME_mapEditor.validTilePosition == false)
		{
			return;
		}

		if(YuME_mapEditor.pickToolOverride || YuME_mapEditor.selectedTool == YuME_mapEditor.toolIcons.pickTool)
		{
			drawSceneGizmoCube(YuME_mapEditor.tilePosition, Vector3.one, YuME_mapEditor.editorData.pickCursorColor);
		}
		else if(YuME_mapEditor.eraseToolOverride || YuME_mapEditor.selectedTool == YuME_mapEditor.toolIcons.eraseTool)
		{
			drawSceneGizmoCube(YuME_mapEditor.tilePosition, YuME_mapEditor.brushSize, YuME_mapEditor.editorData.eraseCursorColor);
		}
		else
		{
			drawSceneGizmoCube(YuME_mapEditor.tilePosition, YuME_mapEditor.brushSize, YuME_mapEditor.editorData.brushCursorColor);
		}
	}

	public static void drawSceneGizmoCube(Vector3 position, Vector3 brushSize, Color gizmoColor)
    {
        Handles.color = gizmoColor;

		var half = brushSize / 2;

        // draw front
        Handles.DrawLine(position + new Vector3(-half.x, -0.5f, half.z), position + new Vector3(half.x, -0.5f, half.z));
        Handles.DrawLine(position + new Vector3(-half.x, -0.5f, half.z), position + new Vector3(-half.x, brushSize.y - 0.5f, half.z));
        Handles.DrawLine(position + new Vector3(half.x, brushSize.y - 0.5f, half.z), position + new Vector3(half.x, -0.5f, half.z));
        Handles.DrawLine(position + new Vector3(half.x, brushSize.y - 0.5f, half.z), position + new Vector3(-half.x, brushSize.y - 0.5f, half.z));
        // draw back
        Handles.DrawLine(position + new Vector3(-half.x, -0.5f, -half.z), position + new Vector3(half.x, -0.5f, -half.z));
        Handles.DrawLine(position + new Vector3(-half.x, -0.5f, -half.z), position + new Vector3(-half.x, brushSize.y - 0.5f, -half.z));
        Handles.DrawLine(position + new Vector3(half.x, brushSize.y - 0.5f, -half.z), position + new Vector3(half.x, -0.5f, -half.z));
        Handles.DrawLine(position + new Vector3(half.x, brushSize.y - 0.5f, -half.z), position + new Vector3(-half.x, brushSize.y - 0.5f, -half.z));
        // draw corners
        Handles.DrawLine(position + new Vector3(-half.x, -0.5f, -half.z), position + new Vector3(-half.x, -0.5f, half.z));
        Handles.DrawLine(position + new Vector3(half.x, -0.5f, -half.z), position + new Vector3(half.x, -0.5f, half.z));
        Handles.DrawLine(position + new Vector3(-half.x, brushSize.y - 0.5f, -half.z), position + new Vector3(-half.x, brushSize.y - 0.5f, half.z));
        Handles.DrawLine(position + new Vector3(half.x, brushSize.y - 0.5f, -half.z), position + new Vector3(half.x, brushSize.y - 0.5f, half.z));
    }

    public static void displayGizmoGrid()
	{
		if (YuME_mapEditor.findEditorGameObject())
		{
			YuME_mapEditor.editorGameObject.GetComponent<YuME_GizmoGrid>().toolEnabled = YuME_mapEditor.toolEnabled;
		}
	}

    public struct handleInfo
    {
        public string tileName;
        public float grid;
        public string layer;
    }

    public static void drawTileInfo(Vector3 position, handleInfo info)
    {
        Handles.color = Color.white;
        Handles.Label(position, info.tileName);
        position.y -= 0.15f;
        Handles.Label(position, "Grid Height: " + info.grid);
        position.y -= 0.15f;
        Handles.Label(position, "Layer: " + info.layer);
    }
}
