

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChestService : MonoSingletonGeneric<ChestService>
{
    [SerializeField]
    private LayoutGroup chestGrid;
    public ChestSystemScriptableObject ChestSystem;
    [SerializeField]
    private ChestView chestCardPrefab;

    public List<ChestView> UnlockQueue = new();

    public List<ChestView> ChestInScene = new();

    private void Start()
    {
        InitialSpawnChestCards();
        EventService.Instance.ChestUnlocked += DequeChest;
    }

    private void DequeChest()
    {
        UnlockQueue.RemoveAt(0);
        if (UnlockQueue.Count > 0)
        {
            UnlockQueue[0].ChestController.SetChestState(ChestStates.Unlocking);
        }
    }

    private void InitialSpawnChestCards()
    {
        for (int i = 0; i < ChestSystem.NumOfChestInScene; i++)
        {
            ChestInScene.Add(Instantiate<ChestView>(chestCardPrefab, chestGrid.gameObject.transform));
        }
    }

    public void AddToUlockQueue(ChestView chestView)
    {
        if (UnlockQueue.Find(x => x.Equals(chestView)) != null)
        {
            UiService.Instance.EnableErrorPopup("Already In queue");
            return;
        }
        if (UnlockQueue.Count == ChestSystem.NumOfChestInUnlockQueue)
        {
            UiService.Instance.EnableErrorPopup("Wait for chests to open");
            return;
        }
        chestView.SetBgColor(Color.green);
        UnlockQueue.Add(chestView);
        if (UnlockQueue.Count == 1)
        {
            chestView.ChestController.SetChestState(ChestStates.Unlocking);
        }
    }

    public void SpawnChest()
    {
        if (ChestInScene.Count == ChestSystem.NumOfChestInScene)
        {
            UiService.Instance.EnableErrorPopup("No more Chest can be spawned");
            return;
        }
        ChestInScene.Add(Instantiate<ChestView>(chestCardPrefab, chestGrid.gameObject.transform));
    }
}
