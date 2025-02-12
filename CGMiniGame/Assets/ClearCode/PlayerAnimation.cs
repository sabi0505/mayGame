using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    Transform s;
    [SerializeField]
    Transform e;
    [SerializeField]
    Transform shadow;

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            float t = 0;
            while (t < 3)
            {
                transform.position = Vector3.Lerp(s.position, e.position, t / 3f);
                shadow.localScale = Vector3.Lerp(new Vector3(7, 2), new Vector3(6, 1), t / 3f);
                t += Time.deltaTime;
                yield return null;
            }
            t = 0;
            while (t < 3)
            {
                transform.position = Vector3.Lerp(e.position, s.position, t / 3f);
                shadow.localScale = Vector3.Lerp(new Vector3(6, 1), new Vector3(7, 2), t / 3f);
                t += Time.deltaTime;
                yield return null;
            }
        }
    }
}
