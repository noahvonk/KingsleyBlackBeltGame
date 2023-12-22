using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TroopSpawner : MonoBehaviour
{

    public GameObject TroopParent;

    // Start is called before the first frame update
    void Start()
    {
        TroopParent = this.gameObject;
    }

    Camera m_Camera;
    void Awake()
    {
        m_Camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TroopBuyModeOff();
        }
        if (Input.GetMouseButtonDown(0) && GameManager.Instance.TroopSpawning)
        {
            Debug.Log(m_Camera.ScreenToWorldPoint(Input.mousePosition));
            Vector3 mousePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 5);
            Debug.Log("Placed Troop");
            PlaceTroop(mousePosition);
        }
    }

    public void TroopBuyModeOff()
    {
        SelectedTroop = Troops.None;
        GameManager.Instance.TroopSpawning = false;
    }

    public void TroopBuyModeOn()
    {
        GameManager.Instance.TroopSpawning = true;
    }

    public void PlaceTroop(Vector3 pos)
    {
        // Instantiate Troop
        GameObject troop = Instantiate(TroopPrefabs[(int)SelectedTroop]);
        troop.transform.position = pos;
        gameObject.transform.localScale = new Vector3(1, 1, 1);

        troop.transform.SetParent(TroopParent.transform);
    }

    public void OnWarriorButtonPressed()
    {
        SelectedTroop = Troops.Warrior;
        TroopBuyModeOn();
    }

    public void OnHeroButtonPressed()
    {
        SelectedTroop = Troops.Hero;
        TroopBuyModeOn();
    }

    public void OnSpearmanButtonPressed()
    {
        SelectedTroop = Troops.Spearman;
        TroopBuyModeOn();
    }


    public enum Troops { Hero, Warrior, Spearman, Archer, None, etc, misc}
    public Troops SelectedTroop = Troops.None;

    [Header("Order is  Hero, Warrior, Spearman, Archer, None,  etc, misc "), SerializeField]
    private List<GameObject> TroopPrefabs = new();
}
