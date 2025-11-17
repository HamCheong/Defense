using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip deathSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            audioSource.clip = deathSound;
            audioSource.Play();
        }
    }
}
