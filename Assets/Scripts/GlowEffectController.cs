using UnityEngine;
using System.Collections;

public class GlowEffectController : MonoBehaviour {

    private float duration;

	// Use this for initialization
	void Start () {
        duration = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (duration >= 1.5)
        {
            Destroy(gameObject);
        }
        else {
            duration += Time.deltaTime * 5;
        }
	}
}
