using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{

    //Array of background sprites from folder
    public Sprite[] images = new Sprite[10];

    float currentTime = 0f;

    // Use this for initialization
    void Start()
    {
        //Initializes background randomly to one of the ten
        gameObject.GetComponent<SpriteRenderer>().sprite = images[(int) (Random.value * images.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        //Make background move relative to the camera in an ellipse of width 8.69f and height 2.5f
        currentTime += Time.deltaTime;

        float x = Mathf.Cos(currentTime / 10);
        float y = Mathf.Sin(currentTime / 10);

        transform.position = new Vector3(8.69f * x, 2.5f * y + transform.parent.transform.position.y, transform.parent.position.z + 11f);
    }

}
