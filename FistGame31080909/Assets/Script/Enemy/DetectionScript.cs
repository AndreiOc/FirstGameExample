using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D detecedPlayer;
    public Collider2D cc2D;
    private Rigidbody2D rb2D;
    // Update is called once per frame
    private void Start()
    {
        rb2D = transform.parent.GetComponent<Rigidbody2D>();    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            detecedPlayer = other;

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
            detecedPlayer = null;

    }
}
