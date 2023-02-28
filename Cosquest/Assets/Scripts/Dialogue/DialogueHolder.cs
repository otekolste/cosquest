using System.Collections;
using UnityEngine.UI;
using UnityEngine;



namespace DialogueSystem{
    public class DialogueHolder : MonoBehaviour{

        [SerializeField] private Image imageHolder;
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;
        [SerializeField] private Text textHolder;
        [SerializeField] private Text nameHolder;


        public bool finished;

        private void Awake(){
            //    Debug.Log("Good morning!");

            StartCoroutine(dialogueSequence());
        }

        protected IEnumerator dialogueSequence(){

            for(int i = 0; i < transform.childCount; i++){
                //    transform.GetChild(i).gameObject.SetActive(true);
            //    Debug.Log("Starting sentence...");
             //   StopAllCoroutines();
                StartCoroutine(writeSentence(transform.GetChild(i).GetComponent<DialogueLine>().input, transform.GetChild(i).GetComponent<DialogueLine>().sound, transform.GetChild(i).GetComponent<DialogueLine>().characterSprite, transform.GetChild(i).GetComponent<DialogueLine>().name));
            //    Debug.Log("beep boop");
                yield return new WaitUntil(() => finished == true);
            }
        }

        private IEnumerator writeSentence(string[] input, AudioSource sound, Sprite cSprite, string cName)
        {
           // Debug.Log("hi");
            nameHolder.text = cName;
            textHolder.text = "";
            imageHolder.sprite = cSprite;
            finished = false;
            for (int j = 0; j < input.Length; j++)
            {
                textHolder.text = "";
                foreach (char letter in input[j].ToCharArray())
                {
                    textHolder.text += letter;
                    sound.Play(); //play letter sound
                    yield return new WaitForSeconds(delay);
                    if(Input.GetMouseButton(1))
                    {

                        textHolder.text = input[j];
                        break;
                    }
                }

                yield return new WaitUntil(() => Input.GetMouseButton(0));
            }
            //  yield return new WaitUntil(()=>Input.GetMouseButton(0));
          //  Debug.Log("all done!");
            finished = true;
        }

    }
}

