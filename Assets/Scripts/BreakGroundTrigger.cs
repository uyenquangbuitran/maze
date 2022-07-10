using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGroundTrigger : MonoBehaviour
{
    public BreakGround breakGround;
    private void OnTriggerEnter(Collider other)
    {
        breakGround.isStartDecaying = true;
    }
}
