using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CellAnimationData
{
    public AnimationDirecting CellAnimations;
    public RectTransform CellStartPos;
    public RectTransform CellEndPos;
}

public class UpgradePopupOpenAnimation : MonoBehaviour
{
    [SerializeField, Header("이동 애니메이션 시간")]
    private float _moveAnimationTime = 0.4f;

    [SerializeField, Header("스케일 애니메이션 시간")]
    private float _scaleAnimationTime = 0.5f;

    [SerializeField, Header("애니메이션 딜레이 시간")]
    private float _delayAnimationTime = 0.2f;

    [SerializeField, Header("애니메이션 커브")]
    private AnimationCurve _cellMoveCurve;

    [SerializeField]
    private List<CellAnimationData> _cells;

    public void PopupOpen()
    {
        Time.timeScale = 0;

        foreach(var cell in _cells)
            cell.CellAnimations.AddAnimation(AnimationType.MoveCurve, cell.CellEndPos.anchoredPosition, _moveAnimationTime, _cellMoveCurve, false);

        PopUpManager.Instance.PopUpOpen("UpgradePopup");
        StartCoroutine(Animation());
    }

    public void PopupNotSelect(int index)
    {
        _cells[index].CellAnimations.AddAnimation(AnimationType.MoveCurve, _cells[index].CellStartPos.anchoredPosition, _moveAnimationTime, _cellMoveCurve, false);
        _cells[index].CellAnimations.RunAnimation();
    }

    public void PopupSelect(int index)
    {
        _cells[index].CellAnimations.AddAnimation(AnimationType.AwhileSize, Vector2.one * 1.1f, _scaleAnimationTime, null, false);

        StartCoroutine(PopupSelectAnimation(index));
    }

    private IEnumerator Animation()
    {
         yield return new WaitForSecondsRealtime(_delayAnimationTime);
        foreach(var cell in _cells)
        {
            cell.CellAnimations.RunAnimation();
            yield return new WaitForSecondsRealtime(_delayAnimationTime);
        }
    }

    private IEnumerator PopupSelectAnimation(int index)
    {
        _cells[index].CellAnimations.RunAnimation();
        yield return new WaitForSecondsRealtime(_scaleAnimationTime + _delayAnimationTime);

        PopupNotSelect(index);
        yield return new WaitForSecondsRealtime(_moveAnimationTime + _delayAnimationTime);

        PopUpManager.Instance.PopUpClose("UpgradePopup");
        Time.timeScale = 1;
    }
}
