using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderRewardPanrel : MonoBehaviour
{
    private Slider slider;
    private float currentValue;
    [SerializeField] private float step;
    [SerializeField] private TakeDailyReward dailyReward;

    private void Start()
    {
        slider = GetComponent<Slider>();
        currentValue = slider.value;
        slider.value = currentValue / step;
        slider.onValueChanged.AddListener(OnChangeValueReward);
    }

    public void OnChangeValueReward(float sliderValue)
    {
        currentValue += step;

        currentValue = slider.value;
    }
}
