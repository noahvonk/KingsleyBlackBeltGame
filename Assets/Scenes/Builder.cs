using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : Troops
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 1000;
        speed = 1;
        damage = 1;
        StartCoroutine(WallTimer());
    }

    IEnumerator WallTimer()
        {
        Debug.Log("Wall Timer");
        yield return new WaitForSeconds(20);
        foreach (GameObject walls in GameManager.Instance.Walls){
            walls.GetComponent<WallHealth>().wallHP += 250;
        };
        StartCoroutine(WallTimer());
        }
}
