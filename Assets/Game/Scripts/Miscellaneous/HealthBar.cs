using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform _whiteFollow;
    private Slider healthBar;
    private TextMeshProUGUI healthValueText;
    private float _maxHealth;
    private float _currentHealth;
    
    void Start()
    {
        healthBar = GetComponentInChildren<Slider>();
        healthValueText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void InitializeHealthBar(float totalHealth){
        _maxHealth = totalHealth;
        _currentHealth = totalHealth;
        healthValueText.text = ((int)totalHealth).ToStringShortenedNumber();
    }

    public void SetHealth(float health){
        _currentHealth = health;
        _currentHealth = Mathf.Clamp(_currentHealth,0f,_maxHealth);
        if(_currentHealth == 0){
            transform.DOScale(Vector3.zero,.2f);
            _whiteFollow.localScale = Vector3.zero;
        } 
        healthBar.value = _currentHealth/_maxHealth + .05f;
        healthValueText.text = ((int)_currentHealth).ToStringShortenedNumber();
        float t = _currentHealth/_maxHealth;
        _whiteFollow.DOKill();
        _whiteFollow.DOMoveX(Mathf.Lerp(-1f,0f,t),.45f);
        _whiteFollow.DOSizeDelta(new Vector2(Mathf.Lerp(0f,2f,t),.35f),.45f);
    }
}
