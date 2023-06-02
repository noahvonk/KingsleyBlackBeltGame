using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        labelText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnSliderChange()
    {
        labelText.text = "Game Speed: " + Mathf.Round(slider.value * 100).ToString() + "%";
        Time.timeScale = slider.value;
    }

    [SerializeField]
    Slider slider;

    private Text labelText;
    
}
