using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayerController : MonoBehaviour, IDamageable
{

    public float health = 5f;
    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void OnHit(float damage, Vector2 knockback)
    {
        throw new System.NotImplementedException();
    }

    public void OnHit(float damage)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
