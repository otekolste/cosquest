﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour
{
    // Start is called before the first frame update
public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
}
