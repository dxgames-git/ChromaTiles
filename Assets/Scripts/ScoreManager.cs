using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;

    //Pause OR Death Menu Scores
    public Text pauseScoreText;
    public Text pauseHighScoreText;
    public Text levelName;
    public Text deathName;

    //Death Menu Scores
    public Text deathScore;
    public Text deathHighScore;

    private float scoreCount;
    private float highScoreCount;

    public float pointsPerSecond;
    public bool scoreIncreasing;

    private LevelChooser whichLevel;
    public int level;

    // Use this for initialization
    void Start()
    {
        whichLevel = GameObject.FindGameObjectWithTag("LevelChooser").GetComponent<LevelChooser>();
        level = whichLevel.level;
        if (level == 3)
        {
            levelName.text = "EASY";
            if (PlayerPrefs.HasKey("HighScore"))
            {
                highScoreCount = PlayerPrefs.GetFloat("HighScore");
            }
        }
        else if (level == 5)
        {
            levelName.text = "HARD";
            if(PlayerPrefs.HasKey("HighScoreHard"))
            { 
                highScoreCount = PlayerPrefs.GetFloat("HighScoreHard");
            }
        }
        deathName.text = levelName.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            if (level == 3)
            {
                PlayerPrefs.SetFloat("HighScore", highScoreCount);
            }
            else if (level == 5)
            {
                PlayerPrefs.SetFloat("HighScoreHard", highScoreCount);
            }
        }
        scoreText.text = "" + Mathf.Round(scoreCount);
        pauseScoreText.text = "" + Mathf.Round(scoreCount);
        pauseHighScoreText.text = "High: " + Mathf.Round(highScoreCount);
        deathScore.text = pauseScoreText.text;
        deathHighScore.text = pauseHighScoreText.text;
    }
    public void touchRightBox()
    {
        scoreCount += 1;
    }

}
