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
        health = rnd.Next(10, 2501);
        damage = rnd.Next(10, 1501);
        speed = rnd.Next(15, 50);
        goldDrops = rnd.Next(10, 101);
    }
}
