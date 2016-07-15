using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {

    public int number;
    private GameObject theCamera;
    public Color tileColor;

    //Stopping movement when paused or dead
    private UIManager stopMovement;

	// Use this for initialization
	void Start () {

        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Invoke("SetColor", 0.01f);
        stopMovement = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

    }
	
    void SetColor ()
    {
        Color[] color = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>().color;
        int[] numbers = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>().numbers;

        tileColor = color[numbers[number]];
        gameObject.GetComponent<SpriteRenderer>().color = tileColor;
    }

	// Update is called once per frame
	void Update () {

        if (!stopMovement.pauseWork && !stopMovement.deathWork)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(1.87f, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1.87f, 0);
            }
            if (transform.position.x < -1.87f)
            {
                transform.position = new Vector3(1.87f, theCamera.transform.position.y - 3.6f);
            }
            else if (transform.position.x > 1.87f)
            {
                transform.position = new Vector3(-1.87f, theCamera.transform.position.y - 3.6f);
            }
        }
    }
}
