using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValues : MonoBehaviour
{
    public Slider slider;
    [SerializeField]
    private TMP_Text value;

    void Start()
    {
        ShowSliderValue();
    }

    public void ShowSliderValue()
    {
        value.text ="" + slider.value;
    }
}
