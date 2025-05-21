using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bob : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 100000;
        damage = 750;
        speed = 5;
        goldDrops = 750;
    }
}
