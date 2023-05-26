using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{

    public float speed;
    public Rigidbody2D target;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dirvec = target.position - rigid.position;
        Vector2 newxtvec = dirvec.normalized * speed * Time.deltaTime;
        rigid.velocity = newxtvec * speed;

    }
}