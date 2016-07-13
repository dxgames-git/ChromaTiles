using UnityEngine;
using System.Collections;

public class BoxGenerator : MonoBehaviour {

    private GameObject theCamera;
    public GameObject box;

    public Color[] color;
    public int[] numbers;

    // Use this for initialization
    void Start () {
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
        transform.position = new Vector3(0, theCamera.transform.position.y + 7f);

        color = new Color[7];
        numbers = new int[3];

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
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[j] == theNumber)
                {
                    while (numbers[j] == theNumber)
                    {
                        theNumber = (int)(Random.value * color.Length);
                    }
                }
            }
            numbers[i] = theNumber;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (theCamera.transform.position.y + 10f > transform.position.y)
        {
            Instantiate(box, new Vector3(0, transform.position.y), transform.rotation);
            transform.position = new Vector3(0, transform.position.y + 7f);
        }
	}
}
