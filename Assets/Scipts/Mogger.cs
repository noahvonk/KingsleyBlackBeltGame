using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mogger : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 50000;
        damage = 5000;
        speed = 10;
        goldDrops = 500;
    }

}
