using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationMove : AnimationBase
{
    private Vector2 _pos = Vector2.zero;
    private float _time = 0f;

    public AnimationMove(GameObject gameObject, Vector2 position, float time, bool effect = true) : base(gameObject, effect)
    {
        _pos = position;
        _time = time;
    }

    public override IEnumerator Animation()
    {
        RectTransform rectTransform = null;
        Vector3 start = Vector3.zero;

        if(_target.TryGetComponent<RectTransform>(out rectTransform))
            start = rectTransform.anchoredPosition;
        else
            start = _target.transform.position;

        float t = 0f;

        if (rectTransform != null)
        {
            while (t <= _time)
            {
                if (_isTimeScaleEffect)
                    t += Time.deltaTime;
                else
                    t += Time.unscaledDeltaTime;

                rectTransform.anchoredPosition = Vector3.Lerp(start, _pos, t / _time);
                yield return null;
            }
            rectTransform.anchoredPosition = _pos;
        }
        else
        {
            while (t <= _time)
            {
                if (_isTimeScaleEffect)
                    t += Time.deltaTime;
                else
                    t += Time.unscaledDeltaTime;

                _target.transform.position = Vector3.Lerp(start, _pos, t / _time);
                yield return null;
            }
            _target.transform.position = _pos;
        }
    }
}
    