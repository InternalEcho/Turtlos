using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour {

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
    // Use this for initialization
    void Start () {

        Debug.Log("start map");
        internalGrid = new GridCell[lengthX, lengthY];
        for(int i=0; i<lengthX; i++)
        {
            for(int j=0; j<lengthY; j++)
            {
                internalGrid[i,j] = new GridCell();
                this.internalGrid[i, j].Cell = Instantiate(DefaultTerrain, new Vector3(i, 0f, j), Quaternion.identity) as GameObject;
                this.internalGrid[i, j].Cell.transform.SetParent(this.gameObject.transform);

            }
        }
        this.internalGrid[25, 25].Cell.GetComponent<gridCellBehavior>().meteor();
        this.internalGrid[10, 25].Cell.GetComponent<gridCellBehavior>().meteor();

    }
    // Update is called once per frame
    void Update () {
        
        player0PositionOnGridX = (int) player0.transform.position.x;
        player0PositionOnGridY = (int) player0.transform.position.z;
        player1PositionOnGridX = (int)player1.transform.position.x;
        player1PositionOnGridY = (int)player1.transform.position.z;
        //Debug.Log(playerPositionOnGridX);
        //Debug.Log(playerPositionOnGridY);
        this.internalGrid[player0PositionOnGridX, player0PositionOnGridY].Cell.GetComponent<Renderer>().material.color = player0.GetComponent<player>().playerColor;
        this.internalGrid[player1PositionOnGridX, player1PositionOnGridY].Cell.GetComponent<Renderer>().material.color = player1.GetComponent<player>().playerColor;


    }

   
}
