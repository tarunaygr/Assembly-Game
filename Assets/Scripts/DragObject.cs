using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 Offset;
    private float Zmouse;
    private Vector3 GetMouseWorldPos()
    {
        Debug.Log("1");
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Zmouse;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDown()
    {
        Debug.Log("2");
        Zmouse = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Offset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        Debug.Log("3");
        transform.position = GetMouseWorldPos() + Offset;
    }
}
