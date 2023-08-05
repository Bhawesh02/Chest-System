
public abstract class ChestState
{
    public ChestView ChestView;
    public virtual void OnStateEnter()
    { }

    public virtual void Tick() { }
    public abstract void Clicked();

    public virtual void OnStateExit() { }
}

public enum ChestStates
{
    Locked,
    Unlocking,
    Unlocked
}