using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void ChangeScene(string Scenes)
    {
        Debug.Log("Scenes123");
        SceneManager.LoadScene("Scenes123");
    }
}
