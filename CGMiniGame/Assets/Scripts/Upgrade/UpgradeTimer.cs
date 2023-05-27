using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTimer : MonoBehaviour
{
    [SerializeField, Header("업그레이드 시간")]
    private float _gameTime = 75;

    Slider _timer;

    [SerializeField]
    UpgradePopupOpenAnimation _popup;

    private float _time;

    private void Start()
    {
        _timer = GetComponent<Slider>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        _timer.value = _time / _gameTime;

        if (_timer.value >= 1)
        {
            _time = 0;
            _timer.value = 0;
            _popup.PopupOpen();
        }
    }
}
