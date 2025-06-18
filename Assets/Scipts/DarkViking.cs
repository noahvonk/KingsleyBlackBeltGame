using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkViking : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 4500;
            damage = 300;
            speed = 10;
            goldDrops = 10;
        } else {
        health = 1250;
        damage = 150;
        speed = 7;
        goldDrops = 15;
        }
    }

}
