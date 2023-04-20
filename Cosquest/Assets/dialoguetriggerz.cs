using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialoguetriggerz : MonoBehaviour
{
    public dialoguez dia;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialoogueManagerz>().StartDialogue(dia);
    }
}
