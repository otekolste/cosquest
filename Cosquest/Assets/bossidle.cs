using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossidle : StateMachineBehaviour
{
    private GameObject wanderer;
    private GameObject enemy;
    private GameObject patrol;
    private GameObject boss; 
    private Vector2 wandererpos;
    private Vector2 currentpos;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.GetInteger("state") != 1 && animator.GetInteger("state") != 3)
        {
            return;
        }
        wanderer = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        patrol = GameObject.FindGameObjectWithTag("Patrol");
        boss = GameObject.FindGameObjectWithTag("boss");
        GameObject newEnemy = Object.Instantiate(enemy, boss.transform.position, Quaternion.identity, patrol.transform);
        newEnemy.transform.position = new Vector3(newEnemy.transform.position.x, -1.4f, 0);
        animator.SetInteger("state", 5);
    }

}
