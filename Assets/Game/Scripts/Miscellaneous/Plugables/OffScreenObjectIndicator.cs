using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffScreenObjectIndicator : MonoBehaviour
{
    [SerializeField] private Sprite indicationSprite;
    [SerializeField] private float spriteSizeMultiplier = 1f;
    [SerializeField] private bool rotateIndicatorTowardsTarget;
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;
    private Image pointerImage;
    private float borderSize= 60f;
    private Camera mainCam;
    private Transform _transform;

    private void Awake() {
        _transform = GetComponent<Transform>();
        mainCam = Camera.main;

        targetPosition = transform.position;
        GameObject pointerObject = Instantiate(new GameObject("Pointer"),Vector3.zero,Quaternion.identity,GameObject.Find("UICameraSpace").transform.GetChild(0));
        pointerObject.AddComponent(typeof(Image));
        pointerImage = pointerObject.GetComponent<Image>();
        pointerImage.sprite = indicationSprite;
        pointerRectTransform =  pointerObject.GetComponent<RectTransform>();
        pointerImage.rectTransform.anchoredPosition = Vector2.zero;
        
        pointerImage.rectTransform.anchorMin = Vector2.zero;
        pointerImage.rectTransform.anchorMax = Vector2.zero;
    }

    private void LateUpdate() {

        if(rotateIndicatorTowardsTarget){
            Vector3 toPosition = _transform.position;
            Vector3 fromPosition = mainCam.transform.position;
            fromPosition.z = 0f;
            Vector3 dir = (toPosition-fromPosition).normalized;
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360;
            pointerRectTransform.localEulerAngles = new Vector3(0f,0f,angle);
        }
        
        Vector3 targetPositionScreenPoint = mainCam.WorldToScreenPoint(_transform.position);
        bool isOffScreen = targetPositionScreenPoint.x <= 0 || targetPositionScreenPoint.x >= Screen.width || targetPositionScreenPoint.y <= 0 || targetPositionScreenPoint.y >= Screen.height;
        if(isOffScreen){
            pointerRectTransform.localScale = Vector3.one;
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            if(cappedTargetScreenPosition.x <= 0) cappedTargetScreenPosition.x = borderSize;
            if(cappedTargetScreenPosition.x >= Screen.width) cappedTargetScreenPosition.x = Screen.width - borderSize;
            if(cappedTargetScreenPosition.y <= 0) cappedTargetScreenPosition.y = borderSize;
            if(cappedTargetScreenPosition.y >= Screen.height) cappedTargetScreenPosition.y = Screen.height - borderSize;
            pointerRectTransform.anchoredPosition = cappedTargetScreenPosition;
        }
        else{
            pointerRectTransform.localScale = Vector3.zero;
        }
        
        
    }
}
