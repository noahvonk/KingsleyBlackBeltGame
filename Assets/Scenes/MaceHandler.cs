using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceHandler : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        health = 75;
        damage = 50;
        speed = 5;
        goldDrops = 100;
    }
}
