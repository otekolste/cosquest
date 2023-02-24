using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace DialogueSystem{
    public class DialogueLine : DialogueBaseClass{
        private Text textHolder;
        [SerializeField]private string input;

        [Header("Character Image")]
        [SerializeField]private Sprite characterSprite;
        [SerializeField]private Image imageHolder;
        [SerializeField]private float delay;
        [SerializeField]private float delayBetweenLines;
        [SerializeField]private AudioClip sound;
         
        private void Awake(){
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }
        
        private void Start(){
            StartCoroutine(writeText(input, textHolder, delay, sound, delayBetweenLines));
        }

    }
}

