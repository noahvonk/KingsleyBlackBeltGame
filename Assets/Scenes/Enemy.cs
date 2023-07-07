using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : HumanoidAI
{
    public Target curWall;

    void Start()
    {
        health = maxHealth;
        GameManager.Instance.enemies.Add(gameObject);
    }

    public override void TakeDamage(int Tdamage)
    {
        health -= Tdamage;
        if (health <= 0)
        {
            HealthBar.fillAmount = 0;
            GameManager.Instance.enemies.Remove(gameObject);
            Destroy(gameObject);
        }
        else
        {
            HealthBar.fillAmount = (float)health / maxHealth;
        }
    }

    public void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Wallas") && canAttack)
        {
            curWall = c.gameObject.GetComponentInChildren<Target>();
            isAttacking = true;
        }
    }

    public void OnCollisionExit(Collision c)
    {
        if (c.gameObject.CompareTag("Wallas") && canAttack)
        {
            curWall = null;
            isAttacking = false;
        }
    }

    public void Update()
    {
        Debug.Log("Update running");
        if (!GameManager.Instance.wallsDead)
        {
            if (canAttack && curWall != null)
            {
                MoveToTarget(curWall);
            }

            if (isAttacking && canAttack)
            {
                DoDamage();
            }
            if (curWall == null)
            {
                foreach (Target t in GameManager.Instance.targets)
                {
                    Debug.Log("Checking targets");
                    if (curWall == null)
                    {
                        curWall = t;
                    }
                    else if (Vector3.Distance(t.gameObject.transform.position, transform.position) < Vector3.Distance(curWall.transform.position, transform.position))
                    {
                        curWall = t;
                    }
                }
                //Debug.Log(gameObject.name + " is moving");
            }
        }

    }
    public override void DoDamage()
    {
        curWall.transform.parent.GetComponent<WallHealth>().TakeDamage(damage);
        canAttack = false;
        StartCoroutine(WaitOnAttack());
    }
}
