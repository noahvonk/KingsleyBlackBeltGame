using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKing : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 15000;
        damage = 999;
        speed = 6;
    }
}
