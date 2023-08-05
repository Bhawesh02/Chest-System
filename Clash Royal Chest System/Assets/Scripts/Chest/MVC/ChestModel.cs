
using UnityEngine;

public class ChestModel
{
    public Rewards Reward { get; private set; }
    public float TimeToOpenInMin { get; private set; }
    public Sprite ChestClose { get; private set; }
    public Sprite ChestOpen { get; private set; }

    public ChestState State;

    public ChestModel(ChestScriptableObject chestScriptableObject)
    {
        Reward = chestScriptableObject.Reward;
        TimeToOpenInMin = chestScriptableObject.TimeToOpenInMin;
        ChestClose = chestScriptableObject.ChestClose;
        ChestOpen = chestScriptableObject.ChestOpen;
        State = ChestState.Locked;
    }
}
