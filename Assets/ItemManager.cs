using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private int ticketBank;

    public int TicketBank
    {
        get { return ticketBank; }
        set { ticketBank = value; }
    }

    [SerializeField] private int dollarsBank;

    public int DollarsBank
    {
        get { return dollarsBank; }
        set { dollarsBank = value; }
    }

    public static event Action OnItemBuyed;

    public void BuyedTicket(int value)
    {
        ticketBank += value;
        OnItemBuyed?.Invoke();
    }

    public void BuyedItem(int value)
    {
        ticketBank -= value;
        OnItemBuyed?.Invoke();
    }
}
