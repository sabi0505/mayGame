using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterSpawnController : ObjectPooling<Monster>
{
    [SerializeField]
    private List<MonsterData> _datas;
    [SerializeField]
    private GameTimer slider;

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
            Vector2 pos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f)));

            var p = SpawnObject();
            p.transform.position = pos;

            _spawnMark.Init(p.transform.position);
            yield return new WaitForSeconds(2.3f);

            if(slider._time > 200)
                p.Init(_datas[Random.Range(0, 4)]);
            else if (slider._time > 150)
                p.Init(_datas[Random.Range(0, 3)]);
            else if (slider._time > 70)
                p.Init(_datas[Random.Range(0, 2)]);
            else
                p.Init(_datas[Random.Range(0, 1)]);

            yield return new WaitForSeconds(3);
        }
    }
}
