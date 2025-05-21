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
        health = 1000;
        //damage =  500 * upgrade;
        speed = 30;
    }
/*
    public override void TakeDamage(int Tdamage){
         health -= Tdamage;
        if (health <= 0)
        {
            HealthBar.fillAmount = 0;
            //Debug.Log("Hero ForEach Instance Setter");
            GameManager.Instance.Troops.Remove(gameObject);
            TroopSpawner.Instanc.HeroActive = false;
            Debug.Log("TS Instanc Boolean Change");
            Destroy(gameObject);
            GameManager.Instance.TTroops--;
            /*
            foreach (GameObject heros in GameManager.Instance.Troops){
                if(heros.GetComponent<Heros>().health >= 1){
                    GameManager.Instance.Troops.Remove(gameObject);
                    Debug.Log("Hero ForEach Instance Setter");
                TroopSpawner.Instance.HeroActive = false;
                    Destroy(gameObject);
                } else {
                    break;
                }
            };
            
                //Debug.Log("Hero ForEach Instance Setter");
                //TroopSpawner.Instance.HeroActive = false;
            //Debug.Log("Deleted");
            
        }
        else
        {
            HealthBar.fillAmount = (float)health / maxHealth;
        }
    }
    */
    
    protected override void Update(){
        damage = 1000 * upgrade;
        
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
