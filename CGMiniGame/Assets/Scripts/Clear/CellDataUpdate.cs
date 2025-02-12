using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellDataUpdate : MonoBehaviour
{
    private Button _button;

    [SerializeField]
    private Slider _slider;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    public void UpdateData()
    {
        _slider.value++;

        if (_slider.value >= 5)
        {
            _button.interactable = false;
        }
    }
}
