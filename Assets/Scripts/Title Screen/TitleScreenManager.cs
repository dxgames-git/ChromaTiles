using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{

    private AudioSource gameMusic;
    private GameObject checkMarkEasy;
    private GameObject checkMarkHard;

    // Use this for initialization
    void Start()
    {
        gameMusic = GameObject.Find("Audio").GetComponent<AudioSource>();
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
        checkMarkEasy.SetActive(true);
        if (checkMarkHard.activeInHierarchy)
        {
            checkMarkHard.SetActive(false);
        }
    }

    void pressedHard()
    {
        checkMarkHard.SetActive(true);
        if (checkMarkEasy.activeInHierarchy)
        {
            checkMarkEasy.SetActive(false);
        }
    }

    public void startLevel()
    {
        if (checkMarkEasy.activeInHierarchy || checkMarkHard.activeInHierarchy && !(checkMarkEasy.activeInHierarchy == checkMarkHard.activeInHierarchy))
        {
            //Call fade
            gameMusic.Stop();
            transform.GetComponent<SceneTransitionManager>().fadeIn(0.15f);
            Invoke("loadLevel", 0.3f);
        }
    }

    void loadLevel()
    {
        SceneManager.LoadScene("Main");
    }

}
