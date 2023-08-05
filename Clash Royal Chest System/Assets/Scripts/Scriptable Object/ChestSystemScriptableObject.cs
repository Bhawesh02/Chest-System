
using UnityEngine;

[CreateAssetMenu(fileName = "NewChestSystemScriptableObject",menuName ="ScriptableObject/NewChestSystem")]
public class ChestSystemScriptableObject : ScriptableObject
{
    public ChestScriptableObject[] chestScriptableObjects;
    public int NumOfChestInScene;
    public int NumOfChestInUnlockQueue;
}
