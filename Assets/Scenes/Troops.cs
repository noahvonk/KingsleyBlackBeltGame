using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troops : MonoBehaviour
{
    public int health;

    public int damage;

    public int speed;

    public Enemy[] enemys;

    public Enemy[] nearestEnemy;

    public int tSpace;

    public int waitTime;

    public bool canAttack = true;

    public bool isAttacking = false;

    private GameObject curEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //public virtual void Update()
    //{
    //    if (canAttack)
    //    {
    //        MoveToTarget();
    //    }

    //    if (isAttacking && canAttack)
    //    {
    //        DoDamage();
    //    }
    //    if (curTarget == null)
    //    {
    //        foreach (GameObject t in GameManager.Instance.targets)
    //        {
    //            if (curTarget == null)
    //            {
    //                curTarget = t;
    //            }
    //            else if (Vector3.Distance(t.transform.position, transform.position) < Vector3.Distance(curTarget.transform.position, transform.position))
    //            {
    //                curTarget = t;
    //            }
    //        }
    //        //Debug.Log(gameObject.name + " is moving");
    //    }
    //}

    //public void MoveToTarget()
    //{
    //    if (curTarget != null)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, curTarget.transform.position, Time.deltaTime * speed);
    //    }

    //}

    //public void DoDamage()
    //{
    //    curTarget.GetComponent<WallHealth>().TakeDamage(damage);
    //    canAttack = false;
    //    StartCoroutine(WaitOnAttack());
    //}

    //public void OnCollisionEnter(Collision c)
    //{
    //    if (c.gameObject.CompareTag("Wallas") && canAttack)
    //    {
    //        curTarget = c.gameObject;
    //        isAttacking = true;
    //    }
    //}

    //public void OnCollisionExit(Collision c)
    //{
    //    if (c.gameObject.CompareTag("Wallas") && canAttack)
    //    {
    //        curTarget = null;
    //        isAttacking = false;
    //    }
    //}

    //public IEnumerator WaitOnAttack()
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    canAttack = true;
    //}
}
