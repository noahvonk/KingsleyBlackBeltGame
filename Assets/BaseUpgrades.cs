using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUpgrades : MonoBehaviour
{
    public void UpgradeBaseHP()
    {
        //only upgrades wall 1
        if(GameManager.Instance.gold - 150 >= 0){
        WallHealth.Instance.wallHP += 1000;
        GameManager.Instance.gold -= 150;
        };
    }

    public void UpgradeHeroDMG()
    {
        //only upgrades the latest placed troop/hero
        if(GameManager.Instance.gold - 10000 >= 0)
        {
                Debug.Log("Upgrade Hero");
                GameManager.Instance.gold -= 10000;
                Heros.Instant.upgrade += 1;
        };
        //HumanoidAI.damage += 5;
    }
}
