using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // 왼쪽으로 이동
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // 화면 밖으로 나가면 제거
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}

