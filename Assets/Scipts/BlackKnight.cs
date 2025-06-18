using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackKnight : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 2000;
            damage = 350;
            speed = 23;
            goldDrops = 20;
        } else {
        health = 1000;
        damage = 95;
        speed = 23;
        goldDrops = 20;
        }
    }
}
