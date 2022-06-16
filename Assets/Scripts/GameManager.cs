using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject StartScreen, ConsentScreen,LevelScreen;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("UI Manager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }
    public static int Level { get; private set ; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    private void Awake()
    {
        _instance= this;
        StartScreen.SetActive(true);
        ConsentScreen.SetActive(false);
        LevelScreen.SetActive(false);
    }

    public void SetLevel(int l)
    {
        Level = l;
        LoadGame();
    }
}
