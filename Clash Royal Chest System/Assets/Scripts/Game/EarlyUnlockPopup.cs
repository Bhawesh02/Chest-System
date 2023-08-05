using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EarlyUnlockPopup : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI required;
    [SerializeField]
    private Button cancelButton;
    [SerializeField]
    private Button confirmButton;
    public ChestView ChestView;

    
    private void Start()
    {
        cancelButton.onClick.AddListener(Cancel);
        confirmButton.onClick.AddListener(Confirm);
    }

    private void Confirm()
    {
        ChestView.ChestController.SetChestState(ChestStates.Unlocked);
        gameObject.SetActive(false);
    }

    private void Cancel()
    {
        gameObject.SetActive(false);
    }
    
}
