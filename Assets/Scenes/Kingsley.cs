using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kingsley : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 75000;
        damage = 7500;
        speed = 8;
    }
}
