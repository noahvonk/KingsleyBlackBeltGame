using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bahamut : Troops
{
    protected override void Start()
    {
        base.Start();
        health = 100000;
        damage = 100000;
        speed = 25;
        TroopSpawner.Instanc.BahamutActive = true;
    }
}
