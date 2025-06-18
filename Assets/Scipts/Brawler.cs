using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brawler : Troops
{
    protected override void Start()
    {
        base.Start();
        health = 750;
        damage = 15;
        speed = 15;
    }    
}
