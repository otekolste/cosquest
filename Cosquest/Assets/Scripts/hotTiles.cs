using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotTiles : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    public int damage;


    private void DamagePlayer()
    {

        playerHealth.TakeDamage(damage);
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
