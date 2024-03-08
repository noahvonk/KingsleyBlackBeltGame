using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heros : Troops
{
    public static Heros Instance;

    // Start is called before the first frame update
    public void Awake()
    {
        Instance = this;
    }
    protected override void Start()
    {
        base.Start();
        health = 250;
        damage = 500;
        speed = 15;
    }

    public void OnSkillButtonPressed()
    {
        damage = 500;
        Debug.Log(damage);
        speed = 100;
        SkillTimer();
    }

    IEnumerator SkillTimer()
    {
        yield return new WaitForSeconds(9999999999999999f);
        //ReturnHrDamage();
    }

    public void ReturnHrDamage()
    {
        damage = 50;
        speed = 15;
    }
}
