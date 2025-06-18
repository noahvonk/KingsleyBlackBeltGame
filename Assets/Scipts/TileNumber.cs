using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNumber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int index = 0;

        foreach (Tile t in GameManager.Instance.tiles){
            t.indexNumber = index;
            index ++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
