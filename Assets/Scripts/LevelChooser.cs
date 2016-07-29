using UnityEngine;
using System.Collections;

public class LevelChooser : MonoBehaviour {

    private BoxGenerator differentLevel;
    public float number;
	// Use this for initialization
	void Start () {
        differentLevel = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void levelEasy() {
        differentLevel.gameDifficulty = 3;
        number = differentLevel.gameDifficulty;
    }
    public void levelNormal()
    {
        differentLevel.gameDifficulty = 4;
        number = differentLevel.gameDifficulty;
    }
    public void levelHard()
    {
        differentLevel.gameDifficulty = 5;
        number = differentLevel.gameDifficulty;
    }
}
