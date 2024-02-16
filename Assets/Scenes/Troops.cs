using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troops : HumanoidAI
{
    // Update is called once per frame

    public override void TakeDamage(int Tdamage)
    {
        health -= Tdamage;
        if (health <= 0)
        {
            HealthBar.fillAmount = 0;
            GameManager.Instance.Troops.Remove(gameObject);
            Destroy(gameObject);
        }
        else
        {
            HealthBar.fillAmount = (float)health / maxHealth;
        }
    }

    public void Update()
    {
        {
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
            }
        }

    }

    public override void DoDamage()
    {
        Debug.Log("Attacking");
        curTarget.transform.GetComponent<Enemy>().TakeDamage(damage);
        canAttack = false;
        StartCoroutine(WaitOnAttack());
    }

    public void OnTriggerEnter(Collider c)
    {
        Debug.Log("Collided");
        if (c.gameObject.CompareTag("Enemy") && canAttack)
        {
            curTarget = c.gameObject;
            isAttacking = true;
        }
    }

    public void OnTriggerExit(Collider c)
    {
        if (c.gameObject.CompareTag("Enemy") && canAttack)
        {
            curTarget = null;
            isAttacking = false;
        }
    }

    new protected virtual void Start()
    {
        base.Start();
        GameManager.Instance.Troops.Add(gameObject);
    }
}
