using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTile : MonoBehaviour
{
    public enum TileType { Gate, ManualTrigger, AutoTrigger}

    [SerializeField]
    private TileType tileType;

    private void OnTriggerEnter(Collider other)
    {
        switch (tileType)
        {
            case TileType.AutoTrigger:
                GameManager.Instance.SetActivePanel(GameManager.PanelType.AutoGuide, true);
                GameManager.Instance.GetPlayer().movingType = PlayerController.MovingType.Auto;
                break;
            case TileType.ManualTrigger:
                GameManager.Instance.SetActivePanel(GameManager.PanelType.ManualGuide, true);
                GameManager.Instance.GetPlayer().movingType = PlayerController.MovingType.Manual;
                break;
            case TileType.Gate:
                GameManager.Instance.SetActivePanel(GameManager.PanelType.Win, true);
                Time.timeScale = 0f;
                break;
            default:
                Debug.LogError("INVALID TILE TYPE!");
                break;
        }
        gameObject.SetActive(false);
    }
}
