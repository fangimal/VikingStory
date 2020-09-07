using UnityEngine;
using UnityEngine.UI;


public class SaveScore : MonoBehaviour
{
    public Text scoreDisplay;
    private int score;
    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreDisplay.text = score.ToString();

    }

    void Update()
    {

    }
}
