using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationBase
{
    protected GameObject _target;
    protected bool _isTimeScaleEffect;

    public AnimationBase(GameObject gameObject, bool isTimeScaleEffect = true)
    {
        _target = gameObject;
        _isTimeScaleEffect = isTimeScaleEffect;
    }

    public abstract IEnumerator Animation();
}