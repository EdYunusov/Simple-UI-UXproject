using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField] private ItemManager itemManager;

    [SerializeField] private GameObject previuseLevel;
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private GameObject nextLockObject;
    [SerializeField] private GameObject levelNumber;

    [SerializeField] private int levelReward = 10;

    public static event Action OnTicketUpdate;

    private void Awake()
    {
        if (levelNumber == null) return;
        if (previuseLevel == null) return;
        if (nextLevel == null) return;
        if (nextLockObject == null) return;
        nextLockObject.SetActive(true);

        levelNumber.SetActive(false);
    }

    public void NextLevelActive()
    {
        if (nextLevel == null) return;

        nextLockObject.SetActive(false);

        itemManager.TicketBank += levelReward;
        UIButton button = GetComponent<UIButton>();
        button.StopInteractable();

        levelNumber.SetActive(true);

        OnTicketUpdate?.Invoke();
    }
}
