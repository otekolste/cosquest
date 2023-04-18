using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    [SerializeField] public DialogueManager dm;

    [SerializeField] private Text textHolder;
    [SerializeField] private Text nameHolder;
    [SerializeField] private float delay;
    [SerializeField] private float delayBetweenLines;
    [SerializeField] private Image imageHolder;
    // Start is called before the first frame update

    private bool isInRange;

    private void Update()
    {
        if (isInRange && Input.GetButtonDown("Interact"))
        {
            dm.dialogueSequence(imageHolder, delay, delayBetweenLines, textHolder, nameHolder);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
        }

    }
}
