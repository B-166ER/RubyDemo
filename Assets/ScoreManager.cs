using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public static int Score;
    [SerializeField]
    private TextMeshProUGUI scoreUILabel;
    int HighScore;
    [SerializeField] HighScoreText HSText;


    private void Start()
    {
        //score manager singleton
        if (instance == null) instance = this;

        //record event listeners
        GameManager.instance.OnShotOccured += IncreaseScore;
        GameManager.instance.OnTimerEnded += HandleHighScore;

        // using playerprefs for non volatile mem
        if (PlayerPrefs.HasKey("HighScore"))
            HSText.SetNewHighScore(PlayerPrefs.GetInt("HighScore"));
        else
        {
            PlayerPrefs.SetInt("HighScore", 0);
            HSText.SetNewHighScore(0);
        }
    }

    public void HandleHighScore()
    {
        Time.timeScale = 0;
        Debug.Log("Game ended");
        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScore = PlayerPrefs.GetInt("HighScore");
            if (Score < HighScore)
            {
                //dont update high score

            }
            else
            {
                //update high score
                PlayerPrefs.SetInt("HighScore",Score);
                //there is a new high score,notify HighScoreManager
                HSText.SetNewHighScore(Score);
            }
        }
        else
        {
            // there is no highscore yet
            PlayerPrefs.SetInt("HighScore",Score);
            //new highscore,notify game manager
        }

    }
    public void IncreaseScore()
    {
        Score++;
        scoreUILabel.text = Score.ToString();
    }

}
