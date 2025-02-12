using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAllData : MonoBehaviour
{
    void Start()
    {
        PopUpManager.Instance.PopUpClose("GameOverPopup");
        PopUpManager.Instance.PopUpClose("ClearPopup");
        PlayerDataManager.Instance.ResetData();
    }
}
