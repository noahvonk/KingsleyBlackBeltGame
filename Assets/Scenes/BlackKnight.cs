using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackKnight : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 1000;
        damage = 95;
        speed = 23;
        goldDrops = 20;
    }
}
