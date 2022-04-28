using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnergy : MonoBehaviour
{
    public GameObject attackEnergy;
    public bool noAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UseAttackEnergy();
    }

    public void UseAttackEnergy()
    {
        if(Input.GetButton("Fire2") && !noAttack)
        {
            StartCoroutine(NotAllowAttack());
            GameObject subItem = Instantiate(attackEnergy, transform.position, Quaternion.identity);


            if (transform.localScale.x < 0)
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f, 0f), ForceMode2D.Force);
            } else
            {
                subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(600f, 0f), ForceMode2D.Force);
            }
        }
    }


    IEnumerator NotAllowAttack()
    {
        noAttack = true;
        yield return new WaitForSeconds(2);
        noAttack = false;

    }
}
