using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    // Update is called once per frame
   public void OpenScene()
    {
        SceneManager.LoadScene("initial_cutscene");
    }
}
