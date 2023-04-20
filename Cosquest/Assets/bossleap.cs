using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossleap : StateMachineBehaviour
{
    private GameObject boss;
    private Rigidbody2D bossrb;
    private GameObject wanderer;
    private bool isFlipped = true;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetInteger("state") != 2)
        {
            return;
        }
        wanderer = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("boss");
        bossrb = boss.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetInteger("state") != 2)
        {
            return;
        }
        lookAtPlayer();
        bossrb.transform.Translate(new Vector2(0, 10 * Time.fixedDeltaTime));
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    void lookAtPlayer()
    {
        Vector3 flipped = boss.transform.localScale;
        flipped.z *= -1f;
        if (boss.transform.position.x > wanderer.transform.position.x && isFlipped)
        {
            boss.transform.localScale = flipped;
            boss.transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (boss.transform.position.x < wanderer.transform.position.x && !isFlipped)
        {
            boss.transform.localScale = flipped;
            boss.transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
 }
