using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour
{

    public GameObject fadeEffect;
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
        float alpha = fadeObject.GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = fadeObject.GetComponent<SpriteRenderer>().color;
            newColor.a =  Mathf.Lerp(alpha, aValue, t);
            fadeObject.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }

    public void fadeOut(float duration)
    {
        fadeObject = (GameObject) Instantiate(fadeEffect, new Vector3(0, transform.position.y - 3.35f, Camera.main.transform.position.z + 10.5f), transform.rotation);
        fadeObject.transform.parent = Camera.main.transform;
        fadeObject.transform.position = new Vector3(fadeObject.transform.position.x, fadeObject.transform.position.y, fadeObject.transform.parent.position.z + 10.5f);
        StartCoroutine(FadeTo(0.0f, duration));
        Destroy(fadeObject, duration + 0.15f);
    }

}
