using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kratos : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 12500;
        damage = 9999;
        speed = 3;
    }

}