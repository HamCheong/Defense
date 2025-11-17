using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cdcd2 : MonoBehaviour
{
    public Transform B;
    // Start is called before the first frame update
    bool th = false;

    void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.tag == "bbbbb")
        {
            th = true;
        }


    }

    void OnCollisionExit2D(Collision2D collider)
    {

        if (collider.gameObject.tag == "bbbbb")
        {
            th = false;
        }
    }
    void Update()
    {

        if (th == true)
        {

            B.position = Vector2.MoveTowards(B.position, new Vector2(11.0600004f,4.05000019f), 2.0f * Time.deltaTime);

        }
        else
        {
            B.position = Vector2.MoveTowards(B.position, new Vector2(6.01000023f,4.05000019f), 2.0f * Time.deltaTime);
        }



    }
}
