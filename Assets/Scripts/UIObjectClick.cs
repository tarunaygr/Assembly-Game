using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectClick : MonoBehaviour
{
    [SerializeField]
    GameObject tospawn,penPanel=null;
    // Start is called before the first frame update
    public void SpawnObject()
    {
        Instantiate(tospawn, new Vector3(0, 12, 10), Quaternion.identity);
        Instantiate(tospawn, new Vector3(999, 990, 963), Quaternion.identity);
    }
    private void OnMouseDown()
    {
        if(gameObject.transform.CompareTag("Level1UI"))
        {
            SpawnObject();
            UIManager.Instance.PartsPanel.SetActive(false);
        }
        else if(gameObject.transform.CompareTag("Level2UI"))
        {
            transform.parent.gameObject.SetActive(false);
            penPanel.SetActive(true);
            UIManager.Instance.PartsPanel.SetActive(false);
            SpawnObject();
        }
        
    }
}
