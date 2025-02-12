using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationType
{
    Move,
    MoveCurve,
    AwhileSize
}

public class AnimationDirecting : MonoBehaviour
{
    private Queue<AnimationBase> _animation;

    private void Awake()
    {
        _animation = new Queue<AnimationBase>();
    }

    public void AddAnimation(AnimationType type, Vector2 vector, float time, AnimationCurve curve = null, bool effect = true)
    {
        switch (type)
        {
            case AnimationType.Move:
                _animation.Enqueue(new AnimationMove(gameObject, vector, time, effect));
                break;
            case AnimationType.MoveCurve:
                _animation.Enqueue(new AnimationMoveCurve(gameObject, curve, vector, time, effect));
                break;
            case AnimationType.AwhileSize:
                _animation.Enqueue(new AnimationAwhileSize(gameObject, vector, time, effect));
                break;
        }
    }

    public void RunAnimation()
    {
        while(_animation.Count > 0) {
            StartCoroutine(_animation.Dequeue().Animation());
        }
    }
}
