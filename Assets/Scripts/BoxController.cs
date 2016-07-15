﻿using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour {

    //Setting the Box's color
    private GameObject box;
    private GameObject theCamera;
    public Color boxColor;

	// Use this for initialization
	void Start () {

        theCamera = GameObject.FindGameObjectWithTag("MainCamera");

        Color[] color = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>().color;
        int[] numbers = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>().numbers;
        int picker = numbers[(int)(Random.value * numbers.Length)];
        gameObject.GetComponent<SpriteRenderer>().color = color[picker];
        boxColor = color[picker];

    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y + 10f < theCamera.transform.position.y)
        {
            Destroy(gameObject, 0.3f);
        }

	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.GetComponent<TileController>().tileColor.Equals(boxColor))
        {
            //Increase Score
            Destroy(gameObject, 0.05f);
        }
        else
        {
            //Invoke Death Scene
        }
    }

}
