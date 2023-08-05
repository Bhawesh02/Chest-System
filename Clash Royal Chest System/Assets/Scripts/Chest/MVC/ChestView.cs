
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class ChestView : MonoBehaviour
{
    private ChestController chestController;
    private ChestModel chestModel;
    private static ChestService chestService ;

    public Image ChestImage;
    public TextMeshProUGUI StateInfo;

    private void Start()
    {
        chestService = ChestService.Instance;
        SetModelAndController();
        chestController.SetChestImage(chestModel.ChestClose);
    }

    private void SetModelAndController()
    {
        int sObjInt = Random.Range(0,chestService.ChestSystem.chestScriptableObjects.Length);
        chestModel = new(chestService.ChestSystem.chestScriptableObjects[sObjInt]);
        chestController = new(chestModel,this);
    }
}
