using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heros : Troops
{
    public static Heros Instant;
    public int upgrade;
    //public int damage;

    // Start is called before the first frame update
    public void Awake()
    {
        Instant = this;
    }
    protected override void Start()
    {
        base.Start();
        health = 500;
        //damage =  500 * upgrade;
        speed = 15;
    }
    
    protected override void Update(){
        damage = 500 * upgrade;
         if (!GameManager.Instance.wallsDead)
            {
                if (curTarget != null && canAttack)
                {
                    MoveToTarget(curTarget);
                }

                if (isAttacking && canAttack)
                {
                    if (curTarget != null && Vector3.Distance(curTarget.gameObject.transform.position, transform.position) < 3)
                    {
                        DoDamage();
                    }
                    
                }
                if (curTarget == null)
                {
                    foreach (GameObject t in GameManager.Instance.enemies)
                    {
                        if (curTarget == null)
                        {
                            isAttacking = false;
                            curTarget = t;
                        }
                        else if (Vector3.Distance(t.gameObject.transform.position, transform.position) < Vector3.Distance(curTarget.transform.position, transform.position))
                        {
                            curTarget = t;
                        }
                    }
                    //Debug.Log(gameObject.name + " is moving");
                }
                //TroopSpawner.Instance.HeroActive = false;
                //Destroy(gameObject);
            }
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
