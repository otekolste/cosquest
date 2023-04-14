using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level4 : MonoBehaviour

{

    [Header("Dialogue stuff")]
    [SerializeField] private Text textHolder;
    [SerializeField] private Text nameHolder;
    [SerializeField] private float delay;
    [SerializeField] private float delayBetweenLines;
    [SerializeField] private Image imageHolder;
    [SerializeField] private DialogueManager dm;

    [Header("2nd round box")]
    [SerializeField] private Text textHolder2;

    [Header("Characters")]
    [SerializeField] private PlayerController player;
    [SerializeField] private Animator dino;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(HotLevelStart());

    }


    public IEnumerator HotLevelStart()
    {

        dm.dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

        yield return new WaitUntil(DialogueOver);

        dino.SetBool("Visible", true);

        yield return new WaitForSeconds(1.5f);

        dm.dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder2, nameHolder);

        yield return new WaitUntil(DialogueOver);

        dino.SetBool("Visible", false);
    }

    bool DialogueOver()
    {
        return dm.finished;
        Debug.Log("dialogue Done");
    }
}
