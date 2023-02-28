using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private static CheckpointController cpc;
    public Vector2 lastCheckpoint;
       
    // Start is called before the first frame update
    void Awake()
    {
        if(cpc == null)
        {
            cpc = this;
            DontDestroyOnLoad(cpc);
        } else
        {
            Destroy(gameObject);
        }
    }
}
