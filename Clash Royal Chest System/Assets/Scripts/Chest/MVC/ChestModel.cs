
using UnityEngine;

public class ChestModel
{
    public Rewards Reward { get; private set; }
    public int TimeToOpenInMin { get; private set; }
    public Sprite ChestClose { get; private set; }
    public Sprite ChestOpen { get; private set; }

    public ChestView ChestView { get; private set; }

    public ChestStates State;

    public ChestLockedState ChestLockedState { get; private set; }
    public ChestUnlockingState ChestUnlockingState { get; private set; }
    public ChestUnlockedState  ChestUnlockedState { get; private set; }


    public ChestState CurrentState;

    public ChestModel(ChestScriptableObject chestScriptableObject, ChestView chestView)
    {
        Reward = chestScriptableObject.Reward;
        TimeToOpenInMin = chestScriptableObject.TimeToOpenInMin;
        ChestClose = chestScriptableObject.ChestClose;
        ChestOpen = chestScriptableObject.ChestOpen;
        ChestView = chestView;
        ChestLockedState = new ChestLockedState(ChestView);
        ChestUnlockingState = new ChestUnlockingState(ChestView);
        ChestUnlockedState = new ChestUnlockedState(ChestView);
        CurrentState = null;
    }
}
