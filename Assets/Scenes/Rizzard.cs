using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rizzard : Troops
{
    protected override void Start()
    {
        base.Start();
        health = 150;
        damage = 2500;
        speed = 10;
    }
}
