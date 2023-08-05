
using System.Diagnostics;

public class ChestLockedState : ChestState
{
    public ChestLockedState(ChestView chestView)
    {
        ChestView = chestView;
    }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        ChestView.ChestController.SetChestImage(ChestView.ChestModel.ChestClose);
    }
    public override void Clicked()
    {
        ChestService.Instance.AddToUlockQueue(ChestView);
    }
}
