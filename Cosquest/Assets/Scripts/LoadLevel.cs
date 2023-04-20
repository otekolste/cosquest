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

    public void OpenLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void OpenLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
     public void OpenLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void OpenLevel5()
    {
        SceneManager.LoadScene("Level5");
    }

    public void OpenBoss()
    {
        SceneManager.LoadScene("Boss");
    }

}
