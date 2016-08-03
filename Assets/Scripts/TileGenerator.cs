using UnityEngine;
using System.Collections;

public class TileGenerator : MonoBehaviour {

    public GameObject Tile;

    private int numTiles;
    private BoxGenerator boxGen;
    private float width;

	// Use this for initialization
	void Start () {
        numTiles = GameObject.FindGameObjectWithTag("LevelChooser").GetComponent<LevelChooser>().level;
        boxGen = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>();
        width = 5.61f / boxGen.numbers.Length;
        for (int i = 1; i <= numTiles; i++)
        {
            float x = (-(numTiles / 2) + (numTiles - i)) * width;
            GameObject theTile = (GameObject)Instantiate(Tile, new Vector3(x, -3.6f), transform.rotation);
            theTile.transform.localScale = new Vector3(theTile.transform.localScale.x * 3f / numTiles, theTile.transform.localScale.y);
            theTile.transform.parent = GameObject.Find("Tiles").transform;

            //Set Color of Box
            Color[] color = boxGen.color;
            int[] numbers = boxGen.numbers;
            Color tileColor = color[numbers[i - 1]];
            theTile.GetComponent<SpriteRenderer>().color = tileColor;
            theTile.GetComponent<TileController>().tileColor = tileColor;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
