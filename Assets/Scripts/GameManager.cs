using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        Cursor.visible = false;
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

    public void ConfirmBtn_OnClick()
    {
        SetActivePanel(PanelType.AutoGuide, false);
        SetActivePanel(PanelType.ManualGuide, false);
    }
}
