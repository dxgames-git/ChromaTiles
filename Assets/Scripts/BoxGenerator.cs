﻿using UnityEngine;
using System.Collections;

public class BoxGenerator : MonoBehaviour
{

    public GameObject box;
    public GameObject triangle;
    public GameObject circle;
    public int gameDifficulty;

    public Color[] color;
    public int[] numbers;

    private GameObject[] objects;
    private int lastColor;

    // Use this for initialization
    void Start()
    {
        gameDifficulty = GameObject.FindGameObjectWithTag("LevelChooser").GetComponent<LevelChooser>().level;

        transform.position = new Vector3(0, Camera.main.transform.position.y + 7f);

        color = new Color[7];
        numbers = new int[gameDifficulty];

        color[0] = Color.red;
        color[1] = Color.white;
        color[2] = Color.yellow;
        color[3] = Color.green;
        color[4] = Color.blue;
        color[5] = Color.cyan;
        color[6] = Color.magenta;

        //Pick x different colors for tiles based on difficulty x
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = color.Length;
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            int theNumber = (int) (Random.value * color.Length);
            for (int j = i - 1; j >= 0; j--)
            {
                if (numbers[j] == theNumber)
                {
                    theNumber = (int) (Random.value * color.Length);
                    j = i;
                }
            }
            numbers[i] = theNumber;
        }

        lastColor = numbers[(int) (Random.value * numbers.Length)];

        //Generating different objects
        objects = new GameObject[3];
        objects[0] = box;
        objects[1] = circle;
        objects[2] = triangle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.y + 10f > transform.position.y)
        {
            int sub = (int) (Random.value * numbers.Length);
            while (lastColor == numbers[sub])
            {
                sub = (int) (Random.value * numbers.Length);
            }
            lastColor = numbers[sub];
            GameObject theBox = (GameObject) Instantiate(objects[(int) (Random.value * 3)], new Vector3(0, transform.position.y), transform.rotation);
            theBox.GetComponent<SpriteRenderer>().color = color[lastColor];
            transform.position = new Vector3(0, transform.position.y + 6.75f);
        }
    }

}
