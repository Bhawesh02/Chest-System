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

    private string initialText ;

    public int GemsRequired;

    private void Awake()
    {
        initialText = required.text;
    }

    private void Start()
    {
        cancelButton.onClick.AddListener(Cancel);
        confirmButton.onClick.AddListener(Confirm);
    }
    private void OnEnable()
    {
        required.text += "\n" + GemsRequired;
    }
    private void Confirm()
    {
        ChestView.ChestController.SetChestState(ChestStates.Unlocked);
        SetOff();
    }

    private void Cancel()
    {
        SetOff();
    }
    
    private void SetOff()
    {
        required.text = initialText;
        Debug.Log(initialText);
        gameObject.SetActive(false);
    }
}
