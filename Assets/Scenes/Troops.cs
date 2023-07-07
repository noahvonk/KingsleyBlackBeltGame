using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troops : HumanoidAI
{
    // Update is called once per frame
    public void Update()
    {
        if (!GameManager.Instance.wallsDead)
        {
            if (canAttack)
            {
                MoveToTarget(curTarget);
            }

            if (isAttacking && canAttack)
            {
                DoDamage();
            }
            if (curTarget == null)
            {
                foreach (GameObject t in GameManager.Instance.enemies)
                {
                    if (curTarget == null)
                    {
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
