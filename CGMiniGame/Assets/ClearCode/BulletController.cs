using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : ObjectPooling<EU_Bullet>
{
    public void Init(Transform start, Transform target)
    {
        var p = SpawnObject();
        p.Init(start, target);
    }
}
