
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChestScriptableObject", menuName = "ScriptableObject/NewChest")]
public class ChestScriptableObject : ScriptableObject
{
    public Rewards Reward;
    public ChestType Type;
    public int TimeToOpenInMin;
    public Sprite ChestClose;
    public Sprite ChestOpen;

}
[Serializable]
public class Rewards
{
    public int MaxGem;
    public int MinGem;
    public int MaxCoin;
    public int MinCoin;
}
public enum ChestType
{
    None,
    Common,
    Rare,
    Epic,
    Legendary
}


