using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class catDefault : MonoBehaviour
{public RawImage catcat;
    public Texture catcat2;
    private int flag = 0;
    private int startflag = 0;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    IEnumerator changeImg()
    {
        
            
            yield return new WaitForSeconds(2.0f);
        catcat.texture = catcat2;
        startflag = 1;


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
        if (startflag == 1)
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                audioSource.loop = false;
                audioSource.Stop();
                audioSource2.loop = false;
                audioSource2.Play();
}
        }
   
    }
}
