using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 Offset;
    private float Zmouse;
    [SerializeField]
    private float objectheight=12f,max_width=13,max_height=6.5f;
    public Camera Cam;
    Vector3 prevPos = Vector3.zero;
    Vector3 PosDelta = Vector3.zero;

    void Start()
    {
        Cam = GameObject.Find("3D View Camera").GetComponent<Camera>();
        if (Cam != null)
            Debug.Log(Cam.rect);
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

        float xclamp=Mathf.Clamp(GetMouseWorldPos().x+Offset.x,-max_height,max_height);
        float zclamp = Mathf.Clamp(GetMouseWorldPos().z + Offset.z, -max_width, max_width);
        if (Input.GetMouseButton(0) && Input.mousePosition.x < (0.75 * Screen.width) && Input.mousePosition.y > (0.25 * Screen.height))
        {
            transform.position = new Vector3(xclamp, objectheight, zclamp);
            Cam.transform.position = new Vector3(xclamp, Cam.transform.position.y, zclamp);
        }

    }
    void Update()
    {
        if (Input.GetMouseButton(0) && Input.mousePosition.x > (Cam.rect.x * Screen.width) && Input.mousePosition.y < ((1-Cam.rect.y) * Screen.height))
        {
            PosDelta = Input.mousePosition - prevPos;

            transform.Rotate(transform.right, -Vector3.Dot(PosDelta, Camera.main.transform.up), Space.World);

        }
        prevPos = Input.mousePosition;
    }
    /*   private void OnMouseOver()
       {
           gameObject.transform.localScale = new Vector3(2,2,2);
       }
    */
       private void OnMouseExit()
       {
           transform.rotation = Quaternion.identity;
       }
    
   
}
