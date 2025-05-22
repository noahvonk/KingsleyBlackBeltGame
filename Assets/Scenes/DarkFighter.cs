using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkFighter : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 2500;
            damage = 1000;
            speed = 30;
            goldDrops = 10;
        } else {
        health = 200;
        damage = 75;
        speed = 25;
        goldDrops = 5;
        }
    }
}
