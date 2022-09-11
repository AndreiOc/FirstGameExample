using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public Collider2D swordCollider;
    Vector2 rightAttackOffest;
    public float damage = 1f;
    public float knockBackForce = 100f;

    public Vector3 faceRight = new Vector3(0.92f,0,0) ;
    public Vector3 faceLeft = new Vector3(-0.37f,0,0) ;

    private void Start()
    {
        swordCollider.enabled = false;
        rightAttackOffest = transform.localPosition;
    }
    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffest;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        //TODO da capire perchè non va questo maledetto codice 
        transform.localPosition = new Vector3(-0.37f, rightAttackOffest.y);
    }
    public void StopAttack()
    {
        swordCollider.enabled = false;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageableObject = other.GetComponent<IDamageable>();
        if(damageableObject != null)
        {
            //Vettori utili al knockback
            Vector2 directionKnockback;
            //se attacco da destra va a destra 
            if((Vector2)transform.localPosition == rightAttackOffest)
                directionKnockback = new Vector2(1,0);
            else
            {
                directionKnockback = new Vector2(-1,0);

            }
            Vector2 knockBack = directionKnockback * knockBackForce;
            damageableObject.OnHit(damage,knockBack);
            
        }
        else
        {
            Debug.Log("No IDamageable");
        }

    } 


}
