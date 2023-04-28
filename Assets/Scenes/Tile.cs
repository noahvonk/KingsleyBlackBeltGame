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

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
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
            if(Input.GetMouseButtonDown(0) && !isOccupied && GameManager.Instance.gold >= 1 && GameManager.Instance.buildMode){
                //buildingToPlace = null;
                isOccupied = true;
                GameManager.Instance.customCursor.Reset();
                GameManager.Instance.gold -= GameManager.Instance.gfHouseCost;
                gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.gfHouseSprite;
                //GameManager.Instance.gold
                GameManager.Instance.houseCount += 1;
                //somehow turn the tile into a house
                //foreach(tile t in array name)
                // t.setactive(false)
                //tileT = A[i].pop   s.appened[t]
                GameManager.Instance.TileSwitcher(indexNumber);
                GameManager.Instance.HideTiles();
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
