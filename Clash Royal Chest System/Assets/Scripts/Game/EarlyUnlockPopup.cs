using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class EarlyUnlockPopup : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI required;
    [SerializeField]
    private Button cancelButton;
    [SerializeField]
    private Button confirmButton;
    [SerializeField]
    private GameObject notEnoughtGemPopup;
    [SerializeField]
    private Button notEnoughGemPopupOk;
    private string initialText;
    public ChestView ChestView;
    public int GemsRequired;

    private void Awake()
    {
        initialText = required.text;
    }

    private void Start()
    {
        cancelButton.onClick.AddListener(Cancel);
        confirmButton.onClick.AddListener(Confirm);
        notEnoughGemPopupOk.onClick.AddListener(OkNotEnoughGem);
    }

    

    private void OnEnable()
    {
        required.text += "\n" + GemsRequired;
    }
    private void Confirm()
    {
        if (CurrencyService.Instance.GemsAvailable < GemsRequired)
        {
            CurrencyService.Instance.UseGem(GemsRequired);
            notEnoughtGemPopup.SetActive(true);
        }
        else
        {
            ChestView.ChestController.SetChestState(ChestStates.Unlocked);
        }
        SetOff();
    }

    private void Cancel()
    {
        SetOff();
    }
    
    private void SetOff()
    {
        required.text = initialText;
        gameObject.SetActive(false);
    }
    private void OkNotEnoughGem()
    {
        notEnoughtGemPopup.SetActive(false);
    }
}
