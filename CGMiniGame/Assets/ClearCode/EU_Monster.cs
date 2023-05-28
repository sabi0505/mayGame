using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EU_Monster : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    SpriteRenderer renderer;
    public status Status;
    public unitCode UnitCode;
    public int nowHp; 

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
        Vector2 nextvec = dirvec.normalized * Status.moveSpeed * Time.deltaTime;
        transform.position += (Vector3)nextvec;
    }

    public void Init(Sprite sprite, int nowHp)
    {
        //renderer.sprite = sprite;
        nowHp = Status.maxHp;
        gameObject.SetActive(true);
    }

    public void Damage(int damage)
    {
        nowHp -= damage;

        if (nowHp <= 0)
        {
            spawnController.ReturnObject(this);
            gameObject.SetActive(false);
        }
    }
}
