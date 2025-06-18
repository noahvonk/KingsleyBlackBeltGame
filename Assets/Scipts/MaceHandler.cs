using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceHandler : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 750;
            damage = 3000;
            speed = 19;
            goldDrops = 10;
        } else {
        health = 150;
        damage = 300;
        speed = 19;
        goldDrops = 10;
        }
    }
}
