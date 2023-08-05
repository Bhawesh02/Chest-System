
public class ChestUnlockedState : ChestState
{
    public ChestUnlockedState(ChestView chestView)
    {
        ChestView = chestView;
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        ChestView.ChestController.SetChestImage(ChestView.ChestModel.ChestOpen);
    }
    public override void Clicked()
    {

    }
}
