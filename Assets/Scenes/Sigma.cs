using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Sigma : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = 654321;
        damage = 12345;
        speed = 15;
    }
}
