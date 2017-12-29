using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    public GameObject defaultTerrain;
    public GameObject invisibleWall;
  
    public GameObject player0;
    public GameObject player1;

    public int lengthX, lengthY;
    public int offsetX;
    public int offsetY;

    private List<GameObject> players;
    private GridCell playerPosition;

    private Color defaultTerrainColor;
    private GridCell[,] internalGrid;
    
    //Determining position for center of each X and Y axis of the grid.
    private bool pairNumber;
    private int centerX, centerY;

    // Use this for initialization
    void Start()
    {
        players = new List<GameObject>();
        players.Add(player0);
        players.Add(player1);

        centerX = findCenter(lengthX);
        centerY = findCenter(lengthY);

        defaultTerrainColor = defaultTerrain.GetComponent<gridCellBehavior>().gridColor.color;
        generateGridMap(lengthX, lengthY);
       //generateInvisibleWalls(lengthX, lengthY);
        
        //debug meteor hit
        //this.internalGrid[25, 25].Cell.GetComponent<gridCellBehavior>().meteorHit();
        //this.internalGrid[10, 25].Cell.GetComponent<gridCellBehavior>().meteorHit();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var player in players)
        {
            if (player == null) // remove dead players from the list of players
                players.Remove(player);
            if (players.Count == 1)
            {
                StartCoroutine(endRound());
                players.Clear();
            }
               

            playerPosition = this.internalGrid[(int)player.transform.position.x, (int)player.transform.position.z]; // finds current player gridcell
            if (this.playerPosition.Cell.GetComponent<Renderer>().material.color == Color.black)    // Player loses Hp when walking on charred tiles?
                player.GetComponent<player>().loseHp();
            if ((this.playerPosition.Cell.GetComponent<Renderer>().material.color != player.GetComponent<player>().playerColor)
            && (this.playerPosition.Cell.GetComponent<Renderer>().material.color != defaultTerrainColor))
            {
                player.GetComponent<player>().decreaseSpeed();
            }
            this.playerPosition.Cell.GetComponent<Renderer>().material.color = player.GetComponent<player>().playerColor;
        }
    }

    void generateGridMap(int lengthX, int lengthY)
    {
        internalGrid = new GridCell[lengthX, lengthY];

        for (int i = 0; i < lengthX; i++)
        {
            for (int j = 0; j < lengthY; j++)
            {
                internalGrid[i, j] = gameObject.AddComponent<GridCell>();
                this.internalGrid[i, j].Cell = Instantiate(defaultTerrain, new Vector3(i, 0f, j), Quaternion.identity) as GameObject;
                this.internalGrid[i, j].Cell.transform.SetParent(this.gameObject.transform);
            }
        }
    }

    void generateInvisibleWalls(int lengthX, int lengthY)
    {
        GameObject WallX1 = Instantiate(invisibleWall, new Vector3(-1, 0.0f, centerY - 1), Quaternion.identity) as GameObject;    // -x
        WallX1.transform.localScale = new Vector3(1.0f, 5.0f, lengthY + 2);
        GameObject WallX2 = Instantiate(invisibleWall, new Vector3(lengthX, 0.0f, centerY - 1), Quaternion.identity) as GameObject;    // +x
        WallX2.transform.localScale = new Vector3(1.0f, 5.0f, lengthY + 2);
        GameObject WallZ1 = Instantiate(invisibleWall, new Vector3(centerX, 0.0f, -1), Quaternion.identity) as GameObject;   // -z
        WallZ1.transform.localScale = new Vector3(lengthX + 2, 5.0f, 1.0f);
        GameObject WallZ2 = Instantiate(invisibleWall, new Vector3(centerX, 0.0f, lengthY), Quaternion.identity) as GameObject;   // +z
        WallZ2.transform.localScale = new Vector3(lengthX + 2, 5.0f, 1.0f);
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

    public GridCell getCell(int positionX, int positionY)
    {
        return internalGrid[positionX, positionY];
    }

    IEnumerator endRound()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("GameHandler").GetComponent<GameManagementScript>().GoToWinnerChicken();
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
