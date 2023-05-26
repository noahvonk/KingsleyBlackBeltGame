using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkFighter : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 10;
        speed = 20;
        goldDrops = 100;
    }
}
