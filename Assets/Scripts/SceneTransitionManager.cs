using UnityEngine;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{

    public GameObject theFade;
    private GameObject fadeObject;
    private GameObject theCamera;

    // Use this for initialization
    void Start()
    {
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = fadeObject.GetComponent<SpriteRenderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            fadeObject.GetComponent<SpriteRenderer>().material.color = newColor;
            yield return null;
        }
    }

    public void fadeIn(float duration)
    {
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
        fadeObject = (GameObject) Instantiate(theFade, new Vector3(theCamera.transform.position.x, theCamera.transform.position.y, theCamera.transform.position.z + 1f), transform.rotation);
        fadeObject.transform.parent = theCamera.transform;
        fadeObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0);
        StartCoroutine(FadeTo(1.0f, duration));
        //wtf
    }

    public void fadeOut(float duration)
    {
        theCamera = GameObject.FindGameObjectWithTag("MainCamera");
        fadeObject = (GameObject) Instantiate(theFade, new Vector3(theCamera.transform.position.x, theCamera.transform.position.y, theCamera.transform.position.z + 1f), transform.rotation);
        fadeObject.transform.parent = theCamera.transform;
        fadeObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);
        StartCoroutine(FadeTo(0.0f, duration));
        Destroy(fadeObject, duration + 0.15f);
    }


}
