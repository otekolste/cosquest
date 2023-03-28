using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Dialogue : MonoBehaviour
{

    [Header("Dialogue stuff")]
    [SerializeField] private Text textHolder;
    [SerializeField] private Text nameHolder;
    [SerializeField] private float delay;
    [SerializeField] private float delayBetweenLines;
    [SerializeField] private Image imageHolder;
    [SerializeField] private DialogueManager dm;

    [Header("Characters")]
    [SerializeField] private PlayerController player;
    [SerializeField] private Animator dino;
    // Start is called before the first frame update
    void Start()
    {
        
        IceLevelStart();

    }

    public IEnumerator IceLevelStart()
    {

        dm.dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

        yield return new WaitUntil(DialogueOver);

        dino.SetTrigger("dinoRunForward");
    }

    bool DialogueOver()
    {
        return dm.finished;
        Debug.Log("dialogue Done");
    }



}
