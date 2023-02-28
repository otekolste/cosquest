using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace DialogueSystem{
    public class DialogueLine : DialogueBaseClass{
       // private Text textHolder;
        [SerializeField]public string[] input;

        [Header("Character Image")]
        [SerializeField]public Sprite characterSprite;

        [SerializeField]public AudioSource sound;

        [SerializeField] public string name;
         
        /*
        private void Start(){
            StartCoroutine(writeText(input, textHolder, delay, sound, delayBetweenLines));
        }
        */

    }
}

