using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("�÷��̾� �̵��ӵ�")]
    public float speed = 5f;
    Rigidbody2D rigid;
    Transform pos;
    Vector2 invec;
    [Header("���Ÿ����� �ֱ�(����ӵ�)")]
    public float AttackSpeed;

    public GameObject[] enemyObj;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        InvokeRepeating("BulletSpawn", 1f, AttackSpeed);     /// �Ѿ��� 1�ʸ��� �����մϴ�.

        // enemyObj = GameObject.FindGameObjectsWithTag("Enemy");
    }


    void Update()
    {
        invec.x = Input.GetAxis("Horizontal");
        invec.y = Input.GetAxis("Vertical");

        Vector2 nextvec = invec * speed * Time.deltaTime;
        transform.position = transform.position + new Vector3(nextvec.x, nextvec.y);
        EnemyFind();
    }
    public void BulletSpawn()
    {
        GameObject obj = Instantiate(Resources.Load("Bullet"), gameObject.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        GameObject enemy = enemyObj[0];
        obj.GetComponent<Bullet>().target = enemy.transform;
    }

    public void EnemyFind()
    {
        enemyObj = GameObject.FindGameObjectsWithTag("Enemy");
    }
}