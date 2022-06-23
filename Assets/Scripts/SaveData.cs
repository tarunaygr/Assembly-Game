using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class SaveData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TMP_InputField age, Name;
    [SerializeField]
    private TMP_Dropdown gender;
    string filename;
    void Start()
    {
        CreateFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateFile()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath+"/Game Results");
    }
    public void SaveName()
    {
        filename = Application.streamingAssetsPath + "/Game Results/" + Name.text+".txt";
        if(!File.Exists(filename))
        {
            File.WriteAllText(filename,"Name: "+ Name.text+"\n");
        }
    }
    public void SaveAge()
    {
        if(File.Exists(filename))
        {
            File.AppendAllText(filename, "Age: " + age.text + "\n");
        }
    }

    public void SaveGender()
    {
        if (File.Exists(filename))
        {
            File.AppendAllText(filename, "Gender: " + gender.options[gender.value].text + "\n");
            Debug.Log(gender.options[gender.value].text);

        }
    }
}
