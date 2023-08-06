
using TMPro;
using UnityEngine;

public class CurrencyService : MonoSingletonGeneric<CurrencyService> 
{
    [SerializeField]
    private TextMeshProUGUI gemsUi;
    [SerializeField]
    private TextMeshProUGUI coinsUi;
    [HideInInspector]
    public int CoinsAvailable { get; private set; }
    [HideInInspector]
    public int GemsAvailable { get; private set; }

    private void Awake()
    {
        CoinsAvailable = 1000;
        GemsAvailable = 1000;
    }
    private void Start()
    {
        updateUiText();
        EventService.Instance.ChestClaimed += addCurency;
    }

    private void updateUiText()
    {
        gemsUi.text = GemsAvailable.ToString(); ;
        coinsUi.text = CoinsAvailable.ToString();
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
