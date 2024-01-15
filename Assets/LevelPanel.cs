using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private GameObject closeLevel;

    [SerializeField] private ItemManager itemManager;

    [SerializeField] private int levelRewards;

    private void Start()
    {
        level.SetActive(true);
        //closeLevel.SetActive(false);
        nextLevel.SetActive(false);
    }

    public void LevelComplited()
    {
        //closeLevel.SetActive(true);
        nextLevel.SetActive(true);

        itemManager.TicketBank += levelRewards;
    }
}
