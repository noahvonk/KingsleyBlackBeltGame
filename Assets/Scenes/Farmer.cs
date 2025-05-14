using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Troops
{
    protected override void Start()
    {
        base.Start();
        health = 1500;
        damage = 0;
        speed = 0;
        StartCoroutine(FarmerGoldTimer());
    }

    IEnumerator FarmerGoldTimer()
    {
        yield return new WaitForSeconds(12);
        GameManager.Instance.gold += (100);
        StartCoroutine(FarmerGoldTimer());
    }
}
