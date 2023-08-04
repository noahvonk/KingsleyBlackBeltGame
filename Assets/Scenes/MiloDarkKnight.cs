using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiloDarkKnight : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 50;
        damage = 15;
        speed = 10;
        goldDrops = 50;
    }
}
