using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    new Rigidbody2D rb;
    bool fall = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        rb = GetComponent<Rigidbody2D>();
        if (!fall)
        {
            if(collision.gameObject.tag == "Player")
            {
                rb.isKinematic = false;
                rb.gravityScale = 8f;
                fall = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Hazard")
        {
            gameObject.tag = "Ground";
        }    
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
