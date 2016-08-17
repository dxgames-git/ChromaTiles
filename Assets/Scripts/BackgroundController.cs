using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

    public Sprite[] images = new Sprite[10];

    // Use this for initialization
    void Start () {
        //Initializes background randomly to one of the ten
        gameObject.GetComponent<SpriteRenderer>().sprite = images[(int) (Random.value * images.Length)];
    }
	
	// Update is called once per frame
	void Update () {
        //Implement scrolling
    }

}
