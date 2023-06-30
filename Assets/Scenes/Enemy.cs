using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int EHP;

    public int maxEHp;

    public Image HealthBar;

    public int health;

    public int damage;

    public int speed;

    public int goldDrops;

    public int waitTime;

    public bool canAttack = true;

    public bool isAttacking = false;

    [SerializeField]
    private Target curTarget;

    //public int drops;

    [SerializeField]
    public Troops[] nearestTroop;

    //make the enemy recognize the nearest box collider 2d and target it
    void Start()
    {
        EHP = maxEHp;
    }

    public void MoveToTarget()
    {
        if(curTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, curTarget.transform.position, Time.deltaTime * speed);   
        }
        
    }

    public void TakeDamage()
    {
        HealthBar.fillAmount = (float)EHP / maxEHp;
    }

    public void DoDamage()
    {
        curTarget.transform.parent.GetComponent<WallHealth>().TakeDamage(damage);
        canAttack = false;
        StartCoroutine(WaitOnAttack());
    }
   

    public void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.CompareTag("Wallas") && canAttack)
        {
            curTarget = c.gameObject.GetComponentInChildren<Target>();
            isAttacking = true;
        }
    }

    public void OnCollisionExit(Collision c)
    {
        if (c.gameObject.CompareTag("Wallas") && canAttack)
            {
                curTarget = null;
                isAttacking = false;
            }
    }

    public void Healing()
    {

    }

    //public void Drops()
    

    

    //public void GoldDrops()



    //public void VoiceLine()
    

    
    // Start is called before the first frame update

    // Update is called once per frame
    public virtual void Update()
    {
        if (!GameManager.Instance.wallsDead)
        {
            if (canAttack)
            {
                MoveToTarget();
            }

            if (isAttacking && canAttack)
            {
                DoDamage();
            }
            if (curTarget == null)
            {
                foreach (Target t in GameManager.Instance.targets)
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

    public IEnumerator WaitOnAttack(){
        yield return new WaitForSeconds(waitTime);
        canAttack = true;
    }

}
