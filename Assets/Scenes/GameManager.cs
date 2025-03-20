using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;

    [SerializeField] private PerkManager perkManager;

    public int gold;
    public Text GoldText;
    public Text WaveText;
    public Text TroopsText;
    public Text MaxTroopsText;
    public Text HeroDMGText;
    public Text HeroHPText;
    public Text HeroSPDText;
    public Text TutorialText;
    public int wave;

    public Building gfHouseToPlace;
    public GameObject grid;

    public CustomCursor customCursor;

    public Tile[] tiles;
    public Tile[] building;
    private int bIndex = 0;
    //public int gfHouseCost = 25;
    //public int trHouseCost = 25;

    public Building[] houseTypes;

    public int houseCount = 0;
    public int houseEarnings = 25;

    public bool buildMode = false;
    public bool TroopSpawning = false;

    public enum btype {TRHOUSE, GFHOUSE}

    public btype curHouse = btype.TRHOUSE;

    public int maxTroops = 50;
    public int TTroops;
    //Each troops takes an amount of space( ex. tank = 5tSpace) there is a max cap on how much space you can use and everytime you buy a tHouse, you will gain +5 tSpace

    public bool wallsDead = false;

    public List<Target> targets;
    
     [SerializeField] public List<GameObject> Walls = new List<GameObject>();

    public List<GameObject> enemies = new List<GameObject>();

    [SerializeField] public List<GameObject> Troops = new List<GameObject>();

     [SerializeField] public List<GameObject> Hero = new List<GameObject>();

    public GameObject background;
    public bool ManagerModeOn;

    public bool TutorialOn;
    public int TTS;
    public GameObject Haon;
    public GameObject TutText;
    //public int dmgMulti = 1;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(GoldTimer());
        building = new Tile[tiles.Length];
        ManagerModeOn = true;
        TutorialOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && TutorialOn == true){
            //Debug.Log("Mouse Down");
            if(TTS >= 18){
                TutorialOn = false;
                Haon.SetActive(false); 
                TutText.SetActive(false);
                //TutorialText.SetActive(false);
            } else {
                TTS++;
                ChangeCurText();
            }
        }
        GoldText.text = gold.ToString();
        WaveText.text = wave.ToString();
        TroopsText.text = TTroops.ToString();
        MaxTroopsText.text = maxTroops.ToString();
        foreach (GameObject heros in Troops){
        HeroDMGText.text = heros.GetComponent<Heros>().damage.ToString();
        HeroHPText.text = heros.GetComponent<Heros>().health.ToString();
        HeroSPDText.text = heros.GetComponent<Heros>().speed.ToString();
        };
        //TroopSpawner.Instance.TTroops = Troops.Count;
        if(targets.Count == 0)
        {
            wallsDead = true;
            ImagineLosing();
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            if(buildMode == true){
                customCursor.Reset();
                HideTiles();
            } else {
                
            };
        }
        
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(ManagerModeOn == false){
                ManagerModeOn = true;
                background.SetActive(true);
            } else if (ManagerModeOn == true){
                ManagerModeOn = false;
                background.SetActive(false);
            }
        }

    }

    public void ChangeCurText()
    {
       if(TTS == 1){
        TutorialText.text = "This game is a wave defense game, the goal is to defend your castle from being conquered by the dark forces";
       } else if(TTS == 2){
        TutorialText.text = "My name is Haon and i am here to help you learn how to play this game";
       } else if (TTS == 3) {
        TutorialText.text = "If you look at the middle of your screen, you will see a castle, defend that at all costs";
       } else if(TTS == 4){
        TutorialText.text = "Take a look at what happens if you press the houses to the top left of your screen";
       } else if (TTS == 5) {
        TutorialText.text = "Look! a grid popped up inside the castle, those squares represent where you can put down building, but beware not to put too much, as they all cost gold";
       } else if(TTS == 6){
        TutorialText.text = "Speaking of gold, you are going to need it for practically everything within the game, whether that be troops, buildings, upgrades, and more.";
       } else if (TTS == 7) {
        TutorialText.text = "Take a look at the houses, they are different in color and shape. The straw house, or the yellowish one is the one that grants you money.";
       } else if(TTS == 8){
        TutorialText.text = "If you look at the next house, the blue one, or the military house, this one give you troop spaces, you can buy these houses to increase the maximum amount of troops you can put down. ";
       } else if (TTS == 9) {
        TutorialText.text = "With troops, you can find them on the bottom right side of your screen. If you open up the troop menu, you will find a varity of troops.";
       } else if(TTS == 10){
        TutorialText.text = "Be careful not to put down too many troops, as they cost both money and troop spaces. You can stop putting down the troops with the Q key.";
       } else if (TTS == 11) {
        TutorialText.text = "on the bottom left corner of your screen, you will see the upgrades menu. Here you can upgrade your heroes damage, health, speed and even base health.";
       } else if(TTS == 12){
        TutorialText.text = "If you look above the upgrades menu, you will see a slider bar. This here will help you progress faster as it will speed up the game, this can go as slow as 0x speed and as fast as 10x the speed of the game.";
       } else if (TTS == 13) {
        TutorialText.text = "After this tutorial has ended, the enemies will spawn soon, make sure to defend them. Enemies appear in waves, each one increasing in difficulty.";
       } else if(TTS == 14){
        TutorialText.text =  "one thing to know about enemies is that some only target one specific type of your defense, like the walls or your troops, but most target both. Beware, because after 10 waves as there will be a strong boss.";
       } else if(TTS == 15){ 
        TutorialText.text = "In the later waves, there will be mini bosses every 5 waves, and a boss every 10. make sure to be geared up because enemies will get very difficult after a certain wave.";
       } else if(TTS == 16){
        TutorialText.text = "The goal is to defend for 100 waves of enemies, and succesfully defend your base from the dark forces, go ahead and have fun trying to win against them.";
       } else if (TTS == 17) {
        TutorialText.text = "This marks the end of this tutorial, so make sure to defend your empire with all you got, okay? Watch out because as soon as you click off of this, the enemies will start spawning. Good luck!";
       } else if (TTS == 18){
        TutorialText.text = " ";
       }
    }

    public void TileSwitcher(int index)
    {
        building[bIndex] = tiles[index];
        tiles[index] = null;
        bIndex++;
    }

    public void HideTiles()
    {
        foreach(Tile t in tiles){
            if(t != null){
                t.gameObject.SetActive(false);
            }
        }
    }

    public void ShowTiles()
    {
        foreach(Tile t in tiles){
            if(t != null){
                t.gameObject.SetActive(true);
            }
        }
    }

    public void BuyBuilding(int b)
    {
            ChangeCurHouse(b);
            ShowTiles();
            customCursor.BuildMode(b);
    }

    public void ChangeCurHouse(int num)
    {
        switch (num)
        {
            case 0:
                curHouse = btype.TRHOUSE;
                return;
            case 1:
                curHouse = btype.GFHOUSE;
                return;
            default:
                return;
        }
    }

    public int GetCurHouseIndex(){
        switch (curHouse)
        {
            case btype.TRHOUSE:
                return 0;
            case btype.GFHOUSE:
                return 1;
            default:
                return 0;
        }
    }

    IEnumerator GoldTimer()
    {
        yield return new WaitForSeconds(5);
        gold += (houseEarnings * houseCount);
        StartCoroutine(GoldTimer());
    }

    void ImagineLosing()
    {
        if(wallsDead = true)
        {
            SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(2).name);
        }
    }
}
