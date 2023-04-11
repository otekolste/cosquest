using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatelevel : MonoBehaviour
{
    public int levelscompleted;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("levelscompleted") < levelscompleted)
        {
            PlayerPrefs.SetInt("levelscompleted", levelscompleted);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("levelscompleted") < levelscompleted)
        {
            PlayerPrefs.SetInt("levelscompleted", levelscompleted);

        }
    }
}
