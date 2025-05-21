using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiloDarkKnight : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 200;
        damage = 30;
        speed = 15;
        goldDrops = 5;
    }
}
