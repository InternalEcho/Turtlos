using UnityEngine;
using UnityEditor;

public class YuME_mouseShorcuts : EditorWindow 
{
	public static void checkMouseShortcuts(Event mouseEvent)
	{
        if (mouseEvent.type == EventType.scrollWheel && mouseEvent.shift && !mouseEvent.control && !mouseEvent.alt)
        {
            mouseEvent.Use();

            if (Event.current.delta.y >= 0f)
            {
                YuME_mapEditor.gridHeight++;
            }
            else
            {
                YuME_mapEditor.gridHeight--;
            }
            
        }
        if (mouseEvent.type == EventType.scrollWheel && mouseEvent.shift && mouseEvent.alt && !mouseEvent.control)
        {
            mouseEvent.Use();

            if (Event.current.delta.y >= 0f)
            {
                YuME_mapEditor.gridHeight+=0.25f;
            }
            else
            {
                YuME_mapEditor.gridHeight-=0.25f;
            }

        }
        else if (mouseEvent.type == EventType.scrollWheel && mouseEvent.control && mouseEvent.alt && YuME_mapEditor.selectedTool == YuME_mapEditor.toolIcons.brushTool)
		{
			mouseEvent.Use();

			if (Event.current.delta.y >= 0f)
			{
				YuME_mapEditor.tileRotation+=90f;
			}
			else
			{
				YuME_mapEditor.tileRotation-=90f;
			}
		}
        else if(mouseEvent.type == EventType.scrollWheel && mouseEvent.control && mouseEvent.shift == true && YuME_mapEditor.selectedTool == YuME_mapEditor.toolIcons.brushTool)
        {
            mouseEvent.Use();

            YuME_mapEditor.currentBrushType = YuME_mapEditor.brushTypes.standardBrush;

            if (Event.current.delta.y > 0f)
            {
                YuME_mapEditor.currentBrushIndex++;

                if (YuME_mapEditor.currentBrushIndex >= YuME_mapEditor.currentTileSetObjects.Length)
                {
                    YuME_mapEditor.currentBrushIndex = YuME_mapEditor.currentTileSetObjects.Length - 1;
                }

                YuME_mapEditor.currentTile = YuME_mapEditor.currentTileSetObjects[YuME_mapEditor.currentBrushIndex];
                YuME_mapEditor.currentTile.transform.eulerAngles = new Vector3(0f, YuME_mapEditor.tileRotation, 0f);
                YuME_brushFunctions.updateBrushTile();
            }
            else
            {
                YuME_mapEditor.currentBrushIndex--;

                if(YuME_mapEditor.currentBrushIndex < 0)
                {
                    YuME_mapEditor.currentBrushIndex = 0;
                }

                YuME_mapEditor.currentTile = YuME_mapEditor.currentTileSetObjects[YuME_mapEditor.currentBrushIndex];
				YuME_mapEditor.currentTile.transform.eulerAngles = new Vector3(0f, YuME_mapEditor.tileRotation, 0f);
                YuME_brushFunctions.updateBrushTile();
            }
        }
	}
}
