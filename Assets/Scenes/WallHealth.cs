using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{
    public int wallHP;
    public int maxHp;
    public Image health;
    private GameObject target;
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        wallHP = maxHp;
        target = GameObject.FindWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int d)
    {
        if(wallHP - d <= 0 && !dead)
        {
            wallHP = 0;
            WallDie();
            dead = true;
        } else {
            wallHP -= d;
        }
        //health.SetActive(true);
        health.fillAmount = (float) wallHP/maxHp;
        Debug.Log(health.fillAmount);
    }

    public int GetIndex()
    {
        string wallName = target.name;

        string[] splits = wallName.Split("_");
        Debug.Log(splits[1]);
        return int.Parse(splits[1]);
        
    }

    void WallDie()
    {
        GameManager.Instance.targets.RemoveAt(GetIndex());
        Destroy(this.gameObject);
    }   

    
}
