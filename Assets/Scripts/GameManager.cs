using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager instance;

    // canvas to be activated after shot
    [SerializeField] Canvas EndingCanvas;

    // the event that will be fired after the shot
    public event Action OnShotOccured;
    public event Action OnTimerEnded;
    public event Action OnNewHighScore;

    [SerializeField] public bool isMouseEventTimeRelevant;
    [SerializeField] public bool waitForTouchGroundBeforePush;
    public void NewHighScore()
    {
        if (OnNewHighScore != null)
        {
            OnNewHighScore();
        }
    }

    public void ShotOccured()
    {
        if (OnShotOccured != null)
        {
            OnShotOccured();
            // wait and show restart button
            // dont wait and end at single basket now.
            //StartCoroutine( WaitAndEnd() );
        }
    }
    // when cound down clock hits 0 end the game .
    // and handle persistence highscore
    public void TimerEnded()
    {
        //Game timer ended handle high score logic
        if (OnTimerEnded != null)
        {
            OnTimerEnded();
        }
    }

    //deprecated
    private IEnumerator WaitAndEnd()
    {
        yield return new WaitForSecondsRealtime(5f);
        EndingCanvas.enabled = true;
    }

    public void SceneReload()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        instance = this;
    }
}
