

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
}
