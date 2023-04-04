using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// code adapted from here: https://github.com/Brackeys/2D-Animation/blob/master/2D%20Animation/Assets/Scripts/PlayerMovement.cs

public class MovementStat
{
	public bool jump = false;
	public bool dash = false;
	public bool crouch = false;
}

public class PlayerMovement : MonoBehaviour
{

	public PlayerController controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;

	public MovementStat status = new MovementStat();

	private Timer DashTimer = new Timer();

	[SerializeField] private AudioSource jumpSoundEffect;
	[SerializeField] private AudioSource deathSoundEffect;
	[SerializeField] private AudioSource runSoundEffect;

	// Update is called once per frame
	void Update()
	{
        if (Input.GetButtonDown("Fire3"))
        {
			SceneManager.LoadScene("Main_Menu_new");
		}
		if(controller.canMove)
		{
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

			if (Input.GetButtonDown("Jump"))
			{
				status.jump = true;
				jumpSoundEffect.Play();
				CanvasGroup cg = GameObject.FindGameObjectWithTag("jumptag").GetComponent<CanvasGroup>();
				cg.alpha = 1;
				animator.SetBool("IsJumping", true);
			}

			//ToDo: Implement dash sound effect and cg
			else if (Input.GetButtonDown("Dash"))
			{
				status.dash = true;

				animator.SetBool("IsDashing", true);

				DashTimer.startTimer(0.05f, stopDash);
			}

			DashTimer.Update();
		}

        else
        {
			horizontalMove = 0f;
        }

	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
		Debug.Log("landed!");
		CanvasGroup cg = GameObject.FindGameObjectWithTag("jumptag").GetComponent<CanvasGroup>();
		cg.alpha = 0;
	}

	public void stopDash()
	{
		status.dash = false;
		animator.SetBool("IsDashing", false);
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, status);
		status.jump = false;
	}
}