using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;

    void Start()
    {
        
    }


    void Update()
    {
        scoreDisplay.text = "Счёт: " + score.ToString();
    }

    public void Kill()
    {
        score++;
    }
}
