using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CASEOH : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 500000;
        damage = 1000;
        speed = 5;
        goldDrops = 750;
    }

}
