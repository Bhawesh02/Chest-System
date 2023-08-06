using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UiService : MonoSingletonGeneric<UiService>
{
    [SerializeField]
    private TextMeshProUGUI gemsUi;
    [SerializeField]
    private TextMeshProUGUI coinsUi;

    [SerializeField]
    private GameObject earlyUnlockPopup;
    [SerializeField]
    private TextMeshProUGUI earlyUnlockPopupRequired;
    [SerializeField]
    private Button earlyUnlockPopupCancelButton;
    [SerializeField]
    private Button earlyUnlockPopupConfirmButton;
    [SerializeField]
    private GameObject notEnoughtGemPopup;
    [SerializeField]
    private Button notEnoughGemPopupOk;
    [SerializeField]
    private GameObject rewardGotPopup;
    [SerializeField]
    private Button rewardGotPopupOk;
    [SerializeField]
    private TextMeshProUGUI gemsRewardGot;
    [SerializeField]
    private TextMeshProUGUI coinRewardGot;


    private string initialText;
    public ChestView ChestView;
    public int GemsRequired;

  

    private void Start()
    {
        initialText = earlyUnlockPopupRequired.text;
        earlyUnlockPopupCancelButton.onClick.AddListener(DisableEarlyPopup);
        earlyUnlockPopupConfirmButton.onClick.AddListener(Confirm);
        notEnoughGemPopupOk.onClick.AddListener(OkNotEnoughGem);
        rewardGotPopupOk.onClick.AddListener(OkRewardClaimed);
        EventService.Instance.ChestClaimed += EnableRewardsGotPopup;
    }
    public void UpdateUiText()
    {
        gemsUi.text = CurrencyService.Instance.GemsAvailable.ToString(); ;
        coinsUi.text = CurrencyService.Instance.CoinsAvailable.ToString();
    }
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

    private void Confirm()
    {
        if (CurrencyService.Instance.GemsAvailable < GemsRequired)
        {
            notEnoughtGemPopup.SetActive(true);
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
    private void OkNotEnoughGem()
    {
        notEnoughtGemPopup.SetActive(false);
    }

    public void EnableEarlyPopup()
    {
        earlyUnlockPopup.SetActive(true);
        earlyUnlockPopupRequired.text += "\n" + GemsRequired;
    }
}
