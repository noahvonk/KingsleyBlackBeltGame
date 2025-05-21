using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkFighter : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 200;
        damage = 75;
        speed = 25;
        goldDrops = 5;
    }
}
