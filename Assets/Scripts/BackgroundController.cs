using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{

    GameObject other;
    float currentTime = 0f;
    Vector3 scale;

    // Use this for initialization
    void Start()
    {
        if (gameObject.name.Equals("Background1"))
        {
            other = GameObject.Find("Background2");
        }
        else
        {
            other = GameObject.Find("Background1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime < 45f)
        {
            scale = new Vector3(0, -(5f * currentTime / 45f) * Time.deltaTime);
        }
        transform.position += scale;
        if (transform.localPosition.y < -13f)
        {
            transform.position = new Vector3(transform.position.x, other.transform.position.y + 12.9f);
        }
    }

}
