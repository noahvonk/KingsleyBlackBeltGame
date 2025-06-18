using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUpgrades : MonoBehaviour
{
    public void TroopTextSwitcher(){
        if (GameManager.Instance.TroopNum == 0 && (GameManager.Instance.gold - 5000) >= 0){
            GameManager.Instance.NewTroop.text = "Thief";
            GameManager.Instance.NewTroopDesc.text = "Health: 500\nDamage: 500 \nSpeed: 35 (Fastest Troop) \nCost: 500 || Cooldown: 50s"; 
            GameManager.Instance.gold -= 5000; 
            GameManager.Instance.NewTroopCost.text = "10000C";
            TroopSpawner.Instanc.FarmerButton.SetActive(true);
            GameManager.Instance.TroopNum += 1;
        } else if(GameManager.Instance.TroopNum == 1 && (GameManager.Instance.gold - 10000) >= 0){
            GameManager.Instance.NewTroop.text = "Archer Tower";
            GameManager.Instance.NewTroopDesc.text = "Health: 10000\nDamage: 4500   (Shoots Arrows)\nSpeed: 0\nCost: 10000 || Cooldown: 300s"; 
            GameManager.Instance.gold -= 10000; 
            GameManager.Instance.NewTroopCost.text = "20000C";
            TroopSpawner.Instanc.ThiefButton.SetActive(true);
            GameManager.Instance.TroopNum += 1;
        } else if (GameManager.Instance.TroopNum == 2 && (GameManager.Instance.gold - 20000) >= 0){
            GameManager.Instance.NewTroop.text = "Bahamut, The One";
            GameManager.Instance.NewTroopDesc.text = "Health: 100000\nDamage: 100000\nSpeed: 25\nCost: 99999 || Cooldown: Can Only Spawn One"; 
            GameManager.Instance.gold -= 20000; 
            GameManager.Instance.NewTroopCost.text = "40000";
            TroopSpawner.Instanc.ArcherTowerButton.SetActive(true);
            GameManager.Instance.TroopNum += 1;
        } else if (GameManager.Instance.TroopNum == 3 && (GameManager.Instance.gold - 40000) >= 0){
            GameManager.Instance.NewTroop.text = "Max Level";
            GameManager.Instance.NewTroopDesc.text = ""; 
            GameManager.Instance.gold -= 40000; 
            GameManager.Instance.NewTroopCost.text = "";
            TroopSpawner.Instanc.BahamutButton.SetActive(true);
            GameManager.Instance.TroopNum += 1;
        }
        
    }

    public void ProductionUpgrade()
    {
        if(TroopSpawner.Instanc.ProductionUpgrade == 0 && (GameManager.Instance.gold - 7500) >= 0){
            //Debug.Log("Upg Start");
            TroopSpawner.Instanc.ProductionUpgrade += 1;
            GameManager.Instance.gold -= 7500;
            GameManager.Instance.ProductionUpgradeCost.text = "10000C";
            //Debug.Log("Upg Finished");
            GameManager.Instance.ProductionUpgradeText.text = "1";
        } else if (TroopSpawner.Instanc.ProductionUpgrade == 1 && (GameManager.Instance.gold - 10000) >= 0){
            TroopSpawner.Instanc.ProductionUpgrade += 1;
            GameManager.Instance.gold -= 10000;
            GameManager.Instance.ProductionUpgradeCost.text = "MAX";
            GameManager.Instance.ProductionUpgradeText.text = "2";
        }
    }

    public void UpgradeBaseHP()
    {
        //only upgrades wall 1
        if(GameManager.Instance.gold - 1500 >= 0){
            GameManager.Instance.gold -= 1500;
            //foreach (GameObject walls in GameManager.Instance.Walls)
        //WallHealth.Instance.wallHP += 1000;
            GameManager.Instance.TopWall.GetComponent<WallHealth>().wallHP += 2500;
            GameManager.Instance.RightWall.GetComponent<WallHealth>().wallHP += 2500;
            GameManager.Instance.LeftWall.GetComponent<WallHealth>().wallHP += 2500;
            GameManager.Instance.BottomWall.GetComponent<WallHealth>().wallHP += 2500;
            //walls.GetComponent<WallHealth>().maxHp += 1000;
        };
        
    }

    public void UpgradeHeroDMG()
    {
        //only upgrades the latest placed troop/hero
        if((GameManager.Instance.gold - 500) >= 0)
        {
                GameManager.Instance.gold -= 500;
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
        if((GameManager.Instance.gold - 750) >= 0)
        {
                GameManager.Instance.gold -= 750;
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
        if((GameManager.Instance.gold - 1000) >= 0)
        {
                GameManager.Instance.gold -= 1000;
                //Debug.Log("Upgrade Hero");
                foreach (GameObject heros in GameManager.Instance.Troops){
                    //heros.Heros.Instant.upgrade += 1;
                    heros.GetComponent<Heros>().speed += 1; // * Heros.Instant.upgrade;
                };
                
                
        };
        //HumanoidAI.damage += 5;
    }
}
