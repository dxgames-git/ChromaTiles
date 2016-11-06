using UnityEngine;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{

    public GameObject theFade;
    private GameObject fadeObject;

    // Use this for initialization
    void Start()
    {
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
        StopCoroutine("FadeTo");
        fadeObject = (GameObject) Instantiate(theFade, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 1f), transform.rotation);
        fadeObject.transform.parent = Camera.main.transform;
        fadeObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0);
        StartCoroutine(FadeTo(1.0f, duration));
    }

    public void fadeOut(float duration)
    {
        StopCoroutine("FadeTo");
        fadeObject = (GameObject) Instantiate(theFade, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 1f), transform.rotation);
        fadeObject.transform.parent = Camera.main.transform;
        fadeObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 1);
        StartCoroutine(FadeTo(0.0f, duration));
        Destroy(fadeObject, duration + 0.20f);
    }


}
