
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ChestUnlockingState : ChestState
{
    public float StartTime { get; private set; }

    private int TimeToOpen;

    private CancellationTokenSource cancellationTokenSource;

    private int GemsRequiredPer10Min;
    public ChestUnlockingState(ChestView chestView)
    {
        ChestView = chestView;
        cancellationTokenSource = new CancellationTokenSource();
        GemsRequiredPer10Min = ChestService.Instance.ChestSystem.GemsRequiredPer10Min;
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
        try
        {
            await Task.Delay(5000, cancellationTokenSource.Token);
            TimeToOpen--;
            ShowTime();
            if (TimeToOpen == 0)
            {
                ChestView.ChestController.SetChestState(ChestStates.Unlocked);
                return;
            }
            AfterEveryMin();
        }
        catch (TaskCanceledException)
        {

        }
    }

    public override void Clicked()
    {
        EarlyUnlockPopup earlyUnlockPopup = ChestService.Instance.EarlyUnlockPopup;
        earlyUnlockPopup.ChestView = ChestView;
        earlyUnlockPopup.GemsRequired = CalculateGemsRequired();
        earlyUnlockPopup.gameObject.SetActive(true);
    }

    private int CalculateGemsRequired()
    {
        decimal d = (TimeToOpen / (decimal)10);
        int gems = (int)Math.Ceiling(d) * GemsRequiredPer10Min;
        return gems;
    }

    public override void OnStateExit()
    {
        cancellationTokenSource?.Cancel();
    }
}
