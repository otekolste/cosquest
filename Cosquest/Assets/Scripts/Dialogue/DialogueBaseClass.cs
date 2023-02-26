using System.Collections;
using UnityEngine.UI;
using UnityEngine;


namespace DialogueSystem{
    public class DialogueBaseClass : MonoBehaviour{
        public bool finished {get; private set;}
        protected IEnumerator writeText(string[] input, Text textHolder, float delay, AudioClip sound, float delayBetweenLines){
            for(int j = 0; j < input.Length; j++){
                textHolder.text = "";
                foreach (char letter in input[j].ToCharArray())
                {
                    textHolder.text += letter;
                    SoundManager.instance.PlaySound(sound); //play letter sound
                    yield return new WaitForSeconds(delay);
                }
                yield return new WaitUntil(() => Input.GetMouseButton(0));
            }
          //  yield return new WaitUntil(()=>Input.GetMouseButton(0));
            finished = true;
        }
    }
}
