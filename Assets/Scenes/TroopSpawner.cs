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
            Debug.Log("Mouse Pressed");
            Vector3 mousePosition = Input.mousePosition;
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

    public enum Troops { Warrior, Archer, None, blah, etc, misc}
    public Troops SelectedTroop = Troops.None;

    [Header("Order is  Warrior, Archer, None, blah, etc, misc "), SerializeField]
    private List<GameObject> TroopPrefabs = new();
}
