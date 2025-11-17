using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip waterSound;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            audioSource.clip = waterSound;
            audioSource.Play();
        }
    }
}
