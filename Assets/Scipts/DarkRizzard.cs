using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRizzard : Enemy
{
    protected override void Start()
    {
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 2500;
            damage = 350;
            speed = 20;
            goldDrops = 10;
        } else {
            health = 95;
            damage = 150;
            speed = 20;
            goldDrops = 10;
        }
        
    }
    
}
