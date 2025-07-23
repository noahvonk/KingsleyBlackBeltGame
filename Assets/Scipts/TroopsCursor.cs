using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopsCursor : MonoBehaviour
{
   public GameObject Warrior;
   public GameObject Spearman;
   public GameObject Shieldman;
   public GameObject Brawler;
   public GameObject Builder;
   public GameObject Farmer;
   public GameObject Thief;
   public GameObject Prince;
   public GameObject ArcherTower;
   public GameObject Bahamut;

   //public image warriorImg;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TroopSpawningMode(){
        if(TroopSpawner.Instanc.SelectedTroop == TroopSpawner.Troops.Warrior){
            Cursor.SetCursor(Warrior, Vector2.zero, CursorMode.Auto);
        } else if(TroopSpawner.Instanc.SelectedTroop == TroopSpawner.Troops.Mage){
            Cursor.SetCursor(Wizard, Vector2.zero, CursorMode.Auto);
        }
        
        //Cursor.SetCursor(GameManager.Instance.houseTypes[GameManager.Instance.GetCurHouseIndex()].image, Vector2.zero, CursorMode.Auto);
        GameManager.Instance.buildMode = true;
    }

    public void Reset() {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            TroopSpawner.Instanc.TroopBuyModeOff();
        }
}
