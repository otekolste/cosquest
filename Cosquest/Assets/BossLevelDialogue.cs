using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLevelDialogue : MonoBehaviour
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
    [SerializeField] private GameObject boss;

    [Header("3rd round (after fight) box")]
    [SerializeField] private Text textHolder3;

    [SerializeField] private Image levelOver;
    [SerializeField] private AudioSource music;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(BossStart());

    }



    public IEnumerator BossStart()
    {
        dm.dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

        yield return new WaitUntil(DialogueOver);

        dino.SetBool("Visible", true);

        yield return new WaitForSeconds(1.5f);

        dm.dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder2, nameHolder);

        yield return new WaitUntil(DialogueOver);

        dino.SetBool("Visible", false);

        yield return new WaitForSeconds(1.5f);

        boss.SetActive(true);
    }

    public IEnumerator BossEnd()
    {

        dm.dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder3, nameHolder);

        yield return new WaitUntil(DialogueOver);

        boss.SetActive(false);

        music.Pause();

        levelOver.gameObject.SetActive(true);

    }

    bool DialogueOver()
    {
        return dm.finished;
        Debug.Log("dialogue Done");
    }
}
