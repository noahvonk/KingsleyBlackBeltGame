using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jahames : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 25000;
        damage = 3000;
        speed = 30;
        goldDrops = 200;
    }

}
