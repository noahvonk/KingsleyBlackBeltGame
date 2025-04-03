using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUpgrades : MonoBehaviour
{
    public void UpgradeBaseHP()
    {
        //only upgrades wall 1
        if(GameManager.Instance.gold - 1500 >= 0){
            foreach (GameObject walls in GameManager.Instance.Walls)
        //WallHealth.Instance.wallHP += 1000;
            walls.GetComponent<WallHealth>().wallHP += 1000;
            //walls.GetComponent<WallHealth>().maxHp += 1000;
        };
        GameManager.Instance.gold -= 1500;
    }

    public void UpgradeHeroDMG()
    {
        //only upgrades the latest placed troop/hero
        if(GameManager.Instance.gold - 3000 >= 0)
        {
                //Debug.Log("Upgrade Hero");
                foreach (GameObject heros in GameManager.Instance.Troops){
                    //heros.Heros.Instant.upgrade += 1;
                    heros.GetComponent<Heros>().upgrade += 1; // * Heros.Instant.upgrade;
                };
                GameManager.Instance.gold -= 3000;
                
        };
        //HumanoidAI.damage += 5;
    }

     public void UpgradeHeroHP()
    {
        //only upgrades the latest placed troop/hero
        if(GameManager.Instance.gold - 2500 >= 0)
        {
                //Debug.Log("Upgrade Hero");
                foreach (GameObject heros in GameManager.Instance.Troops){
                    //heros.Heros.Instant.upgrade += 1;
                    heros.GetComponent<Heros>().health += 1000; // * Heros.Instant.upgrade;
                };
                GameManager.Instance.gold -= 2500;
                
        };
        //HumanoidAI.damage += 5;
    }

    public void UpgradeHeroSpeed()
    {
        //only upgrades the latest placed troop/hero
        if(GameManager.Instance.gold - 7500 >= 0)
        {
                //Debug.Log("Upgrade Hero");
                foreach (GameObject heros in GameManager.Instance.Troops){
                    //heros.Heros.Instant.upgrade += 1;
                    heros.GetComponent<Heros>().speed += 1; // * Heros.Instant.upgrade;
                };
                GameManager.Instance.gold -= 7500;
                
        };
        //HumanoidAI.damage += 5;
    }
}
