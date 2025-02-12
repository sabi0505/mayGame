using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgrade : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Vector2 _target;

    public void Init(Transform start, Transform target)
    {
        transform.position = start.position;
        _target = target.position - start.position;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        Vector2 newxtvec = _target.normalized * _speed * Time.deltaTime;
        transform.position += (Vector3)newxtvec;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Wall"))
        {
            var monster = collision.GetComponent<Monster>();
            monster.Attacked(PlayerDataManager.Instance.MagicStat);
        }
    }
}
