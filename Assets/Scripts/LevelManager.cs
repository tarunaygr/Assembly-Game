using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Slider mental, physical, effort, frustration, temporal, performance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        GameManager.Instance.SurveyDataStore(((int)mental.value), ((int)physical.value), ((int)temporal.value), ((int)performance.value), ((int)effort.value), ((int)frustration.value));
        GameManager.Instance.LoadNextLevel();
    }

}
