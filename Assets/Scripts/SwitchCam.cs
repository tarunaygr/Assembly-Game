using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public GameObject CamMain;
    public GameObject Cam3D;
    public GameObject CamUI;

    void Start()
    {
        Cam3D.SetActive(false);
    }

    public void ToggleCam()
    {
        if(CamMain.activeSelf)
        {
            CamMain.SetActive(false);
            Cam3D.SetActive(true);
            CamUI.SetActive(true);
        }
        else if(!CamMain.activeSelf)
        {
            CamMain.SetActive(true);
            Cam3D.SetActive(false);
            CamUI.SetActive(true);
        }
    }
}
