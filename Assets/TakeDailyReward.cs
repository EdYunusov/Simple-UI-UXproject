using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TakeDailyReward : MonoBehaviour
{
    [SerializeField] private int rewardCost;
    [SerializeField] private ItemManager manager;

    [SerializeField] private Slider slider;
    [SerializeField] private float currentValue;
    [SerializeField] private float step;

    public static event Action OnTicketUpdate;

    void Start()
    {
        if (slider == null) return;
        slider = GetComponent<Slider>();
        slider.value = currentValue;
        slider.onValueChanged.AddListener(SliderUpdate);
    }

    public void TakeReward(int value)
    {
        value = rewardCost;
        manager.TicketBank += value;
        OnTicketUpdate?.Invoke();
    }

    //динамическая функция обновления слайдера в дейли наградах - не работает.

    public void SliderUpdate(float sliderValue)
    {
        currentValue += step;
    }
}
