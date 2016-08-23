using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    private GameObject checkMarkEasy;
    private GameObject checkMarkHard;
    private LevelCheckMark choseLevel;

    void Start() {
        checkMarkEasy = GameObject.FindGameObjectWithTag("CheckMarkEasy");
        checkMarkHard = GameObject.FindGameObjectWithTag("CheckMarkHard");
        choseLevel = GameObject.FindGameObjectWithTag("LevelChooser").GetComponent<LevelCheckMark>();
    }

    public void startLevel()
    {
        if (choseLevel.didPressEasy == true || choseLevel.didPressHard == true)
        {
            Application.LoadLevel("Main");
        }
    }

}
