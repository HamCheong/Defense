using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class button : MonoBehaviour
{
    // 버튼 클릭 시 실행되는 함수
    public void QuitGame()
    {
        Debug.Log("게임 종료 버튼이 눌렸습니다.");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터에서 정지
#else
        Application.Quit(); // 빌드된 게임에서는 종료
#endif
    }
}

