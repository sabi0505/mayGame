using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enhanced_MeleeAttack : MonoBehaviour
{
    [Header("주변 칼 회전 속도")]
    public float RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, RotationSpeed);
    }
}
