using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : Enemy
{
    public GameObject Goblin;
    public GameObject DWitch;

   protected override void Start()
    {
        StartCoroutine(GoblinSpawn());
        base.Start();
        if(GameManager.Instance.wave >= 50){
            health = 5000;
            damage = 50;
            speed = 1;
            goldDrops = 25;
        } else {
        health = 200;
        damage = 50;
        speed = 1;
        goldDrops = 25;
        }
    }

    IEnumerator GoblinSpawn(){
        yield return new WaitForSeconds(3);
        //Debug.Log("Pos Found");
        GameObject SpawnedGoblin = Instantiate(Goblin, DWitch.transform.position, DWitch.transform.rotation);
        //Debug.Log("Goblin Spawned");
        //SpawnedGoblin.transform.localScale = WitchPos;
        //Debug.Log("Goblin Pos found and placed");
        StartCoroutine(GoblinSpawn());
    }
}
