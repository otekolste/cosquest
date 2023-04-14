using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3 : MonoBehaviour
{

    [Header("Dialogue stuff")]
    [SerializeField] private Text textHolder;
    [SerializeField] private Text nameHolder;
    [SerializeField] private float delay;
    [SerializeField] private float delayBetweenLines;
    [SerializeField] private Image imageHolder;
    [SerializeField] private DialogueManager dm;
    // Start is called before the first frame update
    void Start()
    {
        dm.dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
