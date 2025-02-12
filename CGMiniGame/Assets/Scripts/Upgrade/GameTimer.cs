using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField, Header("게임 전체 시간")]
    private float _gameTime = 300;

    Slider _timer;

    public float _time;

    [SerializeField]
    GameObject boss;

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
            boss.SetActive(true);
        }
    }
}
