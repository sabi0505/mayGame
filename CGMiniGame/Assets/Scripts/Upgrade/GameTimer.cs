using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField, Header("게임 전체 시간")]
    private float _gameTime = 300;

    Slider _timer;

    private float _time;

    private void Start()
    {
        _timer = GetComponent<Slider>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        _timer.value = _time / _gameTime;
    }
}
