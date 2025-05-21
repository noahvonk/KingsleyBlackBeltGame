using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragnir : Enemy
{
    protected override void Start()
    {
        base.Start();
        health = 1000000;
        damage = 50000;
        speed = 10;
        GameManager.Instance.DragnirActive = true;
    }
}
