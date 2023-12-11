using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeAttackBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void UpdateChargeAttack(float current)
    {
        _slider.value = current;
    }

    public void InitAttackBar()
    {
        _slider.maxValue = 2;
        UpdateChargeAttack(0f);
    }
}
