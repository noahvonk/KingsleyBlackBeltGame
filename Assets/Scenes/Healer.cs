using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Troops
{
    public GameObject Warrior;
    public GameObject Spearman;
    public GameObject Rizzard;
    public GameObject Hero;
    public GameObject Builder;
    public GameObject Thief;
    public GameObject OtherHealers;
    public GameObject ArcherTower;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 500;
        damage = 1;
        speed = 1;
        StartCoroutine(HealingTimer());
    }

    IEnumerator HealingTimer(){
        yield return new WaitForSeconds(30);
            Debug.Log("Healing Activate");
            Warrior.GetComponent<Troops>().health += 10;
            Spearman.GetComponent<Troops>().health += 10;
            Rizzard.GetComponent<Troops>().health += 10;
            Hero.GetComponent<Troops>().health += 10;
            Builder.GetComponent<Troops>().health += 10;
            Thief.GetComponent<Troops>().health += 10;
            OtherHealers.GetComponent<Troops>().health += 10; 
            ArcherTower.GetComponent<Troops>().health += 10;
            //troops.GetComponent<Builder>().health += 30;
            //Debug.Log("Healing Activate Past 1");
            //troops.GetComponent<Rizzard>().health += 30;
            //troops.GetComponent<Thief>().health += 30;
            //troops.GetComponent<Healer>().health += 30;
            //troops.GetComponent<ArcherTower>().health += 30;
            //troops.GetComponent<Spearman>().health += 30;
            //troops.GetComponent<Heros>().health += 30;
            Debug.Log("Healing Finished");
            StartCoroutine(HealingTimer());
        }
    }

    // Update is called once per frame


