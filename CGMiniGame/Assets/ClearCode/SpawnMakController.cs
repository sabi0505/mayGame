using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMakController : ObjectPooling<SpawnMark>
{
    public void Init(Vector2 pos)
    {
        var mark = SpawnObject();
        mark.Init(pos);
    }
}
