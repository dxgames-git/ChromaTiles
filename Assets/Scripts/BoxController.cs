using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {

    //Setting the Box's color
    private GameObject box;
    private GameObject theCamera;

	// Use this for initialization
	void Start () {

        box = gameObject;
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");

        Color[] color = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>().color;
        int[] numbers = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>().numbers;

        box.GetComponent<SpriteRenderer>().color = color[numbers[(int) (Random.value * numbers.Length)]];

    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y + 15f < theCamera.transform.position.y)
        {
            Destroy(gameObject, 0.3f);
        }

	}
}
