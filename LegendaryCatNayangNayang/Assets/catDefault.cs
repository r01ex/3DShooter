using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class catDefault : MonoBehaviour
{public RawImage catcat;
    public Texture catcat2;
    private int flag = 0;
    IEnumerator changeImg()
    {
        
            
            yield return new WaitForSeconds(2.0f);
        catcat.texture = catcat2;

    }
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (flag == 0&&gameObject.activeInHierarchy==true)
        {
     StartCoroutine("changeImg");
            flag++;
        }
   
    }
}
