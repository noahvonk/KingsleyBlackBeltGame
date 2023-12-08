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
        health = 500;
        damage = 150;
        speed = 1;
        goldDrops = 1000;
    }

}
