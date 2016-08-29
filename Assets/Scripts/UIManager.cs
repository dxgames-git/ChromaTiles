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

    private GameObject Box;

    private AudioSource gameMusic;

    // Use this for initialization
    void Start()
    {
        isPaused = false;
        isDead = false;
        Box = GameObject.FindGameObjectWithTag("Box");
        gameMusic = gameObject.GetComponent<AudioSource>();

        timeCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (Input.GetButtonDown("Cancel"))
        {
            switchPause();
        }
        {
        }
        {
            deathPanel.SetActive(true);
        }
        {
        }
    }
    public void switchPause()
    {
        {
        }
    }
    public void restart()
    {
        gameMusic.Stop();
    }
    public void mainMenu()
    {
    }
}
