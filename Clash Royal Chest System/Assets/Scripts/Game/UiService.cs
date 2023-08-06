using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiService : MonoSingletonGeneric<UiService>
{
    [SerializeField]
    private Button spawnChestButton;
    
    
    [Header("Currency UI")]
    [SerializeField]
    private TextMeshProUGUI gemsUi;
    [SerializeField]
    private TextMeshProUGUI coinsUi;

    [Header("Early Unlock Popup")]
    [SerializeField]
    private GameObject earlyUnlockPopup;
    [SerializeField]
    private TextMeshProUGUI earlyUnlockPopupRequired;
    [SerializeField]
    private Button earlyUnlockPopupCancelButton;
    [SerializeField]
    private Button earlyUnlockPopupConfirmButton;
    
    [Header("Error Popup")]
    [SerializeField]
    private GameObject errorPopup;
    [SerializeField]
    private TextMeshProUGUI errorPopupHeading;
    [SerializeField]
    private Button errorPopupOk;

    [Header("Reward Got Popup")]
    [SerializeField]
    private GameObject rewardGotPopup;
    [SerializeField]
    private Button rewardGotPopupOk;
    [SerializeField]
    private TextMeshProUGUI gemsRewardGot;
    [SerializeField]
    private TextMeshProUGUI coinRewardGot;


    private string initialText;
    [HideInInspector]
    public ChestView ChestView;
    [HideInInspector]
    public int GemsRequired;

  

    private void Start()
    {
        initialText = earlyUnlockPopupRequired.text;
        earlyUnlockPopupCancelButton.onClick.AddListener(DisableEarlyPopup);
        earlyUnlockPopupConfirmButton.onClick.AddListener(EarlyPopUpConfirm);
        errorPopupOk.onClick.AddListener(ErrorPopupOkClick);
        rewardGotPopupOk.onClick.AddListener(OkRewardClaimed);
        spawnChestButton.onClick.AddListener(ChestService.Instance.SpawnChest);
        EventService.Instance.ChestClaimed += EnableRewardsGotPopup;
    }
    public void UpdateUiText()
    {
        gemsUi.text = CurrencyService.Instance.GemsAvailable.ToString(); ;
        coinsUi.text = CurrencyService.Instance.CoinsAvailable.ToString();
    }
    #region EarlyPopup
    public void EnableEarlyPopup()
    {
        earlyUnlockPopup.SetActive(true);
        earlyUnlockPopupRequired.text += "\n" + GemsRequired;
    }
    private void EarlyPopUpConfirm()
    {
        if (CurrencyService.Instance.GemsAvailable < GemsRequired)
        {
            EnableErrorPopup("Not Enough Gem");
        }
        else
        {
            CurrencyService.Instance.UseGem(GemsRequired);
            ChestView.ChestController.SetChestState(ChestStates.Unlocked);
        }
        DisableEarlyPopup();
    }


    private void DisableEarlyPopup()
    {
        earlyUnlockPopupRequired.text = initialText;
        earlyUnlockPopup.SetActive(false);
    }
    #endregion

    #region RewardGot
    private void EnableRewardsGotPopup(int coinsAmt, int gemsAmt)
    {
        rewardGotPopup.SetActive(true);
        gemsRewardGot.text = gemsAmt.ToString();
        coinRewardGot.text = coinsAmt.ToString();
    }
    private void OkRewardClaimed()
    {
        rewardGotPopup.SetActive(false);
    }
    #endregion

    #region ErrorPopup
    public void EnableErrorPopup(string message)
    {
        errorPopup.SetActive(true);
        errorPopupHeading.text = message;
    }
    private void ErrorPopupOkClick()
    {
        errorPopup.SetActive(false);
    }
    #endregion

}
