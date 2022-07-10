using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
        
    public float velocity = 2f;
    
    public enum MovingType { Manual, Auto}

    private const float MAX_ACCELERATOR = 5f;
    private float accelerator = 0.01f;

    private bool isSpeedUp = false;
    public MovingType movingType = MovingType.Auto;
        
    void Update()
    {
        float _velocity = velocity;
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 direction = Vector3.zero;

        if (movingType == MovingType.Auto)
        {            
            if (accelerator < MAX_ACCELERATOR)
            {
                accelerator += Time.deltaTime * 0.2f;
            }

            direction = transform.forward;
            controller.SimpleMove(direction.normalized * _velocity * accelerator);
        }
        else if (movingType == MovingType.Manual)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _velocity *= 3;
                isSpeedUp = true;
            }
            else
            {
                isSpeedUp = false;
            }

            direction = transform.forward * vInput + transform.right * hInput;
            controller.SimpleMove(direction.normalized * _velocity);
        }
        else
        {
            Debug.LogError("INVALID MOVING TYPE!");
        }        

        #region Old movement controller
        //float distance = velocity * Time.deltaTime;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * distance);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.back * distance);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.left * distance);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.right * distance);
        //}
        #endregion

        //Falling check
        if (transform.position.y <= -10f)
        {
            GameManager.Instance.SetActivePanel(GameManager.PanelType.Lose, true);
            Time.timeScale = 0;
            enabled = false;
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
    }

    public bool IsSpeedUp()
    {
        return isSpeedUp;
    }
}
