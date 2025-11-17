using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick2 : MonoBehaviour
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
        if (collider.gameObject.name == "f5baea7a-9c31-41a1-a24f-8254ad526003-removebg-preview")
        {
            gameover.SetActive(true);
            Destroy(this.gameObject);
        }



    }
}
