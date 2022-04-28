using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    bool isInmune;
    public float inmunityTime;
    SpriteRenderer sprite;
    Blink material;
    public float knockBackForceX;
    public float knockBackForceY;
    Rigidbody2D rb;
    public Image healthImage;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        material = GetComponent<Blink>();
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = health / 100;

        if (health > maxHealth)
        {
            health = maxHealth;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Inmunity());

            if (collision.transform.position.x > transform.position.x) {
                rb.AddForce(new Vector2(-knockBackForceX, knockBackForceY), ForceMode2D.Force);
            } else
            {
                rb.AddForce(new Vector2(knockBackForceX, knockBackForceY), ForceMode2D.Force);
            }

            if (health <= 0 )
            {
                // Show Game Over Screen;
            }
        }
    }

    IEnumerator Inmunity()
    {
        isInmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.original;
        isInmune = false;

    }
}
