

using System;

public class EventService : SingletonGeneric<EventService>
{
    public event Action ChestUnlocked;

    public void InvokeChestUnlocked()
    {
        ChestUnlocked?.Invoke();
    }
}
