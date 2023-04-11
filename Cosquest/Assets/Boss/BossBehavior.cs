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
    public Animator animator;
    public BossState currentState;
    public GameObject wanderer; // = GameObject.FindGameObjectWithTag("Player");
    private Vector2 wandererpos;
    private Vector2 currentpos;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine();
        animator.SetInteger("state", 1);
    }

    void stateMachine()
    {
        BossState nextState;
        wandererpos = wanderer.transform.position;
        currentpos = new Vector2(transform.position.x, transform.position.y);
        Vector2 dist = currentpos - wandererpos;
        if ((currentpos - wandererpos).magnitude < 500 && currentState != BossState.meleeAttack)
        {
<<<<<<< Updated upstream:Cosquest/Assets/BossBehavior.cs
            nextState = BossState.meleeAttack;
        } else if (currentState == BossState.hurt) 
=======
            nextState = BossState.wandering;
        } else if (currentState == BossState.wandering)
        {
            if (dist.x * dist.x + dist.y * dist.y > 10) nextState = BossState.leapingAttack; else nextState = BossState.meleeAttack;
        } else if (currentState == BossState.leapingAttack || currentState == BossState.meleeAttack)
        {
            nextState = BossState.wandering;
        } else if (currentState == BossState.vulnerable && hurt)
        {
            nextState = BossState.hurt;
        } else if (currentState == BossState.vulnerable && !hurt)
        {
            nextState = BossState.wandering;
        } else if (currentState == BossState.hurt)
>>>>>>> Stashed changes:Cosquest/Assets/Boss/BossBehavior.cs
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
<<<<<<< Updated upstream:Cosquest/Assets/BossBehavior.cs
        for (float timeToVibe = 3f; timeToVibe > 0f; timeToVibe -= Time.deltaTime) yield return null; 
=======
        animator.SetInteger("state", 1);
        for (float timeToVibe = 3f; timeToVibe > 0f; timeToVibe -= Time.deltaTime) yield return null;
        for (int i = 0; i < enemiesToInstantiate.Length; i++) 
            Instantiate(enemiesToInstantiate[i], new Vector3(transform.position.x + 2f * i, transform.position.y, 0), Quaternion.identity); ;
>>>>>>> Stashed changes:Cosquest/Assets/Boss/BossBehavior.cs
        stateMachine();
    }
    IEnumerator leapingAttackState()
    {
<<<<<<< Updated upstream:Cosquest/Assets/BossBehavior.cs
        yield return null;
=======
        animator.SetInteger("state", 2);
        for (float jumpHeight = 10f; jumpHeight > 0f; jumpHeight -= Time.deltaTime)
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
>>>>>>> Stashed changes:Cosquest/Assets/Boss/BossBehavior.cs
        stateMachine();
    }
    IEnumerator meleeAttackState()
    {
        animator.SetInteger("state", 3);
        yield return null;
        stateMachine();
    }
    IEnumerator hurtState()
    {
        animator.SetInteger("state", 4);
        yield return null;
        stateMachine();
    }
    IEnumerator  wanderingState()
    {
        animator.SetInteger("state", 5);
        yield return null;
        stateMachine();
    }
<<<<<<< Updated upstream:Cosquest/Assets/BossBehavior.cs
    IEnumerator fleeingState()
    {
        yield return null;
=======
    IEnumerator wanderingState()
    {
        animator.SetInteger("state", 6);
        currentpos = new Vector2(transform.position.x, transform.position.y);
        wandererpos = wanderer.transform.position;
        Vector2 dist = currentpos - wandererpos;
        while(dist.x * dist.x + dist.y * dist.y < 40000 && dist.x * dist.x + dist.y * dist.y > 250)
        {
            Vector3 newdirection = new Vector3(Random.Range(-10f, 10f), 0, 0);
            for (float time = 0.5f; time > 0f; time -= Time.deltaTime)
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
        animator.SetInteger("state", 7);
        for (float time = 0.5f; time > 0f; time -= Time.deltaTime)
        {
            transform.position += Vector3.forward * Time.deltaTime;
            yield return null;
        }
>>>>>>> Stashed changes:Cosquest/Assets/Boss/BossBehavior.cs
        stateMachine();
    }
    // Update is called once per frame - currently not use but may be useful??
    // void Update()
    // {
    //    
    // }
}
