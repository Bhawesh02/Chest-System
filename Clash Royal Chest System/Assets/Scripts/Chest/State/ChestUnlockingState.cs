
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
        await Task.Delay(60000, cancellationTokenSource.Token);
        TimeToOpen--;
        ShowTime();
        if (TimeToOpen == 0)
        {
            ChestView.ChestController.SetChestState(ChestStates.Unlocked);
            return;
        }
        AfterEveryMin();
    }

    public override void Clicked()
    {
        ChestService.Instance.EarlyUnlockPopup.ChestView = ChestView;
        ChestService.Instance.EarlyUnlockPopup.gameObject.SetActive(true);
    }
    public override void OnStateExit()
    {
        cancellationTokenSource.Cancel();
    }
}
