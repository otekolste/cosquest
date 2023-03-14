﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image endScreen;

    [SerializeField] private Text textHolder;
    [SerializeField] private Text nameHolder;
    [SerializeField] private float delay;
    [SerializeField] private float delayBetweenLines;
    [SerializeField] private Image imageHolder;

    [SerializeField] private string playerTag;
    [SerializeField] private DialogueManager dm;

    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource victoryNoise;

    [SerializeField] private PlayerController wanderer;





    public bool hasTriggered = false;
    // Start is called before the first frame update


    public IEnumerator TriggerEndSequence()
    {

      //  StopAllCoroutines();

        FindObjectOfType<DialogueManager>().dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

        yield return new WaitUntil(DialogueOver);

        Debug.Log("hi");
        music.Pause();
        victoryNoise.Play();

        endScreen.gameObject.SetActive(true);
        wanderer.canMove = false;


        yield return null;



    }

    bool DialogueOver()
    {
        return dm.finished;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        //  Debug.Log("trigger");
        if (other.tag == playerTag && hasTriggered == false)
        {
            textHolder.gameObject.SetActive(true);

            hasTriggered = true;

            StartCoroutine(TriggerEndSequence());
            
            
        }
    }
}
