using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bob : Enemy
{
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 200000;
            damage = 2500;
            speed = 5;
            goldDrops = 750;
        } else {
        health = 20000;
        damage = 750;
        speed = 5;
        goldDrops = 750;
        }
    }
}
