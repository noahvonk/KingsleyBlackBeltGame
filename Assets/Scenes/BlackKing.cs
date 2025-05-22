using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKing : Enemy
{
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 20000;
            damage = 500;
            speed = 15;
            goldDrops = 10;
        } else {
        health = 1250;
        damage = 100;
        speed = 14;
        goldDrops = 40;
        }
    }
}
