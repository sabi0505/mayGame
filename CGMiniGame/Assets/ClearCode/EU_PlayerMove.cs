using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EU_PlayerMove : MonoBehaviour
{
    [Header("플레이어 이동속도")]
    public float speed = 5f;
    [Header("원거리공격 주기(연사속도)")]
    public float AttackSpeed;

    [SerializeField]
    BulletController _bulletController;

    [SerializeField]
    BulletUpgrade bullet;
    [SerializeField]
    GameObject s;

    void Start()
    {
        InvokeRepeating("BulletSpawn", 1f, AttackSpeed);
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 nextvec = new Vector2(x, y) * (speed + PlayerDataManager.Instance.HealthStat / 10) * Time.deltaTime;
        transform.position = transform.position + new Vector3(nextvec.x, nextvec.y);

        if (PlayerDataManager.Instance.SwordStat >= 199)
        {
            s.SetActive(true);
        }
    }

    public void BulletSpawn()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1000, Vector3.zero, 0, 1 << LayerMask.NameToLayer("Enemy"));

        if (hit.collider == null)
            return;


        if (PlayerDataManager.Instance.MagicStat >= 170)
        {
            bullet.Init(transform, hit.collider.transform);

        }
        else
            _bulletController.Init(transform, hit.collider.transform);
    }
}