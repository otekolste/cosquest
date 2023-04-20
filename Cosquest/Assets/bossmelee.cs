using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmelee : StateMachineBehaviour
{
    private GameObject boss;
    private Rigidbody2D bossrb;
    private GameObject wanderer;
    private Health health;
    private bool isFlipped = false;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.GetInteger("state") != 3)
        {
            return;
        }
        wanderer = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("boss");
        bossrb = boss.GetComponent<Rigidbody2D>();
        health = wanderer.GetComponent<Health>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetInteger("state") != 3 || animator.GetInteger("state") == 7)
        {
            return;
        }
        lookAtPlayer();
        Vector2 target = new Vector2(wanderer.transform.position.x, bossrb.position.y);
        Vector2 newPos = Vector2.MoveTowards(bossrb.position, target, 8f * Time.fixedDeltaTime);
        bossrb.MovePosition(newPos);
        if(Vector2.Distance(bossrb.position, wanderer.transform.position) < 0.5f)
        {
            health.TakeDamage(3);
            animator.SetInteger("state", 1);
        }
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
