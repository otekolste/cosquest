using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTester : MonoBehaviour
{
    private CheckpointController cpc;

    // Start is called before the first frame update
    void Start()
    {
        cpc = GameObject.FindGameObjectWithTag("CPC").GetComponent<CheckpointController>();
        transform.position = cpc.lastCheckpoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
