using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Troops
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 7500;
        damage = 0;
        speed = 0;
        StartCoroutine(ArrowCooldown());
    }

    IEnumerator ArrowCooldown(){
        yield return new WaitForSeconds(10);
        GameObject Arrow = Instantiate(GameManager.Instance.Arrow);
        Arrow.transform.SetParent(TroopSpawner.Instanc.TroopParent.transform);
        StartCoroutine(ArrowCooldown());
    }
}
