using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectre : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 1000;
        damage = 9999;
        speed = 35;
        goldDrops = 15;
    }
}
