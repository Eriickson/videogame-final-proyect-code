using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBallItem : MonoBehaviour
{
    public int dragonBallNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BankAccount.instance.addDragonBalls(dragonBallNumber);
            AudioManager.instance.PlayAudio(AudioManager.instance.DragonBall);
            Destroy(gameObject);
        }
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
