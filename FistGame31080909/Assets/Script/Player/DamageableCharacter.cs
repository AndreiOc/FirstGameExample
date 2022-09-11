using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour,IDamageable
{
    
    public float health = 5f;
    public float damage = 1f;
    private Animator animator;
    
    PlayerUIManager uIManager;
    Rigidbody2D rb2D;
    private void Start()
    {
        animator = GetComponent<Animator>();    
        rb2D = GetComponent<Rigidbody2D>();
        uIManager = GameObject.Find("UIManager").GetComponent<PlayerUIManager>();
    }

    /// <summary>
    /// Setta e diminuisce la salute
    /// </summary>
    /// <value></value>
    public float Health
    {
        set{
            health = value;
            animator.SetTrigger("isTakingDamage");
            if(health<=0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }


    public void Defeated()
    {
        rb2D.simulated = false; // quando muore disattivo il suo rigidbody
        animator.SetTrigger("isDying");
        if(transform.tag == "Enemy")
        {
            uIManager.IncreaseScore();
        }
    }
    public void RemoveObject()
    {
        if(transform.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if(transform.tag == "Player")
        {
            uIManager.EndGame();
        }
    }
    
    /// <summary>
    /// Funzione che sottrae la  vita al nemico
    /// </summary>
    /// <param name="damage"> danno inflitto</param>

    public void OnHit(float damage,Vector2 knockback)
    {
        Health -= damage;
        rb2D.AddForce(knockback);
    }


    public void OnHit(float damage)
    {
        Health -= damage;
    }

} 