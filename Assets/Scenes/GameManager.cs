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

    public List<GameObject> enemies = new List<GameObject>();

    public List<GameObject> Troops = new List<GameObject>();

    public int dmgMulti = 1;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(GoldTimer());
        building = new Tile[tiles.Length];
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = gold.ToString();
        WaveText.text = wave.ToString();
        TroopsText.text = TTroops.ToString();
        MaxTroopsText.text = maxTroops.ToString();
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
