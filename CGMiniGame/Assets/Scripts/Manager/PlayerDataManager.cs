using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    public int HealthStat { get; set; } = 1;
    public int SowrdStat { get; set; } = 1;
    public int MagicStat { get; set; } = 1;
}
