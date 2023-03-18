using UnityEngine;

//Adapted from https://github.com/nickbota/Unity-Platformer-Episode-10/blob/main/Assets/Scripts/Enemy/EnemyPatrol.cs

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    [Header ("RB")]
    [SerializeField] private Rigidbody2D enemy_RB;

    [SerializeField] private bool enemyFacingRight;
    public float runSpeed = 40f;

    private void Awake()
    {
        initScale = enemy.localScale;
        enemy_RB = GetComponent<Rigidbody2D>();
    }
    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);

        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction * -1,
            initScale.y, initScale.z);

        //Move in that direction
        enemy_RB.velocity = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
    /*
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        enemyFacingRight = !enemyFacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnColliderEnter(Collider other)
    {
        if (other.tag==("PatrolPoint")) {
            Flip();
        }
    }
    */
}
