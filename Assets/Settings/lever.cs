using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            anim.SetBool("IsTouch", true);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            anim.SetBool("IsTouch", false);
        }
    }
}
