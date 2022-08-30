using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PeriodicMover : MonoBehaviour
{
    [SerializeField] private Vector3 axis;
    [SerializeField] private float periodSpeed;
    private Vector3 ofset;

    private void Start() {
        ofset = transform.localPosition;
        DOTween.Sequence()
        .Append(transform.DOLocalMove(ofset + axis,1f/periodSpeed).SetEase(Ease.InOutSine))
        .Append(transform.DOLocalMove(ofset,1f/periodSpeed).SetEase(Ease.InOutSine)).SetLoops(-1);
    }

}

