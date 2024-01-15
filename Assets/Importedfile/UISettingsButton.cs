using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsButton : UIButtonSelectable, IScriptableObjectProperty
{
    [SerializeField] private Settings settings;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private Image previousImage;
    [SerializeField] private Image nextImage;
    [SerializeField] private Slider slider;

    public Settings Settings => settings;


    private void Awake()
    {
        ApplayProperty(settings);

        if (titleText == null) return;
        if (nextImage == null) return;
        if (previousImage == null) return;
    }

    public void SetNextValueSettings()
    {
        settings?.SetNextValue();
        settings.Apply();
        UpdateInfo();
    }

    public void SetPreviousValueSettings()
    {
        settings?.SetPreviousValue();
        settings.Apply();
        UpdateInfo();
    }

    public void OnVolumeChange()
    { 
        settings?.OnVolumeChange();
        settings.Apply();
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        //titleText.text = settings.Title;
        valueText.text = settings.GetStringValue();

        //previousImage.enabled = !settings.isMinValue;
        //nextImage.enabled = !settings.isMaxValue;
    }

    public void ApplayProperty(ScriptableObject property)
    {
        if (property == null) return;

        if (property is Settings == false) return;

        settings = property as Settings;

        UpdateInfo();
    }

}
