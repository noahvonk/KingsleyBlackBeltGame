using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Troops
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 600;
        damage = 1000;
        speed = 35;
    }
}
