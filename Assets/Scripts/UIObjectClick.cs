using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectClick : MonoBehaviour
{
    [SerializeField]
    GameObject tospawn;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        Instantiate(tospawn,new Vector3(0,12,10),Quaternion.identity);
        transform.parent.gameObject.SetActive(false);
    }
}
