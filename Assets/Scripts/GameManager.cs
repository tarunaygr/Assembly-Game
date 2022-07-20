using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject StartScreen, ConsentScreen,LevelScreen;
    [SerializeField]
    private TMP_InputField age, Name;
    [SerializeField]
    private TMP_Dropdown gender;
    string filename;
    int error_score;
    [SerializeField]
    float reactionTime = 0f;
    private static GameManager _instance;
    [SerializeField]
    private bool moved;
    private List<int> LevelsToChoose=new List<int>() { 1,2,3,4,5};
    [SerializeField]
    private GameObject Canvas, Survey;
    private int NoChild, i;


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
    public static Scene CurrnetScene { get; private set; }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CurrnetScene = scene;
        if (CurrnetScene.name == "Game")
        {
            moved = false;
            error_score = 0;
            UpdateErrorScore();
        }
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Start()
    {
        CreateFile();
        
      //  Debug.Log(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrnetScene.name=="Game")
        {
            if(Input.GetKeyDown(KeyCode.A))
                {
                    MadeError();
                }
            if(moved==false)
            {
                reactionTime+=Time.deltaTime;
            }
            if(HasMouseMoved() && !moved)
            {
                moved=true;
                Debug.Log(reactionTime);
                File.AppendAllText(filename, "Reaction Time: " + reactionTime.ToString() + " seconds\n");
            }
            if(Input.GetKeyDown(KeyCode.N))
            {
                LoadNextLevel();
            }
        }
        
    }

    void LoadGame()
    {

        SceneManager.LoadScene("Game");
    }
    private void Awake()
    {
        _instance= this;
        StartScreen.SetActive(true);
        ConsentScreen.SetActive(false);
        LevelScreen.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void SetLevel()
    {
        int nextIndex=Random.Range(0, LevelsToChoose.Count);
        int nextLevel=LevelsToChoose[nextIndex];
        Level = nextLevel;
        LevelsToChoose.RemoveAt(nextIndex);
        File.AppendAllText(filename, "\nPlayed Level: " + GameManager.Level.ToString() + "\n");
        LoadGame();
    }
    public void CreateFile()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Game Results");
    }
    public void SaveInitialData()
    {
        filename = Application.streamingAssetsPath + "/Game Results/" + Name.text + ".txt";
        File.WriteAllText(filename, "Name: " + Name.text + "\n");
        File.AppendAllText(filename, "Age: " + age.text + "\n");
        File.AppendAllText(filename, "Gender: " + gender.options[gender.value].text + "\n");
        
    }
    public void MadeError()
    {
        error_score += 1;
        UpdateErrorScore();
    }
    public void UpdateErrorScore()
    {
        
        UIManager.Instance.UpdateErrorScoreText(error_score);
    }
    bool HasMouseMoved()
    {
        return (Input.GetAxis("Mouse X") != 0) || (Input.GetAxis("Mouse Y") != 0);
    }

    public void LoadNextLevel()
    {
        //Add code to store the rest of the stats here
        reactionTime = 0;
        File.AppendAllText(filename, "Errors Made: " + error_score.ToString() + "\n");
        SetLevel();
    }

    public void survey()
    {
        Canvas = GameObject.Find("Canvas");
        Survey = Canvas.transform.GetChild(0).gameObject;
        NoChild = Canvas.transform.childCount;

        for(i=0;i<NoChild;i++)
        {
            Canvas.transform.GetChild(i).gameObject.SetActive(false);
        }

        Survey.gameObject.SetActive(true);
    }
}
