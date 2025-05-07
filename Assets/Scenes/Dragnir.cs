using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragnir : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 10000000;
        damage = 50000;
        speed = 1;
    }
}
