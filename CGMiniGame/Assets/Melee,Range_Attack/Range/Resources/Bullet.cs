using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 마법공격으로 날아가는 총알을 관리하는 스크립트 입니다.

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
        if (collision.gameObject.CompareTag("Enemy"))   //tag가 Enemy 이면
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