using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code adapted from here: https://github.com/Brackeys/2D-Animation/blob/master/2D%20Animation/Assets/Scripts/PlayerMovement.cs

public class PlayerMovement : MonoBehaviour
{

	public PlayerController controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;

	[SerializeField] private AudioSource jumpSoundEffect;
	[SerializeField] private AudioSource deathSoundEffect;
	[SerializeField] private AudioSource runSoundEffect;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			jumpSoundEffect.Play();

			animator.SetBool("IsJumping", true);
		}



	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
		Debug.Log("landed!");
	}



	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}
}