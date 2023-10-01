using DG.Tweening;
using UnityEngine;

public class ClicableCard : UIClicableItem
{
    [SerializeField] private Vector2 m_startPosition;
    [SerializeField] private Vector2 m_endPosition;
    [SerializeField] private Vector2 m_startScale;
    [SerializeField] private Vector2 m_endScale;
    private bool m_isScaled;
    [SerializeField] private float m_duration;

    protected override void Click()
    {
        var mySequence = DOTween.Sequence();
        var moveCard = MRoot.DOAnchorPos(m_isScaled ? m_startPosition : m_endPosition, m_duration);
        var scaleCard = MRoot.DOScale(m_isScaled ? m_startScale : m_endScale, m_duration);
        mySequence.Append(m_isScaled ? scaleCard : moveCard).Append(m_isScaled ? moveCard : scaleCard);
        m_isScaled = !m_isScaled;
    }


}
