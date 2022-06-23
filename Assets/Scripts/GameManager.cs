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
        CreateFile();
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

    public void SetLevel()
    {
        Level = Random.Range(1,6);
        LoadGame();
    }
    public void CreateFile()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Game Results");
    }
    public void SaveInitialData()
    {
        filename = Application.streamingAssetsPath + "/Game Results/" + Name.text + ".txt";
        if (!File.Exists(filename))
        {
            File.WriteAllText(filename, "Name: " + Name.text + "\n");
            File.AppendAllText(filename, "Age: " + age.text + "\n");
            File.AppendAllText(filename, "Gender: " + gender.options[gender.value].text + "\n");
        }
    }
}
