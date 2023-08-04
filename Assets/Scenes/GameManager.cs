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
    public int houseEarnings = 10;

    public bool buildMode = false;

    public enum btype {TRHOUSE, GFHOUSE}

    public btype curHouse = btype.TRHOUSE;

    public int maxTroops;

    public bool wallsDead = false;
    //Each troops takes an amount of space( ex. tank = 5tSpace) there is a max cap on how much space you can use and everytime you buy a tHouse, you will gain +5 tSpace

    public List<Target> targets;

    public List<GameObject> enemies = new();

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
        if(targets.Count == 0)
        {
            wallsDead = true;
            ImagineLosing();
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
        if(wallsDead)
        {
            SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(2).name);
        }
    }
}
