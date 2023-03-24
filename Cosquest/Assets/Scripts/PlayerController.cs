using UnityEngine;
using UnityEngine.Events;
using System.Collections;

// code adapted from here: https://github.com/Brackeys/2D-Animation/blob/master/2D%20Animation/Assets/Scripts/CharacterController2D.cs

public class PlayerController : MonoBehaviour
{

	[Header("Positioning")]
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = true;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	public AudioSource DeathSound;

	public Vector3 RespawnPoint;
	public GameObject FallDetector;

	public bool canMove;
	private Shooting shooting;

	private bool iceControls;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[Header("Respawn")]
	[SerializeField] private float respawnOffset;


	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Start()
    {
        // Get a reference to the Shooting component on the same GameObject
        shooting = GetComponent<Shooting>();
		shooting.canShoot = false;
    }

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		RespawnPoint = transform.position;
		canMove = true;
	}

	private void Update()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject && colliders[i].tag=="Platform")
			{
				m_Grounded = true;
				if (!wasGrounded) { 
				OnLandEvent.Invoke();

				}
			}
		}

		FallDetector.transform.position = new Vector2(transform.position.x, FallDetector.transform.position.y);
	}


	public void Move(float move, MovementStat status)
	{
		if (canMove)
		{
			//only control the player if grounded or airControl is turned on
			if (m_Grounded || m_AirControl)
			{


				// Move the character by finding the target velocity
				Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
				// And then smoothing it out and applying it to the character
				if (status.dash && move != 0.0f)
				{
					if (m_FacingRight)
					{
						targetVelocity = new Vector2(50f, 0);
					}
					else
					{
						targetVelocity = new Vector2(-50f, 0);
					}
				}

                if (iceControls)
                {
					m_Rigidbody2D.AddForce(targetVelocity);
				}
				else {

					m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

				}

				// If the input is moving the player right and the player is facing left...
				if (move > 0 && !m_FacingRight)
				{
					// ... flip the player.
					Flip();
				}
				// Otherwise if the input is moving the player left and the player is facing right...
				else if (move < 0 && m_FacingRight)
				{
					// ... flip the player.
					Flip();
				}
			}
			// If the player should jump...
			if (m_Grounded && status.jump)
			{
				// Add a vertical force to the player.
				m_Grounded = false;
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			}
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private IEnumerator ResetCanShoot(){
		yield return new WaitForSeconds(5f);
		shooting.canShoot = false;
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Powerup_Laser"){
			Debug.Log("Powerup!\n");
			Destroy(collision.gameObject);
			shooting.canShoot = true;
			StartCoroutine(ResetCanShoot());
		}

		if (collision.tag == "FallDetector")
		{
			DeathSound.Play();
			Respawn();
		}

		if(collision.tag == "Checkpoint")
        {
			RespawnPoint = collision.transform.position;
			collision.GetComponent<Animator>().SetTrigger("activate");
        }

	}

	public void Respawn()
    {
		transform.position = new Vector3(RespawnPoint.x, RespawnPoint.y + respawnOffset, RespawnPoint.z);
	}

	public void setIceControls(bool ice)
    {
		iceControls = ice;
    }

}