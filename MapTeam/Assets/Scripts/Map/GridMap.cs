using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{

    public GameObject DefaultTerrain;
    public GridCell[,] internalGrid;
    public int lengthX = 100;
    public int lengthY = 100;
    public GameObject player0;
    public GameObject player1;
    private int player0PositionOnGridX;
    private int player0PositionOnGridY;
    private int player1PositionOnGridX;
    private int player1PositionOnGridY;

	public int offsetX;
	public int offsetY;

    //Determining position for center of each X and Y axis of the grid.
    private float findingMiddleValueX, findingMiddleValueY, middleValueX, middleValueXpair, middleValueY, middleValueYpair;
    private bool pairNumber;
    [HideInInspector]
    public int mapCenterX, mapCenterY, valeurAbsMapCenterX, valeurAbsMapCenterY, valeurAbsOffsetX, valeurAbsOffsetY, minX, maxX, minY, maxY;

    public void findMiddleValue()
    {
        if (offsetX < 0)
        {
            findingMiddleValueX = lengthX + offsetX * -1;
            //valeurAbsOffsetX = offsetX * -1;
        }
        else
        {
            findingMiddleValueX = lengthX + offsetX;
            //valeurAbsOffsetX = offsetX;
        }

        if (findingMiddleValueX % 2 == 1)
        {
            middleValueX = (findingMiddleValueX - 1) / 2;
            middleValueXpair = middleValueX;
        }
        else if ((findingMiddleValueX % 2) == 0)
        {
            middleValueX = findingMiddleValueX / 2;
            middleValueXpair = ++middleValueX;
        }


        if (offsetY < 0)
        {
            findingMiddleValueY = lengthY + offsetY * -1;
            //valeurAbsOffsetY = offsetY * -1;
        }
        else
        {
            findingMiddleValueY = lengthY + offsetY;
            //valeurAbsOffsetY = offsetY;
        }

        if (findingMiddleValueY % 2 == 1)
        {
            middleValueY = (findingMiddleValueY - 1) / 2;
            middleValueYpair = middleValueY;
        }
        else if ((findingMiddleValueY % 2) == 0)
        {
            middleValueY = findingMiddleValueY / 2;
            middleValueYpair = ++middleValueY;
        }


        if (offsetX <= 0)
            mapCenterX = -(int)((middleValueX + middleValueXpair) / 2);
        else if (offsetX > 0)
            mapCenterX = (int)((middleValueX + middleValueXpair) / 2);

        if (offsetY <= 0)
            mapCenterY = -(int)((middleValueY + middleValueYpair) / 2);
        else if (offsetY > 0)
            mapCenterY = (int)((middleValueY + middleValueYpair) / 2);

        valeurAbsMapCenterX = (int)((middleValueX + middleValueXpair) / 2);
        valeurAbsMapCenterY = (int)((middleValueY + middleValueYpair) / 2);

        minX = -(--valeurAbsMapCenterX);
        maxX = (--valeurAbsMapCenterX);
        minY = -(--valeurAbsMapCenterY);
        maxY = (--valeurAbsMapCenterY);


    }

    // Use this for initialization
    void Start()
    {
        findMiddleValue();
        Debug.Log("start map");
        internalGrid = new GridCell[lengthX, lengthY];

        for (int i = 0; i < lengthX; i++)
        {
            for (int j = 0; j < lengthY; j++)
            {
                internalGrid[i, j] = new GridCell();
                this.internalGrid[i, j].Cell = Instantiate(DefaultTerrain, new Vector3(i+mapCenterX, 0f, j+mapCenterY), Quaternion.identity) as GameObject;
                this.internalGrid[i, j].Cell.transform.SetParent(this.gameObject.transform);

            }
        }
        this.internalGrid[25, 25].Cell.GetComponent<gridCellBehavior>().meteor();
        this.internalGrid[10, 25].Cell.GetComponent<gridCellBehavior>().meteor();
        Debug.Log("minX: ");
        Debug.Log(minX);
        Debug.Log("maxX: ");
        Debug.Log(maxX);
        Debug.Log("minY: ");
        Debug.Log(minY);
        Debug.Log("maxY: ");
        Debug.Log(maxY);
    }
    // Update is called once per frame
    void Update()
    {
        player0PositionOnGridX = (int)player0.transform.position.x;
        player0PositionOnGridY = (int)player0.transform.position.z;
        player1PositionOnGridX = (int)player1.transform.position.x;
        player1PositionOnGridY = (int)player1.transform.position.z;
        //Debug.Log(playerPositionOnGridX);
        //Debug.Log(playerPositionOnGridY);
		this.internalGrid[player0PositionOnGridX-mapCenterX, player0PositionOnGridY-mapCenterY].Cell.GetComponent<Renderer>().material.color = player0.GetComponent<player>().playerColor;
		this.internalGrid[player1PositionOnGridX-mapCenterX, player1PositionOnGridY-mapCenterY].Cell.GetComponent<Renderer>().material.color = player1.GetComponent<player>().playerColor;


    }

}
