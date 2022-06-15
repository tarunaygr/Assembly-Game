using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenSelect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject parts; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        transform.parent.gameObject.SetActive(false);
        parts.SetActive(true);
    }
}
