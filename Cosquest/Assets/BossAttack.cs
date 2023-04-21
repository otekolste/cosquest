using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
	public int attackDamage = 20;
	public int enragedAttackDamage = 40;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public Health playerHealth;
	public Animator playerAnim;


	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo.tag == "Player")
		{
			playerHealth.TakeDamage(attackDamage);
			playerAnim.SetTrigger("Hurt");
		}
	}
	
	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo.tag == "Player")
		{
			playerHealth.TakeDamage(attackDamage);
			playerAnim.SetTrigger("Hurt");

		}
	}
	

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}