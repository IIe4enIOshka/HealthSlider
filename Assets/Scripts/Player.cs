using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Button _buttonAdd;
    [SerializeField] private Button _buttonRemove;
    [SerializeField] private int _amountHealthChanged;
    [SerializeField] private int _maxHealth;

    private int _health = 50;

    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    private void OnEnable()
    {
        _buttonAdd.onClick.AddListener(AddHp);
        _buttonRemove.onClick.AddListener(RemoveHp);
    }

    private void OnDisable()
    {
        _buttonAdd.onClick.RemoveListener(AddHp);
        _buttonRemove.onClick.RemoveListener(RemoveHp);
    }

    private void AddHp()
    {
        _health += _amountHealthChanged;

        if (_health > _maxHealth)
            _health = _maxHealth;

        HealthChanged?.Invoke(_health);
    }

    private void RemoveHp()
    {
        _health -= _amountHealthChanged;

        if (_health < 0)
            _health = 0;

        HealthChanged?.Invoke(_health);
    }
}
