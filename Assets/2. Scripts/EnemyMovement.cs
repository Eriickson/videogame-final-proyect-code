using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed;
    Rigidbody2D rb;
    Animator anim;

    public bool isStatic;
    public bool isFly;
    public bool isPatrol;
    public bool shouldWait;
    public float timeToWait;
    public bool isWaiting;

    public bool walkRight;

    public Transform walkCheck, pitCheck, groundCheck;

    bool walkDetected, pitDetected, isGrounded;

    public float detectionRadius;
    public LayerMask whatIsGround;

    public Transform PointA, PointB;
    bool goToA, goToB;

    // Start is called before the first frame update
    void Start()
    {
        goToA = true;
        speed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.localScale = new Vector2(-1, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {

        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectionRadius, whatIsGround);
        walkDetected = Physics2D.OverlapCircle(walkCheck.position, detectionRadius, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, detectionRadius, whatIsGround);

        if ((pitDetected || walkDetected) && isGrounded)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if(isStatic)
        {
            anim.SetBool("Idle", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if(isFly)
        {
            anim.SetBool("Idle", false);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            if(walkRight)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            } else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }

        }
        if(isPatrol)
        {

            if(goToA)
            {
                if(!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                }
                

                if(Vector2.Distance(transform.position, PointA.position) < 0.2f)
                {

                    if(shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }

                    Flip();
                    goToA = false;
                    goToB = true;
                }
            }

            if(goToB)
            {
                if (!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                }

                if (Vector2.Distance(transform.position, PointB.position) < 0.2f)
                {

                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }

                    Flip();
                    goToA = true;
                    goToB = false;
                }
            }

        }

    }

    IEnumerator Waiting()
    {
        anim.SetBool("Idle", true);
        isWaiting = true;
        Flip();
        yield return new WaitForSeconds(timeToWait);
        Flip();
        isWaiting = false;
        anim.SetBool("Idle", false);

    }

    public void Flip()
    {
        walkRight = !walkRight;
        transform.localScale = new Vector2(-1, transform.localScale.y);
    }
}
