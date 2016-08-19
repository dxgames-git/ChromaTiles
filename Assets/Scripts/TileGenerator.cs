using UnityEngine;
using System.Collections;

public class TileGenerator : MonoBehaviour
{

    //Generic Tile Prefab
    public GameObject Tile;

    //Stop tile control movement when paused or dead or animating
    private UIManager stopMovement;

    //Tile "animation"
    public bool moving;
    private GameObject theCamera;

    private int direction;
    private float ElapsedTime;
    private float FinishTime;
    private Vector3 StartPosition;
    private Vector3 Target;

    //Tile generation parameters
    private BoxGenerator boxGen;
    private int numTiles;
    private float width;
    private int scalar;

    // Use this for initialization
    void Start()
    {
        theCamera = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
        numTiles = GameObject.FindGameObjectWithTag("LevelChooser").GetComponent<LevelChooser>().level;
        boxGen = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>();
        stopMovement = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        moving = false;
        width = 5.61f / boxGen.numbers.Length;
        scalar = numTiles / 2;

        for (int i = 1; i <= numTiles; i++) //(int i = 1; i <= numTiles; i++)
        {
            //Calculate position of box and generate box
            float x = (-(numTiles / 2) + (numTiles - i)) * width;
            GameObject theTile = (GameObject) Instantiate(Tile, new Vector3(x, -3.6f), transform.rotation);
            theTile.transform.localScale = new Vector3(theTile.transform.localScale.x * 3f / numTiles, theTile.transform.localScale.y);
            theTile.transform.parent = transform;

            //Set Color of Box
            Color[] color = boxGen.color;
            int[] numbers = boxGen.numbers;
            Color tileColor = color[numbers[i - 1]];
            theTile.GetComponent<SpriteRenderer>().color = tileColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMovement.pauseWork && !stopMovement.deathWork && !moving)
        {
            transform.position = new Vector3(transform.position.x, theCamera.transform.position.y);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //Generate New Tile at the right
                GameObject theTile = (GameObject) Instantiate(Tile, new Vector3(width * scalar + width, /**/theCamera.transform.position.y - 3.6f), transform.rotation);
                theTile.transform.localScale = new Vector3(theTile.transform.localScale.x * 3f / numTiles, theTile.transform.localScale.y);
                theTile.transform.parent = transform;
                //Assign values identical to the leftmost tile to the new right tile
                GameObject leftTile = transform.GetChild(0).gameObject;
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).position.x <= (-(numTiles / 2) + (numTiles - numTiles)) * width + 0.1f)
                    {
                        leftTile = transform.GetChild(i).gameObject;
                    }
                }
                theTile.GetComponent<SpriteRenderer>().color = leftTile.GetComponent<SpriteRenderer>().color;
                //Move the tile parent
                Move(-1);
                //Delete left one that is out of bound
                Destroy(leftTile, 0.11f);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //Generate New Tile at the left
                GameObject theTile = (GameObject) Instantiate(Tile, new Vector3(-width * scalar - width, /**/theCamera.transform.position.y - 3.6f), transform.rotation);
                theTile.transform.localScale = new Vector3(theTile.transform.localScale.x * 3f / numTiles, theTile.transform.localScale.y);
                theTile.transform.parent = transform;
                //Assign values identical to the rightmost tile to the new left tile
                GameObject rightTile = transform.GetChild(0).gameObject;
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (transform.GetChild(i).position.x >= (-(numTiles / 2) + (numTiles - 1)) * width - 0.1f)
                    {
                        rightTile = transform.GetChild(i).gameObject;
                    }
                }
                theTile.GetComponent<SpriteRenderer>().color = rightTile.GetComponent<SpriteRenderer>().color;
                //Move the tile parent
                Move(1);
                //Delete right one that is out of bound
                Destroy(rightTile, 0.1f);
            }
        }
        else if (!stopMovement.pauseWork && !stopMovement.deathWork && moving)
        {
            ElapsedTime += Time.deltaTime;
            Target = new Vector3(StartPosition.x + (direction * width), /**/theCamera.transform.localPosition.y);
            transform.position = Vector3.Lerp(StartPosition, Target, ElapsedTime / FinishTime);
            transform.position = new Vector3(transform.position.x, theCamera.transform.position.y);
            if (ElapsedTime - .0035f >= FinishTime)
            {
                moving = false;
            }
        }
    }

    void Move(int dir)
    {
        moving = true;
        direction = dir;

        ElapsedTime = 0;
        FinishTime = 0.1f;
        StartPosition = transform.position;
        Target = new Vector3(transform.position.x + (dir * width), /**/theCamera.transform.localPosition.y);

        Update();
    }

}
