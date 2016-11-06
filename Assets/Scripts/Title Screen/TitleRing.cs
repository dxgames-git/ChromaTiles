using UnityEngine;
using System.Collections;

public class TitleRing : MonoBehaviour
{

    private int dir;

    // Use this for initialization
    void Start()
    {

        dir = (int) (Random.value * 2f);
        if (dir < 1)
            dir = -1;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.forward * -20 * dir * Time.deltaTime);

    }

}
