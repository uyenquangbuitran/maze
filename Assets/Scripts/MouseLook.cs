using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float rotaionSpeed;

    private void Start()
    {
        rotaionSpeed = 75000 / (float)Screen.width;        
    }
    void Update()
    {
        float mouseH = Input.GetAxis("Mouse X");
        float mouseV = Input.GetAxis("Mouse Y");
        float angleH = mouseH * rotaionSpeed * Time.deltaTime;
        float angleV = mouseV * rotaionSpeed * Time.deltaTime;

        //transform.Rotate(-angleV, angleH, 0);
        transform.Rotate(0, angleH, 0);
    }
}
