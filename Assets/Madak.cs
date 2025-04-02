using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Madak : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 15000;
        damage = 500;
        speed = 1;
        goldDrops = 1000;
    }

}
