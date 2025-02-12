using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackableObject : MonoBehaviour
{
    private int _hp;

    public void SetHP(int hp)
    {
        _hp = hp;
    }

    public void Attacked(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
            Dead();
    }

    public abstract void Dead();
}
