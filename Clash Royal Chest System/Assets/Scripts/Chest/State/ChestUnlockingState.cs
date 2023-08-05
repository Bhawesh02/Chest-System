
using System;
using UnityEngine;

public class ChestUnlockingState : ChestState
{
    public ChestUnlockingState(ChestView chestView)
    {
        ChestView = chestView;
    }
    public float StartTime { get; private set; }

    private int TimeToOpen;
    


    public override void OnStateEnter()
    {
        StartTime = Time.time;
        TimeToOpen = ChestView.ChestModel.TimeToOpenInMin;
        ChestView.StateInfo.text = "Unlocking\n";
        ShowTime();
    }

    private void ShowTime()
    {
        int hrTime = TimeToOpen / 60;
        int minTime = TimeToOpen % 60;
        if (hrTime > 0)
            ChestView.StateInfo.text += hrTime + " Hr\n";
        if (minTime > 0)
            ChestView.StateInfo.text += minTime + " Min\n";

    }

    public override void Tick()
    {
        
    }

    public override void Clicked()
    {

    }
}
