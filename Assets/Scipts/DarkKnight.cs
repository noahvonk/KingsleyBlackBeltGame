using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkKnight : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 4500;
            damage = 250;
            speed = 25;
            goldDrops = 10;
        } else {
        health = 250;
        damage = 25;
        speed = 25;
        goldDrops = 25;
        }
    }

}
