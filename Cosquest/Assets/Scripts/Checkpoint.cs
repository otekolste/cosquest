using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointController cpc;
    // Start is called before the first frame update
    void Start()
    {
        cpc = GameObject.FindGameObjectWithTag("CPC").GetComponent<CheckpointController>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cpc.lastCheckpoint = transform.position;
        }
    }
}
