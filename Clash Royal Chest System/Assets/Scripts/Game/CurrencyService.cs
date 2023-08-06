
using TMPro;
using UnityEngine;

public class CurrencyService : MonoSingletonGeneric<CurrencyService> 
{
    

    public int initialAmt;

    public int CoinsAvailable { get; private set; }
    public int GemsAvailable { get; private set; }

    private UiService uiService;
        
    private void Start()
    {
        CoinsAvailable = initialAmt;
        GemsAvailable = initialAmt;
        uiService = UiService.Instance;
        uiService.UpdateUiText();
        EventService.Instance.ChestClaimed += AddCurency;
    }

    

    public void UseGem(int gemAmt)
    {
        if (gemAmt > GemsAvailable)
            return;
        GemsAvailable-=gemAmt;
        uiService.UpdateUiText() ;
    }

    public void DeductGems(int AmtToDeduct)
    {
        GemsAvailable -= AmtToDeduct;
        uiService.UpdateUiText() ;
    }
    public void DeductCoins(int AmtToDeduct)
    {
        CoinsAvailable -= AmtToDeduct;
        uiService.UpdateUiText();
    }

    private void AddCurency(int coinsAmt, int gemsAmt)
    {
        CoinsAvailable += coinsAmt;
        GemsAvailable += gemsAmt;
        uiService.UpdateUiText();
    }

}
