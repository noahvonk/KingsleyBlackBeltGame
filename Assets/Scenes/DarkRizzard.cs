using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRizzard : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 95;
        damage = 150;
        speed = 20;
        goldDrops = 10;
    }
    
}
