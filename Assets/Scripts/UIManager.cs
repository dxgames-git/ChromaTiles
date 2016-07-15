using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject deathPanel;

    public bool isPaused;
    public bool isRestart;
    public bool isDead;

    private GameObject Box;
    // Use this for initialization
    void Start()
    {
        isPaused = false;
        isRestart = false;
        isDead = false;
        Box = GameObject.FindGameObjectWithTag("Box");
    }

    // Update is called once per frame
    void Update()
    {

        //Pause Menu
        if (isPaused)
        {
            pauseGame(true);
        }
        else {
            pauseGame(false);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            switchPause();
        }
        if (isRestart)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (isDead) {
            deathPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
    void pauseGame(bool state)
    {
        if (state)
        {
            Time.timeScale = 0.0f; //Paused
        }
        else {
            Time.timeScale = 1.0f; //Unpaused
        }
        pausePanel.SetActive(state);
    }
    public void switchPause()
    {
        if (isPaused)
        {
            isPaused = false; //Changes the bool value 
        }
        else {
            isPaused = true;
        }
    }
    public void restart()
    {
        isRestart = true;
    }
}
