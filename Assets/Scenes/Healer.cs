using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Troops
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 500;
        damage = 1;
        speed = 15;
    }

    IEnumerator HealingTimer(){
        yield return new WaitForSeconds(30);
        foreach (GameObject troops in GameManager.Instance.Troops){
            troops.GetComponent<Builder>().health += 30;
            troops.GetComponent<Warrior>().health += 30;
            troops.GetComponent<Rizzard>().health += 30;
            troops.GetComponent<Thief>().health += 30;
            troops.GetComponent<Healer>().health += 30;
            troops.GetComponent<ArcherTower>().health += 30;
            troops.GetComponent<Spearman>().health += 30;
        }
    }

    // Update is called once per frame

}
