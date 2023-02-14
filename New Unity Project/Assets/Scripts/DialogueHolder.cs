using System.Collections;
using UnityEngine.UI;
using UnityEngine;



namespace DialogueSystem{
    public class DialogueHolder : MonoBehaviour{
        
        private void Awake(){

            StartCoroutine(dialogueSequence());
        }

        protected IEnumerator dialogueSequence(){

            for(int i = 0; i < transform.childCount; i++){  
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
        }
        private void Deactivate(){  
            for(int k = 0; k < transform.childCount; k++){
                    transform.GetChild(k).gameObject.SetActive(false);
            }
        }
    }
}

