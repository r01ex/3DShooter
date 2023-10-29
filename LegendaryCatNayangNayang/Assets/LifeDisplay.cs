using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeDisplay : MonoBehaviour
{
    public int life;
    public TextMeshProUGUI textMeshPro;
    // Update is called once per frame
    void Update()
    {
      
        textMeshPro.text = "LIFE\n\t\t" + life;
    }
}
