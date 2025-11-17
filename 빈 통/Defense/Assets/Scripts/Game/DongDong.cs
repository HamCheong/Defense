using System.Collections; // 시스템 목록 기능 사용
using System.Collections.Generic; // 일반적인 목록 기능 사용
using UnityEngine; // 유니티 엔진 기본 기능 사용

public class DongDong : MonoBehaviour // DongDong 클래스 정의 (유니티 컴포넌트)
{
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러 변수 선언
    public Sprite[] sprites; // 스프라이트(그림) 배열 변수 선언
    public int flag = 1; // 회전 허용/중지 플래그 (1: 허용, 0: 중지)
    public AudioSource audioSource; // 오디오 소스 변수 선언

    void ChangeImage() // 스프라이트를 순서대로 변경하는 함수
    {
        // 현재 스프라이트가 첫 번째(0번 인덱스)이면
        if (spriteRenderer.sprite == sprites[0])
        {
            spriteRenderer.sprite = sprites[1]; // 두 번째 스프라이트로 변경
        }
        // 현재 스프라이트가 두 번째(1번 인덱스)이면
        else if (spriteRenderer.sprite == sprites[1])
        {
            spriteRenderer.sprite = sprites[2]; // 세 번째 스프라이트로 변경
        }
        // 현재 스프라이트가 세 번째(2번 인덱스)이면
        else if (spriteRenderer.sprite == sprites[2])
        {
            spriteRenderer.sprite = sprites[3]; // 네 번째(마지막) 스프라이트로 변경
            flag = 0; // flag를 0으로 설정하여 회전 중지
        }
    }

    // 오브젝트 생성 후 최초 1회 실행
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>(); // AudioSource 컴포넌트 연결
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer 컴포넌트 연결
        spriteRenderer.sprite = sprites[0]; // 초기 스프라이트를 첫 번째(0번)로 설정       
    }

    // 일정한 시간 간격으로 반복 실행 (물리 계산에 적합)
    void FixedUpdate()
    { 
        // flag가 1일 경우에만
        if (flag == 1)
        {
            transform.Rotate(0, 0, -2); // Z축을 기준으로 -2도씩 회전
        }
    }

    // 다른 2D 충돌체와 접촉했을 때 실행
    void OnTriggerEnter2D(Collider2D col)
    {
        audioSource.Play(); // 오디오 재생
        ChangeImage(); // 이미지 변경 함수 실행

        // 충돌한 오브젝트의 태그가 "Dong"일 경우
        if(col.gameObject.tag == "Dong")
        {
            // GameManager 싱글톤을 통해 라이프(lifeInt) 1 감소
            GameManager.Instance.lifeInt -= 1; 
            Destroy(col.gameObject, 0.5f); // 충돌한 오브젝트를 0.5초 후 제거
        }
    }
}