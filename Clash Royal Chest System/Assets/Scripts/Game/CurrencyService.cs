
using TMPro;
using UnityEngine;

public class CurrencyService : MonoSingletonGeneric<CurrencyService> 
{
    [SerializeField]
    private TextMeshProUGUI gemsUi;
    [SerializeField]
    private TextMeshProUGUI coinsUi;

    public int initialAmt;

    public int CoinsAvailable { get; private set; }
    public int GemsAvailable { get; private set; }

        
    private void Start()
    {
        CoinsAvailable = initialAmt;
        GemsAvailable = initialAmt;
        updateUiText();
        EventService.Instance.ChestClaimed += addCurency;
    }

    private void updateUiText()
    {
        gemsUi.text = GemsAvailable.ToString(); ;
        coinsUi.text = CoinsAvailable.ToString();
    }

    public void UseGem(int gemAmt)
    {
        if (gemAmt > GemsAvailable)
            return;
        GemsAvailable-=gemAmt;
        updateUiText() ;
    }

    public void DeductGems(int AmtToDeduct)
    {
        GemsAvailable -= AmtToDeduct; 
        updateUiText() ;
    }
    public void DeductCoins(int AmtToDeduct)
    {
        CoinsAvailable -= AmtToDeduct;
        updateUiText();
    }

    private void addCurency(int coinsAmt, int gemsAmt)
    {
        CoinsAvailable += coinsAmt;
        GemsAvailable += gemsAmt;
        updateUiText();
    }

}
