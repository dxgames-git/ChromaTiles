using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject deathPanel;

    public bool isPaused;
    public bool isDead;

    public AudioClip introMusic;
    public AudioClip loopMusic;
    public AudioClip deathMusic;

    //Music controls
    public AudioSource gameMusic;
    private float timeCounter;
    private bool loopDone;
    private bool deathDone;
    private TitleScreenManager isMusicOn;

    private GameObject ScoreText;
    private GameObject Manager;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        isPaused = false;
        isDead = false;

        gameMusic = gameObject.GetComponent<AudioSource>();

        timeCounter = 0f;
        loopDone = false;
        deathDone = false;

        ScoreText = GameObject.Find("ScoreText");
        Manager = GameObject.Find("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        //Computer-only: Press escape to toggle pause menu
        if (Input.GetButtonDown("Cancel"))
        {
            switchPause();
        }
        //if(isMusicOn.toggleAudio)
        //Loops music for gameplay
        if (timeCounter >= introMusic.length && !loopDone)
        {
            loopDone = true;
            gameMusic.Stop();
            gameMusic.clip = loopMusic;
            gameMusic.PlayDelayed(0.75f);
        }

        //Changes music for death screen
        if (isDead && !deathDone)
        {
            deathDone = true;
            pausePanel.SetActive(false);
            deathPanel.SetActive(true);
            ScoreText.SetActive(false);
            gameMusic.Stop();

            Time.timeScale = 0f;
        }
        if (deathDone)
        {
            Time.timeScale = 0f;
        }
    }

    //Gets called whenever the pause button is pressed
    public void switchPause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0.0f; //Paused
            isPaused = true; //Required for recognizing which toggle it is.
            gameMusic.Pause();
            pausePanel.SetActive(true);
            ScoreText.SetActive(false);
            AdManager.Instance.ShowBanner();
            return;
        }
        Time.timeScale = 1.0f; //Unpaused
        isPaused = false;
        gameMusic.UnPause();
        pausePanel.SetActive(false);
        ScoreText.SetActive(true);
    }

    public void restart()
    {
        gameMusic.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Start();
    }

    public void mainMenu()
    {
        //Application.LoadLevel("Title Screen"); is outdated *Had to include "using UnityEngine.SceneManagement;" up top
        gameMusic.Stop();
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
        //Manager.GetComponent<SceneTransitionManager>().fadeIn(0.3f);
        callFade();
        Start();
    }

    void callFade()
    {
        Manager.GetComponent<SceneTransitionManager>().fadeIn(0.15f);
        Invoke("loadLevel", 0.2f);
    }

    void loadLevel()
    {
        SceneManager.LoadScene("Title Screen");
    }

}
