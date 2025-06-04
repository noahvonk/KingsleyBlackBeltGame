using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TroopSpawner : MonoBehaviour
{
    public static TroopSpawner Instanc;
    public int TroopCost;
    public bool HeroBuy = false;
    public bool HeroActive = false;
    public bool BahamutActive = false;
    public int ProductionUpgrade;
    public int TroopUpgrade;
    public GameObject TroopParent;
    GameManager GameManag;

    public GameObject ProductionUpgradeButton;
    public GameObject WarriorButton;
    public GameObject SpearButton;
    public GameObject WizButton;
    public GameObject BuilderButton;
    public GameObject HeroButton;
    public GameObject ThiefButton;
    public GameObject HealerButton;
    public GameObject ArcherTowerButton;
    public GameObject FarmerButton;
    public GameObject BahamutButton;
    public GameObject BrawlerButton;
    //Heros Hr;

    // Start is called before the first frame update
    void Start()
    {
        TroopParent = this.gameObject;
        GameManag = GameManager.Instance;
        //Hr = Heros.Instance;
    }

    Camera m_Camera;
    void Awake()
    {
        Instanc = this;
        m_Camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if(HeroActive == false){
            HeroButton.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TroopBuyModeOff();
        }
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.TroopSpawning && GameManager.Instance.TutorialOn == false)
        {
            //Debug.Log(m_Camera.ScreenToWorldPoint(Input.mousePosition));
            Vector3 mousePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 5);
            //Debug.Log("Placed Troop");
            if(GameManager.Instance.TTroops < GameManager.Instance.maxTroops){
        if ((GameManager.Instance.gold -= TroopCost) <= 1){
            TroopBuyModeOff();
        } else if((GameManager.Instance.gold -= TroopCost) >= 1){
            PlaceTroop(mousePosition);
            GameManager.Instance.gold -= TroopCost;
        } 
        };  
        } else {

        };
        if(BahamutActive == false && GameManager.Instance.TroopNum == 4){
            BahamutButton.SetActive(true);
        } else if (BahamutActive == true){
            BahamutButton.SetActive(false);
        }
    }

    public void TroopBuyModeOff()
    {
        SelectedTroop = Troops.None;
        GameManager.Instance.TroopSpawning = false;
    }

    public void TroopBuyModeOn()
    {
        GameManager.Instance.TroopSpawning = true;
    }

    public void PlaceTroop(Vector3 pos)
    {
        // Instantiate Troop
         //if(GameManager.Instance.TTroops < GameManager.Instance.maxTroops){
            //if ((GameManager.Instance.gold -= TroopCost) <= 0){
            //TroopBuyModeOff();
        //} else {
        //Depending on which troop you place down, set a certain cooldown next to the unit : add a CD Number next to the troop button
        GameObject troop = Instantiate(TroopPrefabs[(int)SelectedTroop]);
        troop.transform.position = pos;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        troop.transform.SetParent(TroopParent.transform);
        GameManager.Instance.TTroops++;
        if(HeroBuy == true){
                HeroActive = true;
                HeroBuy = false;
                TroopBuyModeOff();
            };

        if(SelectedTroop == Troops.Warrior){
            StartCoroutine(WarCooldown());
            WarriorButton.SetActive(false);
            TroopBuyModeOff();
        } else if(SelectedTroop == Troops.Spearman){
            StartCoroutine(SpearCooldown());
            SpearButton.SetActive(false);
            TroopBuyModeOff();
        } else if (SelectedTroop == Troops.Mage){
            StartCoroutine(WizCooldown());
            WizButton.SetActive(false);
            TroopBuyModeOff();
        } else if (SelectedTroop == Troops.Builder){
            StartCoroutine(BuilderCooldown());
            BuilderButton.SetActive(false);
            TroopBuyModeOff();
        } else if (SelectedTroop == Troops.Hero){
            HeroButton.SetActive(false);
            TroopBuyModeOff();
        } else if (SelectedTroop == Troops.Thief){
            StartCoroutine(ThiefCooldown());
            ThiefButton.SetActive(false);
            TroopBuyModeOff();
        } else if (SelectedTroop == Troops.Healer){
            StartCoroutine(HealerCooldown());
            HealerButton.SetActive(false);
            TroopBuyModeOff();
        } else if (SelectedTroop == Troops.ArcherTower){
            StartCoroutine(ArcherTowerCooldown());
            ArcherTowerButton.SetActive(false);
            TroopBuyModeOff();
        } else if (SelectedTroop == Troops.Farmer){
            StartCoroutine(FarmerCooldown());
            FarmerButton.SetActive(false);
            TroopBuyModeOff();
        }  else if (SelectedTroop == Troops.Bahamut){
            BahamutButton.SetActive(false);
            BahamutActive = true;
            TroopBuyModeOff();
        } else if (SelectedTroop == Troops.Brawler){
            BrawlerButton.SetActive(false);
            StartCoroutine(BrawlerCooldown());
            TroopBuyModeOff();
        } 
         //};
         

    }

    public void OnWarriorButtonPressed()
    {
        SelectedTroop = Troops.Warrior;
        TroopCost = 10;
        TroopBuyModeOn();
    }

    public void OnHeroButtonPressed()
    {
        TroopCost = 50;
        if(HeroActive == false){
        SelectedTroop = Troops.Hero;
        TroopBuyModeOn();
        HeroBuy = true;
        //Debug.Log("HeroActiveFalse");
        } else if (HeroActive == true){
            TroopBuyModeOff();
            //Debug.Log("HeroActiveTrue");
        }
    }

    public void OnSpearmanButtonPressed()
    {
        TroopCost = 15;
        SelectedTroop = Troops.Spearman;
        TroopBuyModeOn();
    }

    public void OnWizardButtonPressed()
    {
         TroopCost = 75;
        SelectedTroop = Troops.Mage;
        TroopBuyModeOn();
    }

    public void OnBuilderButtonPressed()
    {
        TroopCost = 1000;
        SelectedTroop = Troops.Builder;
        TroopBuyModeOn();
        // move this to the wall builder troop and have it run it. WallBuilder();
    }

    public void OnThiefButtonPressed()
    {
        TroopCost = 167;
        SelectedTroop = Troops.Thief;
        TroopBuyModeOn();
        // move this to the wall builder troop and have it run it. WallBuilder();
    }
    public void OnHealerButtonPressed()
    {
        TroopCost = 1667;
        SelectedTroop = Troops.Healer;
        TroopBuyModeOn();
        // move this to the wall builder troop and have it run it. WallBuilder();
    }
    public void OnArcherTowerButtonPressed()
    {
        TroopCost = 3333;
        SelectedTroop = Troops.ArcherTower;
        TroopBuyModeOn();
        // move this to the wall builder troop and have it run it. WallBuilder();
    }
    public void OnFarmerButtonPressed()
    {
        TroopCost = 500;
        SelectedTroop = Troops.Farmer;
        TroopBuyModeOn();
        // move this to the wall builder troop and have it run it. WallBuilder();
    }

    public void OnBahamutButtonPressed()
    {
        TroopCost = 33333;
        SelectedTroop = Troops.Bahamut;
        TroopBuyModeOn();
        // move this to the wall builder troop and have it run it. WallBuilder();
    }

    public void OnBrawlerButtonPressed()
    {
        TroopCost = 150;
        SelectedTroop = Troops.Brawler;
        TroopBuyModeOn();
        // move this to the wall builder troop and have it run it. WallBuilder();
    }


    IEnumerator WarCooldown()
    {
        if(ProductionUpgrade >= 1){
            yield return new WaitForSeconds(6);
            WarriorButton.SetActive(true);
        } else if (ProductionUpgrade >= 2){
            yield return new WaitForSeconds(3);
            WarriorButton.SetActive(true);
        } else {
        yield return new WaitForSeconds(8);
        WarriorButton.SetActive(true);
        };
    }
    IEnumerator SpearCooldown()
    {
        if(ProductionUpgrade >= 1){
            yield return new WaitForSeconds(7);
            SpearButton.SetActive(true);
        } else if (ProductionUpgrade >= 2){
            yield return new WaitForSeconds(4);
            SpearButton.SetActive(true);
        } else{
        yield return new WaitForSeconds(10);
        SpearButton.SetActive(true);
        }
    }
    IEnumerator WizCooldown()
    {
        if(ProductionUpgrade >= 1){
            yield return new WaitForSeconds(15);
            WizButton.SetActive(true);
        } else if (ProductionUpgrade >= 2){
            yield return new WaitForSeconds(12);
            WizButton.SetActive(true);
        } else{
        yield return new WaitForSeconds(20);
        WizButton.SetActive(true);
        }
    }
    IEnumerator BuilderCooldown()
    {
        if(ProductionUpgrade >= 1){
            yield return new WaitForSeconds(30);
            BuilderButton.SetActive(true);
        } else if (ProductionUpgrade >= 2){
            yield return new WaitForSeconds(20);
            BuilderButton.SetActive(true);
        } else{
            yield return new WaitForSeconds(45);
            BuilderButton.SetActive(true);
        }
        
    }
    IEnumerator ThiefCooldown()
    {
        if(ProductionUpgrade >= 1){
            yield return new WaitForSeconds(25);
            ThiefButton.SetActive(true);
        } else if (ProductionUpgrade >= 2){
            yield return new WaitForSeconds(15);
            ThiefButton.SetActive(true);
        } else{
            yield return new WaitForSeconds(30);
            ThiefButton.SetActive(true);
        }
        
    }
    IEnumerator HealerCooldown()
    {
        
        yield return new WaitForSeconds(180);
        HealerButton.SetActive(true);
    }
    IEnumerator ArcherTowerCooldown()
    {
        if(ProductionUpgrade >= 1){
            yield return new WaitForSeconds(80);
            ArcherTowerButton.SetActive(true);
        } else if (ProductionUpgrade >= 2){
            yield return new WaitForSeconds(45);
            ArcherTowerButton.SetActive(true);
        } else{
            yield return new WaitForSeconds(120);
            ArcherTowerButton.SetActive(true);
        }
        
    }
    IEnumerator FarmerCooldown()
    {
        if(ProductionUpgrade >= 1){
            yield return new WaitForSeconds(45);
            FarmerButton.SetActive(true);
        } else if (ProductionUpgrade >= 2){
            yield return new WaitForSeconds(30);
            FarmerButton.SetActive(true);
        } else{
            yield return new WaitForSeconds(75);
            FarmerButton.SetActive(true);
        }
        
    }
    IEnumerator BrawlerCooldown()
    {
        if(ProductionUpgrade >= 1){
            yield return new WaitForSeconds(18);
            BrawlerButton.SetActive(true);
        } else if (ProductionUpgrade >= 2){
            yield return new WaitForSeconds(12);
            BrawlerButton.SetActive(true);
        } else {
            yield return new WaitForSeconds(25);
            BrawlerButton.SetActive(true);
        }
        
    }


    public enum Troops { Hero, Warrior, Spearman, Mage, Builder, Thief, Healer, ArcherTower, Farmer, Bahamut, Brawler, None, etc, misc}
    public Troops SelectedTroop = Troops.None;

    [Header("Order is  Hero, Warrior, Spearman, Mage, Builder, Thief, Healer, Archer Tower, Farmer, Bahamut, Brawler, None "), SerializeField]
    private List<GameObject> TroopPrefabs = new();
}
