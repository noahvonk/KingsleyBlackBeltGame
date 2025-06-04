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
            health = 35000;
            damage = 150;
            speed = 25;
            goldDrops = 10;
        } else {
        health = 3500;
        damage = 750;
        speed = 25;
        goldDrops = 15;
        }
    }
}
