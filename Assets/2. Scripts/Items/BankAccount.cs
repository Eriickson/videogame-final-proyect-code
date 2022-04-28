using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankAccount : MonoBehaviour
{
    public float bank;
    public int dragonBalls;
    public Text bankText;
    public Text dragonBallText;


    public static BankAccount instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Money(float cashCollected)
    {
        bank += cashCollected;
        bankText.text = "x " + bank.ToString();
    }

    public void addDragonBalls(int dragonBallCollected)
    {
        dragonBalls += dragonBallCollected;
        dragonBallText.text = dragonBalls.ToString() + " / 7";
    }

    // Start is called before the first frame update
    void Start()
    {
        bankText.text = "x " + bank.ToString();
        dragonBallText.text = dragonBalls.ToString() + " / 7";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
