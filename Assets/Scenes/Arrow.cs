using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Troops
{
    protected override void Start()
    {
        base.Start();
        health = 999999;
        damage = 4500;
        speed = 50;
    }

    protected override void OnTriggerEnter(Collider c)
    {
        //Debug.Log("Collided");
        if (c.gameObject.CompareTag("Enemy"))
        {
            curTarget = c.gameObject;
            DoDamage();
            isAttacking = true;
            Destroy(gameObject);
        }
    }
}
