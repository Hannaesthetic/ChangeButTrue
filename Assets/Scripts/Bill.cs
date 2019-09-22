using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bill : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void SetCost(float amount)
    {
        text.SetText($"{amount.ToString("n2")}€");
    }
}
