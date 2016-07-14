using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {

    public float distanceFromMiddle;

    private Transform camera;
	// Use this for initialization
	void Start () {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(transform.position.x, camera.position.y - distanceFromMiddle, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
        }

    }
}
