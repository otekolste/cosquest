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
        fleeing,
        vulnerable
    }
    public BossState currentState;
    public GameObject wanderer; // = GameObject.FindGameObjectWithTag("Player");
    public GameObject[] enemiesToInstantiate; // = GameObject.FindGameObjectsWithTag("Enemy");
    private Vector2 wandererpos;
    private Vector2 currentpos;
    private bool hurt;

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
        if(currentState == BossState.idle)
        {
            nextState = BossState.wandering;
        } else if (currentState == BossState.wandering)
        {
            if (dist.x * dist.x + dist.y * dist.y > 1000) nextState = BossState.leapingAttack; else nextState = BossState.meleeAttack;
        } else if (currentState == BossState.leapingAttack || currentState == BossState.meleeAttack)
        {
            nextState = BossState.vulnerable;
        } else if (currentState == BossState.vulnerable && hurt)
        {
            nextState = BossState.hurt;
        } else if (currentState == BossState.vulnerable && !hurt)
        {
            nextState = BossState.wandering;
        } else if (currentState == BossState.hurt)
        {
            nextState = BossState.fleeing;
        } else if (currentState == BossState.fleeing)
        {
            nextState = BossState.idle;
        } else {
            nextState = BossState.idle;
        }
        StopCoroutine(currentState.ToString() + "State");
        currentState = nextState;
        StartCoroutine(currentState.ToString() + "State");
    }
    IEnumerator idleState()
    {
        for (float timeToVibe = 3f; timeToVibe > 0f; timeToVibe -= Time.deltaTime) yield return null;
        for (int i = 0; i < enemiesToInstantiate.Length; i++) 
            Instantiate(enemiesToInstantiate[i], new Vector3(transform.position.x + 2f * i, transform.position.y, 0), Quaternion.identity); ;
        stateMachine();
    }
    IEnumerator leapingAttackState()
    {
        for (float jumpHeight = 100f; jumpHeight > 0f; jumpHeight -= Time.deltaTime)
        {
            transform.position += new Vector3(0, 100 * Time.deltaTime, 0);
            yield return null;
        }
        currentpos = new Vector2(transform.position.x, transform.position.y);
        wandererpos = wanderer.transform.position;
        Vector2 dist = currentpos - wandererpos;
        Vector2 sep = dist;
        while (sep.x * sep.x + sep.y * sep.y > 1) // i cant believe there's no way to take a norm 
        {
            transform.position += new Vector3(dist.x * Time.deltaTime, dist.y * Time.deltaTime, 0);
            currentpos = new Vector2(transform.position.x, transform.position.y);
            wandererpos = wanderer.transform.position;
            sep = currentpos - wandererpos;
            yield return null;
        }
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
    IEnumerator vulnerableState()
    {
        yield return null;
        stateMachine();
    }
    IEnumerator wanderingState()
    {
        currentpos = new Vector2(transform.position.x, transform.position.y);
        wandererpos = wanderer.transform.position;
        Vector2 dist = currentpos - wandererpos;
        while(dist.x * dist.x + dist.y * dist.y < 40000 && dist.x * dist.x + dist.y * dist.y > 250)
        {
            Vector3 newdirection = new Vector3(Random.Range(-100f, 100f), 0, 0);
            for (float time = 2f; time > 0f; time -= Time.deltaTime)
            {
                transform.position += newdirection * Time.deltaTime;
                yield return null;
            }
            currentpos = new Vector2(transform.position.x, transform.position.y);
            wandererpos = wanderer.transform.position;
            dist = currentpos - wandererpos;
        }
        stateMachine();
    }
    IEnumerator fleeingState()
    {
        for(float time = 2f; time > 0f; time -= Time.deltaTime)
        {
            transform.position += Vector3.forward * Time.deltaTime;
            yield return null;
        }
        stateMachine();
    }
    // Update is called once per frame - currently not use but may be useful??
    // void Update()
    // {
    //    
    // }
}
