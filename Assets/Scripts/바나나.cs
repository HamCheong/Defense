using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 바나나 : MonoBehaviour
{
    public GameObject gg;
    public GameObject re;
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
        if (collider.gameObject.name == "불")
        {
            gg.SetActive(true);
            re.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}