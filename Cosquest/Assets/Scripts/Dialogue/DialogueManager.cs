using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{



    [SerializeField] public Animator anim;

    private Queue<DialogueLine> lines;

    public bool finished;

    void Awake()
    {

        lines = new Queue<DialogueLine>();


    }

    public void dialogueSequence(Image imageHolder, float delay, float delayBetweenLines, Text textHolder, Text nameHolder)
    {
        Debug.Log("Starting dialogue!");
        finished = false;
        anim.SetBool("IsOpen", true);
        Debug.Log(textHolder.transform.childCount);

        for (int i = 0; i < textHolder.transform.childCount; i++)
        {
           // Debug.Log(textHolder.transform.GetChild(i).GetComponent<DialogueLine>().name);
            //   StartCoroutine(writeSentence(textHolder.transform.GetChild(i).GetComponent<DialogueLine>().input, textHolder.transform.GetChild(i).GetComponent<DialogueLine>().sound, textHolder.transform.GetChild(i).GetComponent<DialogueLine>().characterSprite, textHolder.transform.GetChild(i).GetComponent<DialogueLine>().name));
            lines.Enqueue(textHolder.transform.GetChild(i).GetComponent<DialogueLine>());
            Debug.Log("yippee!");
        }
        DisplayNextSentence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

    }

    private void DisplayNextSentence(Image imageHolder, float delay, float delayBetweenLines, Text textHolder, Text nameHolder)
    {
        if(lines.Count==0)
        {
            EndDialogue(textHolder);
            Debug.Log("all done!");
            return;
        }
        Debug.Log(lines.Count);
        DialogueLine currentLine = lines.Dequeue();
        StartCoroutine(writeSentence(currentLine.input, currentLine.sound, currentLine.characterSprite, currentLine.name, imageHolder, nameHolder, textHolder, delay, delayBetweenLines));
    }

    private IEnumerator writeSentence(string[] input, AudioSource sound, Sprite cSprite, string cName, Image imageHolder, Text nameHolder, Text textHolder, float delay, float delayBetweenLines)
    {
        // Debug.Log("hi");
        nameHolder.text = cName;
        textHolder.text = "";
        imageHolder.sprite = cSprite;

        for (int j = 0; j < input.Length; j++)
        {
            textHolder.text = "";
            foreach (char letter in input[j].ToCharArray())
            {
                textHolder.text += letter;
                sound.Play(); //play letter sound
                yield return new WaitForSeconds(delay);
                if (Input.GetMouseButton(1))
                {

                    textHolder.text = input[j];
                    break;
                }
            }

            yield return new WaitUntil(() => Input.GetMouseButton(0));
        }

        DisplayNextSentence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);
    }

    private void EndDialogue(Text textHolder)
    {
        finished = true;
        Debug.Log("Dialogue over!");
        anim.SetBool("IsOpen", false);

        textHolder.enabled = false;



    }

    public bool IsDialogueOver()
    {
        return finished;
    }
}
