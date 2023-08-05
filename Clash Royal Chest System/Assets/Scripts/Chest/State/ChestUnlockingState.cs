
using UnityEngine;

public class ChestUnlockingState : ChestState
{
    public ChestUnlockingState(ChestView chestView)
    {
        ChestView = chestView;
    }
    public float StartTime { get; private set; }
    public override void OnStateEnter()
    {
        StartTime = Time.time;
        ChestView.StateInfo.text = "Unlocking";
    }
    public override void Clicked()
    {

    }
}
