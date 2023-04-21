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

    public Building buildingToPlace;
    public GameObject grid;

    public CustomCursor customCursor;

    public Tile[] tiles;
    public int buildingCost = 50;

    public Texture2D buildingImage;
    public Sprite buildingSprite;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
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
}
