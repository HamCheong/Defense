using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        if(collider.gameObject.name == "Triangle")
        {
            Transform targetTr = collider.gameObject.transform;
            targetTr.position = Vector3.MoveTowards(targetTr.position, new Vector3(targetTr.position.x,targetTr.position.y + 10f, targetTr.position.z),3f * Time.deltaTime);
            //targetTr.position = new Vector3(targetTr.position.x,targetTr.position.y + 1f, targetTr.position.z);
        }
    }
}
