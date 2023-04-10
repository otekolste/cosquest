using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotTiles : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    public int damage;
    [SerializeField] private Animator playerAnim;


    private void DamagePlayer()
    {

        playerHealth.TakeDamage(damage);
        playerAnim.SetTrigger("Hurt");
        Debug.Log("Applied Damage!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DamagePlayer();
        }
    }

}
