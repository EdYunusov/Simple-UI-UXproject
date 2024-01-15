using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{
    [SerializeField] private TMP_Text ticketValue;
    [SerializeField] private TMP_Text dollarValue;
    [SerializeField] private ItemManager manager;
    [SerializeField] private TakeDailyReward rewardButton;
    [SerializeField] private StoreManager storeManager;


    private void OnEnable()
    {
        TakeDailyReward.OnTicketUpdate += SetText;
        StoreManager.OnDollarsBankUpdate += SetText;
        StoreManager.OnTicketBankUpdate += SetText;
        ItemManager.OnItemBuyed += SetText;
        Levels.OnTicketUpdate += SetText;
    }

    private void OnDisable()
    {
        TakeDailyReward.OnTicketUpdate -= SetText;
        StoreManager.OnDollarsBankUpdate -= SetText;
        StoreManager.OnTicketBankUpdate -= SetText;
        ItemManager.OnItemBuyed -= SetText;
        Levels.OnTicketUpdate -= SetText;
    }

    private void SetText()
    {
        ticketValue.text = manager.TicketBank.ToString();
        dollarValue.text = manager.DollarsBank.ToString();

    }
}
