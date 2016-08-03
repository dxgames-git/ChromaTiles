using UnityEngine;
using System.Collections;

public class LevelChooser : MonoBehaviour {

    private BoxGenerator differentLevel;
	// Use this for initialization
	void Start () {
        differentLevel = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    //calling the methods using buttons
    public void levelEasy() {
        Invoke("changeLevelEasy", 0.001f);
    }
    public void levelNormal()
    {
        Invoke("changeLevelNormal", 0.05f);
    }
    public void levelHard()
    {
        Invoke("changeLevelHard", 0.05f);
    }

    //delaying the methods
    void changeLevelEasy() {
        differentLevel.gameDifficulty = 3;
    }
    void changeLevelNormal()
    {
        differentLevel.gameDifficulty = 4;
    }
    void changeLevelHard()
    {
        differentLevel.gameDifficulty = 5;
    }
}
