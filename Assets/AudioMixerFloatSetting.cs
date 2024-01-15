using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu]
public class AudioMixerFloatSetting : Settings
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string namePrametr;

    [SerializeField] private float minRealValue;
    [SerializeField] private float maxRealValue;

    [SerializeField] private float virtualStep;
    [SerializeField] private float minVirtualValue;
    [SerializeField] private float maxVirtualValue;

    private float currentValue = 0;

    public override bool isMinValue { get => currentValue == minRealValue; }
    public override bool isMaxValue { get => currentValue == maxRealValue; }

    public override void SetNextValue()
    {
        AddValue(Mathf.Abs(maxRealValue - minRealValue) / virtualStep);
    }

    public override void SetPreviousValue()
    {
        AddValue(- Mathf.Abs(maxRealValue - minRealValue) / virtualStep);
    }

    private void AddValue(float value)
    {
        currentValue += value;
        currentValue = Mathf.Clamp(currentValue, minRealValue, maxRealValue);
    }

    public override string GetStringValue()
    {
        return Mathf.Lerp(minVirtualValue, maxVirtualValue, (currentValue - minRealValue) / (maxRealValue - minRealValue)).ToString();
    }

    public override object GetValue()
    {
        return currentValue;
    }

    public override void Apply()
    {
        audioMixer.SetFloat(namePrametr, currentValue);
        Save();
    }

    public override void Load()
    {
        currentValue = PlayerPrefs.GetFloat(settingsTitle, 0);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(settingsTitle, currentValue);
    }


}
