using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : AttackableObject
{
    [SerializeField]
    private ObjectPooling<Monster> _pool;

    [SerializeField]
    protected Transform _target;
    protected SpriteRenderer _renderer;
    protected MonsterData _data;

    private float _coolTime = 2f;
    private float _leftCoolTime;

    protected MonsterBullet _bullet;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _bullet = transform.GetChild(0).GetComponent<MonsterBullet>();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        _leftCoolTime -= Time.deltaTime;

        Vector3 dirvec = _target.position - transform.position;
        Vector2 nextvec = dirvec.normalized * 7.5f * Time.deltaTime;
        transform.position += (Vector3)nextvec;

        if (_leftCoolTime <= 0)
        {
            Vector2 dir = _target.position - transform.position;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, _data.AtkRange, 1 << LayerMask.NameToLayer("Player"));

            if (hit.collider == null)
                return;

            _leftCoolTime = _coolTime;

            PlayerDataManager.Instance.Damage(_data.AtkDamage);
        }
    }

    public void Init(MonsterData monsterData)
    {
        _data = monsterData;
        _renderer.sprite = monsterData.Sprite;
        SetHP(_data.HP);
        gameObject.SetActive(true);
        Attack();
    }

    public override void Dead()
    {
        _pool.ReturnObject(this);
        gameObject.SetActive(false);
    }

    public void Attack()
    {
        StopAllCoroutines();

        switch (_data.type)
        {
            case unitCode.heart:
                StartCoroutine(Dash());
                break;
            case unitCode.dia:
                StartCoroutine(Shoot());
                break;
            case unitCode.Boss:
                StartCoroutine(Dash());
                StartCoroutine(Shoot());
                break;
            default:
                break;
        }
    }

    private IEnumerator Dash()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);

            Vector2 dir = _target.position - transform.position;
            Vector2 endPos = (Vector2)transform.position + dir.normalized * 70;

            float t = 0f;

            _renderer.sprite = _data.AttackSprite;

            while (t < 1.6f)
            {
                t += Time.deltaTime;
                transform.position = Vector2.Lerp(transform.position, endPos, t / 1.6f);
                yield return null;
            }

            _renderer.sprite = _data.Sprite;
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            _renderer.sprite = _data.AttackSprite;

            _bullet.Init(transform, _target);

            yield return new WaitForSeconds(1);

            _renderer.sprite = _data.Sprite;
        }
    }
}
