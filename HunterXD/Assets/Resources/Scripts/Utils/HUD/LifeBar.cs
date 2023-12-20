using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void ChangeCurrentLife(float current)
    {
        _slider.value = current;
    }

    public void InitLifeBar()
    {
        _slider.maxValue = 5;
        ChangeCurrentLife(5f);
    }
}
