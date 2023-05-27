using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EU_PlayerMove : MonoBehaviour
{
    [Header("�÷��̾� �̵��ӵ�")]
    public float speed = 5f;
    [Header("���Ÿ����� �ֱ�(����ӵ�)")]
    public float AttackSpeed;

    [SerializeField]
    BulletController _bulletController;

    void Start()
    {
        InvokeRepeating("BulletSpawn", 1f, AttackSpeed);
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 nextvec = new Vector2(x, y) * speed * Time.deltaTime;
        transform.position = transform.position + new Vector3(nextvec.x, nextvec.y);
    }
    public void BulletSpawn()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 10, Vector3.zero, 0, 1 << LayerMask.NameToLayer("Enemy"));

        if (hit.collider == null)
            return;

        Debug.Log("as");
        _bulletController.Init(transform, hit.collider.transform);
    }
}