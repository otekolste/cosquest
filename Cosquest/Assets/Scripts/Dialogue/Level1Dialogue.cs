using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Dialogue : MonoBehaviour
{

    [SerializeField] private Text textHolder;
    [SerializeField] private Text nameHolder;
    [SerializeField] private float delay;
    [SerializeField] private float delayBetweenLines;
    [SerializeField] private Image imageHolder;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueManager>().dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

    }


}
