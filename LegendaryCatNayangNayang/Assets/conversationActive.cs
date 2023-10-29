using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class conversationActive : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    string[] conv =
    {

"다 죽이러 가는 거다냥!",
"전설적인 전설냥이 등장!",
"고양행성 전설냥이 출동!",
"나님 등장~",

    };
    
    
    // Start is called before the first frame update
    void Start()
    {int randomInt = UnityEngine.Random.Range(1, 4); textMeshPro.text = conv[randomInt];
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //여기부터 줄글 출력
        
    }
}
