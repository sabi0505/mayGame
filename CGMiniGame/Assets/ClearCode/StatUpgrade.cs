using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUpgrade : MonoBehaviour
{
    public void Upgrade(int i)
    {
        switch (i)
        {
            case 0:
                PlayerDataManager.Instance.SwordStat += 20;
                break;
            case 1:
                PlayerDataManager.Instance.MagicStat += 20;
                break;
            case 2:
                PlayerDataManager.Instance.HealthStat += 20;
                PlayerDataManager.Instance.Heal(PlayerDataManager.Instance.HealthStat);
                break;
        }
    }
}
