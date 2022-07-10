using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = GameManager.Instance.GetPlayer();
        float _velocity = playerController.velocity;
        if (playerController.IsSpeedUp())
        {
            _velocity *= 3;
        }

        Vector3 verDir = -playerController.transform.forward;
        Vector3 horDir = -playerController.transform.right;
        Vector3 direction = verDir + horDir;
        playerController.controller.SimpleMove(direction.normalized * _velocity * 100);       
    }
}
