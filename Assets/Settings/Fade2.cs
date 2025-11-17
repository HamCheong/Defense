using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade2 : MonoBehaviour
{
    public Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CoFadeIn");
    }
    IEnumerator CoFadeIn()
    {
        Color fadeCol = fadeImage.color; // 컬러 따오기
        while (fadeCol.a < 1f) // 완전이 불투명해질때까지
        {
            fadeCol.a += 0.05f; // 조금씩 불투명해짐
            fadeImage.color = fadeCol; //색 덮어씌우기
            yield return new WaitForSeconds(0.05f); // 0.01초간 대기
        }
        SceneManager.LoadScene("Ending"); // 다른 씬으로 이동
    }
}
