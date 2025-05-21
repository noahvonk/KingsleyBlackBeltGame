using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rizzard : Troops
{
    protected override void Start()
    {
        base.Start();
        health = 100;
        damage = 150;
        speed = 10;
    }
}
