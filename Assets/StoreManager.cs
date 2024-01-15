using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PurchasesType
{
    DollarsPurchases,
    TicketPurchases
}

public class StoreManager : MonoBehaviour
{
    [SerializeField] private float dollarItemPrice;
    [SerializeField] private int ticketItemPrice;
    [SerializeField] private int itemCount;
    [SerializeField] private TMP_Text priceValue;
    [SerializeField] private ItemManager manager;
    [SerializeField] private GameObject buyingComferd;
    [SerializeField] private GameObject level;

    public static event Action OnDollarsBankUpdate;
    public static event Action OnTicketBankUpdate;

    [SerializeField] public PurchasesType type;

    private void Awake() 
    {
        if (type == PurchasesType.DollarsPurchases)
        {
            priceValue.text = dollarItemPrice.ToString();
        }

        if (type == PurchasesType.TicketPurchases)
        {
            priceValue.text = ticketItemPrice.ToString();
        }

        if (level == null) return;
        if (buyingComferd == null) return;

        buyingComferd.SetActive(false);
        level.SetActive(false);



    }

    public void BuyTicket()
    {
        if (type == PurchasesType.DollarsPurchases)
        {
            manager.DollarsBank -= (int)dollarItemPrice;
            manager.BuyedTicket(itemCount);
            OnDollarsBankUpdate?.Invoke();
        }
    }

    public void BuyItemForTicket()
    {
        if (type == PurchasesType.TicketPurchases)
        {
            manager.TicketBank -= ticketItemPrice;
            manager.BuyedItem(itemCount);
            OnTicketBankUpdate?.Invoke();
        }
    }

    public void BuyComferm()
    {
        buyingComferd.SetActive(true);
    }

    public void BuyLevel()
    {
        level.SetActive(true);
    }
}
