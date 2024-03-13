using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 13209;
        damage = 4832;
        speed = 6;
    }

}
