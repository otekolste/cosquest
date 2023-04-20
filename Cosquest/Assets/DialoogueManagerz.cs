using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoogueManagerz : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public Animator animator;
    private GameObject textbox;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(dialoguez dia)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dia.name;
        sentences.Clear();
        foreach (string sentence in dia.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        waiter();
        DisplayNextSentence();
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        // Time.timeScale = 1;
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
    }
}
