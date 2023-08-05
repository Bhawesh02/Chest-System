
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChestView : MonoBehaviour
{
    private ChestController chestController;
    private ChestModel chestModel;
    private ChestService chestService ;

    private void Awake()
    {
        SetModelAndController();
    }

    private void SetModelAndController()
    {
        //private int sObjInt = Random.Range(0,);
    }
}
