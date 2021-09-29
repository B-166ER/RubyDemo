using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreText : MonoBehaviour
{
    
    [SerializeField]
    private TextMeshProUGUI HighScoreUIText;

    public void SetNewHighScore(int scr)
    {
        HighScoreUIText.text = scr.ToString();
    }
}
