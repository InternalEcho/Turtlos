using UnityEngine;
using System.Collections;

public class YuME_GizmoGrid : MonoBehaviour
{
    [HideInInspector]
    public int tileSizeX = 1;
    [HideInInspector]
    public int tileSizeZ = 1;
    [HideInInspector]
    public int gridWidth = 11;
    [HideInInspector]
    public int gridDepth = 11;

    [HideInInspector]
    public float gridHeight
    {
        get
        {
            return _gridHeight;
        }
        set
        {
            _gridHeight = value;
        }
    }

    float _gridHeight = 0;

    [HideInInspector]
    public bool toolEnabled = true;

	public float gridOffset = 0.01f;

    float gridXYOffset = 0.5f;
    float gridYOffset = 0.5f;

    [HideInInspector]
    public Color gridColorNormal = Color.white;
    [HideInInspector]
    public Color gridColorBorder = Color.green;
    [HideInInspector]
    public Color gridColorFill = new Color(1, 0, 0, 0.5F);

    float gridWidthOffset;
    float gridDepthOffset;

    Vector3 gridColliderPosition;
    Vector3 gridColliderSize;
    BoxCollider gridCollider;

    void OnEnable()
    {
        gameObject.SetActive(false);
    }

    void OnDrawGizmos()
    {
        if (toolEnabled)
        {
            gridWidthOffset = gridWidth / 2;
            gridDepthOffset = gridDepth / 2;

            Gizmos.color = gridColorFill;
			Gizmos.DrawCube(new Vector3(0 - gridXYOffset, gridHeight - gridYOffset - gridOffset, 0- gridXYOffset), new Vector3(gridWidth, 0.01f, gridDepth));

            Gizmos.color = gridColorNormal;
            GridGizmo();

            Gizmos.color = gridColorBorder;
            GridFrameBorder();
            moveGrid();
        }
    }

    public void moveGrid()
    {
        gridColliderPosition = gameObject.GetComponent<BoxCollider>().center;
        gridColliderPosition.y = gridHeight - 0.5f;
        gameObject.GetComponent<BoxCollider>().center = gridColliderPosition;
    }

    private void GridFrameBorder()
    {
		Gizmos.DrawLine(new Vector3(0 - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, 0 - gridDepthOffset - gridXYOffset), 
			new Vector3(0 - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, gridDepth - gridDepthOffset - gridXYOffset));

		Gizmos.DrawLine(new Vector3(0 - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, 0 - gridDepthOffset - gridXYOffset), 
			new Vector3(gridWidth - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, 0 - gridDepthOffset - gridXYOffset));

		Gizmos.DrawLine(new Vector3(gridWidth - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, gridDepth - gridDepthOffset - gridXYOffset), 
			new Vector3(gridWidth - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, 0 - gridDepthOffset - gridXYOffset));

		Gizmos.DrawLine(new Vector3(0 - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, gridDepth - gridDepthOffset - gridXYOffset), 
			new Vector3(gridWidth - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, gridDepth - gridDepthOffset - gridXYOffset));
    }

    private void GridGizmo()
    {
        if (tileSizeX != 0)
        {
            for (int i = tileSizeX; i < gridWidth; i += tileSizeX)
            {
                Gizmos.DrawLine(
					new Vector3((float)i - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, 0 - gridDepthOffset - gridXYOffset),
					new Vector3((float)i - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, gridDepth - gridDepthOffset - gridXYOffset));
            }
        }

        if (tileSizeZ != 0)
        {
            for (int j = tileSizeZ; j < gridDepth; j += tileSizeZ)
            {
                Gizmos.DrawLine(
					new Vector3(0 - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, j - gridDepthOffset - gridXYOffset),
					new Vector3(gridWidth - gridWidthOffset - gridXYOffset, gridHeight - gridYOffset - gridOffset, j - gridDepthOffset - gridXYOffset));
            }
        }
    }
}
