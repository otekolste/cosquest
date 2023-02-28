using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float startPos;
    private float Lenght;
    private GameObject cam;
    [SerializeField] private float parallaxEffect;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        startPos = transform.position.x;
        Lenght = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temporary = (cam.transform.position.x * (1- parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(temporary > startPos + Lenght)
        {
            startPos += Lenght;
        }
        else if(temporary < startPos - Lenght)
        {
            startPos -= Lenght;
        }
    }
}
