using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CASEOH : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 9999999;
        damage = 1;
        speed = 1;
    }

}
