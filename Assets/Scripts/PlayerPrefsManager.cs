using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    const string SCORE_KEY = "last_score";
    public static void SetLevelUnlocked(int score)
    {
        PlayerPrefs.SetInt(SCORE_KEY, score);
    }
}
