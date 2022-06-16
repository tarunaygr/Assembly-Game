using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Error_Score : MonoBehaviour
{
    public static int errorScore = 10;
    public TextMeshProUGUI errorScoreText;

    void Update()
    {
        errorScoreText.text = "Errors : " + errorScore.ToString();
    }
}
