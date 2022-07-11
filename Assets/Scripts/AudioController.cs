using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [HideInInspector]
    public static AudioController Instance;

    public AudioSource collisionSound;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }


    public void PlayCollisionSound()
    {
        collisionSound.Play();
    }
}
