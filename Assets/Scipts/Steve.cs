using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;


public class Steve : Enemy
{
    Random rnd = new Random();
    protected override void Start()
    {
    base.Start();
        if(GameManager.Instance.wave >= 50){

            health = rnd.Next(10000, 75001);
        damage = rnd.Next(1000, 10001);
        speed = rnd.Next(1, 11);
        goldDrops = rnd.Next(1, 10001);
        } else {
        health = rnd.Next(1, 50001);
        damage = rnd.Next(1000, 10001);
        speed = rnd.Next(1, 11);
        goldDrops = rnd.Next(1, 10001);
        }
    }
}
