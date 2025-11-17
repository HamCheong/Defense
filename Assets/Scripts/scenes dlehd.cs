using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 이동 기능을 쓰기 위해선 맨 위에 이걸 추가해야함!
public class scenesdlehd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Move()
    {
    
 
        SceneManager.LoadScene("Game 1"); // 원하는 씬으로 이동

    }
}
