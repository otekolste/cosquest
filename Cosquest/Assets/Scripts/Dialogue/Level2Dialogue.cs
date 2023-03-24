using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Dialogue : MonoBehaviour
{

    [SerializeField] private Text textHolder;
    [SerializeField] private Text nameHolder;
    [SerializeField] private float delay;
    [SerializeField] private float delayBetweenLines;
    [SerializeField] private Image imageHolder;
    [SerializeField] private DialogueManager dm;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueManager>().dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

    }

    public IEnumerator IceLevelStart()
    {

        FindObjectOfType<DialogueManager>().dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

        yield return new WaitUntil(DialogueOver);
    }

    bool DialogueOver()
    {
        return dm.finished;
    }



}
