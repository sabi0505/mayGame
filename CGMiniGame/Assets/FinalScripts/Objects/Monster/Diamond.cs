//using System.Collections;
//using System.Collections.Generic;
//using Unity.Burst.CompilerServices;
//using UnityEngine;
//using static UnityEngine.GraphicsBuffer;

//public class Diamond : Monster
//{
//    private EU_Bullet _bullet;

//    private void Start()
//    {
//        _bullet = GetComponentInChildren<EU_Bullet>();
//    }

//    public override void Attack()
//    {
//        StopAllCoroutines();
//        StartCoroutine(Shoot());
//    }

//    private IEnumerator Shoot()
//    {
//        while (true)
//        {
//            yield return new WaitForSeconds(3);

//            _renderer.sprite = _data.AttackSprite;

//            _bullet.Init(transform, _target);

//            yield return new WaitForSeconds(0.5f);

//            _renderer.sprite = _data.Sprite;
//        }
//    }
//}
