using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUpgrades : MonoBehaviour
{
    public void TroopTextSwitcher(){
        if (GameManager.Instance.TroopNum == 0 && (GameManager.Instance.gold - 10000) >= 0){
            GameManager.Instance.NewTroop.text = "Farmer";
            GameManager.Instance.NewTroopDesc.text = "Health: 1500\nMoney: 50 (Makes Money for You)\nSpeed:0\nCost: 1500 || Cooldown: 120s"; 
            GameManager.Instance.gold -= 10000; 
            GameManager.Instance.NewTroopCost.text = "20000C";
            TroopSpawner.Instanc.ThiefButton.SetActive(true);
        } else if(GameManager.Instance.TroopNum == 1 && (GameManager.Instance.gold - 20000) >= 0){
            GameManager.Instance.NewTroop.text = "Archer Tower";
            GameManager.Instance.NewTroopDesc.text = "Health: 10000\nDamage: 4500   (Shoots Arrows)\nSpeed: 0\nCost: 10000 || Cooldown: 300s"; 
            GameManager.Instance.gold -= 20000; 
            GameManager.Instance.NewTroopCost.text = "30000C";
            TroopSpawner.Instanc.FarmerButton.SetActive(true);
        } else if (GameManager.Instance.TroopNum == 2 && (GameManager.Instance.gold - 30000) >= 0){
            GameManager.Instance.NewTroop.text = "Bahamut, The One";
            GameManager.Instance.NewTroopDesc.text = "Health: 100000\nDamage: 100000\nSpeed: 25\nCost: 99999 || Cooldown: Can Only Spawn One"; 
            GameManager.Instance.gold -= 30000; 
            GameManager.Instance.NewTroopCost.text = "50000";
            TroopSpawner.Instanc.ArcherTowerButton.SetActive(true);
        } else if (GameManager.Instance.TroopNum == 3 && (GameManager.Instance.gold - 50000) >= 0){
            GameManager.Instance.NewTroop.text = "Max Level";
            GameManager.Instance.NewTroopDesc.text = ""; 
            GameManager.Instance.gold -= 50000; 
            GameManager.Instance.NewTroopCost.text = "";
            TroopSpawner.Instanc.BahamutButton.SetActive(true);
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
        if((GameManager.Instance.gold - 1000) >= 0)
        {
                GameManager.Instance.gold -= 1000;
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
        if((GameManager.Instance.gold - 1500) >= 0)
        {
                GameManager.Instance.gold -= 1500;
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
        if((GameManager.Instance.gold - 3000) >= 0)
        {
                GameManager.Instance.gold -= 3000;
                //Debug.Log("Upgrade Hero");
                foreach (GameObject heros in GameManager.Instance.Troops){
                    //heros.Heros.Instant.upgrade += 1;
                    heros.GetComponent<Heros>().speed += 1; // * Heros.Instant.upgrade;
                };
                
                
        };
        //HumanoidAI.damage += 5;
    }
}
