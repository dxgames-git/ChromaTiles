using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {

    public int number;
    public Color tileColor;

    private GameObject theCamera;
    private BoxGenerator boxGen;
    private float width;
    private float scalar;

    //Stopping movement when paused or dead
    private UIManager stopMovement;

	// Use this for initialization
	void Start () {

        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
        stopMovement = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        boxGen = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>();

        width = 5.61f / boxGen.numbers.Length;
        int level = GameObject.FindGameObjectWithTag("LevelChooser").GetComponent<LevelChooser>().level;
        scalar = (level / 2);
    }

	// Update is called once per frame
	void Update () {

        if (!stopMovement.pauseWork && !stopMovement.deathWork)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(width, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(width, 0);
            }
            if (transform.position.x < -width * scalar)
            {
                transform.position = new Vector3(width * scalar, theCamera.transform.position.y - 3.6f);
            }
            else if (transform.position.x > width * scalar)
            {
                transform.position = new Vector3(-width * scalar, theCamera.transform.position.y - 3.6f);
            }
        }
    }
}
