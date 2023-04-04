using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector2 : MonoBehaviour
{

    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene("cashins_sample 2");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main_Menu_new");
    }
}
