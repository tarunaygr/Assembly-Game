using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    public GameObject MainPanel,ChildPanel;

    // Start is called before the first frame update
    void Start()
    {
      switch(GameManager.Level)
        {
            case 1:
                ChildPanel=MainPanel.transform.GetChild(0).gameObject;
                break;
            case 2:
                ChildPanel = MainPanel.transform.GetChild(1).gameObject;
                break;
            case 3:
                ChildPanel = MainPanel.transform.GetChild(2).gameObject;
                break;
            case 4:
                ChildPanel = MainPanel.transform.GetChild(3).gameObject;
                break;
            case 5:
                ChildPanel = MainPanel.transform.GetChild(4).gameObject;
                break;
        }

        ChildPanel.SetActive(true);
    }

    public void toggleInstructions()
    {
        if(MainPanel.activeSelf==true)
            MainPanel.SetActive(false);
        else
        {
            MainPanel.SetActive(true);
        }
    }

    
}
