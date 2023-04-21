using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Adapted from https://github.com/nickbota/Unity-Platformer-Episode-10/blob/main/Assets/Scripts/Health/Health.cs


public class BossHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int startingHealth;
    public int currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    public BossHealthBar bossBar;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Controller")]
    [SerializeField] private PlayerController wandererController;
    [SerializeField] private EnemyPatrol EnemyController;

    public BossLevelDialogue dialogue;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int damage)
    {
        if (invulnerable) return;

        currentHealth -= damage;
        Debug.Log(currentHealth);
        bossBar.SetHealth(currentHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }

        if(currentHealth< startingHealth/2)
        {
            anim.SetBool("IsEnraged", true);
        }

        if(currentHealth<=0)
        {
            anim.SetBool("IsDed", true);
            StartCoroutine(dialogue.BossEnd());

        }

    }
    /*
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    */
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

    
}