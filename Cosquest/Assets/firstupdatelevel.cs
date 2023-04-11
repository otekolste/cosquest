using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstupdatelevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("levelscompleted", 0);

    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("levelscompleted", 0);

    }
}
