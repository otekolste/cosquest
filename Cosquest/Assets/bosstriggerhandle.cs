using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosstriggerhandle : MonoBehaviour
{
    public GameObject wanderer;
    public Animator animator;
    public GameObject laser;
    public float timetofight;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("hit the player\n");
        } else if (collision.gameObject.tag == "laser")
        {
            Debug.Log("shot the boss\n");
        } else
        {
            Debug.Log("some other coll\n");
        }
    }

    void Update()
    {
       if(Mathf.Floor(timetofight) % 30 == 0) 
        {
            timetofight -= Time.deltaTime;
        } else if (timetofight <= 0)
        {
            animator.SetInteger("state", 7);
        } else
        {
            timetofight -= Time.deltaTime;
        }
    }
}
