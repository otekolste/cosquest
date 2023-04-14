using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField] private Animator playerAnim;

    public bool dialogue;
    public int nextSceneLoad;





    public bool hasTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

    }


    public IEnumerator TriggerEndSequence()
    {

        //  StopAllCoroutines();

        if (dialogue)
        {
            textHolder.gameObject.SetActive(true);
            FindObjectOfType<DialogueManager>().dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

            yield return new WaitUntil(DialogueOver);
        }

    //    Debug.Log("hi");
        music.Pause();
        victoryNoise.Play();

        endScreen.gameObject.SetActive(true);
        wanderer.canMove = false;
        playerAnim.SetFloat("Speed", 0);


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
           // textHolder.gameObject.SetActive(true);

            hasTriggered = true;

            StartCoroutine(TriggerEndSequence());

            PlayerPrefs.SetInt("levelAt", nextSceneLoad);


      


        }
    }
}
