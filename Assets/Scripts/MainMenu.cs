using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        
        SceneManager.LoadScene("GamePlay");

    }

    public void Quit()
    {
        Application.Quit();
         
    }
    public void MainMenuLoad()
    {
        SceneManager.LoadScene("Main Menu");
    }

 public void ShowGames()
    {
        SceneManager.LoadScene("GameList");
       
    }
    public void SpaceShooterLoad()
    {
        SceneManager.LoadScene("SpaceShooterGamePlay");

    }
    public void DuckShooterLoad()
    {
        SceneManager.LoadScene("DuckShooterGameplay");
    }
    public void SlideyMark()
    {
        SceneManager.LoadScene("GamePlay");

    }
    public void RaceCarLoad()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");

    }

}
