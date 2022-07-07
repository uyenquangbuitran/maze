using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    
    [SerializeField]
    float velocity = 5f;
        
    void Update()
    {
        float _velocity = velocity;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _velocity *= 3;
        }
        //float hInput = Input.GetAxis("Horizontal");
        //float vInput = Input.GetAxis("Vertical");
        //Vector3 direction = transform.forward * vInput + transform.right * hInput;
        //controller.SimpleMove(direction.normalized * _velocity);

        float distance = velocity * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * distance);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * distance);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * distance);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * distance);
        }

        if (transform.position.y <= -10f)
        {
            GameManager.Instance.losePanel.SetActive(true);
            Time.timeScale = 0;
            enabled = false;
        }
    }    
}
