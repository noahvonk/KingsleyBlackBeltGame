using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBrawler : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 75){
            health = 75000;
            damage = 150;
            speed = 25;
            goldDrops = 10;
        } else {
        health = 7500;
        damage = 150;
        speed = 25;
        goldDrops = 15;
        }
    }
}
