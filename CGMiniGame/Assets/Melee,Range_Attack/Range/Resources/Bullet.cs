using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // ������������ ���ư��� �Ѿ��� �����ϴ� ��ũ��Ʈ �Դϴ�.

    public float speed;
    public Transform target;
    Rigidbody2D rigid;




    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        InvokeRepeating("BulletDead", 5f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {


            Vector2 dirvec = target.position - transform.position;
            Vector2 newxtvec = dirvec.normalized * speed * Time.deltaTime;
            rigid.velocity = newxtvec * 1000 * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))   //tag�� Enemy �̸�
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    public void BulletDead()
    {
        Destroy(gameObject);
    }
}