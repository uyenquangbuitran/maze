using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGround : MonoBehaviour
{
    public float maxTime = 3.5f;

    private float currentTime = 0f;
    private float timeOffset = 1.2f;

    public bool isStartDecaying = false;

    private void Start()
    {
        currentTime = maxTime;
    }

    [SerializeField]
    private Material material;

    [SerializeField]
    private Renderer renderer;

    // Update is called once per frame
    void Update()
    {
        if (isStartDecaying)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime * timeOffset;

                Color curColor = material.color;
                curColor.a = currentTime / maxTime;

                renderer.material.color = curColor;
            }
            else
            {
                gameObject.SetActive(false);
            }            
        }
    }
}
