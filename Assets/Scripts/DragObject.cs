using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 Offset;
    private float Zmouse;
    [SerializeField]
    private float objectheight=12f,max_width=13,max_height=6.5f;
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
        transform.position = new Vector3(xclamp,objectheight,zclamp);

    }
 /*   private void OnMouseOver()
    {
        gameObject.transform.localScale = new Vector3(2,2,2);
    }
    private void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
 */
}
