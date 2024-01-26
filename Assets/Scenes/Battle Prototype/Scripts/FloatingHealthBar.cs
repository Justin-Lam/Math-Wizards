using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void UpdateHealthBar(float currentHP, float maxHP)
    {
        slider.value = currentHP / maxHP;
    }
}
