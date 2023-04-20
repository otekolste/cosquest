using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public enum BossState
    {
        idle, // 1
        leapingAttack, // 2
        meleeAttack, // 3
        hurt, // 4
        wandering, // 5
        fleeing // 6
    }
    public Animator animator;
    public BossState currentState;
    public BossState nextState;
    public GameObject wanderer; 
    private GameObject enemy; 
    private GameObject patrol;  
    private Vector2 wandererpos;
    private Vector2 currentpos;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        patrol = GameObject.FindGameObjectWithTag("Patrol");
        stateMachine();
    }

    Vector2 dist()
    {
        wandererpos = new Vector2(wanderer.transform.position.x, wanderer.transform.position.y);
        currentpos = new Vector2(transform.position.x, transform.position.y);
        return currentpos - wandererpos;
    }
    void stateMachine()
    {
        StopCoroutine(currentState.ToString() + "State");
        currentState = nextState;
        StartCoroutine(currentState.ToString() + "State");
    }
    IEnumerator idleState()
    {
        Debug.Log("idle");
        animator.SetInteger("state", 1);
        GameObject newEnemy = Object.Instantiate(enemy, transform.position, Quaternion.identity, patrol.transform);
        newEnemy.transform.position = new Vector3(newEnemy.transform.position.x, -1.4f, 0);
        for (float timeToVibe = 0.5f; timeToVibe > 0f; timeToVibe -= Time.deltaTime) yield return null;
        nextState = BossState.wandering;
        Debug.Log("end of idle");
        stateMachine();
    }
    IEnumerator leapingAttackState()
    {
        Debug.Log("leaping attact\n");
        nextState = BossState.idle;
        yield return null;
        stateMachine();
    }
    IEnumerator meleeAttackState()
    {
        Debug.Log("melee attact\n");
        nextState = BossState.idle;
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
        animator.SetInteger("state", 5);
        bool facingright = true;
        while (dist().sqrMagnitude > 5 && dist().sqrMagnitude < 20)
        {
            float j = Random.Range(0, 1);
            if(j < 0.5f)
            {
                if (facingright)
                {
                    Vector3 scale = transform.localScale;
                    scale.x *= -1;
                }
                facingright = false;
            } else
            {
                if (!facingright)
                {
                    Vector3 scale = transform.localScale;
                    scale.x *= -1;
                }
                facingright = true;
            }
            for (float i = Random.Range(0f, 2f); i > 0; i -= Time.deltaTime)
            {
                if (facingright)
                {
                    transform.Translate(new Vector3(5*Time.deltaTime, 0, 0));
                } else
                {
                    transform.Translate(new Vector3(-5 * Time.deltaTime, 0, 0));
                }
                yield return null;
            }
        }
        nextState = BossState.wandering;
        if (!facingright)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
        }
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
