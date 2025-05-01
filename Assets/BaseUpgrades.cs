using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUpgrades : MonoBehaviour
{
    public void TroopTextSwitcher(){
        if (GameManager.Instance.TroopNum == 0 && (GameManager.Instance.gold - 15000) >= 0){
            GameManager.Instance.NewTroop.text = "Healer";
            GameManager.Instance.NewTroopDesc.text = "Health: 500\nHealing: 15   (Heals Troops on Map)\nSpeed: 15\nCost: 5000 || Cooldown: 180s"; 
            GameManager.Instance.gold -= 15000; 
            GameManager.Instance.NewTroopCost.text = "30000C";
            TroopSpawner.Instanc.ThiefButton.SetActive(true);
        } else if(GameManager.Instance.TroopNum == 2 && (GameManager.Instance.gold - 30000) >= 0){
            GameManager.Instance.NewTroop.text = "Archer Tower";
            GameManager.Instance.NewTroopDesc.text = "Health: 10000\nDamage: 10000   (Shoots Arrows)\nSpeed: 0\nCost: 10000 || Cooldown: 300s"; 
            GameManager.Instance.gold -= 30000; 
            GameManager.Instance.NewTroopCost.text = "45000C";
            TroopSpawner.Instanc.HealerButton.SetActive(true);
        } else if (GameManager.Instance.TroopNum == 3 && (GameManager.Instance.gold - 45000) >= 0){
            GameManager.Instance.NewTroop.text = "xx";
            GameManager.Instance.NewTroopDesc.text = "xx"; 
            GameManager.Instance.gold -= 45000; 
            GameManager.Instance.NewTroopCost.text = "xx";
            TroopSpawner.Instanc.ArcherTowerButton.SetActive(true);
        }
        GameManager.Instance.TroopNum += 1;
    }

    public void UpgradeBaseHP()
    {
        //only upgrades wall 1
        if(GameManager.Instance.gold - 1500 >= 0){
            GameManager.Instance.gold -= 1500;
            foreach (GameObject walls in GameManager.Instance.Walls)
        //WallHealth.Instance.wallHP += 1000;
            walls.GetComponent<WallHealth>().wallHP += 1000;
            //walls.GetComponent<WallHealth>().maxHp += 1000;
        };
        
    }

    public void UpgradeHeroDMG()
    {
        //only upgrades the latest placed troop/hero
        if((GameManager.Instance.gold - 2000) >= 0)
        {
                GameManager.Instance.gold -= 2000;
                //Debug.Log("Upgrade Hero");
                foreach (GameObject heros in GameManager.Instance.Troops){
                    //heros.Heros.Instant.upgrade += 1;
                    heros.GetComponent<Heros>().upgrade += 1; // * Heros.Instant.upgrade;
                };
                
                
        };
        //HumanoidAI.damage += 5;
    }

     public void UpgradeHeroHP()
    {
        //only upgrades the latest placed troop/hero
        if((GameManager.Instance.gold - 2500) >= 0)
        {
                GameManager.Instance.gold -= 2500;
                //Debug.Log("Upgrade Hero");
                foreach (GameObject heros in GameManager.Instance.Troops){
                    //heros.Heros.Instant.upgrade += 1;
                    heros.GetComponent<Heros>().health += 1000; // * Heros.Instant.upgrade;
                };
                
                
        };
        //HumanoidAI.damage += 5;
    }

    public void UpgradeHeroSpeed()
    {
        //only upgrades the latest placed troop/hero
        if((GameManager.Instance.gold - 4500) >= 0)
        {
                GameManager.Instance.gold -= 4500;
                //Debug.Log("Upgrade Hero");
                foreach (GameObject heros in GameManager.Instance.Troops){
                    //heros.Heros.Instant.upgrade += 1;
                    heros.GetComponent<Heros>().speed += 1; // * Heros.Instant.upgrade;
                };
                
                
        };
        //HumanoidAI.damage += 5;
    }
}
