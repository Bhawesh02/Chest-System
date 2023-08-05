
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestService : MonoSingletonGeneric<ChestService>
{
    [SerializeField]
    private LayoutGroup chestGrid;
    public ChestSystemScriptableObject ChestSystem;
    [SerializeField]
    private ChestView chestCard;

    public Queue<ChestView> UnlockQueue;

    private void Start()
    {
        SpawnChestCards();
    }


    private void SpawnChestCards()
    {
        for (int i = 0; i < ChestSystem.NumOfChestInScene; i++)
        {
            Instantiate(chestCard.gameObject, chestGrid.gameObject.transform);
        }
    }
}
