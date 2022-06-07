using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject PartsPanel;
    private static UIManager _instance;
    

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("UI Manager");
                go.AddComponent<UIManager>();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PartsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleState(GameObject obj)
    {
        Animator anim;
        obj.SetActive(!obj.activeInHierarchy);
        anim= obj.GetComponent<Animator>();
        if(anim!=null)
        {
            anim.SetBool("IsOpen", !anim.GetBool("IsOpen"));
        }
    }

}
