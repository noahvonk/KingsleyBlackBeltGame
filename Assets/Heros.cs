using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heros : Troops
{
    public static Heros Instant;
    public int upgrade;

    // Start is called before the first frame update
    public void Awake()
    {
        Instant = this;
    }
    protected override void Start()
    {
        base.Start();
        health = 250;
        damage = 500;
        speed = 15;
    }

/*
    public void OnSkillButtonPressed()
    {
        upgrade = 4500;
        //Debug.Log(upgrade);
        SkillTimer();
    }

    IEnumerator SkillTimer()
    {
        yield return new WaitForSeconds(10f);
        //ReturnHrDamage();
    }

    public void ReturnHrDamage()
    {
        damage = 50;
        speed = 15;
    }
    */
}
