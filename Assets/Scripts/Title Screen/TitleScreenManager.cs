using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{

    private AudioSource gameMusic;
    private GameObject checkMarkEasy;
    private GameObject checkMarkHard;

    //boolean for if the player has clicked the toggles
    private GameObject audioOn;
    private GameObject audioOff;

    //displaying high scores
    public Text easyScore;
    public Text hardScore;

    // Use this for initialization
    void Start()
    {
        gameMusic = GameObject.Find("Audio").GetComponent<AudioSource>();
        checkMarkEasy = GameObject.FindGameObjectWithTag("EasySquare");
        checkMarkHard = GameObject.FindGameObjectWithTag("HardSquare");
        checkMarkEasy.SetActive(false);
        checkMarkHard.SetActive(false);
        audioOn = GameObject.FindGameObjectWithTag("audioOn");
        audioOff = GameObject.FindGameObjectWithTag("audioOff");
        audioOff.SetActive(false);
        if (PlayerPrefs.HasKey("HighScore"))
        {
            easyScore.text = "" + PlayerPrefs.GetFloat("HighScore");
        }
        if (PlayerPrefs.HasKey("HighScoreHard"))
        {
            hardScore.text = "" + PlayerPrefs.GetFloat("HighScoreHard");
        }

        if (AudioListener.volume == 0f)
        {
            audioOn.SetActive(false);
            audioOff.SetActive(true);
        }
        //pressedEasy();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void checkMusic()
    {
        if (audioOn.activeInHierarchy)
        {
            audioOn.SetActive(false);
            audioOff.SetActive(true);
            AudioListener.volume = 0f;
        }
        else
        {
            audioOn.SetActive(true);
            audioOff.SetActive(false);
            AudioListener.volume = 1f;
        }
    }

    public void pressedEasy()
    {
        checkMarkEasy.SetActive(true);
        if (checkMarkHard.activeInHierarchy)
        {
            checkMarkHard.SetActive(false);
        }
    }

    public void pressedHard()
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
            transform.GetComponent<AudioSource>().PlayDelayed(0f);
            Invoke("callFade", 0.2f);
        }
    }

    void callFade()
    {
        transform.GetComponent<SceneTransitionManager>().fadeIn(0.15f);
        Invoke("loadLevel", 0.3f);
    }

    void loadLevel()
    {
        SceneManager.LoadScene("Main");
    }

}
