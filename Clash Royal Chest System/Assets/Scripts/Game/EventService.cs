

using System;

public class EventService : SingletonGeneric<EventService>
{
    public event Action ChestUnlocked;
    public event Action<int,int> ChestClaimed;
    public void InvokeChestUnlocked()
    {
        ChestUnlocked?.Invoke();
    }

    internal void InvokeChestClamed(int coinsAmt, int gemsAmt)
    {
        ChestClaimed?.Invoke(coinsAmt, gemsAmt);
    }
}
