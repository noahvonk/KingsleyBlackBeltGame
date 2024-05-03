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
        health = rnd.Next(1, 1000001);
        damage = rnd.Next(100, 1000001);
        speed = rnd.Next(1, 11);
        goldDrops = 10000;
    }
}
