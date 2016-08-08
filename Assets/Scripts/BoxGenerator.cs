using UnityEngine;
using System.Collections;

public class BoxGenerator : MonoBehaviour {

    public GameObject box;
    public GameObject triangle;
    public GameObject circle;
    public int gameDifficulty;

    private GameObject theCamera;
    private GameObject[] objects;

    public Color[] color;
    public int[] numbers;

    // Use this for initialization
    void Start () {
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
        transform.position = new Vector3(0, theCamera.transform.position.y + 7f);

        gameDifficulty = GameObject.FindGameObjectWithTag("LevelChooser").GetComponent<LevelChooser>().level;

        color = new Color[7];
        numbers = new int[gameDifficulty];

        color[0] = Color.red;
        color[1] = Color.white;
        color[2] = Color.yellow;
        color[3] = Color.green;
        color[4] = Color.blue;
        color[5] = Color.cyan;
        color[6] = Color.magenta;

        //Pick X different colors for tiles based on difficulty
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = color.Length;
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            int theNumber = (int)(Random.value * color.Length);
            for (int j = i - 1; j >= 0; j--)
            {
                if (numbers[j] == theNumber)
                {
                    theNumber = (int)(Random.value * color.Length);
                    j = i;
                }
            }
            numbers[i] = theNumber;
        }
        //Generating different objects
        objects = new GameObject[3];
        objects[0] = box;
        objects[1] = circle;
        objects[2] = triangle;
    }
	
	// Update is called once per frame
	void Update () {
        if (theCamera.transform.position.y + 10f > transform.position.y)
        {
            Instantiate(objects[(int)(Mathf.Round(Random.value * 2))], new Vector3(0, transform.position.y), transform.rotation);
            transform.position = new Vector3(0, transform.position.y + 7f);
        }
	}
}
