using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;


public class Jester : Enemy
{
    Random rnd = new Random();
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = rnd.Next(1000, 25001);
        damage = rnd.Next(100, 15001);
        speed = rnd.Next(15, 50);
        goldDrops = rnd.Next(10, 101);
        } else {
        health = rnd.Next(10, 2501);
        damage = rnd.Next(10, 1501);
        speed = rnd.Next(15, 50);
        goldDrops = rnd.Next(10, 101);
        }
    }
}
