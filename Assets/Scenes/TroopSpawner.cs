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
    public GameObject TroopParent;
    GameManager GameManag;

    public GameObject WarriorButton;
    public GameObject SpearButton;
    public GameObject WizButton;
    public GameObject BuilderButton;
    public GameObject HeroButton;
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
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.TroopSpawning)
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

    IEnumerator WarCooldown()
    {
        yield return new WaitForSeconds(8);
        WarriorButton.SetActive(true);
    }
    IEnumerator SpearCooldown()
    {
        yield return new WaitForSeconds(10);
        SpearButton.SetActive(true);
    }
    IEnumerator WizCooldown()
    {
        yield return new WaitForSeconds(30);
        WizButton.SetActive(true);
    }
    IEnumerator BuilderCooldown()
    {
        yield return new WaitForSeconds(60);
        BuilderButton.SetActive(true);
    }

    public enum Troops { Hero, Warrior, Spearman, Mage, Builder, Archer, None, etc, misc}
    public Troops SelectedTroop = Troops.None;

    [Header("Order is  Hero, Warrior, Spearman, Mage, Builder, Archer, None, etc, misc "), SerializeField]
    private List<GameObject> TroopPrefabs = new();
}
