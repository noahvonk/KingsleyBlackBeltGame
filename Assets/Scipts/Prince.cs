using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prince : Troops
{
   protected override void Start()
    {
        base.Start();
        health = 750;
        damage = 2500;
        speed = 25;
    }
}
