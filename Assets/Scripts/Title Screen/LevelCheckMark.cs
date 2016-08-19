using UnityEngine;
using System.Collections;

public class LevelCheckMark : MonoBehaviour
{

    private bool didPressEasy;
    private bool didPressHard;
    private GameObject checkMarkEasy;
    private GameObject checkMarkHard;

    // Use this for initialization
    void Start()
    {
        didPressEasy = false;
        didPressHard = false;
        checkMarkEasy = GameObject.FindGameObjectWithTag("CheckMarkEasy");
        checkMarkHard = GameObject.FindGameObjectWithTag("CheckMarkHard");
        checkMarkEasy.SetActive(false);
        checkMarkHard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void pressedEasy()
    {
        didPressEasy = true;
        if (didPressHard == true)
        {
            checkMarkHard.SetActive(false);
        }
        checkMarkEasy.SetActive(true);
        didPressHard = false;
    }
    public void pressedHard()
    {
        didPressHard = true;
        if (didPressEasy == true)
        {
            checkMarkEasy.SetActive(false);
        }
        checkMarkHard.SetActive(true);
        didPressEasy = false;
    }

}
