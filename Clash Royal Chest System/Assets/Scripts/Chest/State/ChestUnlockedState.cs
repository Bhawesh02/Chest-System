
public class ChestUnlockedState : ChestState
{
    public ChestUnlockedState(ChestView chestView)
    {
        ChestView = chestView;
    }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        ChestView.ChestController.SetChestImage(ChestView.ChestModel.ChestOpen);
        EventService.Instance.InvokeChestUnlocked();
    }
    public override void Clicked()
    {

    }
}
