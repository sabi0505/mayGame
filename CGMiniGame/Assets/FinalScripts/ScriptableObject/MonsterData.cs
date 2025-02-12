using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster/Create Monster", order = 0)]
public class MonsterData : ScriptableObject
{
    public int HP;
    public unitCode type;
    public Sprite Sprite;
    public Sprite AttackSprite;
    public int AtkDamage;
    public float MoveSpeed;
    public float AtkRange;
}
