using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {

    private Color[] color;
    private int[] numbers;

    //Setting the Box's color
    private GameObject box;

	// Use this for initialization
	void Start () {

        box = GameObject.FindGameObjectWithTag("Box");

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
            int theNumber = (int) (Random.value * color.Length);
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
        box.GetComponent<SpriteRenderer>().material.SetColor("_EmissionColor", color[(int)Random.value * numbers.Length]);

    }
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.LeftArrow)/*Add Touch Input Left*/)
        {

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

        }

	}
}
