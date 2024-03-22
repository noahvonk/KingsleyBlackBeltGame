using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KLZ : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 5000000;
        damage = 1000000;
        speed = 5;
    }
}
