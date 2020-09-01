using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    public Text scoreDisplay;
    private int score;

    void Start()
    {
        score = 0;
    }


    void Update()
    {
        scoreDisplay.text = "Счёт: " + score.ToString();
        
    }

    public void Kill()
    {
        score++;
        PlayerPrefs.SetInt("Score", score);
       
    }
}
