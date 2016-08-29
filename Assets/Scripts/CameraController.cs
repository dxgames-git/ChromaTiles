using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public float scale;
    public float modifier;

    // Use this for initialization
    void Start()
    {
        modifier = 0f;
        scale = 1f / 5f;//5f = 5 seconds per 1 velocity
    }

    // Update is called once per frame
    void Update()
    {
        if (modifier <= 45 * scale)
        {
            modifier += Time.deltaTime * scale;
        }
        transform.position += new Vector3(0, Time.deltaTime * (1 + modifier));
    }

}