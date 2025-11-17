using System.Collections; // 시스템 목록 기능 사용
using System.Collections.Generic; // 일반적인 목록 기능 사용
using UnityEngine; // 유니티 엔진 기본 기능 사용
using TMPro; // TextMeshPro 기능 사용

public class InputManager : MonoBehaviour // InputManager 클래스 정의 (유니티 컴포넌트)
{
    public TMP_InputField inputField; // 입력 필드 변수 선언

    public AudioSource audioSource; // 오디오 소스 변수 선언
    public AudioClip success; // 성공 오디오 클립 변수 선언
    public AudioClip fail; // 실패 오디오 클립 변수 선언

    public string inputText; // 입력된 텍스트를 저장할 변수
    private bool IsCorrect = false; // 정답 여부를 저장할 변수 (기본값 false)

    public void GetTxt() // 텍스트를 가져와 처리하는 함수
    {
        inputText = inputField.text; // 입력 필드의 텍스트를 inputText에 저장
        
        // 40번 반복하며 정답 단어 목록을 확인
        for (int i = 0; i < 40; i++) 
        {
            // 입력 텍스트가 GameManager의 단어 배열(wordArr) 중 하나와 일치하는지 확인
            if (inputText == GameManager.Instance.wordArr[i]) 
            {
                IsCorrect = true; // 정답으로 설정
                audioSource.clip = success; // 성공 클립 준비
                audioSource.Play(); // 성공 소리 재생
                GameManager.Instance.scoreCnt += 100; // 점수에 100점 추가
                Destroy(GameObject.Find(inputText)); // 입력 텍스트와 이름이 같은 게임 오브젝트 제거
                break; // 정답을 찾았으므로 반복문 종료
            }
        } 

        // 정답이 아닌 경우 (IsCorrect가 false인 경우)
        if(!IsCorrect)
        {
            audioSource.clip = fail; // 실패 클립 준비
            audioSource.Play(); // 실패 소리 재생
        }

        IsCorrect = false; // 정답 여부 상태를 다시 false로 초기화
        
        inputText = ""; // 입력 텍스트 변수 비우기
        inputField.text = ""; // 입력 필드 텍스트 비우기
        inputField.ActivateInputField(); // 입력 필드 활성화 (재입력 가능하게 준비)
    } 
}