using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{
    public int wallHP;
    public int maxHp;
    public Image health;
    // Start is called before the first frame update
    void Start()
    {
        wallHP = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int d)
    {
        if(wallHP - d < 0)
        {
            wallHP = 0;
            WallDie();
        } else {
            wallHP -= d;
        }
        health.fillAmount = (float) wallHP/maxHp;
        Debug.Log(health.fillAmount);
    }

    void WallDie()
    {
        Destroy(this.gameObject);
    }   

    
}
