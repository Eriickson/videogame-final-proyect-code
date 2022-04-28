 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy enemy;
    public bool isDamaged;
    public GameObject deathEffect;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb;

    private void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon") && !isDamaged)
        {
            enemy.healthPoints -= 2f;

            if(collision.transform.position.x < transform.position.x)
            {

                rb.AddForce(new Vector2(enemy.knockBackForceX, enemy.knockBackForceY), ForceMode2D.Force);
            }
            else
            {

                rb.AddForce(new Vector2(-enemy.knockBackForceX, enemy.knockBackForceY), ForceMode2D.Force);
            }


            StartCoroutine(Damager());
            if(enemy.healthPoints <=0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Damager()
    {
        isDamaged = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.3f);
        sprite.material = material.original;
        isDamaged = false;

    }
}
