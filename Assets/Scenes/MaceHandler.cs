using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceHandler : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 250;
        damage = 300;
        speed = 19;
        goldDrops = 10;
    }
}
