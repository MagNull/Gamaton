using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
    public void Game()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("scene-1");
    }
}
