using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceHandler : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 150;
        damage = 100;
        speed = 5;
        goldDrops = 100;
    }
}
