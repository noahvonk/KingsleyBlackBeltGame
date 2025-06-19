using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielder : Troops

{
    protected override void Start()
    {
        base.Start();
        health = 2000;
        damage = 125;
        speed = 20;
    }
}