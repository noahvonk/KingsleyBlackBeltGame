using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSpearman : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 65){
            health = 12000;
            damage = 500;
            speed = 20;
            goldDrops = 10;
        } else {
        health = 3000;
        damage = 150;
        speed = 19;
        goldDrops = 10;
        }
    }
}
