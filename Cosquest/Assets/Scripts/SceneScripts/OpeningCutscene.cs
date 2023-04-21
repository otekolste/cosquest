using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningCutscene : MonoBehaviour
{

    [SerializeField] private Text textHolder;
    [SerializeField] private Text nameHolder;
    [SerializeField] private float delay;
    [SerializeField] private float delayBetweenLines;
    [SerializeField] private Image imageHolder;

    [SerializeField] private DialogueManager dm;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(OpeningScene());
    }

    private IEnumerator OpeningScene()
    {
        dm.dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);

        yield return new WaitUntil(DialogueOver);

        SceneManager.LoadScene("Level1");

    }

    private bool DialogueOver()
    {
        return dm.finished;
    }
}
