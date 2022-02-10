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

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke((float)_health / _maxHealth);
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
        _health = Mathf.Clamp(_health + _amountHealthChanged, 0, _maxHealth);
        HealthChanged?.Invoke((float) _health / _maxHealth);
    }

    private void RemoveHp()
    {
        _health = Mathf.Clamp(_health - _amountHealthChanged, 0, _maxHealth);
        HealthChanged?.Invoke((float)_health / _maxHealth);
    }
}
