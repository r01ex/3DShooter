using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class conversationActive : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    string[] conv =
    {

"�� ���̷� ���� �Ŵٳ�!",
"�������� �������� ����!",
"����༺ �������� �⵿!",
"���� ����~",

    };
    
    
    // Start is called before the first frame update
    void Start()
    {int randomInt = UnityEngine.Random.Range(1, 4); textMeshPro.text = conv[randomInt];
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //������� �ٱ� ���
        
    }
}
