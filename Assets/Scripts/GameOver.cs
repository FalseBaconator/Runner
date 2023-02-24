using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI text;
    public string message;
    int highScore;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        score = GameObject.FindGameObjectWithTag("ScoreHolder").GetComponent<ScoreHolder>().Score;
        if(score > highScore)
        {
            highScore = score;
        }
        text.text = message + " " + highScore;
        PlayerPrefs.SetInt("HighScore", highScore);
    }
}
