
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class ChestView : MonoBehaviour
{
    public ChestController ChestController{get; private set;}
    public ChestModel ChestModel { get; private set;}
    private static ChestService chestService ;
    private Button button;
    public Image ChestImage;
    public TextMeshProUGUI StateInfo;

    private void Awake()
    {
        button = GetComponent<Button>();
    }
    private void Start()
    {
        chestService = ChestService.Instance;
        SetModelAndController();
        ChestController.SetChestState(ChestStates.Locked);
        button.onClick.AddListener(ChestController.CardClicked);
    }
    private void Update()
    {
        ChestModel.CurrentState?.Tick();
    }

    private void SetModelAndController()
    {
        int sObjInt = Random.Range(0,chestService.ChestSystem.chestScriptableObjects.Length);
        ChestModel = new(chestService.ChestSystem.chestScriptableObjects[sObjInt],this);
        ChestController = new(ChestModel,this);
    }
}
