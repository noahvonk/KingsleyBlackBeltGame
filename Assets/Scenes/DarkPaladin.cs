using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkPaladin : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 10000;
            damage = 200;
            speed = 10;
            goldDrops = 10;
        } else {
        health = 2000;
        damage = 50;
        speed = 10;
        goldDrops = 20;
        }
    }

}
