using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class status : MonoBehaviour
{
    public unitCode UnitCode { get; }
    public string name { get; set; }
    public int hp { get; set; }
    public int atkDmg { get; set; }
    public float moveSpeed { get; set; }
    public float atkRange { get; set; }

    public status(unitCode UnitCode, string name, int hp, int atkDmg, float moveSpeed, float atkRange)
    {
        this.UnitCode = UnitCode;
        this.name = name; //몬스터 이름 
        this.hp = hp; //체력  
        this.atkDmg = atkDmg; //데미지
        this.moveSpeed = moveSpeed; //속도
        this.atkRange = atkRange; //공격범위

    }

    public status()
    {
    }

    public status SetUnitStatus(unitCode UnitCode)
    {
        status status = null;

        switch (UnitCode)
        {
            case unitCode.clover:
                status = new status(UnitCode, "clover",3,1,0.75f,4f);
                break;
            case unitCode.heart:
                status = new status(UnitCode, "heart",6,1,0.75f,4f);
                break;
            case unitCode.dia:
                status = new status(UnitCode, "dia",2,1,0.75f,4f);
                break;
            case unitCode.spade:
                status = new status(UnitCode, "spade",10,1,0.75f,4f);
                break;
        }
        return status;
    }
}
