using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isGrounded;
    private Animator anim;
    private float moveSpeed=8f;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }
    private void Update()
    {
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
            if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
                rb.AddForce(Vector2.up * 1200f);
            if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
                anim.SetBool("isRunning", true);
            else
                anim.SetBool("isRunning", false);
            if (rb.velocity.y == 0)
            {
                anim.SetBool("IsJumping", false);
            }
            if (rb.velocity.y > 0)
            {
                anim.SetBool("IsJumping", true);
            }
            if (rb.velocity.y < 0)
            {
                anim.SetBool("IsJumping", false);
            }  
    }
    private  void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
        Flip();
    }
    private void Flip()
    {
        if (dirX > 0)
            facingRight = true;
        else if(dirX<0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }

}