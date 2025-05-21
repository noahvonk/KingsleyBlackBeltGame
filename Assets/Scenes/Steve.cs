using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;


public class Steve : Enemy
{
    Random rnd = new Random();
    protected override void Start()
    {
        base.Start();
        health = rnd.Next(1, 500001);
        damage = rnd.Next(1000, 500001);
        speed = rnd.Next(10, 51);
        goldDrops = rnd.Next(1, 10001);
    }
}
