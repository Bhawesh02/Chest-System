
using System;

public class ChestUnlockedState : ChestState
{
    private int maxGems;
    private int minGems;
    private int maxCoins;
    private int minCoins;
    private Random random;
    public ChestUnlockedState(ChestView chestView)
    {
        ChestView = chestView;
    }
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        ChestView.ChestController.SetChestImage(ChestView.ChestModel.ChestOpen);
        ChestView.StateInfo.text = "Unlocked";
        EventService.Instance.InvokeChestUnlocked();
        maxGems = ChestView.ChestModel.Reward.MaxGem;
        minGems = ChestView.ChestModel.Reward.MinGem;
        maxCoins = ChestView.ChestModel.Reward.MaxCoin;
        minCoins = ChestView.ChestModel.Reward.MinCoin;
        random = new Random();
    }
    public override void Clicked()
    {
        int gemsEarned = random.Next(minGems, maxGems);
        int coinsEarned = random.Next(minCoins, maxCoins);
        EventService.Instance.InvokeChestClamed(coinsEarned, gemsEarned);
        ChestView.Destroy(ChestView.gameObject);
    }
}
