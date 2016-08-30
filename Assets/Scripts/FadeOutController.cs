using UnityEngine;
using System.Collections;

public class FadeOutController : MonoBehaviour {

    private GameObject fadePanel;
    private TitleScreenManager checkFade; //Calling the Title Screen Manager script to check if the fade effect boolean has been called
    private float duration;

	// Use this for initialization
	void Start () {
        checkFade = GameObject.FindGameObjectWithTag("LevelChooser").GetComponent<TitleScreenManager>();
        duration = 0;
        fadePanel = GameObject.FindGameObjectWithTag("Fade");
        fadePanel.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        checkFade.fadeStart = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (checkFade.fadeStart == true) {
            if (duration <= 1)
            {
                fadePanel.GetComponent<Renderer>().material.color = new Color(1, 1, 1, duration += 0.125f);
                duration += 0.0625f;
            }
            }
        }
	}

   /* public void callFader() {
        for (float i = duration; i <= 1; i += 0.0625f) {
            Debug.Log(Time.deltaTime);
            fadePanel.GetComponent<Renderer>().material.color = new Color(1, 1, 1, i);
        }
    }*/

