﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
    public Button[] lvlButtons;
    // Start is called before the first frame update
    void Start()
    {
      
        int levelAt = PlayerPrefs.GetInt("levelAt", 3);
        Debug.Log(levelAt);

        for(int i = 0; i < lvlButtons.Length; i++)
        {
            if (i +3> levelAt)
                lvlButtons[i].interactable = false;
        }
        
    }

 

}
