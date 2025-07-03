using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedSlider : MonoBehaviour
{
    public static GameSpeedSlider Inst;
    // Start is called before the first frame update
    void Awake(){
        Inst = this;
    }
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
        labelText.text = Mathf.Round(slider.value * 1).ToString() + "x";
        Time.timeScale = slider.value;
    }

    [SerializeField]
    public Slider slider;

    private Text labelText;
    
}
