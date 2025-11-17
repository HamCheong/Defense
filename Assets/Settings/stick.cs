using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    public GameObject gameover;
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
        if (collider.gameObject.name == "ggggg")
        {
            gameover.SetActive(true);
            Destroy(this.gameObject);
        }




    }

   
}