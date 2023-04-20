using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosslevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Time.timeScale = 0;
        GetComponent<dialoguetriggerz>().TriggerDialogue();
    }

}
