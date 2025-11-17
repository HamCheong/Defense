using System.Collections; // 시스템 목록 기능 사용
using System.Collections.Generic; // 일반적인 목록 기능 사용
using UnityEngine.UI; // UI(Text, Button 등) 기능 사용
using UnityEngine; // 유니티 엔진 기본 기능 사용
using UnityEngine.SceneManagement; // 씬(화면) 관리 기능 사용

public class GameManager : MonoBehaviour // GameManager 클래스 정의 (유니티 컴포넌트)
{
    //int,float,Vector2 등은 primitive 타입 call by value (주석: 기본 타입은 값 복사 방식)

    public static GameManager instance; // 싱글톤 인스턴스를 저장할 정적 변수
    public static GameManager Instance // GameManager 인스턴스에 접근하기 위한 프로퍼티
    {
        get
        {
            if (instance == null) // 인스턴스가 없으면
            {
                Debug.LogError("No GameManagerInstance"); // 에러 메시지 출력
            }
            return instance; // 인스턴스 반환
        }
    }
    private int cnt; // 프레임 카운트 또는 시간 카운트 변수
    private float[] yPosList = new float[4] { 0, -0.1f, -0.2f, -0.3f}; // 오브젝트가 생성될 Y축 위치 목록
    private float yPos; // 현재 오브젝트의 Y축 위치
    public string[] wordArr = new string[40] { // 게임에 사용될 단어 목록 (하드코딩 데이터)
        "자바스크립트", "유니티", "파이썬", "썬크림", "해질녘", 
        "로또", "주식", "성균관대학교", "컴퓨터교육과", "오프라인", 
        "온라인", "멋쟁이사자처럼", "쇠똥구리", "맨드라미", "귀뚜라미", 
        "여치", "비단제비나방", "똥", "바나나똥", "먹구름",
        "씨엠디", "개미", "호랑나비", "소나기", "적란운",
        "필통", "손세정제", "코로나", "마스크", "학생증",
        "비누", "아이스크림", "누가바", "메로나", "비비빅",
        "더위사냥", "쿠앤크", "스크류바", "옥동자", "구슬아이스크림"
    };//하드코딩 문자열 데이터

    public int level; // 게임 레벨 변수
    public int Speedy; // 속도 증가 여부 변수 (0 또는 1)
    public int lifeInt; // 현재 생명(라이프) 변수
    public float bgSpeed = 0.2f; // 배경 이동 속도 변수

    public string lifeString; // 생명 표시 문자열 (예: "♥♥♡")
    private string resultString; // 최종 점수 결과 문자열

    public Text myTime; // 화면에 표시될 시간 UI 텍스트
    public Text myLife; // 화면에 표시될 생명 UI 텍스트
    public Text myScore; // 화면에 표시될 점수 UI 텍스트

    private float timeCnt = 60; // 남은 시간 카운터 (초기값 60초)
    public int scoreCnt; // 현재 점수 변수
    
    public GameObject Dong; // 생성할 단어 오브젝트 프리팹
    public GameObject gameOverPanel; // 게임 오버 패널 오브젝트
    public Button restartBtn; // 재시작 버튼 (현재 코드에선 사용되지 않음)
    public AudioSource audioSource; // 오디오 소스
    public AudioClip bgm; // 배경 음악 클립
    public AudioClip gg; // 게임 오버 사운드 클립
 
    void Awake() // 오브젝트 생성 시 실행 (Start보다 먼저)
    {
        // 이미 인스턴스가 존재하고, 그 인스턴스가 자신이 아닐 경우
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // 현재 오브젝트 파괴 (싱글톤 중복 방지)
            return;
        }
        instance = this; // 현재 오브젝트를 인스턴스로 지정
    }

    // 게임 종료 처리 함수
    void Stop()
    { 
        audioSource.Stop(); // 현재 오디오 정지
        audioSource.clip = gg; // 게임 오버 클립 준비
        audioSource.Play(); // 게임 오버 사운드 재생
        resultString = "Your score is " + scoreCnt; // 결과 문자열 생성
        Time.timeScale = 0; // 게임 시간 정지
        // "ScoreResult" 오브젝트를 찾아 Text 컴포넌트의 텍스트를 결과 문자열로 변경
        GameObject.Find("ScoreResult").GetComponent<Text>().text = resultString; 

        gameOverPanel.SetActive(false); // 게임 오버 패널 비활성화 (버그? 활성화해야 함)
    }

    public void LoadHome() // 홈 화면 로드 함수
    { 
        Time.timeScale = 1; // 게임 시간 정상화
        SceneManager.LoadScene("start"); // "start" 씬 로드
    }

    // 오브젝트 활성화 시 최초 1회 실행
    void Start()
    { 
        Speedy= 0; // 초기 속도 변수 설정
        
        cnt = 0; // 카운트 초기화
        lifeInt = 3; // 생명 3으로 초기화
        scoreCnt = 0; // 점수 0으로 초기화
        instance = this; // 외부에서 instance를 참조하기 위해 (Awake에서 처리되었으므로 중복)
    }


    // 일정한 시간 간격으로 반복 실행 (물리 계산에 적합)
    void FixedUpdate()
    {
        if(timeCnt < 0) Stop(); // 남은 시간이 0보다 작으면 게임 종료
        myScore.text = "Score : " + scoreCnt; // 현재 점수를 UI에 업데이트

        level = (cnt*cnt)/360000;//period // 카운트에 따른 레벨 계산 (난이도 조절)

        // (프레임 카운트 % 150) - 레벨 값이 0이면 (일정 주기에 도달하면)
        if (cnt % 150-level == 0)
        {
            yPos = yPosList[(cnt % 57)%4]; // Y축 위치 목록에서 다음 위치 선택
            // Dong 프리팹을 (2, yPos, 1) 위치에 생성
            GameObject curDong = Instantiate(Dong, new Vector3(2, yPos,1), Quaternion.identity);

            if (Speedy == 1) // Speedy가 1이면 빠르게 설정
            {
                curDong.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, 0); // 왼쪽으로 빠르게 이동
            }
            else // 아니면 기본 속도로 설정
            {
                curDong.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 0); // 왼쪽으로 기본 속도 이동
            }
            
            // 단어 배열에서 무작위 단어를 선택하여 오브젝트 이름으로 설정
            curDong.name = wordArr[Random.Range(0, 40)]; 

            // 오브젝트의 자식 오브젝트에서 TextMesh 컴포넌트를 찾아 텍스트 설정
            TextMesh textContentofDong=curDong.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>();
            textContentofDong.text = curDong.name; // 단어 오브젝트에 무작위 단어 표시
        }
        
        cnt++; // 프레임 카운트 증가
        timeCnt -= Time.deltaTime; // 시간 카운트 감소 (현재 프레임 시간만큼)
        myTime.text = "Time : " + timeCnt.ToString("N2"); // 남은 시간을 소수점 두 자리까지 UI에 표시

        lifeString = ""; // 생명 표시 문자열 초기화
        // 현재 생명 수만큼 ♥ 추가
        for(int i = 0; i < lifeInt; i++)
        {
            lifeString += "♥";
        }
        // 남은 생명 칸만큼 ♡ 추가 (최대 생명이 3이라고 가정)
        for(int i = 0; i < 3 - lifeInt; i++)
        {
            lifeString += "♡";
        }
        myLife.text = lifeString; // 생명 표시 UI 업데이트

        // 목숨이 0이면 1.5초 뒤에 게임 중지 함수 호출
        if(lifeInt==0)
        {
            Invoke("Stop", 1.5f);
        }
    }
}