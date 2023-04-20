using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossrunning : StateMachineBehaviour
{
    private GameObject boss;
    private Rigidbody2D bossrb;
    private GameObject wanderer;
    private bool isFlipped = true;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetInteger("state") != 5)
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
        if(animator.GetInteger("state") != 5 || animator.GetInteger("state") == 7)
        {
            return;
        }
        lookAtPlayer();
        Vector2 target = new Vector2(wanderer.transform.position.x, bossrb.position.y);
        Vector2 newPos = Vector2.MoveTowards(bossrb.position, target, 5f * Time.fixedDeltaTime);
        bossrb.MovePosition(newPos);
        if(Vector2.Distance(wanderer.transform.position, bossrb.position) < 3f)
        {
            animator.SetInteger("state", 3);
        } else if (Vector2.Distance(wanderer.transform.position, bossrb.position) > 10f)
        {
            animator.SetInteger("state", 2);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    void lookAtPlayer() 
    {
        Vector3 flipped = boss.transform.localScale;
        flipped.z *= -1f;
        if(boss.transform.position.x > wanderer.transform.position.x && isFlipped)
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
