using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class countdown : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Setting")]
    public bool hasLimit;
    public float timerLimit;
    void Update()
    {
        currentTime = countDown ? currentTime -=  Time.deltaTime : currentTime += Time.deltaTime;

        if (hasLimit && (countDown && (currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            timerText.text = "Times Up!!";
            timerText.color = Color.red;
            enabled = false;                                // It disables the script automatically.
        }
        else
        {
            setTimerText();
            timerText.color = Color.green;
        }
        
    }
    
    private void setTimerText()
    {
        timerText.text = "Time Left : " + currentTime.ToString("0");       
    }
}
