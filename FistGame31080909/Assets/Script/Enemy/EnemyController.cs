using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float knockBackForce = 800f;
    public float moveSpeed = 1f;
    public DetectionScript detectionZone;
    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool canMove = true;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        if(canMove)
        {
            if(detectionZone.detecedPlayer != null)
            {
                Vector2 direction = (detectionZone.detecedPlayer.transform.position - transform.position).normalized; 
                if(direction.x > 0)
                    spriteRenderer.flipX = false;
                else if(direction.x < 0)
                    spriteRenderer.flipX = true;
                rb2D.MovePosition(rb2D.position + direction * moveSpeed * Time.fixedDeltaTime);
                animator.SetBool("isMoving",true);
            }
            else
            {
                animator.SetBool("isMoving",false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Collider2D collider2D = other.collider;
        IDamageable damageable = other.collider.GetComponent<IDamageable>();
        if(damageable!=null &&  collider2D.tag == "Player")
        {
            Debug.Log(other.collider.gameObject);
            Vector2 direction = (collider2D.transform.position - transform.position).normalized;
            Vector2 knockback = direction * knockBackForce;
            damageable.OnHit(1.0f,knockback);
        }
    }

    public void OnLockMovement(){
        canMove = false;
    }
    public void OnUnLockMovement(){
        canMove = true;
    }

}
