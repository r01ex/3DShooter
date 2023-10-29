using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legendary_Cats_Story : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource 컴포넌트를 가리키는 변수

    void Start()
    {
        audioSource.loop = true;
        // AudioSource 컴포넌트로 음악 파일을 재생
        audioSource.Play();
       
    }
}
