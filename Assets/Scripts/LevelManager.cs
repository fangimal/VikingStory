using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void QuitRequest()
    {
        Debug.Log("Я хочу выйти!");
        Application.Quit();
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

}
