using UnityEngine;
using System.Collections;

public class FadeInController : MonoBehaviour {

    private Color fadePanel;
    private bool delay;
    private float duration;

    // Use this for initialization
    void Start () {
        fadePanel = GameObject.FindGameObjectWithTag("Fade").GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        delay = true;
        duration = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (delay == true) {
            if (duration >= 0)
            {
                //Debug.Log(Time.deltaTime);
                fadePanel = new Color(1, 1, 1, duration -= 0.25f);
                duration -= 0.25f;
            }
        }
	}
}
