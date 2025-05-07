using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Troops
{
    protected override void Start()
    {
        base.Start();
        health = 99999;
        damage = 10000;
        speed = 45;
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
