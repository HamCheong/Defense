using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yMove = Input.GetAxisRaw("Vertical") * 5 * Time.deltaTime;
        this.transform.Translate(new Vector3(0, yMove, 0));

    }
}
