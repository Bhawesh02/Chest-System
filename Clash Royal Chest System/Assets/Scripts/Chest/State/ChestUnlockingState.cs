
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ChestUnlockingState : ChestState
{
    public float StartTime { get; private set; }

    private int TimeToOpen;

    private CancellationTokenSource cancellationTokenSource;

    public ChestUnlockingState(ChestView chestView)
    {
        ChestView = chestView;
        cancellationTokenSource = new CancellationTokenSource();

    }



    public override void OnStateEnter()
    {
        StartTime = Time.time;
        TimeToOpen = ChestView.ChestModel.TimeToOpenInMin;
        ShowTime();
        AfterEveryMin();
    }

    private void ShowTime()
    {
        ChestView.StateInfo.text = "Unlocking\n";
        int hrTime = TimeToOpen / 60;
        int minTime = TimeToOpen % 60;
        if (hrTime > 0)
            ChestView.StateInfo.text += hrTime + " Hr\n";
        if (minTime > 0)
            ChestView.StateInfo.text += minTime + " Min\n";

    }

    

    private async void AfterEveryMin()
    {
        await Task.Delay(1000, cancellationTokenSource.Token);
        TimeToOpen--;
        ShowTime();
        if (TimeToOpen == 0)
        {
            ChestView.ChestController.SetChestState(ChestStates.Unlocked);
            return;
        }

    }

    public override void Clicked()
    {

    }
    public override void OnStateExit()
    {
        cancellationTokenSource.Cancel();
    }
}
