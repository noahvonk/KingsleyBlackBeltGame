using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kingsley : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 100000;
        damage = 10000;
        speed = 3;
    }
}
