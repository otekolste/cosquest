using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("initial_cutscene");
    }
    public void SelectLevel()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
