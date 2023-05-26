using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0) {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        HP = HP - damage;
        Debug.Log("남은 체력 : " +  HP);
    }
}
