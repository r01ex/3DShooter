using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
   public TextMeshProUGUI textMeshPro;

    private static int CountDigits(int number)
    {
        // ���ڸ� ���ڿ��� ��ȯ�Ͽ� ���̸� ��ȯ�մϴ�.
        string numberAsString = number.ToString();
        return numberAsString.Length;
    }
    // Update is called once per frame
    void Update()
    {
        string zeroAttach = "";
        int digit = 6-CountDigits(score);
        for (int i = 0; i < digit; i++) zeroAttach += "0";
        textMeshPro.text = "SCORE\n" +zeroAttach+ score;
    }
}
