using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{

    [SerializeField] private PlayerController w;
    // Start is called before the first frame update
    void Start()
    {
        w.setIceControls(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
