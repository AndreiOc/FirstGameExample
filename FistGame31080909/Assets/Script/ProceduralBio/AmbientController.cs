using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2D;
    public float knockBackForce = 700f;
    public bool playerDirection;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("cc");
        IDamageable damageableObject = other.collider.GetComponent<IDamageable>();
        Collider2D enemy = other.collider;
        if(damageableObject != null && enemy.tag == "Enemy")
        {
            Debug.Log("Collision");
           //Vettori utili al knockback
            Vector2 directionKnockback;
            if(!playerDirection)
                directionKnockback = new Vector2(1,0);
            else
                directionKnockback = new Vector2(-1,0);

            //se attacco da destra va a destra 

            Vector2 knockBack = directionKnockback * knockBackForce;
            damageableObject.OnHit(0f,knockBack);
               
        }
    }
    // Update is called once per frame
    void FUpdate()
    {
        
    }
}
