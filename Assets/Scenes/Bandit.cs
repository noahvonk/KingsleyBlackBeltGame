using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{
    protected override void Start()
    {
        base.Start();
         if(GameManager.Instance.wave >= 50){
            health = 2500;
            damage = 500;
            speed = 45;
            goldDrops = 750;
        } else {
        health = 950;
        damage = 150;
        speed = 45;
        goldDrops = 100;
        }
    }
}
