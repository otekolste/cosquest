using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public void OpenLevelSelect()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void OpenLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

}
