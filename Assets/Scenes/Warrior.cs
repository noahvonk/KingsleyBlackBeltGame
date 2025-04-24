using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Troops
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 1000;
        damage = 50;
        speed = 20;
    }
}

