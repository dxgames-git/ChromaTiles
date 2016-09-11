using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour
{

    //Generic Tile Prefab
    public GameObject Tile;

    //Stop tile movement when paused or dead
    private UIManager stopMovement;

    //Tile generation parameters
    private int numTiles;
    private float width;
    private int scalar;

    //Slide animation fields
    private IEnumerator co;
    private Vector3 Target;
    private float FinishTime;

    // Use this for initialization
    void Start()
    {
        numTiles = GameObject.FindGameObjectWithTag("LevelChooser").GetComponent<LevelChooser>().level;
        stopMovement = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        BoxGenerator boxGen = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>();
        float screenWidth = 2 * Camera.main.orthographicSize * 9f / 16f + 0.1f;
        width = screenWidth / boxGen.numbers.Length;
        scalar = numTiles / 2;

        for (int i = 0; i < numTiles * 3; i++) //(int i = 1; i <= numTiles; i++)
        {
            //Calculate position of box and generate box
            float x = -(numTiles * width + ((scalar) * width)) + (i * width);
            GameObject theTile = (GameObject) Instantiate(Tile, new Vector3(x, -3.6f), transform.rotation);
            theTile.transform.localScale = new Vector3(theTile.transform.localScale.x * 3f / numTiles, theTile.transform.localScale.y);
            theTile.transform.parent = transform;

            //Set Color of Box
            Color[] color = boxGen.color;
            int[] numbers = boxGen.numbers;
            Color tileColor = color[numbers[i % numTiles]];
            theTile.GetComponent<SpriteRenderer>().color = tileColor;
        }
        Target = new Vector3(transform.position.x, Camera.main.transform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMovement.isPaused && !stopMovement.isDead)
        {
            transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y);
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; ++i)
                {
                    Touch touch = Input.GetTouch(i);
                    if (touch.phase == TouchPhase.Began)
                    {
                        if (touch.position.x < Screen.width / 2)
                        {
                            Move(-1);
                        }
                        else if (touch.position.x > Screen.width / 2)
                        {
                            Move(1);
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(-1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(1);
            }
        }
    }

    //Coroutine for tile animation
    IEnumerator slideAnim(float aValue, float aTime, int dir)
    {
        //Move outmost tile to the other side
        Transform change = findClosest(dir * 30f);
        Transform changeTo = findClosest(-dir * 30f);
        change.position = new Vector3(changeTo.position.x - (dir * width), change.position.y);
        //Actually move the tile parent
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, aValue, t), Camera.main.transform.localPosition.y);
            yield return null;
        }
        //Round position so it doesn't accumulate error
        float x = Mathf.Round(transform.position.x * 100) / 100;
        if (Mathf.Abs(x) <= 0.04)
        {
            x = 0f;
        }
        //Ensure tiles stay level vertically
        transform.position = new Vector3(x, transform.position.y);
    }

    //Stop previous motion and start new one
    void Move(int dir)
    {
        if (co != null)
        {
            StopCoroutine(co);
        }
        FinishTime = 0.1f;
        Target += new Vector3((dir * width), 0);
        co = slideAnim(Target.x, FinishTime, dir);
        StartCoroutine(co);
    }

    //Find transform closest horizontally to given x
    Transform findClosest(float x)
    {
        Transform closest = null;
        float minDist = Mathf.Infinity;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            float distance = Mathf.Abs(child.position.x - x);
            if (distance < minDist)
            {
                minDist = distance;
                closest = child;
            }
        }
        return closest;
    }

}
