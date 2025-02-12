using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    public int HealthStat { get; set; } = 100;
    public int SwordStat { get; set; } = 100;
    public int MagicStat { get; set; } = 75;
    public int Hp { get; private set; } = 100;

    public void Damage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            PopUpManager.Instance.PopUpOpen("GameOverPopup");
            Time.timeScale = 0;
        }
    }
    public void Heal(int hp)
    {
        Hp = hp;
    }

    public void ResetData()
    {
        HealthStat = 100;
        SwordStat = 100;
        MagicStat = 75;
        Hp = 100;
    }
}
