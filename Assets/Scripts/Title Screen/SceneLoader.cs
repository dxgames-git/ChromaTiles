using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    private TitleScreenManager choseLevel;

    void Start() {
        choseLevel = GameObject.FindGameObjectWithTag("LevelChooser").GetComponent<TitleScreenManager>();
    }

    public void startLevel()
    {
        /*if (choseLevel.didChooseLevel() == true)
        {
            Application.LoadLevel("Main");
        }*/
    }

}
