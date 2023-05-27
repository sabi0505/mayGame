using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationBaseCurve : AnimationBase
{
    public AnimationBaseCurve(GameObject gameObject, AnimationCurve curve, bool effect = true) : base(gameObject, effect)
    {
        _curve = curve;
    }

    [SerializeField]
    protected AnimationCurve _curve;
}
