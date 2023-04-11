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
        if(PlayerPrefs.GetInt("levelscompleted") > 1)
            SceneManager.LoadScene("Level2");
    }

    public void OpenLevel3()
    {
        if (PlayerPrefs.GetInt("levelscompleted") > 2)
            SceneManager.LoadScene("Level3");
    }
     public void OpenLevel4()
    {
        if (PlayerPrefs.GetInt("levelscompleted") > 3)

            SceneManager.LoadScene("Level4");
    }
    public void OpenLevel5()
    {
        if (PlayerPrefs.GetInt("levelscompleted") > 4)
            SceneManager.LoadScene("Level5");
    }

}
