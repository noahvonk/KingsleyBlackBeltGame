using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopsCursor : MonoBehaviour
{
   [SerializeField] Texture2D Warrior;
   [SerializeField] Texture2D Spearman;
   [SerializeField] Texture2D Shieldman;
   [SerializeField] Texture2D Wizard;
   [SerializeField] Texture2D Brawler;
   [SerializeField] Texture2D Builder;
   [SerializeField] Texture2D Farmer;
   [SerializeField] Texture2D Thief;
   [SerializeField] Texture2D Prince;
   [SerializeField] Texture2D ArcherTower;
   [SerializeField] Texture2D Bahamut;

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
