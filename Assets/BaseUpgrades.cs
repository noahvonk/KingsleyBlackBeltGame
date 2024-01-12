using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUpgrades : WallHealth
{
    public void UpgradeBaseHP()
    {
        wallHP += 500;
        GameManager.Instance.gold -= 150;
    }
}
