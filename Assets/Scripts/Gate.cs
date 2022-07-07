using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
