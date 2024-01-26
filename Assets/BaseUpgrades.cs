using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUpgrades : MonoBehaviour
{
    WallHealth Wall;

    Heros Hero1;
    public void UpgradeBaseHP()
    {
        Wall.wallHP += 500;
        GameManager.Instance.gold -= 150;
    }

    public void UpgradeHeroDMG()
    {
        GameManager.Instance.gold -= 500;
        Hero1.damage += 5;
    }
}
