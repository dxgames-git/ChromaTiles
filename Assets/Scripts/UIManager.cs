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
    private AudioSource gameMusic;
    private float timeCounter;
    private bool loopDone;
    private bool deathDone;

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
            deathPanel.SetActive(true);
            gameMusic.Stop();
            gameMusic.clip = deathMusic;
            gameMusic.PlayDelayed(0.05f);

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
            isPaused = true; //Required for recognizing which toggle it is.
            Time.timeScale = 0.0f; //Paused
            gameMusic.Pause();
            pausePanel.SetActive(true);
            return;
        }
        isPaused = false;
        Time.timeScale = 1.0f; //Unpaused
        gameMusic.UnPause();
        pausePanel.SetActive(false);
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
        SceneManager.LoadScene("Title Screen");
        Start();
    }

}
