using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    [SerializeField] private Text textHolder;
    [SerializeField] private Text nameHolder;
    [SerializeField] private float delay;
    [SerializeField] private float delayBetweenLines;
    [SerializeField] private Image imageHolder;

    [SerializeField] private string playerTag;

    public bool hasTriggered = false;
    // Start is called before the first frame update
    public IEnumerator TriggerDialogue()
    {

        StopAllCoroutines();

        FindObjectOfType<DialogueManager>().dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

        yield return new WaitUntil(FindObjectOfType<DialogueManager>().IsDialogueOver);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
      //  Debug.Log("trigger");
        if (other.tag == playerTag && hasTriggered == false)
        {
            textHolder.gameObject.SetActive(true);

            hasTriggered = true;
            TriggerDialogue();

        }
    }

}

