using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class Helper : MonoBehaviour
{
   public void GoHome()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Pause()
    {
        Time.timeScale = 0f;

    }

   public void Resume()
    {
        Time.timeScale = 1f;
    }
}
