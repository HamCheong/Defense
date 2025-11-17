using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip doorSound;
    public AudioClip leverSound;

    public GameObject fadePanel;
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "door")
        {
            audioSource.clip = doorSound;
            audioSource.Play();
            fadePanel.SetActive(true);
        
        }
        if (collider.gameObject.name == "레버")
        {
            audioSource.clip = leverSound;
            audioSource.Play();
        }
    }


}
