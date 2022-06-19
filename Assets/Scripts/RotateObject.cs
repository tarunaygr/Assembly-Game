using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    
    public  GameObject Cam3D;
    Vector3 prevPos = Vector3.zero;
    Vector3 PosDelta = Vector3.zero;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            PosDelta = Input.mousePosition - prevPos;
            if (Vector3.Dot(transform.up, Vector3.up) >= 0)
            {
                transform.Rotate(transform.up, Vector3.Dot(PosDelta, Cam3D.transform.forward), Space.World);

            }
            else
            {
                transform.Rotate(transform.up, -Vector3.Dot(PosDelta, Cam3D.transform.forward), Space.World);
            }
            transform.Rotate(transform.forward, Vector3.Dot(PosDelta, Cam3D.transform.up), Space.World);


            prevPos = Input.mousePosition;
        }
    }
}
