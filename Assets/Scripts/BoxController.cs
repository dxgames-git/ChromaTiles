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
        int picker = (int) (Random.value * numbers.Length);
        box.GetComponent<SpriteRenderer>().color = color[picker];
        Debug.Log("WTF " + picker);
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y + 15f < theCamera.transform.position.y)
        {
            Destroy(gameObject, 0.3f);
        }

	}
}
