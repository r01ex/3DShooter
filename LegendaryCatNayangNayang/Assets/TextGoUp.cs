using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class TextGoUp : MonoBehaviour
{
    public RectTransform rect;
    public float speed;
    private Vector3 vect = new Vector3(100, -400, 0);
    private void Update()

    {
        vect+= Vector3.up*speed;
        rect.anchoredPosition3D = vect;

        
    }
}
