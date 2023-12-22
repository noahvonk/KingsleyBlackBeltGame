using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman : Troops
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 150;
        damage = 15;
        speed = 7;
    }
}
