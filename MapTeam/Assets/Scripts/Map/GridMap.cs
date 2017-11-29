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
    private int findingMiddleValueX;
    private int findingMiddleValueY;
    private int middleValueX;
    private int middleValueXpair;
    private int middleValueY;
    private int middleValueYpair;
    private bool pairNumber;

    public int findMiddleValue(int findmidvalue)
    {
		int middleValue = 0;
        pairNumber = false;
        if (findmidvalue % 2 == 1)
            middleValue = (findmidvalue - 1) / 2;
		else if ((findmidvalue % 2) == 0)
        {
            middleValue = findmidvalue/ 2;
            pairNumber = true;
        }
        return middleValue;
    }
    // Use this for initialization
    void Start()
    {
		//Probably could be simplified...
        findingMiddleValueX = lengthX + offsetX;
        middleValueX = findMiddleValue(findingMiddleValueX);
        middleValueXpair = middleValueX;
        if (pairNumber == true)
        {
            middleValueXpair = middleValueX + 1;
        }

        findingMiddleValueY = lengthY + offsetY;
        middleValueY = findMiddleValue(findingMiddleValueY);
        middleValueYpair = middleValueY;
        if (pairNumber == true)
        {
            middleValueYpair = middleValueY + 1;
        }
		//Please kill me ^

        Debug.Log("start map");
        internalGrid = new GridCell[lengthX, lengthY];

        for (int i = 0; i < lengthX; i++)
        {
            for (int j = 0; j < lengthY; j++)
            {
                internalGrid[i, j] = new GridCell();
                this.internalGrid[i, j].Cell = Instantiate(DefaultTerrain, new Vector3(i-((middleValueY+middleValueYpair)/2), 0f, j- ((middleValueX + middleValueXpair) / 2)), Quaternion.identity) as GameObject;
                this.internalGrid[i, j].Cell.transform.SetParent(this.gameObject.transform);

            }
        }
        this.internalGrid[25, 25].Cell.GetComponent<gridCellBehavior>().meteor();
        this.internalGrid[10, 25].Cell.GetComponent<gridCellBehavior>().meteor();

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
        this.internalGrid[player0PositionOnGridX, player0PositionOnGridY].Cell.GetComponent<Renderer>().material.color = player0.GetComponent<player>().playerColor;
        this.internalGrid[player1PositionOnGridX, player1PositionOnGridY].Cell.GetComponent<Renderer>().material.color = player1.GetComponent<player>().playerColor;


    }

}
