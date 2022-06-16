using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Replace 'from' with the name of the scipt which contains the informatio about the current level.
public class Level : MonoBehaviour
{
    public TextMeshProUGUI level;
    int currentLevel = GameManager.Level;

    // Start is called before the first frame update
    void Start()
    {
        level.text = "Level : " + currentLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
