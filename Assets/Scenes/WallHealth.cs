using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{

    public int WallHP;
    public Text WHPDisplay;
    // Start is called before the first frame update
    void Start()
    {
        WHPDisplay.text = WallHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
