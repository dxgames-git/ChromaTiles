using UnityEngine;
using System.Collections;

public class TitleScreenManager : MonoBehaviour
{

    public bool didPressEasy;
    public bool didPressHard;
    private GameObject checkMarkEasy;
    private GameObject checkMarkHard;
    //gets called from the FadeController class
    public bool fadeStart; 


    // Use this for initialization
    void Start()
    {
        didPressEasy = false;
        didPressHard = false;
        fadeStart = false;
        checkMarkEasy = GameObject.FindGameObjectWithTag("EasySquare");
        checkMarkHard = GameObject.FindGameObjectWithTag("HardSquare");
        checkMarkEasy.SetActive(false);
        checkMarkHard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void pressedEasy()
    {
        didPressEasy = true;
        if (didPressHard == true)
        {
            checkMarkHard.SetActive(false);
        }
        checkMarkEasy.SetActive(true);
        didPressHard = false;
    }
    void pressedHard()
    {
        didPressHard = true;
        if (didPressEasy == true)
        {
            checkMarkEasy.SetActive(false);
        }
        checkMarkHard.SetActive(true);
        didPressEasy = false;
    }
    public void startLevel()
    {
        if (didPressEasy == true || didPressHard == true)
        {
            fadeStart = true;
            Invoke("loadLevel", 1f);
        }
    }
    void loadLevel() {
        Application.LoadLevel("Main");
    }
}
