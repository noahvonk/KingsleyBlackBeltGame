using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkViking : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 1250;
        damage = 150;
        speed = 7;
        goldDrops = 15;
    }

}
