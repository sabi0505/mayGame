using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EU_Knife : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EU_Monster>().Damage(PlayerDataManager.Instance.SowrdStat);
    }
}
