using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Sigma : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 250000;
        damage = 5432;
        speed = 50;
        goldDrops = 250;
    }
}
