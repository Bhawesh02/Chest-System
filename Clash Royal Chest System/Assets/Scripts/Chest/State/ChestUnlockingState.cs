
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
    }
    public override void Clicked()
    {

    }
}
