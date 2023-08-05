
using UnityEngine;
using UnityEngine.UI;

public class ChestService : MonoSingletonGeneric<ChestService>
{
    [SerializeField]
    private LayoutGroup chestGrid;
    [SerializeField]
    private ChestSystemScriptableObject chestSystem;
    [SerializeField]
    private GameObject chestCard;


    private void Start()
    {
        SpawnChestCards();
    }

    private void SpawnChestCards()
    {
        for (int i = 0; i < chestSystem.NumOfChestInScene; i++)
        {
            Instantiate(chestCard, chestGrid.gameObject.transform);
        }
    }
}
