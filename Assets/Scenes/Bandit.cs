using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 950;
        damage = 150;
        speed = 45;
        goldDrops = 100;
    }
}
