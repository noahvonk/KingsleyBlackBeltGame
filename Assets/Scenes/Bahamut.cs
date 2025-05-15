using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bahamut : Troops
{
    protected override void Start()
    {
        base.Start();
        health = 1000000;
        damage = 1000000;
        speed = 45;
        TroopSpawner.Instanc.BahamutActive = true;
    }
}
