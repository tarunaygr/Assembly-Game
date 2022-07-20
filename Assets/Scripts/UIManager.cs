using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [field: SerializeField]
    public GameObject PartsPanel { get; private set; }
    private static UIManager _instance;
    [Header("Component")]
    [SerializeField]
    private TMP_Text error_text, level_text, timer_text;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Setting")]
    public bool hasLimit;
    public float timerLimit;

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
      //  UpdateErrorScoreText(0);
        UpdateLevelText();
    }

    // Update is called once per frame
    void Update()
    {
        CountdownCalculator();
    }

    public void ToggleState(GameObject obj)
    {
        Animator anim;
        obj.SetActive(!obj.activeInHierarchy);
        anim= obj.GetComponent<Animator>();
        int level = GameManager.Level;
        obj.transform.GetChild((level - 1)/2).gameObject.SetActive(true);
        if(anim!=null)
        {
            anim.SetBool("IsOpen", !anim.GetBool("IsOpen"));
        }
    }
    public void UpdateErrorScoreText(int es)
    {
        error_text.text = "Errors: " + es.ToString();
    }
    void CountdownCalculator()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if (hasLimit && (countDown && (currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            timer_text.text = "Times Up!!";
            timer_text.color = Color.red;
            enabled = false;                                // It disables the script automatically.
            GameManager.Instance.survey();
        }
        else
        {
            UpdateTimerText();
            timer_text.color = Color.green;
        }
    }
    private void UpdateTimerText()
    {
        timer_text.text = "Time Left : " + currentTime.ToString("0");
    }
    private void UpdateLevelText()
    {
        level_text.text = "Level: " + GameManager.Level.ToString();
    }
}
