using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour

{
    public GameObject gg;
    public GameObject re;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "ggggg")
        {
            gg.SetActive(true);
            re.SetActive(true);
            Destroy(this.gameObject);
        }
    }


}
