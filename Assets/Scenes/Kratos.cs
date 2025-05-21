using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kratos : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 55000;
        damage = 4500;
        speed = 10;
        goldDrops = 500;
    }

}