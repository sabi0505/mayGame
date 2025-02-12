using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationAwhileSize : AnimationBase
{
    private Vector2 _size = Vector2.zero;
    private float _time = 0f;

    public AnimationAwhileSize(GameObject gameObject, Vector2 position, float time, bool effect = true) : base(gameObject, effect)
    {
        _size = position;
        _time = time;
    }

    public override IEnumerator Animation()
    {
        RectTransform rectTransform = null;
        Vector3 start = Vector3.zero;

        if (_target.TryGetComponent<RectTransform>(out rectTransform))
            start = rectTransform.anchoredPosition;
        else
            start = _target.transform.position;

        float t = 0f;

        if (rectTransform != null)
        {
            while (t <= _time / 2)
            {
                if(_isTimeScaleEffect)
                    t += Time.deltaTime;
                else
                    t += Time.unscaledDeltaTime;
                
                rectTransform.localScale = Vector3.Lerp(Vector2.one, _size, t / (_time / 2));
                yield return null;
            }

            rectTransform.localScale = _size;

            t = 0;

            while (t <= _time / 2)
            {
                if (_isTimeScaleEffect)
                    t += Time.deltaTime;
                else
                    t += Time.unscaledDeltaTime;

                rectTransform.localScale = Vector3.Lerp(_size, Vector2.one, t / (_time / 2));
                yield return null;
            }

            rectTransform.localScale = Vector2.one;
        }
        else
        {
            while (t <= _time / 2)
            {
                t += Time.deltaTime;
                _target.transform.localScale = Vector3.Lerp(Vector2.one, _size, t / (_time / 2));
                yield return null;
            }

            while (t <= _time / 2)
            {
                t += Time.deltaTime;
                _target.transform.localScale = Vector3.Lerp(_size, Vector2.one, t / (_time / 2));
                yield return null;
            }

            _target.transform.localScale = Vector2.one;
        }
    }
}
