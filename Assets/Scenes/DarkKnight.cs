using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkKnight : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 100;
        damage = 15;
        speed = 10;
        goldDrops = 100;

    }

}
