using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legendary_Cats_Story : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource ������Ʈ�� ����Ű�� ����

    void Start()
    {
        audioSource.loop = true;
        // AudioSource ������Ʈ�� ���� ������ ���
        audioSource.Play();
       
    }
}
