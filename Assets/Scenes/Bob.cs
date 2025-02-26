using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bob : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 200000;
        damage = 100;
        speed = 2;
        goldDrops = 10000;
    }
}
