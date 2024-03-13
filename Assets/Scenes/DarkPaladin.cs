using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkPaladin : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 2000;
        damage = 15;
        speed = 4;
    }

}
