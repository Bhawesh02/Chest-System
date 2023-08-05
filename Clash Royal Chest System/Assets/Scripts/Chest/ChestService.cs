
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestService : MonoSingletonGeneric<ChestService>
{
    [SerializeField]
    private LayoutGroup chestGrid;
    public ChestSystemScriptableObject ChestSystem;
    [SerializeField]
    private ChestView chestCardPrefab;

    public Queue<ChestView> UnlockQueue = new();

    public EarlyUnlockPopup EarlyUnlockPopup;

    private void Start()
    {
        SpawnChestCards();
        EventService.Instance.ChestUnlocked += DequeChest;
    }

    private void DequeChest()
    {
        UnlockQueue.Dequeue();
    }

    private void SpawnChestCards()
    {
        for (int i = 0; i < ChestSystem.NumOfChestInScene; i++)
        {
            Instantiate(chestCardPrefab.gameObject, chestGrid.gameObject.transform);
        }
    }

    public void AddToUlockQueue(ChestView chestView)
    {
        if(UnlockQueue.Count == ChestSystem.NumOfChestInUnlockQueue)
        {
            Debug.Log("Wait for chests to open");
            return;
        }
        UnlockQueue.Enqueue(chestView);
        if(UnlockQueue.Count == 1)
        {
            chestView.ChestController.SetChestState(ChestStates.Unlocking);
        }
    }
}
