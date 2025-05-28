using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Madak : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 75){
            health = 100000;
            damage = 2500;
            speed = 5;
            goldDrops = 750;
        } else {
        health = 7500;
        damage = 500;
        speed = 5;
        goldDrops = 750;
        }
    }

}
