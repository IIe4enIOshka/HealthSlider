using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _slider;
    [SerializeField] private float _step;

    private float _health;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _health = health;   
    }

    void Update()
    {
        _slider.fillAmount = Mathf.MoveTowards(_slider.fillAmount, _health / 100, _step);
    }
}
