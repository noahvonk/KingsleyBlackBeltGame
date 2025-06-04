using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiloDarkKnight : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 1000;
            damage = 300;
            speed = 15;
            goldDrops = 5;
        } else {
        health = 60;
        damage = 25;
        speed = 15;
        goldDrops = 5;
        }
    }
}
