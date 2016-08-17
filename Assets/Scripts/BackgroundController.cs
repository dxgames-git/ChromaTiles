using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

    public Sprite[] images = new Sprite[10];

    float counter = 0f;

    // Use this for initialization
    void Start () {
        //Initializes background randomly to one of the ten
        gameObject.GetComponent<SpriteRenderer>().sprite = images[(int) (Random.value * images.Length)];
    }
	
	// Update is called once per frame
	void Update () {
        //Implement scrolling
        counter += Time.deltaTime;

        float x = Mathf.Cos(counter / 10);
        float y = Mathf.Sin(counter / 10);
        
        transform.position = new Vector3(8.69f * x, 2.5f * y + transform.parent.transform.position.y);
    }

}
