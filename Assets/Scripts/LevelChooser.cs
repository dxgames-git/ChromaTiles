using UnityEngine;
using System.Collections;

public class LevelChooser : MonoBehaviour
{

    public int level;
    private BoxGenerator differentLevel;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //differentLevel = GameObject.FindGameObjectWithTag("BoxGenerator").GetComponent<BoxGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("LevelChooser").Length > 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("LevelChooser")[0]);
        }
    }

    //calling the methods using buttons
    public void levelEasy()
    {
        level = 3;
    }
    public void levelNormal()
    {
        level = 3;
    }
    public void levelHard()
    {
        level = 5;
    }

}
