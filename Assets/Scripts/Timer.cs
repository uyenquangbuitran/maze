using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer;

    public bool isShownOnly = false;

    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;
    
    void Start()
    {
        ResetTimer();
    }
        
    void Update()
    {
        if (!isShownOnly)
        {
            timer += Time.deltaTime;
            UpdateTimeDisplay(timer);
        }        
    }

    private void ResetTimer()
    {
        timer = 0;
    }

    public void UpdateTimeDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    public float GetTime()
    {
        return timer;
    }
}
