using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public float modifier;

    // Use this for initialization
    void Start()
    {
        modifier = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        modifier += Time.deltaTime * .2f;//.005f;
        transform.position += new Vector3(0, 1f * Time.deltaTime * (1 + modifier));
    }
}