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
                PlayerDataManager.Instance.SowrdStat++;
                break;
            case 1:
                PlayerDataManager.Instance.MagicStat++;
                break;
            case 2:
                PlayerDataManager.Instance.HealthStat++;
                break;
        }
    }
}
