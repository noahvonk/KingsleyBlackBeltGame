using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jahames : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 75000;
        damage = 300;
        speed = 15;
        goldDrops = 1000;
    }

}
