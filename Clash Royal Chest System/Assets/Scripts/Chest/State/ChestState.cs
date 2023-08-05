
public abstract class ChestState
{
    public ChestView ChestView;
    public virtual void OnStateEnter()
    {
        return;
    }

    public abstract void Clicked();

    public virtual void OnStateExit() { return;}
}

public enum ChestStates
{
    Locked,
    Unlocking,
    Unlocked
}