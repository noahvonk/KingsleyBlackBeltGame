using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLZ : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 500000;
        damage = 100000;
        speed = 5;
    }
}
