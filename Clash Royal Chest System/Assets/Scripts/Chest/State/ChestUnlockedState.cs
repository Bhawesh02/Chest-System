
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
    }
    public override void Clicked()
    {

    }
}
