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
        this.name = name; //���� �̸� 
        this.hp = hp; //ü��  
        this.atkDmg = atkDmg; //������
        this.moveSpeed = moveSpeed; //�ӵ�
        this.atkRange = atkRange; //���ݹ���

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
