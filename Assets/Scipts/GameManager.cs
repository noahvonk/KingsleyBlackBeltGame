using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//add a unit or upgrade that constantly upgrades the wall

// add a border for units to go to rather than just running off
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
    public GameObject NextButton;
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
    public int houseEarnings = 40;

    public bool buildMode = false;
    public bool TroopSpawning = false;

    public enum btype {TRHOUSE, GFHOUSE}

    public btype curHouse = btype.TRHOUSE;

    public int maxTroops = 50;
    public int TTroops;
    public Text HPText1;
    public Text HPText2;
    public Text HPText3;
    public Text HPText4;

    //Each troops takes an amount of space( ex. tank = 5tSpace) there is a max cap on how much space you can use and everytime you buy a tHouse, you will gain +5 tSpace

    public bool wallsDead = false;

    public List<Target> targets;
    
     [SerializeField] public List<GameObject> Walls = new List<GameObject>();

    public GameObject TopWall;
    public GameObject RightWall;
    public GameObject BottomWall;
    public GameObject LeftWall;

    public List<GameObject> enemies = new List<GameObject>();

    [SerializeField] public List<GameObject> Troops = new List<GameObject>();

     [SerializeField] public List<GameObject> Hero = new List<GameObject>();

    public GameObject background;
    public bool ManagerModeOn;

    public bool TutorialOn;
    public int TTS;
    public GameObject Haon;
    public GameObject TutText;
    public GameObject SkipButton;
    public GameObject EndScreen;
    public GameObject LoseScreen;
    public GameObject Replay;

    public Text NewTroop;
    public Text NewTroopDesc;
    public Text NewTroopCost;
    public int TroopNum = 0;

    public GameObject Arrow;
    public Text ProductionUpgradeText;
    public Text ProductionUpgradeCost;

    public GameObject PauseScreen;
    public bool PauseScreenOn;

    //public bool DragnirActive;
    //public bool GameEnd = false;
    //public int dmgMulti = 1;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        building = new Tile[tiles.Length];
        ManagerModeOn = false;
        TutorialOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0) && TutorialOn == true){
            //Debug.Log("Mouse Down");
            if(TTS >= 18){
                TutorialOn = false;
                Haon.SetActive(false); 
                TutText.SetActive(false);
                TutorialText.text = " ";
                //TutorialText.SetActive(false);
            } else {
                TTS++;
                ChangeCurText();
            }
        }
        */
        GoldText.text = gold.ToString();
        WaveText.text = wave.ToString();
        TroopsText.text = TTroops.ToString();
        MaxTroopsText.text = maxTroops.ToString();
        /*
        if(TroopSpawner.Instanc.HeroActive == true && ManagerModeOn == true){
        foreach (GameObject heros in Troops){
        HeroDMGText.text = heros.GetComponent<Heros>().damage.ToString();
        HeroHPText.text = heros.GetComponent<Heros>().health.ToString();
        HeroSPDText.text = heros.GetComponent<Heros>().speed.ToString();
        };
        };
        */
        //TroopSpawner.Instance.TTroops = Troops.Count;
        if(targets.Count == 0)
        {
            wallsDead = true;
            GameLose();
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            if(buildMode == true){
                customCursor.Reset();
                HideTiles();
            } else {
                
            };
        }
        /*
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
        */
        if(wave >= 100){
            EnemySpawner.Instane.waveCountdown = 999f;
        }
        if(enemies.Count <= 0 && wave >= 100){
            Win();
        }
            HPText1.text = TopWall.GetComponent<WallHealth>().wallHP.ToString();
            HPText2.text = RightWall.GetComponent<WallHealth>().wallHP.ToString();
            HPText3.text = LeftWall.GetComponent<WallHealth>().wallHP.ToString();
            HPText4.text = BottomWall.GetComponent<WallHealth>().wallHP.ToString();
            //walls.GetComponent<WallHealth>().maxHp += 1000;

        if(Input.GetKeyDown("escape")){
            if(PauseScreenOn == false){
                PauseScreen.SetActive(true);
                PauseScreenOn = true;
                grid.SetActive(false);
                Time.timeScale = 0;
            } else {
                PauseScreen.SetActive(false);
                PauseScreenOn = false;
                grid.SetActive(true);
                Time.timeScale = GameSpeedSlider.Inst.slider.value;
            }
            
        }
    }

    public void ChangeCurText()
    {
       if(TTS == 1){
        TutorialText.text = "This game is a wave defense game, the goal is to defend your castle from being conquered by the dark forces, My name is Haon and i am here to help you learn how to play this game";
       } else if(TTS == 2){
        TutorialText.text = "If you look at the middle of your screen, you will see a castle, defend that at all costs";
       } else if (TTS == 3) {
        TutorialText.text = "The Houses on the top left, when clicked on and built, will give you money over time. The gold one is the one that gives the most money, and while the blue house provides money, the blue house provides less";
       } else if(TTS == 4){
        TutorialText.text = "If you clicked on one of the houses, a grid with white squares should show up within the castle. Move your mouse over to the grid after clicking on the house and simply click on one of the grids to place it down";
       } else if (TTS == 5) {
        TutorialText.text = "These houses will provide gold, you can see how much you have on the top right of your screen. You need gold for practically everything in this game, be careful because you can go into debt, and once you do, there is a 2 second money restriction placed on you.";
       } else if(TTS == 6){
        TutorialText.text = "You can see the amount of troops you can place down on the bottom of your screen. The blue house provides 5 more troop spaces per house placed";
       } else if (TTS == 7) {
        TutorialText.text = "The troops are on the bottom right of the screen, press that button and a list of troops and buttons will show up. Each of the troops have a cooldown, so make sure you use them strategically";
       } else if(TTS == 8){
        TutorialText.text = "Once you press on the Button of a troop, if you click with your Mouse, the troop will be placed where your mouse is currently at";
       } else if (TTS == 9) {
        TutorialText.text = "You can stop putting down the troops with the Q key, and all the troops can be placed until you've reached your max amount.";
       } else if(TTS == 10){
        TutorialText.text = "on the bottom left corner of your screen, you will see the upgrades menu. If you press the Anvil, you can upgrade your heroes damage, health, speed and even base health. You can also unlock new Troops with research upgrades and reduce cooldown times";
       } else if (TTS == 11) {
        TutorialText.text = "In that menu, every research cooldown upgrade decreases the cooldown of your troops by roughly 25%, adding up to a total of 50% across all troops.";
       } else if(TTS == 12){
        TutorialText.text = "Now, if you look above the upgrades menu, you will see a slider bar. This here will help you progress faster as it will speed up the game, this can go as slow as 0x speed and as fast as 10x the speed of the game.";
       } else if (TTS == 13) {
        TutorialText.text = "After this tutorial has ended, the enemies will spawn soon, make sure to defend them. Enemies appear in waves, each one increasing in difficulty. These enemies will drop some gold to aid in your kingdom.";
       } else if(TTS == 14){
        TutorialText.text = "One thing to know about enemies is that some only target one specific type of your defense, like the walls or your troops, but most target both. Beware, because after 10 waves as there will be a strong boss.";
       } else if(TTS == 15){ 
        TutorialText.text = "In the later waves, there will be mini bosses every 5 waves, and a boss every 10. make sure to be geared up because enemies will get very difficult after a certain wave.";
       } else if(TTS == 16){
        TutorialText.text = "The goal is to defend for 100 waves of enemies, and succesfully defend your base from the dark forces, go ahead and have fun trying to win against them.";
       } else if (TTS == 17) {
        TutorialText.text = "This marks the end of this tutorial, so make sure to defend your empire with all you got, okay? Watch out because as soon as you click off of this, the enemies will start spawning. Good luck! (I suggest using the slider to stop the game first if you're still confused)";
       } else if (TTS == 18) {
            StartCoroutine(GoldTimer());
            //AudioManager.Instan.musicSource.clip = BackgroundMusic;
            TutorialOn = false;
            Haon.SetActive(false); 
            TutText.SetActive(false);
            NextButton.SetActive(false);
            SkipButton.SetActive(false);
            TutorialText.text = " ";
       }
       TTS++;
    }

    public void SkipText(){
        //AudioManager.Instan.musicSource.clip = BackgroundMusic;
        StartCoroutine(GoldTimer());
        TutorialOn = false;
        Haon.SetActive(false); 
        TutText.SetActive(false);
        NextButton.SetActive(false);
        SkipButton.SetActive(false);
        TutorialText.text = " ";
        TTS = 99;
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
            if(TroopSpawning == true){
                TroopSpawning = false;
        };
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
/*
    IEnumerator WinTimer()
    {
        yield return new WaitForSeconds(5);
        if(DragnirActive == false){
            foreach (GameObject heros in Troops){
            Destroy(heros);
            };
            foreach (GameObject enemy in enemies){
            Destroy(enemy);
            };
            SceneManager.LoadScene(4);
        } else {
            StartCoroutine(WinTimer());
        }
    }
    */
    void Win(){
            foreach (GameObject heros in Troops){
            Destroy(heros);
            };
            foreach (GameObject enemy in enemies){
            Destroy(enemy);
            };
            SceneManager.LoadScene(4);
    }
    

    void GameLose(){
        if(wallsDead = true)
        {
        foreach (GameObject heros in Troops){
            Destroy(heros);
        };
        foreach (GameObject enemy in enemies){
            Destroy(enemy);
        };
        SceneManager.LoadScene(3);
        }
    }

    
}
