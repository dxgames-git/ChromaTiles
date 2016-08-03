using UnityEngine;
using System.Collections;

public class LevelChooser : MonoBehaviour {

    private BoxGenerator differentLevel;
    public int level;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        //differentLevel = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    //calling the methods using buttons
    public void levelEasy() {
        level = 3;
    }
    public void levelNormal()
    {
        level = 4;
    }
    public void levelHard()
    {
        level = 5;
    }

    //delaying the methods
    /*void changeLevelEasy() {
        differentLevel.gameDifficulty = 3;
    }
    void changeLevelNormal()
    {
        differentLevel.gameDifficulty = 4;
    }
    void changeLevelHard()
    {
        differentLevel.gameDifficulty = 5;
    }*/
}
