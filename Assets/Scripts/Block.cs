using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int blockIndex;
    private Vector3 initialScale;
    private BlocksManager _blocksManager;

    private void Start()
    {
        _blocksManager = BlocksManager.Instance;
        initialScale = transform.localScale;
    }

    public void Select() //seçim yapıldıysa obje boyutu değişir
    {
        float scaleMultiplier = _blocksManager.blockSelectScaleMultiplier;
        Vector3 targetScale = new Vector3(initialScale.x * scaleMultiplier, initialScale.y * scaleMultiplier, initialScale.z * scaleMultiplier);
        transform.DOScale(targetScale, .25F);
    }

    public void DeSelect() //işlemden sonra obje asıl boyutuna döner 
    {
        transform.DOScale(initialScale, .25F);
    }
}
