using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
    public Building[] building;
    public int gfHouseCost = 25;

    public Texture2D gfHouseImage;
    public Sprite gfHouseSprite;

    public int houseCount = 0;
    public int houseEarnings = 10;

    public bool buildMode = false;
    //public  TileIndex;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(GoldTimer());
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = gold.ToString();
        
    }

    public void BuyBuilding()
    {
            grid.SetActive(true);
            customCursor.BuildMode();
    }

    IEnumerator GoldTimer()
    {
        yield return new WaitForSeconds(5);
        gold += (houseEarnings * houseCount);
        StartCoroutine(GoldTimer());
    }
}
