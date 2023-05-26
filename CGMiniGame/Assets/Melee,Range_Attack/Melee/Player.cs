using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigid;
    Vector2 invec;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        invec.x = Input.GetAxisRaw("Horizontal");
        invec.y = Input.GetAxisRaw("Vertical");
        Vector2 nextvec = invec * speed * Time.deltaTime;
        transform.position += new Vector3(nextvec.x,nextvec.y);
    }

}
