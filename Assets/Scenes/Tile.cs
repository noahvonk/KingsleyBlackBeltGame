using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{
    public bool isOccupied;

    public Color greenColor;
    public Color redColor;

    public Building attachedBuilding;

    private SpriteRenderer rend;

    private bool mouseEntered = false;

    public int indexNumber;

    GameManager GameManag;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        GameManag = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOccupied == true){
            rend.color = redColor;
        }else{
            rend.color = greenColor;
        }
        if(mouseEntered){
            if(Input.GetMouseButtonDown(0) && !isOccupied && GameManag.gold >= 1 && GameManag.buildMode){
                //buildingToPlace = null;
                isOccupied = true;
                GameManag.customCursor.Reset();
                GameManag.gold -= GameManag.houseTypes[GameManag.GetCurHouseIndex()].cost;
                gameObject.GetComponent<SpriteRenderer>().sprite = GameManag.houseTypes[GameManag.GetCurHouseIndex()].sprite;
                //GameManager.Instance.gold
                GameManag.houseCount += 1;
                //somehow turn the tile into a house
                //foreach(tile t in array name)
                // t.setactive(false)
                //tileT = A[i].pop   s.appened[t]
                GameManag.TileSwitcher(indexNumber);
                GameManag.HideTiles();
            }
        }
    }

    public void OnMouseEnter(){
        mouseEntered = true;
    }

    public void OnMouseExit() {
        mouseEntered = false;
    }


}
