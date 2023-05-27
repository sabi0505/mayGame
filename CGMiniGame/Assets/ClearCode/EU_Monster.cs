using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EU_Monster : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    SpriteRenderer renderer;
    public float speed;

    public int HP = 10;

    [SerializeField]
    MonsterSpawnController spawnController;

    [SerializeField]
    private SpawnMark _mark;

    public void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 dirvec = _target.position - transform.position;
        Vector2 nextvec = dirvec.normalized * speed * Time.deltaTime;
        transform.position += (Vector3)nextvec;
    }

    public void Init(Sprite sprite, int hp)
    {
        //renderer.sprite = sprite;
        HP = hp;
        gameObject.SetActive(true);
    }

    public void Damage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            spawnController.ReturnObject(this);
            gameObject.SetActive(false);
        }
    }
}
