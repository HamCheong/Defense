using System.Collections; // 시스템 목록 기능 사용
using System.Collections.Generic; // 일반적인 목록 기능 사용
using UnityEngine; // 유니티 엔진 기본 기능 사용
using UnityEngine.SceneManagement; // 씬(화면) 관리 기능 사용

public class Title : MonoBehaviour // Title 클래스 정의 (유니티 컴포넌트)
{
    // 오브젝트 활성화 시 최초 1회 실행
    void Start()
    {
        // 현재는 아무런 초기화 작업 없음
    }

    void StartGame() // 게임 시작 함수
    {
        // "bg_and_dong" 씬(게임 화면)을 로드
        SceneManager.LoadScene("bg_and_dong");
    }

    // 매 프레임마다 반복 실행
    void Update()
    {
        // Space 키를 눌렀을 때 (한 번 누르는 순간)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space bar"); // 콘솔에 "Space bar" 메시지 출력
            StartGame(); // StartGame 함수 호출 (게임 씬 로드)
        }
        // "escape" 키 (ESC 키)를 누르고 있는 동안
        if (Input.GetKey("escape"))
        {
            Application.Quit(); // 애플리케이션(게임 자체) 종료
        }
            
    }

}