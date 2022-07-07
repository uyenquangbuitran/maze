using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager Instance;

    public GameObject winPanel;
    public GameObject losePanel;
    public string sceneName;

    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
