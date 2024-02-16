using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mogger : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 99999999;
        damage = 99999999;
        speed = 1;
        goldDrops = 1000;
    }

}
