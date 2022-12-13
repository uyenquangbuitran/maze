using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager Instance;
    
    public string sceneName;

    public enum PanelType { Win, Lose, AutoGuide, ManualGuide}

    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private GameObject autoGuidePanel;
    [SerializeField]
    private GameObject manualGuidePanel;
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private Timer score;
    [SerializeField]
    private GameObject newBestIcon;

    public TextMeshProUGUI mouseSpeed;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        Cursor.visible = false;
        mouseSpeed.text = (75000 / (float)Screen.width).ToString();        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPlaying)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
#endif
            Application.Quit();            
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public PlayerController GetPlayer()
    {
        return playerController;
    }

    public void SetActivePanel(PanelType panelType, bool isActive)
    {
        if (isActive)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.visible = false;
            Time.timeScale = 1;
        }

        switch(panelType)
        {
            case PanelType.Win:
                winPanel.SetActive(isActive);
                score.UpdateTimeDisplay(timer.GetTime());
                ShowHighScoreIcon(timer.GetTime());
                break;
            case PanelType.Lose:
                losePanel.SetActive(isActive);
                break;
            case PanelType.AutoGuide:
                autoGuidePanel.SetActive(isActive);
                break;
            case PanelType.ManualGuide:
                manualGuidePanel.SetActive(isActive);
                break;
            default:
                Debug.LogError("INVALID PANEL TYPE!");
                break;
        }
    }
    
    public void SaveScore(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);

        SPrefs.SetFloat("best_time", time);
    }

    public float GetScore()
    {
        if (!SPrefs.HasKey("best_score"))
        {
            SPrefs.SetFloat("best_score", 0);
        }

        return SPrefs.GetFloat("best_score");
    }

    private void ShowHighScoreIcon(float time)
    {
        float currentBestScore = GetScore();
        if (currentBestScore < time)
        {
            newBestIcon.gameObject.SetActive(true);
        }
    }

    public void ConfirmBtn_OnClick()
    {
        SetActivePanel(PanelType.AutoGuide, false);
        SetActivePanel(PanelType.ManualGuide, false);
    }    
}
