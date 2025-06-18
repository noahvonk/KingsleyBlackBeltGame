using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman : Troops
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 125;
        damage = 100;
        speed = 14;
    }
}
