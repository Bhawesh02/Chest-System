

using System;
using UnityEngine;

public class ChestController
{
    private ChestModel chestModel;
    private ChestView chestView;
    
    public ChestController(ChestModel chestModel, ChestView chestView)
    {
        this.chestModel = chestModel;
        this.chestView = chestView;
    }
    public void SetChestImage(Sprite chestSprite)
    {
        chestView.ChestImage.sprite = chestSprite;
    }

    public void CardClicked()
    {
        chestModel.CurrentState.Clicked();
    }

    public void SetChestState(ChestStates state)
    {
        chestModel.State = state;
        if(chestModel.CurrentState == null)
        {

        }

        switch (state)
        {
            case ChestStates.Locked:
                chestModel.CurrentState = chestModel.ChestLockedState;
                break;
            case ChestStates.Unlocking:
                chestModel.CurrentState = chestModel.ChestUnlockingState;
                break;
            case ChestStates.Unlocked:
                chestModel.CurrentState = chestModel.ChestUnlockedState;
                break;
        }
        chestModel.CurrentState.OnStateEnter();
    }

    
}
