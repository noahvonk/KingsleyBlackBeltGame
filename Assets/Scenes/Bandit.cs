using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 1000;
        damage = 17500;
        speed = 20;
    }
}
