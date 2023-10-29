using System.Collections;
using TMPro;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText; // TextMeshPro Text 컴포넌트를 가리키는 변수
    public float blinkInterval = 0.5f; // 깜빡이는 간격 (초 단위)
    private bool flag = false;
    private int stack = 0;
    public GameObject panel;
    public GameObject Tex;

    void Start()
    {
        StartCoroutine(BlinkTexts());
    }
    
    IEnumerator BlinkTexts()
    {
        while (true) // 무한 루프로 계속 실행
        {
            if (flag) stack++;
            if (stack > 4)
            {
                textMeshProText.enabled = false;
                panel.SetActive(true);
               
             
                break;
            }
            textMeshProText.enabled = !textMeshProText.enabled; // TextMeshPro Text의 활성화 여부를 번갈아가며 변경
            yield return new WaitForSeconds(blinkInterval); // 주어진 간격만큼 대기
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            blinkInterval = 0.1f;
            flag = true ;

        }
    }
}
