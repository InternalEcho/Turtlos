using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    public GameObject DefaultTerrain;
    public GameObject invisibleWall;
    public GridCell[,] internalGrid;
    public int lengthX = 100;
    public int lengthY = 100;
    public GameObject player0;
    public GameObject player1;
    private GridCell player0Position;
    private GridCell player1Position;
    private Color cellColor;

	public int offsetX;
	public int offsetY;

    //Determining position for center of each X and Y axis of the grid.
    private bool pairNumber;
    private int centerX, centerY;

    // Use this for initialization
    void Start()
    {
        centerX = findCenter(lengthX);
        centerY = findCenter(lengthY);

        internalGrid = new GridCell[lengthX, lengthY];

        for (int i = 0; i < lengthX; i++)
        {
            for (int j = 0; j < lengthY; j++)
            {
                internalGrid[i, j] = new GridCell();
                this.internalGrid[i, j].Cell = Instantiate(DefaultTerrain, new Vector3(i, 0f, j), Quaternion.identity) as GameObject;
                this.internalGrid[i, j].Cell.transform.SetParent(this.gameObject.transform);
            }
        }
        cellColor = DefaultTerrain.GetComponent<gridCellBehavior>().gridColor.color;
        //Instantiate Invisible Walls
        GameObject WallX1 = Instantiate(invisibleWall, new Vector3(-1, 0.0f, centerY - 1), Quaternion.identity) as GameObject;    // -x
        WallX1.transform.localScale = new Vector3(1.0f, 5.0f, lengthY + 2);
        GameObject WallX2 = Instantiate(invisibleWall, new Vector3(lengthX, 0.0f, centerY - 1), Quaternion.identity) as GameObject;    // +x
        WallX2.transform.localScale = new Vector3(1.0f, 5.0f, lengthY + 2);
        GameObject WallZ1 = Instantiate(invisibleWall, new Vector3(centerX, 0.0f, -1), Quaternion.identity) as GameObject;   // -z
        WallZ1.transform.localScale = new Vector3(lengthX + 2, 5.0f, 1.0f);
        GameObject WallZ2 = Instantiate(invisibleWall, new Vector3(centerX, 0.0f, lengthY), Quaternion.identity) as GameObject;   // +z
        WallZ2.transform.localScale = new Vector3(lengthX + 2, 5.0f, 1.0f);

        //debug meteor hit
        //this.internalGrid[25, 25].Cell.GetComponent<gridCellBehavior>().meteorHit();
        //this.internalGrid[10, 25].Cell.GetComponent<gridCellBehavior>().meteorHit();
    }

    // Update is called once per frame
    void Update()
    {
        player0Position = this.internalGrid[(int)player0.transform.position.x, (int)player0.transform.position.z];
        player1Position = this.internalGrid[(int)player1.transform.position.x, (int)player1.transform.position.z];
        Debug.Log("1er debug" + this.player0Position.Cell.GetComponent<Renderer>().material.color);
        Debug.Log("2e debug" + player0.GetComponent<player>().playerColor);
        Debug.Log("3e debug" + cellColor);
        if ((this.player0Position.Cell.GetComponent<Renderer>().material.color != player0.GetComponent<player>().playerColor)
            && (this.player0Position.Cell.GetComponent<Renderer>().material.color != cellColor))
        {
            Debug.Log("Decreasing player0 speed");
            player0.GetComponent<player>().decreaseSpeed();
        }
        this.player0Position.Cell.GetComponent<Renderer>().material.color = player0.GetComponent<player>().playerColor;

        if (this.player1Position.Cell.GetComponent<Renderer>().material.color != player1.GetComponent<player>().playerColor
            && this.player1Position.Cell.GetComponent<Renderer>().material.color != cellColor)
        {
            player1.GetComponent<player>().decreaseSpeed();
        }
        this.player1Position.Cell.GetComponent<Renderer>().material.color = player1.GetComponent<player>().playerColor;
    }

    private int findCenter(int value)
    {
        if (value % 2 == 0) // if value is even
            return (value / 2);
        return ((value / 2) + 1);
    }

    public int getCenterX()
    {
        return centerX;
    }
    public int getCenterY()
    {
        return centerY;
    }

    //Simon Code
    void OnTriggerEnter(Collider collision)
    { /*
        if (collision.gameObject.tag == "Meteorites")
        {
            collision.internalGrid[collision.transform.x, collision.transform.z].Cell.GetComponent<Renderer>().material.color = deathTile.color;
            //gameObject deathTile aka prefab of tile but black??
            collision.internalGrid[collision.transform.x, collision.transform.z]
        }*/
    } 
}
