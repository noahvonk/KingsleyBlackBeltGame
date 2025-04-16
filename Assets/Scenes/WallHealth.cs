using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{
    public static WallHealth Instance;
    public int wallHP;
    public int maxHp;
    public Image health;
    [SerializeField]
    private GameObject target;

    private bool dead = false;
    public GameObject hpDisplay;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        wallHP = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = (float) wallHP/maxHp;
    }
    /*
    public void WallUpgradeButtonPressed()
    {
        if(GameManager.Instance.gold - 150 >= 0){
        WallHP += 500;
        GameManager.Instance.gold -= 150;
        };
    }
*/
    public void TakeDamage(int d)
    {
        if(wallHP - d <= 0 && !dead)
        {
            wallHP = 0;
            WallDie();
            dead = true;
        } else {
           wallHP -= d;
        }
        //health.SetActive(true);
        //Debug.Log(health.fillAmount);
    }

    public int GetIndex()
    {
        if(target == null)
        {
            Destroy(this.gameObject);
            Destroy(hpDisplay);
        }
        string wallName = target.gameObject.name;

        string[] splits = wallName.Split("_");
       // Debug.Log(splits[1]);
        return int.Parse(splits[1]);
        
    }

    void WallDie()
    {
        //Debug.Log("Wall Dead\n Target: " + target.name + "\nWall: " + name);
        GameManager.Instance.targets.Remove(target.GetComponent<Target>());
        Destroy(this.gameObject);
    }   

}
