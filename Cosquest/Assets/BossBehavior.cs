using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public enum BossState
    {
        idle,
        leapingAttack,
        meleeAttack,
        hurt,
        wandering,
        fleeing
    }
    public BossState currentState;
    public GameObject wanderer; // = GameObject.FindGameObjectWithTag("Player");
    private Vector2 wandererpos;
    private Vector2 currentpos;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine();
    }

    void stateMachine()
    {
        BossState nextState;
        wandererpos = wanderer.transform.position;
        currentpos = new Vector2(transform.position.x, transform.position.y);
        Vector2 dist = currentpos - wandererpos;
        if ((currentpos - wandererpos).magnitude < 500 && currentState != BossState.meleeAttack)
        {
            nextState = BossState.meleeAttack;
        } else if (currentState == BossState.hurt) 
        {
            nextState = BossState.fleeing;
        } else
        {
            nextState = BossState.leapingAttack;
        }
        StopCoroutine(currentState.ToString() + "State");
        currentState = nextState;
        StartCoroutine(currentState.ToString() + "State");
    }
    IEnumerator idleState()
    {
        for (float timeToVibe = 3f; timeToVibe > 0f; timeToVibe -= Time.deltaTime) yield return null; 
        stateMachine();
    }
    IEnumerator leapingAttackState()
    {
        yield return null;
        stateMachine();
    }
    IEnumerator meleeAttackState()
    {
        yield return null;
        stateMachine();
    }
    IEnumerator hurtState()
    {
        yield return null;
        stateMachine();
    }
    IEnumerator  wanderingState()
    {
        yield return null;
        stateMachine();
    }
    IEnumerator fleeingState()
    {
        yield return null;
        stateMachine();
    }
    // Update is called once per frame - currently not use but may be useful??
    // void Update()
    // {
    //    
    // }
}
