using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SaveScore : MonoBehaviour
{
    public Text scoreDisplay;
    private int score;
    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreDisplay.text = "Последний счёт: " + score.ToString();
        
    }

    void Update()
    {
        
    }
}
