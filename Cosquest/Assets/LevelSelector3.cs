using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector3 : MonoBehaviour
{

    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene("Level3");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main_Menu_new");
    }
}
