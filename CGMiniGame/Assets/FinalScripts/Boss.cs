using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    [SerializeField]
    MonsterData monster;

    [SerializeField]
    MonsterBullet bullet;
    void Start()
    {
        _data = monster;
        Init(_data);
        Vector2 pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1.5f));
        transform.position = pos;
        _bullet = bullet;
    }

    public override void Dead()
    {
        base.Dead();
        PopUpManager.Instance.PopUpOpen("ClearPopup");
        Time.timeScale = 0;
    }
}
