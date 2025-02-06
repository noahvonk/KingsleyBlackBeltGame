using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUpgrades : MonoBehaviour
{
    public void UpgradeBaseHP()
    {
        if(GameManager.Instance.gold - 150 >= 0){
        WallHealth.Instance.wallHP += 500;
        GameManager.Instance.gold -= 150;
        };
    }

    public void UpgradeHeroDMG()
    {
        if(GameManager.Instance.gold - 500 >= 0){
            GameManager.Instance.gold -= 500;
            Heros.Instant.upgrade++;
        };
        //HumanoidAI.damage += 5;
    }
}
