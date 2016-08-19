using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text highScoreText;
    public Text deathHighScore;

    //public Text highScoreTextHard;
    //public Text deathHighScoreHard;

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
        if (level == 3 && PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        else if (level == 5 && PlayerPrefs.HasKey("HighScoreHard"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScoreHard");
        }
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
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
        deathHighScore.text = highScoreText.text;
    }
    public void touchRightBox()
    {
        scoreCount += 1;
    }

}
