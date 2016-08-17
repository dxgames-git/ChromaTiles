using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

    public Color lerpedColor = Color.white;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<SpriteRenderer>().color = lerpedColor;
    }
	
	// Update is called once per frame
	void Update () {
        lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        gameObject.GetComponent<SpriteRenderer>().color = lerpedColor;
    }

}
