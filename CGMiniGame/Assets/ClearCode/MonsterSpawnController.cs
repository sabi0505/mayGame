using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnController : ObjectPooling<EU_Monster>
{
    [SerializeField]
    private List<Sprite> _sprites;

    [SerializeField]
    SpawnMakController _spawnMark;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            var p = SpawnObject();

            _spawnMark.Init(p.transform.position);
            yield return new WaitForSeconds(2.3f);

            p.Init(_sprites[0], 10);

            yield return new WaitForSeconds(3);
        }
    }
}
