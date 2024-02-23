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
        health = rnd.Next(10, 1001);
        damage = rnd.Next(100, 15001);
        speed = rnd.Next(9, 21);
        goldDrops = 10000;
    }
}
