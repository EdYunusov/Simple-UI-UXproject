using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class UIButtonSelectable : UIButton
{
    [SerializeField] private Image selectImage;
    [SerializeField] private AudioSource audio;

    public UnityEvent OnSelect;
    public UnityEvent OnUnselect;

    private void Start()
    {
        if (selectImage == null) return;
        selectImage.enabled = false;
    }

    public override void SetFocuse()
    {
        Debug.Log("On focuse");
        base.SetFocuse();

        audio.Play();
        selectImage.enabled = true;

        OnSelect?.Invoke();
    }

    public override void SetUnfocuse()
    {
        base.SetUnfocuse();

        selectImage.enabled = false;
        OnUnselect?.Invoke();
    }
    public static void ExitGame()
    {
        Application.Quit();
    }
}
