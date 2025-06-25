using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 2000;
            damage = 500;
            speed = 10;
            goldDrops = 15;
        } else {
        health = 200;
        damage = 250;
        speed = 10;
        goldDrops = 10;
        }
    }
}
