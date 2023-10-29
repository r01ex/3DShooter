using System.Collections;
using TMPro;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText; // TextMeshPro Text ������Ʈ�� ����Ű�� ����
    public float blinkInterval = 0.5f; // �����̴� ���� (�� ����)
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
        while (true) // ���� ������ ��� ����
        {
            if (flag) stack++;
            if (stack > 4)
            {
                textMeshProText.enabled = false;
                panel.SetActive(true);
               
             
                break;
            }
            textMeshProText.enabled = !textMeshProText.enabled; // TextMeshPro Text�� Ȱ��ȭ ���θ� �����ư��� ����
            yield return new WaitForSeconds(blinkInterval); // �־��� ���ݸ�ŭ ���
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
