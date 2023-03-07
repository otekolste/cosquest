using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        FindObjectOfType<DialogueManager>().dialogueSequence();
    }
}
