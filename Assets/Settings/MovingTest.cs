using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTest : MonoBehaviour
{

    private bool IsTouch = false;
    public Transform target;
    public Transform up;
    public Transform down;

    // Update is called once per frame
    void Update()
    {
        if (IsTouch)
        {
            target.position = Vector2.MoveTowards(target.position, up.position, 2.0f * Time.deltaTime);
        }
        else
        {
            target.position = Vector2.MoveTowards(target.position, new Vector2(4.51999998f,-3.48000002f), 2.0f * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Cube") IsTouch = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Cube") IsTouch = false;
    }
}
