using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 Offset;
    private float Zmouse;
    private int flag;
    [SerializeField]
    private float objectheight=12f,max_width=13,max_height=6.5f;
    public Camera Cam;
    Vector3 prevPos = Vector3.zero;
    Vector3 PosDelta = Vector3.zero;
    float xclamp;
    float zclamp;
    void Start()
    {
        Cam = GameObject.Find("3D View Camera").GetComponent<Camera>();
        flag=0;
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Zmouse;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDown()
    {

        Zmouse = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Offset = gameObject.transform.position - GetMouseWorldPos();
        Offset.y = 0;
    }

    void OnMouseDrag()
    {

        xclamp=Mathf.Clamp(GetMouseWorldPos().x+Offset.x,-max_height,max_height);
        zclamp = Mathf.Clamp(GetMouseWorldPos().z + Offset.z, -max_width, max_width);
        if (Input.GetMouseButton(0) && !(Input.mousePosition.x > (0.75 * Screen.width) && Input.mousePosition.y < (0.25 * Screen.height)) && flag == 0)
        {
            transform.position = new Vector3(xclamp, objectheight, zclamp);
            Cam.transform.position = new Vector3(xclamp, Cam.transform.position.y, zclamp);
        }

        else if (Input.GetMouseButton(0) && Input.mousePosition.x > (0.75 * Screen.width) && Input.mousePosition.y < (0.25 * Screen.height))
        {
            transform.Rotate(transform.right, -Vector3.Dot(PosDelta, Camera.main.transform.up), Space.World);
        }

        else
        {
            transform.rotation = Quaternion.identity;

        }

        if (Input.GetMouseButton(0) && Input.mousePosition.x < (0.15 * Screen.width) && Input.mousePosition.x > (0.10 * Screen.width) && Input.mousePosition.y < (0.15 * Screen.height) && Input.mousePosition.y > (0.10 * Screen.height) && flag==0)
            Destroy(gameObject);

    }
    void Update()
    {
        if (Input.GetMouseButton(0) && Input.mousePosition.x > (0.75 * Screen.width) && Input.mousePosition.y < (0.25 * Screen.height))
        {
            flag = 1;
            PosDelta = Input.mousePosition - prevPos;
        }
        else
        {
            transform.rotation = Quaternion.identity;
            
        }
        prevPos = Input.mousePosition;
    }
    /*   private void OnMouseOver()
       {
           if (Input.GetMouseButton(0) && Input.mousePosition.x < (0.25 * Screen.width) && Input.mousePosition.y < (0.25 * Screen.height))
            Destroy(gameObject);
       }
    */
    private void OnMouseExit()
    {
        
            flag = 0;
        StopAllCoroutines();
        
    }

    /*private void OnMouseUp()
    {
        if (Input.GetMouseButton(0) && Input.mousePosition.x < (0.25 * Screen.width) && Input.mousePosition.y < (0.25 * Screen.height))
            Destroy(gameObject);
    }
    */
    private void OnMouseClick()
    {
        xclamp = Mathf.Clamp(GetMouseWorldPos().x + Offset.x, -max_height, max_height);
        zclamp = Mathf.Clamp(GetMouseWorldPos().z + Offset.z, -max_width, max_width);

        Cam.transform.position = new Vector3(xclamp, Cam.transform.position.y, zclamp);
    }


}
