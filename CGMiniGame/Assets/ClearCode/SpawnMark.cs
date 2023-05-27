using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMark : MonoBehaviour
{
    private SpriteRenderer _renderer;
    [SerializeField]
    private AnimationCurve _curve;
    [SerializeField]
    private SpawnMakController _controller;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Init(Vector2 pos)
    {
        transform.position = pos;
        gameObject.SetActive(true);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        float t = 0f;

        while (t < 2)
        {
            _renderer.color = Color.Lerp(Color.white, Color.clear, _curve.Evaluate(t / 2));
            t += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
        _controller.ReturnObject(this);

    }
}
