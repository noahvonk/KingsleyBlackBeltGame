using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heros : Troops
{ 
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 500;
        damage = 50;
        speed = 15;
    }
}
