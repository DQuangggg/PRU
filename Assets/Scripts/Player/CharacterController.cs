using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float jump = 400f;
    public GameObject BloodEffect;
    float horizontalMove;
    bool facingRight;
    bool grounded;
    Animator animator;
    Rigidbody2D rb;

    public int hearts = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;
    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);


        if (horizontalMove > 0 && !facingRight)
        {
            flip();
        }
        else if (horizontalMove < 0 && facingRight)
        {
            flip();
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (grounded)
            {
                animator.SetBool("jump", true);
                grounded = false;
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Hazard")
        {
            grounded = true;
            
        }
        if (collision.gameObject.tag == "Wall")
        {
            speed = 0;
            animator.SetBool("jump", false);
        }
        if (collision.gameObject.tag == "Trap")
        {
            animator.SetBool("dead", true);
            Instantiate(BloodEffect, transform.position, transform.rotation);
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        //stop all movement on main character
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        yield return new WaitForSeconds(0.5f);
        hearts--;
        if (hearts <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else {
            animator.SetBool("dead", false);
            transform.position = new Vector3(12, 10, 0);
        }
    }

}
