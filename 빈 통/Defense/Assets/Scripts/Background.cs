using System.Collections; // 시스템 목록 기능 사용
using System.Collections.Generic; // 일반적인 목록 기능 사용
using System.Diagnostics; // 진단 기능 사용 (유니티에선 일반적으로 UnityEngne.Debug 사용)
using UnityEngine; // 유니티 엔진 기본 기능 사용

public class Background : MonoBehaviour // Background 클래스 정의 (유니티 컴포넌트)
{
    public float bgSpeed = 0.2f; // 배경 이동 속도 변수 (기본값 0.2)
    Material myMaterial; // 오브젝트의 재질(Material)을 저장할 변수
    
    // 오브젝트 활성화 시 최초 1회 실행
    void Start()
    {
        // 이 오브젝트에 있는 Renderer 컴포넌트의 Material을 가져와 myMaterial에 연결
        myMaterial = GetComponent<Renderer>().material;
    }

    // 일정한 시간 간격으로 반복 실행 (고정 프레임 업데이트)
    void FixedUpdate()//고정 프레임
    {
        Vector2 newOffset = myMaterial.mainTextureOffset; // 현재 텍스처의 오프셋(위치) 값을 가져옴
        
        // 새로운 X축 오프셋을 계산: 현재 오프셋 + (속도 * 프레임 간 시간)
        // Time.deltaTime을 곱해 컴퓨터 성능에 관계없이 일정한 속도로 이동하게 함
        newOffset.Set(newOffset.x + (bgSpeed * Time.deltaTime),0); 
        
        myMaterial.mainTextureOffset = newOffset; // 계산된 새로운 오프셋 값으로 텍스처 위치 업데이트
    }
}