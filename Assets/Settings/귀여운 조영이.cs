using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 귀여운조영이 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal") * 5 * Time.deltaTime;
        this.transform.Translate(new Vector3(xMove, 0, 0));

    }
}
