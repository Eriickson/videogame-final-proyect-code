using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed, jumpHeight;
    float speedX, speedY;
    Rigidbody2D rb;
    public Transform groundCheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    bool leftPosition = false;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(isGrounded)
        {
            anim.SetBool("Jump", false);
        } else
        {
            anim.SetBool("Jump", true);
        }

        FlipCharacter();


    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
        Attack();
    }


    public void Movement()
    {

        speedX = Input.GetAxisRaw("Horizontal");
        speedY = rb.velocity.y;

        rb.velocity = new Vector2(speedX * speed, speedY);

        if (rb.velocity.x != 0)
        {
            anim.SetBool("Fly", true);
        }
        else
        {
            anim.SetBool("Fly", false);
        }
    }

    public void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    public void Attack()
    {

        if(Input.GetButton("Fire1"))
        {
            anim.SetBool("Attack", true);
        } else
        {
            anim.SetBool("Attack", false);
        }
    }


    public void FlipCharacter()
    {

        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            leftPosition = false;
        }
        else if(rb.velocity.x < 2)
        {
            leftPosition = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
